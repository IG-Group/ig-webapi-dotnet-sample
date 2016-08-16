using System;
using System.Collections.ObjectModel;
using System.Linq;
using IGWebApiClient;
using Lightstreamer.DotNet.Client;
using SampleWPFTrader.Model;
using dto.endpoint.workingorders.get.v2;

namespace SampleWPFTrader.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private WorkingOrder _currentOrder;
             
        // L1 Prices subscription...
		private MarketDetailsTableListerner _l1OrderPricesSubscription;
        // LS subscription table keys ....
        private SubscribedTableKey _orderPricesSubscriptionTableKey;      

        public OrdersViewModel()
        {
            InitialiseViewModel();
           
			Orders = new ObservableCollection<IgPublicApiData.OrderModel>();

            WireCommands();

            // Initialise LS subscriptions            
			_l1OrderPricesSubscription = new MarketDetailsTableListerner();
			_l1OrderPricesSubscription.Update += OnMarketUpdate;
            // initialise the LS SubscriptionTableKeys          
            _orderPricesSubscriptionTableKey = new SubscribedTableKey();

            // initialise to null
            _orderPricesSubscriptionTableKey = null;
        }

		private void OnMarketUpdate(object sender, UpdateArgs<L1LsPriceData> e)
		{
			try
			{
				//AddStatusMessage(e.UpdateData); 

				var wlmUpdate = e.UpdateData;

				var epic = e.ItemName.Replace("L1:", "");

				foreach (var orderModel in Orders.Where(p => p.Model.Epic == epic))
				{
					orderModel.Model.Epic = epic;
					orderModel.Model.Bid = wlmUpdate.Bid;
					orderModel.Model.Offer = wlmUpdate.Offer;
					orderModel.Model.NetChange = wlmUpdate.Change;
					orderModel.Model.PctChange = wlmUpdate.ChangePct;
					orderModel.Model.Low = wlmUpdate.Low;
					orderModel.Model.High = wlmUpdate.High;
					orderModel.Model.Open = wlmUpdate.MidOpen;
					orderModel.Model.UpdateTime = wlmUpdate.UpdateTime;
					orderModel.Model.MarketStatus = wlmUpdate.MarketState;
				}
			}

			catch (Exception ex)
			{
				AddStatusMessage(ex.Message);
			}
		}

        private void WireCommands()
        {            
            GetOrdersCommand = new RelayCommand(GetRestOrders);
            ClearOrdersCommand = new RelayCommand(ClearOrders);
           
            GetOrdersCommand.IsEnabled = true;
            ClearOrdersCommand.IsEnabled = true;           
        }

        public RelayCommand UpdateOrderCommand
        {
            get;
            private set;
        }
     
        public RelayCommand GetOrdersCommand
        {
            get;
            private set;
        }

        public RelayCommand ClearOrdersCommand
        {
            get;
            private set;
        }

		public ObservableCollection<IgPublicApiData.OrderModel> Orders { get; set; }

        private bool _ordersTabSelected;
        public bool OrdersTabSelected
        {
            get
            {
                return _ordersTabSelected;
            }
            set
            {
                if (_ordersTabSelected != value)
                {
                    _ordersTabSelected = value;
                    OrdersTabChanged();
                    RaisePropertyChanged("OrdersTabSelected");
                }
            }
        }

        public void OrdersTabChanged()
        {
            if (OrdersTabSelected)
            {
                AddStatusMessage("OrderTab selected");

                if (LoggedIn)
                {                   
                    GetRestOrders();
                }
                else
                {
                    AddStatusMessage("Please log in first");
                }
            }
            else
            {
                AddStatusMessage("OrderTab de-selected");

                // Unsubscribe from Streaming Orders...
                UnsubscribeFromOrders();
            }
        }


        private void UnsubscribeFromOrders()
        {
            if ((igStreamApiClient != null) && (_orderPricesSubscriptionTableKey != null) && (LoggedIn))
            {
                igStreamApiClient.UnsubscribeTableKey(_orderPricesSubscriptionTableKey);
                _orderPricesSubscriptionTableKey = null;
                AddStatusMessage("Unsubscribed from OrderPrices");
            }
        }

        public WorkingOrder CurrentOrder
        {
            get
            {
                return _currentOrder;
            }

            set
            {
                if (_currentOrder != value)
                {
                    _currentOrder = value;
                    RaisePropertyChanged("CurrentOrder");
                    UpdateOrderCommand.IsEnabled = true;
                }
            }
        }

        private WorkingOrder _selectedItem;
        public WorkingOrder SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if ((_selectedItem != value) && (value != null))
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
     
        public void ClearOrders()
        {
            if (Orders != null)
            {
                Orders.Clear();
                AddStatusMessage("Orders cleared");
            }
        }
   
        public void SubscribeToL1OrderPrices(string[] orderSubs)
        {                 
            try
            {
                // Subscribe to L1 price updates for these orders...   
                if (igStreamApiClient != null)
                {
					_orderPricesSubscriptionTableKey = igStreamApiClient.SubscribeToMarketDetails(orderSubs,
                                                                                                  _l1OrderPricesSubscription);
                    AddStatusMessage("Subscribed Successfully to orders");
                }
            }
            catch (Exception ex)
            {
                AddStatusMessage("Could not subscribe to L1 Prices for orders" + ex.Message);                                                         
            }           
        }       

        public async void GetRestOrders()
        {
            try
            {
                AddStatusMessage("Retrieving working orders");

                var response = await igRestApiClient.workingOrdersV2();

                if (response && (response.Response != null) && (response.Response.workingOrders != null))
                {                    
                    Orders.Clear();

                    if (response.Response.workingOrders.Count != 0)
                    {
						foreach (var igOrder in response.Response.workingOrders.Select(LoadOrder).Where(igOrder => Orders != null))
                        {                                                        
                                Orders.Add(igOrder);
                            }

                        // Get unique epics for these orders ( we don't want to subscribe to the same epic twice )
                        var uniqueEpics = (from dbo in Orders
                                                 where dbo.Model.StreamingPricesAvailable == true
                                                 select dbo.Model.Epic).Distinct().ToArray();

                        if (uniqueEpics.Length != 0)
                        {
                            SubscribeToL1OrderPrices(uniqueEpics);
                        }
	                    else
	                    {
		                    AddStatusMessage("There are no orders with streaming prices enabled");
	                    }

                    }
                    else
                    {
                        AddStatusMessage("GetRestOrders: no workingOrders for this account.");
                    }                                     
                }
                else
                {
                    AddStatusMessage("GetRestOrders: HttpStatusCode error" + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                AddStatusMessage(ex.Message);
            }
        }
      
		private static IgPublicApiData.OrderModel LoadOrder(WorkingOrder order)
        {
			return new IgPublicApiData.OrderModel
            {
				Model = new IgPublicApiData.InstrumentModel
            {               
					Bid = order.marketData.bid,
					Offer = order.marketData.offer,
					Epic = order.marketData.epic,
					InstrumentName = order.marketData.instrumentName,
					NetChange = order.marketData.netChange,
					PctChange = order.marketData.percentageChange,
					Low = order.marketData.low,
					High = order.marketData.high,
					StreamingPricesAvailable = order.marketData.streamingPricesAvailable,
					MarketStatus = order.marketData.marketStatus,
				},
				OrderSize = order.workingOrderData.orderSize,
				Direction = order.workingOrderData.direction,
				DealId = order.workingOrderData.dealId,
				CreationDate = order.workingOrderData.createdDate
			};
        }
    }

}
