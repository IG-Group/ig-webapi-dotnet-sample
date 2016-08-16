using System;
using System.Collections.ObjectModel;
using System.Linq;
using IGWebApiClient;
using Lightstreamer.DotNet.Client;
using SampleWPFTrader.Model;
using dto.endpoint.browse;

namespace SampleWPFTrader.ViewModel
{
    public class BrowseViewModel : ViewModelBase
	{
		// LS subscriptions...
		private MarketDetailsTableListerner _l1BrowsePricesSubscription;
		private SubscribedTableKey _browseSubscriptionTableKey;

		private bool _browseTabSelected;
		public bool BrowseTabSelected
		{
			get
			{
				return _browseTabSelected;
			}
			set
			{
				if (_browseTabSelected != value)
				{
					_browseTabSelected = value;
					BrowseTabChanged();
					RaisePropertyChanged("BrowseTabSelected");
				}
			}
		}

		public void BrowseTabChanged()
		{
			if (BrowseTabSelected)
			{
				AddStatusMessage("Browse Tab selected");
				// Get Rest Orders and then subscribe
				if (LoggedIn)
				{
					GetBrowseMarketsRoot();
					AddStatusMessage("Get browse root.");
				}
				else
				{
					AddStatusMessage("Please log in first");
				}
			}
			else
			{
				AddStatusMessage("Browse Tab de-selected");
				UnsubscribeFromBrowsePrices();
			}
		}

		public BrowseViewModel()
		{
			InitialiseViewModel();

			BrowseNodes = new ObservableCollection<HierarchyNode>();
			BrowseMarkets = new ObservableCollection<IgPublicApiData.BrowseModel>();

			NodeIndex = 0;

			// Initialise LS subscriptions            
			_l1BrowsePricesSubscription = new MarketDetailsTableListerner();
			_l1BrowsePricesSubscription.Update += OnMarketUpdate;
			// initialise the LS SubscriptionTableKeys          
			_browseSubscriptionTableKey = new SubscribedTableKey();
			_browseSubscriptionTableKey = null;

			WireCommands();
		}

		private void OnMarketUpdate(object sender, UpdateArgs<L1LsPriceData> e)
		{
			try
			{
				var wlmUpdate = e.UpdateData;

				var epic = e.ItemName.Replace("L1:", "");

				foreach (var browseModel in BrowseMarkets.Where(watchlistItem => watchlistItem.Model.Epic == epic))
				{
					browseModel.Model.Epic = epic;
					browseModel.Model.Bid = wlmUpdate.Bid;
					browseModel.Model.Offer = wlmUpdate.Offer;
					browseModel.Model.NetChange = wlmUpdate.Change;
					browseModel.Model.PctChange = wlmUpdate.ChangePct;
					browseModel.Model.Low = wlmUpdate.Low;
					browseModel.Model.High = wlmUpdate.High;
					browseModel.Model.Open = wlmUpdate.MidOpen;
					browseModel.Model.UpdateTime = wlmUpdate.UpdateTime;
					browseModel.Model.MarketStatus = wlmUpdate.MarketState;
				}
			}

			catch (Exception ex)
			{
                AddStatusMessage(ex.Message);
			}
		}

		private void WireCommands()
		{
			GetBrowseMarketsCommand = new RelayCommand(GetBrowseMarkets);
			GetBrowseRootCommand = new RelayCommand(GetBrowseMarketsRoot);
			GetBrowseMarketsCommand.IsEnabled = false;
			GetBrowseRootCommand.IsEnabled = true;
		}

		private HierarchyNode _selectedItem;
		public HierarchyNode SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (_selectedItem != value)
				{
					_selectedItem = value;
					RaisePropertyChanged("SelectedItem");
				}
			}
		}

		public RelayCommand GetBrowseRootCommand
		{
			get;
			private set;
		}

		public RelayCommand GetBrowseMarketsCommand
		{
			get;
			private set;
		}

		public ObservableCollection<HierarchyNode> BrowseNodes { get; set; }

		public ObservableCollection<IgPublicApiData.BrowseModel> BrowseMarkets { get; set; }

		private int _nodeIndex;
		public int NodeIndex
		{
			get { return _nodeIndex; }
			set
			{
				if (_nodeIndex != value)
				{
					_nodeIndex = value;
					RaisePropertyChanged("NodeIndex");
				}
			}
		}

		public void SubscribeToBrowsePrices(string[] epics)
		{
			try
			{
				// Subscribe to L1 price updates for the instruments contained in this browse node...
				_browseSubscriptionTableKey = igStreamApiClient.SubscribeToMarketDetails(epics, _l1BrowsePricesSubscription);
				AddStatusMessage("Subscribed Successfully to instruments contained within this browse node.");
			}
			catch (Exception ex)
			{
				AddStatusMessage("Could not subscribe to browse instruments : " + ex.Message);
			}
		}

		public void UnsubscribeFromBrowsePrices()
		{
			if ((igStreamApiClient != null) && (_browseSubscriptionTableKey != null) && (LoggedIn))
			{
				igStreamApiClient.UnsubscribeTableKey(_browseSubscriptionTableKey);
				_browseSubscriptionTableKey = null;
				AddStatusMessage("Unsubscribed from Browse Node Prices");
			}
		}

		public async void GetBrowseMarkets()
		{
			try
			{
				if (NodeIndex < 0)
				{
					AddStatusMessage("Please select an item");
					return;
				}

				if ((igRestApiClient == null) || (BrowseNodes == null))
				{
					return;
				}
				if (NodeIndex >= BrowseNodes.Count)
				{
					AddStatusMessage("Please select a node first");
					return;
				}

				UnsubscribeFromBrowsePrices();

				var response = await igRestApiClient.browse(BrowseNodes[NodeIndex].id);

				if (!response || (response.Response == null))
				{
					AddStatusMessage("BrowseMarketNodex: no sub-nodes / markets for this node");
					return;
				}
				if (response.Response.nodes != null)
				{
					BrowseNodes.Clear();

					AddStatusMessage("Retrieving browse market nodes / markets ");

					foreach (var node in response.Response.nodes)
					{
						if (node != null)
						{
							BrowseNodes.Add(node);
							AddStatusMessage("Browse Node found: " + node.name);
						}
					}
				}
				else
				{
					if (response.Response.markets == null)
					{
						return;
					}
					BrowseMarkets.Clear();

					foreach (var market in response.Response.markets.Where(m => m != null).Select(LoadMarket))
					{
						BrowseMarkets.Add(market);
						AddStatusMessage(String.Format("Browse Market found: {0} epic:{1}", market.Model.InstrumentName, market.Model.Epic));
					}

					//
					// Subscribe to Browse Market Instrument Prices ( which are unique and have streaming prices enabled )
					//
					var epics = (from dbo in BrowseMarkets
						where dbo.Model.StreamingPricesAvailable == true
						select dbo.Model.Epic).Distinct().ToArray();

					if (epics.Length != 0)
					{
						SubscribeToBrowsePrices(epics);
					}
				}
			}
			catch (Exception ex)
			{
				AddStatusMessage(ex.Message);
			}
		}

		private IgPublicApiData.BrowseModel LoadMarket(HierarchyMarket market)
		{
			return new IgPublicApiData.BrowseModel
									{
										Model = new IgPublicApiData.InstrumentModel
										{
											Bid = market.bid,
											Offer = market.offer,
											High = market.high,
											Low = market.low,
											InstrumentName = market.instrumentName,
											Epic = market.epic,
											NetChange = market.netChange,
											PctChange = market.percentageChange,
											StreamingPricesAvailable = market.streamingPricesAvailable
										}
									};
		}

		public async void GetBrowseMarketsRoot()
		{
			try
			{
				if (LoggedIn)
				{
					// Unsubscribe from any instruments we are currently subscribed to...
					UnsubscribeFromBrowsePrices();

					var response = await igRestApiClient.browseRoot();

					if (response && (response.Response != null) && (response.Response.nodes != null))
					{
						BrowseNodes.Clear();
						BrowseMarkets.Clear();

						foreach (var node in response.Response.nodes)
						{
							BrowseNodes.Add(node);
						}

						if (response.Response.nodes.Count > 0)
						{
							NodeIndex = 0;
							GetBrowseMarketsCommand.IsEnabled = true;
						}

						AddStatusMessage(String.Format("Browse Market data received for {0} nodes", response.Response.nodes.Count));
					}
					else
					{
						AddStatusMessage("BrowseMarkets : no browse root nodes");
					}
				}
				else
				{
					AddStatusMessage("Please log in first");
				}
			}
			catch (Exception ex)
			{
				AddStatusMessage(ex.Message);
			}
		}        
	}

}
