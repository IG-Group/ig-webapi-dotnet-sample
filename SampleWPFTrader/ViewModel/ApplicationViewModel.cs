using System;
using System.Collections.ObjectModel;
using System.Text;
using dto.endpoint.auth.session.v2;
using dto.endpoint.application.operation;
using IGWebApiClient;
using Lightstreamer.DotNet.Client;
using Newtonsoft.Json;
using SampleWPFTrader.Common;
using SampleWPFTrader.Model;
using System.Collections.Specialized;
using System.Configuration;

namespace SampleWPFTrader.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
	{
        private static ApplicationViewModel instance;

        private Application _currentApplication;
		private AccountDetailsTableListerner _accountBalanceSubscription;
		private TradeSubscription _tradeSubscription;

		private SubscribedTableKey _accountBalanceStk;
		private SubscribedTableKey _tradeSubscriptionStk;

		public ApplicationViewModel()
		{
            instance = this;
            InitialiseViewModel();

			LoggedIn = false;

			// This data structure is used to contain all the account info that we can bind to in our view, and will update automatically...
			Accounts = new ObservableCollection<IgPublicApiData.AccountModel>();
			TradeSubscriptions = new ObservableCollection<IgPublicApiData.TradeSubscriptionModel>();
			AffectedDeals = new ObservableCollection<IgPublicApiData.AffectedDealModel>();

			WireCommands();

			RegisterLightStreamerSubscriptions();
		}

        public static ApplicationViewModel getInstance()
        {
            return instance;
        }


		private void RegisterLightStreamerSubscriptions()
		{
			_accountBalanceSubscription = new AccountDetailsTableListerner();
			_accountBalanceSubscription.Update += OnAccountUpdate;
			_tradeSubscription = new TradeSubscription(this);
		}

		private void OnAccountUpdate(object sender, UpdateArgs<StreamingAccountData> e)
		{
			var accountUpdates = e.UpdateData;

			if ((e.ItemPosition == 0) || (e.ItemPosition > Accounts.Count))
			{
				return;
			}
			var index = e.ItemPosition - 1; // we are subscription to the current account ( which will be account index 0 ).                                     

			if (accountUpdates.AmountDue.HasValue)
				Accounts[index].AmountDue = accountUpdates.AmountDue.Value;
			if (accountUpdates.AvailableCash != null)
				Accounts[index].AvailableCash = accountUpdates.AvailableCash.Value;
			if (accountUpdates.Deposit != null)
				Accounts[index].Deposit = accountUpdates.Deposit.Value;
			if (accountUpdates.ProfitAndLoss != null)
				Accounts[index].ProfitLoss = accountUpdates.ProfitAndLoss.Value;
			if (accountUpdates.UsedMargin != null)
				Accounts[index].UsedMargin = accountUpdates.UsedMargin.Value;
		}

		private void WireCommands()
		{
			ExitCommand = new RelayCommand(Exit);
			ExitCommand.IsEnabled = true;
		}

		public ObservableCollection<IgPublicApiData.AffectedDealModel> AffectedDeals { get; set; }

		public ObservableCollection<IgPublicApiData.AccountModel> Accounts { get; set; }

		public ObservableCollection<IgPublicApiData.TradeSubscriptionModel> TradeSubscriptions { get; set; }

		public RelayCommand ExitCommand
		{
			get;
			private set;
		}

		public Application CurrentApplication
		{
			get
			{
				return _currentApplication;
			}

			set
			{
				if (_currentApplication != value)
				{
					_currentApplication = value;
					RaisePropertyChanged("CurrentApplication");
				}
			}
		}

		private bool _loginTabSelected;
		public bool LoginTabSelected
		{
			get
			{
                return _loginTabSelected;
			}
			set
			{
				if (_loginTabSelected != value)
				{
					_loginTabSelected = value;
					LoginTabChanged();
					RaisePropertyChanged("LoginTabSelected");
				}
			}
		}

        private string _applicationPassword;
		public string ApplicationPassword
		{
			get
			{
				return _applicationPassword;
			}
			set
			{
				if (_applicationPassword != value)
				{
					_applicationPassword = value;
					RaisePropertyChanged("ApplicationPassword");
				}
			}
		}



		public void LoginTabChanged()
		{
			if (LoginTabSelected)
			{
				UpdateDebugMessage("Login Tab selected");

				if (LoggedIn == false)
				{
					Login();
				}
				else
				{
					SubscribeToAccountDetails();
					SubscribeToTradeSubscription();
				}
			}
			else
			{
				UpdateDebugMessage("Login Tab de-selected");

				UnsubscribefromTradeSubscription();
				UnsubscribeFromAccountDetailsSubscription();

				TradeSubscriptions.Clear();
			}
		}

		private void UnsubscribefromTradeSubscription()
		{
			if ((_tradeSubscriptionStk != null) && (igStreamApiClient != null))
			{
				igStreamApiClient.UnsubscribeTableKey(_tradeSubscriptionStk);
				_tradeSubscriptionStk = null;
				UpdateDebugMessage("Successfully unsubscribed from Trade Subscription");
			}
		}

		private void UnsubscribeFromAccountDetailsSubscription()
		{
			if ((_accountBalanceStk != null) && (igStreamApiClient != null))
			{
				igStreamApiClient.UnsubscribeTableKey(_accountBalanceStk);
				_accountBalanceStk = null;

				UpdateDebugMessage("Successfully unsubscribed from Account Balance Subscription");
			}
		}

		public void Exit()
		{
			try
			{

				// Unsubscribe from LS account balance and trade subscriptions...
				if (igStreamApiClient != null)
				{
					UnsubscribeFromAccountDetailsSubscription();
					UnsubscribefromTradeSubscription();
					Accounts = null;
				}

				if (igRestApiClient != null)
				{
					igRestApiClient.logout();

					LoggedIn = false;
					UpdateDebugMessage("Logged out");
				}

				System.Windows.Application.Current.Shutdown();
			}
			catch (Exception ex)
			{
				UpdateDebugMessage(ex.Message);
			}
		}


		public async void Login()
		{
			UpdateDebugMessage("Attempting login");

            var igWebApiConnectionConfig = ConfigurationManager.GetSection("IgWebApiConnection") as NameValueCollection;
            string env = igWebApiConnectionConfig["environment"];
            string userName = igWebApiConnectionConfig["username"];
            string password = igWebApiConnectionConfig["password"];
            string apiKey = igWebApiConnectionConfig["apikey"];
            UpdateDebugMessage("User=" + userName + " is attempting to login to environment=" + env);

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(apiKey))
			{
				UpdateDebugMessage("Please enter a valid username / password / ApiKey combination in ApplicationViewModel ( Login method )");
				return;
			}

			var ar = new AuthenticationRequest { identifier = userName, password = password };

			try
			{
				var response = await igRestApiClient.SecureAuthenticate(ar, apiKey);
				if (response && (response.Response != null) && (response.Response.accounts.Count > 0))
				{
					Accounts.Clear();

					foreach (var account in response.Response.accounts)
					{
						var igAccount = new IgPublicApiData.AccountModel
						{
							ClientId = response.Response.clientId,
							ProfitLoss = response.Response.accountInfo.profitLoss,
							AvailableCash = response.Response.accountInfo.available,
							Deposit = response.Response.accountInfo.deposit,
							Balance = response.Response.accountInfo.balance,
							LsEndpoint = response.Response.lightstreamerEndpoint,
							AccountId = account.accountId,
							AccountName = account.accountName,
							AccountType = account.accountType
						};

						Accounts.Add(igAccount);
					}

					LoggedIn = true;

					UpdateDebugMessage("Logged in, current account: " + response.Response.currentAccountId);

					ConversationContext context = igRestApiClient.GetConversationContext();

					UpdateDebugMessage("establishing datastream connection");

					if ((context != null) && (response.Response.lightstreamerEndpoint != null) &&
						(context.apiKey != null) && (context.xSecurityToken != null) && (context.cst != null))
					{
						try
						{
							CurrentAccountId = response.Response.currentAccountId;

							var connectionEstablished =
								igStreamApiClient.Connect(response.Response.currentAccountId,
														  context.cst,
														  context.xSecurityToken, context.apiKey,
															response.Response.lightstreamerEndpoint);
							if (connectionEstablished)
							{
								UpdateDebugMessage(String.Format("Connecting to Lightstreamer. Endpoint ={0}",
																	response.Response.lightstreamerEndpoint));

								// Subscribe to Account Details and Trade Subscriptions...
								SubscribeToAccountDetails();
								SubscribeToTradeSubscription();
							}
							else
							{
								igStreamApiClient = null;
								UpdateDebugMessage(String.Format(
									"Could NOT connect to Lightstreamer. Endpoint ={0}",
									response.Response.lightstreamerEndpoint));
							}
						}
						catch (Exception ex)
						{
							UpdateDebugMessage(ex.Message);
						}
					}
				}
				else
				{
					UpdateDebugMessage("Failed to login. HttpResponse StatusCode = " +
										response.StatusCode);
				}
			}
			catch (Exception ex)
			{
				UpdateDebugMessage("ApplicationViewModel exception : " + ex.Message);
			}
		}

		#region LightStreamerSubscriptions

		public void SubscribeToAccountDetails()
		{
			try
			{
				if (CurrentAccountId != null)
				{
					_accountBalanceStk = igStreamApiClient.SubscribeToAccountDetails(CurrentAccountId, _accountBalanceSubscription);
					UpdateDebugMessage("Lightstreamer - Subscribing to Account Details");
				}
			}
			catch (Exception ex)
			{
				UpdateDebugMessage("ApplicationViewModel - SubscribeToAccountDetails" + ex.Message);
			}

		}

		public void SubscribeToTradeSubscription()
		{
			try
			{
				if (CurrentAccountId != null)
				{
					_tradeSubscriptionStk = igStreamApiClient.SubscribeToTradeSubscription(CurrentAccountId, _tradeSubscription);
					UpdateDebugMessage("Lightstreamer - Subscribing to CONFIRMS, Working order updates and open position updates");
				}
			}
			catch (Exception ex)
			{
				UpdateDebugMessage("ApplicationViewModel - SubscribeToTradeSubscription" + ex.Message);
			}

		}

		#endregion // LightstreamerSubscriptions

		public class TradeSubscription : HandyTableListenerAdapter
		{
			private readonly ApplicationViewModel _applicationViewModel;
			public TradeSubscription(ApplicationViewModel avm)
			{
				_applicationViewModel = avm;
			}

			public IgPublicApiData.TradeSubscriptionModel UpdateTs(int itemPos, string itemName, IUpdateInfo update, string inputData, TradeSubscriptionType updateType)
			{
				var tsm = new IgPublicApiData.TradeSubscriptionModel();

				try
				{
					var tradeSubUpdate = JsonConvert.DeserializeObject<LsTradeSubscriptionData>(inputData);

					tsm.DealId = tradeSubUpdate.dealId;
					tsm.AffectedDealId = tradeSubUpdate.affectedDealId;
					tsm.DealReference = tradeSubUpdate.dealReference;
					tsm.DealStatus = tradeSubUpdate.dealStatus.ToString();
					tsm.Direction = tradeSubUpdate.direction.ToString();
					tsm.ItemName = itemName;
					tsm.Epic = tradeSubUpdate.epic;
					tsm.Expiry = tradeSubUpdate.expiry;
					tsm.GuaranteedStop = tradeSubUpdate.guaranteedStop;
					tsm.Level = tradeSubUpdate.level;
					tsm.Limitlevel = tradeSubUpdate.limitLevel;
					tsm.Size = tradeSubUpdate.size;
					tsm.Status = tradeSubUpdate.status.ToString();
					tsm.StopLevel = tradeSubUpdate.stopLevel;

					switch (updateType)
					{
						case TradeSubscriptionType.Opu:
							tsm.TradeType = "OPU";
							break;
						case TradeSubscriptionType.Wou:
							tsm.TradeType = "WOU";
							break;
						case TradeSubscriptionType.Confirm:
							tsm.TradeType = "CONFIRM";
							break;
					}

					SmartDispatcher.getInstance().BeginInvoke(() =>
					{
						if (_applicationViewModel != null)
						{
							_applicationViewModel.UpdateDebugMessage("TradeSubscription received : " + tsm.TradeType);
							_applicationViewModel.TradeSubscriptions.Add(tsm);

							if ((tradeSubUpdate.affectedDeals != null) && (tradeSubUpdate.affectedDeals.Count > 0))
							{
								foreach (var ad in tradeSubUpdate.affectedDeals)
								{
									var adm = new IgPublicApiData.AffectedDealModel
									{
										AffectedDealId = ad.dealId,
										AffectedDealStatus = ad.status
									};
									_applicationViewModel.AffectedDeals.Add(adm);
								}
							}

						}
					});
				}
				catch (Exception ex)
				{
					_applicationViewModel.ApplicationDebugData += ex.Message;
				}
				return tsm;
			}

			public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
			{
				var sb = new StringBuilder();
				sb.AppendLine("Trade Subscription Update");

				try
				{
					var confirms = update.GetNewValue("CONFIRMS");
					var opu = update.GetNewValue("OPU");
					var wou = update.GetNewValue("WOU");

					if (!(String.IsNullOrEmpty(opu)))
					{
						UpdateTs(itemPos, itemName, update, opu, TradeSubscriptionType.Opu);
					}
					if (!(String.IsNullOrEmpty(wou)))
					{
						UpdateTs(itemPos, itemName, update, wou, TradeSubscriptionType.Wou);
					}
					if (!(String.IsNullOrEmpty(confirms)))
					{
						UpdateTs(itemPos, itemName, update, confirms, TradeSubscriptionType.Confirm);
					}

				}
				catch (Exception ex)
				{
					_applicationViewModel.ApplicationDebugData += "Exception thrown in TradeSubscription Lightstreamer update" + ex.Message;
                }
			}
		}
	}
}
