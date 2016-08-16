using System;
using System.Collections.ObjectModel;
using System.Linq;
using dto.endpoint.watchlists.retrieve;
using IGWebApiClient;
using Lightstreamer.DotNet.Client;
using SampleWPFTrader.Model;

namespace SampleWPFTrader.ViewModel
{
    public class WatchlistsViewModel : ViewModelBase
    {
        private IgPublicApiData.WatchlistModel _currentWatchlist;

        //
        // This value is used to indicate the index of the watchlist that we have subscribed to, in the 
        // watchlists array...
        //

		private int _watchlistIndex;
		private int _watchlistMarketIndex;
        private int _chartIndex;

        private SubscribedTableKey _watchlistL1PricesSubscribedTableKey;
        private SubscribedTableKey _chartSubscribedTableKey;
		private MarketDetailsTableListerner _l1PricesSubscription;
        private ChartCandleTableListerner _chartSubscription;

        public WatchlistsViewModel()
        {           
			Watchlists = new ObservableCollection<IgPublicApiData.WatchlistModel>();
			WatchlistMarkets = new ObservableCollection<IgPublicApiData.WatchlistMarketModel>();
            ChartMarketData = new ObservableCollection<IgPublicApiData.ChartModel>();
           
            WatchlistIndex = 0;
            WatchlistMarketIndex = 0;
            ChartIndex = 0;
           
            WireCommands();
            
			_l1PricesSubscription = new MarketDetailsTableListerner();
			_l1PricesSubscription.Update += OnMarketUpdate;
            _watchlistL1PricesSubscribedTableKey = new SubscribedTableKey();
            _watchlistL1PricesSubscribedTableKey = null;

            _chartSubscribedTableKey = new SubscribedTableKey();

            _chartSubscription = new ChartCandleTableListerner();
            _chartSubscription.Update += OnChartCandleDataUpdate;
        }

        private void OnChartCandleDataUpdate(object sender, UpdateArgs<ChartCandelData> e)
        {
            var candleUpdate = e.UpdateData;

            var tempEpic = e.ItemName.Replace("CHART:", "");
            var tempArray = tempEpic.Split(':');
            var epic = tempArray[0];
            var time = tempArray[1];

            foreach (var candleData in ChartMarketData.Where(chartItem => chartItem.ChartEpic == epic))
            {                                            
                candleData.Bid = new IgPublicApiData.ChartHlocModel();
                candleData.Bid.Close = candleUpdate.Bid.Close;
                candleData.Bid.High = candleUpdate.Bid.High;
                candleData.Bid.Low = candleUpdate.Bid.Low;
                candleData.Bid.Open = candleUpdate.Bid.Open;
               
                candleData.DayChange = candleUpdate.DayChange;
                candleData.DayChangePct = candleUpdate.DayChangePct;
                candleData.DayHigh = candleUpdate.DayHigh;
                candleData.DayLow = candleUpdate.DayLow;
                candleData.DayMidOpenPrice = candleUpdate.DayMidOpenPrice;
                candleData.EndOfConsolidation = candleUpdate.EndOfConsolidation;
                candleData.IncrimetalTradingVolume = candleUpdate.IncrimetalTradingVolume;

                if (candleUpdate.LastTradedVolume != null)
                {
                    candleData.LastTradedVolume = candleUpdate.LastTradedVolume;
                    candleData.LastTradedPrice = new IgPublicApiData.ChartHlocModel();
                    candleData.LastTradedPrice.Close = candleUpdate.LastTradedPrice.Close;
                    candleData.LastTradedPrice.High = candleUpdate.LastTradedPrice.High;
                    candleData.LastTradedPrice.Low = candleUpdate.LastTradedPrice.Low;
                    candleData.LastTradedPrice.Open = candleUpdate.LastTradedPrice.Open;
                }                

                candleData.Offer = new IgPublicApiData.ChartHlocModel();
                candleData.Offer.Close = candleUpdate.Offer.Close;
                candleData.Offer.Open = candleUpdate.Offer.Open;
                candleData.Offer.High = candleUpdate.Offer.High;
                candleData.Offer.Low = candleUpdate.Offer.Low;

                candleData.TickCount = candleUpdate.TickCount;
                candleData.UpdateTime = candleUpdate.UpdateTime;                
            }
        }

		private void OnMarketUpdate(object sender, UpdateArgs<L1LsPriceData> e)
        {
			try
			{				
				var wlmUpdate = e.UpdateData;

				var epic = e.ItemName.Replace("L1:", "");

				foreach (var watchlistItem in WatchlistMarkets.Where(watchlistItem => watchlistItem.Model.Epic == epic))
				{
					watchlistItem.Model.Epic = epic;
					watchlistItem.Model.Bid = wlmUpdate.Bid;
					watchlistItem.Model.Offer = wlmUpdate.Offer;
					watchlistItem.Model.NetChange = wlmUpdate.Change;
					watchlistItem.Model.PctChange = wlmUpdate.ChangePct;
					watchlistItem.Model.Low = wlmUpdate.Low;
					watchlistItem.Model.High = wlmUpdate.High;
					watchlistItem.Model.Open = wlmUpdate.MidOpen;
					watchlistItem.UpdateTime = wlmUpdate.UpdateTime;
					watchlistItem.Model.MarketStatus = wlmUpdate.MarketState;
				}
        }

			catch (Exception ex)
            {
				WatchlistL1PriceUpdates = ex.Message;
			}
        }

		public ObservableCollection<IgPublicApiData.WatchlistModel> Watchlists { get; set; }

		public ObservableCollection<IgPublicApiData.WatchlistMarketModel> WatchlistMarkets { get; set; }

        public ObservableCollection<IgPublicApiData.ChartModel> ChartMarketData { get; set; }

        private void WireCommands()
        {            
            GetWatchlistsCommand = new RelayCommand(GetRestWatchlists);
            GetWatchlistMarketsCommand = new RelayCommand(GetRestWatchlistMarkets);           
            GetWatchlistsCommand.IsEnabled = true;           
        }

        public RelayCommand UpdateWatchlistCommand
        {
            get;
            private set;
        }      

        public RelayCommand GetWatchlistsCommand
        {
            get;
            private set;
        }

        public RelayCommand GetWatchlistMarketsCommand
        {
            get;
            private set;
        }
          
        public IgPublicApiData.WatchlistModel CurrentWatchlist
        {
            get
            {
                return _currentWatchlist;
            }

            set
            {
                if (_currentWatchlist != value)
                {
                    _currentWatchlist = value;
                    RaisePropertyChanged("CurrentWatchlist");
                    UpdateWatchlistCommand.IsEnabled = true;
                }
            }
        }

        public int WatchlistIndex
        {
            get
            {                
                return _watchlistIndex;
            }
            set
            {
                if (_watchlistIndex != value)
                {                    
                    _watchlistIndex = value;
                    RaisePropertyChanged("WatchlistIndex");
                    WatchlistIndexChanged();

                    GetWatchlistMarketsCommand.IsEnabled = true;
                }
            }
        }

        public int ChartIndex
        {
            get
            {
                return _chartIndex;
            }
            set
            {
                if (_chartIndex != value)
                {
                    _chartIndex = value;
                    RaisePropertyChanged("ChartIndex");                    
                }
            }
        }


        public void WatchlistIndexChanged()
        {
            ClearWatchlistMarkets();  
            UnsubscribeFromWatchlistInstruments();
            UnsubscribeFromCharts();

            if (WatchlistIndex >= 0)
            {                
                // Now subscribe to instruments in this watchlist ( indicated by WatchlistIndex ).              
                GetRestWatchlistMarkets();
            }          
        }


        private void UnsubscribeFromWatchlistInstruments()
        {            
            if ((igStreamApiClient != null) && (_watchlistL1PricesSubscribedTableKey != null) && (LoggedIn))
            {
                igStreamApiClient.UnsubscribeTableKey(_watchlistL1PricesSubscribedTableKey);
                _watchlistL1PricesSubscribedTableKey = null;

                AddStatusMessage("WatchlistsViewModel : Unsubscribing from L1 Prices for Watchlists");
            }
        }

        private void UnsubscribeFromCharts()
        {
            if ((igStreamApiClient != null) && (_chartSubscribedTableKey!= null) && (LoggedIn))
            {
                igStreamApiClient.UnsubscribeTableKey(_chartSubscribedTableKey);
                _chartSubscribedTableKey = null;

                AddStatusMessage("WatchlistsViewModel : Unsubscribing from candle data from charts");
            }
        }


        public void WatchlistTabChanged()
        {
            WatchlistIndex = -1;

            if (WatchlistTabSelected)
            {
                AddStatusMessage("Get Watchlists");                               
                if (LoggedIn)
                {
                    GetRestWatchlists();                    
                }
                else
                {
                    AddStatusMessage("Please log in first");
                }
            }
        }

        private bool _watchlistTabSelected;
        public bool WatchlistTabSelected
        {
            get
            {
                return _watchlistTabSelected;
            }
            set
            {
                if (_watchlistTabSelected != value)
                {
                    _watchlistTabSelected = value;
                    WatchlistTabChanged();
                    RaisePropertyChanged("WatchlistTabSelected");
                }
            }
        }


        public int WatchlistMarketIndex
        {
            get
            {
                return _watchlistMarketIndex;
            }

            set
            {
                if (_watchlistMarketIndex != value)
                {
                    _watchlistMarketIndex = value;                   
                    RaisePropertyChanged("WatchlistMarketIndex");                   
                }
            }
        }

        private string _watchlistsData;
        public string WatchlistsData
        {
            get { return _watchlistsData; }
            set
            {
                if ((_watchlistsData != value) && (value != null))
                {
                    _watchlistsData = value;
                    RaisePropertyChanged("WatchlistsData");
                }
            }
        }
       
        private string _watchlistL1PriceUpdates;
        public string WatchlistL1PriceUpdates
        {
            get { return _watchlistL1PriceUpdates; }
            set
            {
                if ((_watchlistL1PriceUpdates != value) && (value != null))
                {
                    _watchlistL1PriceUpdates = value;
                    RaisePropertyChanged("WatchlistL1PriceUpdates");
                }
            }
        }
      
        public void UpdateWatchlistL1PricesMessage(string message)
        {
            WatchlistL1PriceUpdates += message + Environment.NewLine;
        }
      
        private void ClearWatchlistMarkets()
        {
            if (WatchlistMarkets != null)
            {
                UnsubscribeFromWatchlistInstruments();
                WatchlistMarkets.Clear();                                   
            }
        }
       
        // <Summary>
        // GetRestWatchlists
        // </Summary>
        public async void GetRestWatchlists()
        {
            try
            {               
                AddStatusMessage("Retrieving watchlists");
                var response = await igRestApiClient.listOfWatchlists();
				if (response && (response.Response.watchlists != null))
                {
                    Watchlists.Clear();
                    foreach (var wl in response.Response.watchlists)
                    {
                        var wm = new IgPublicApiData.WatchlistModel();
                        wm.WatchlistId = wl.id;
                        wm.WatchlistName = wl.name;
                        wm.Editable = wl.editable;
                        wm.Deletable = wl.deleteable;  
                      
                        Watchlists.Add(wm);                       
                    }

                    if (Watchlists.Count >= 1)
                    {
                        GetWatchlistMarketsCommand.IsEnabled = true;
                        WatchlistIndex = 0;                       
                    }

                    // Set the Watchlist Index to the first one in the list.
                    WatchlistIndex = 0;                   
                }
                else
                {
                    AddStatusMessage("GetRestWatchlists : no watchlists returned from server");
                }

            }
            catch (Exception ex)
            {
                AddStatusMessage(ex.Message);
            }
        }
    
        // <Summary>
        // GetRestWatchlistMarkets
        // </Summary>
        public async void GetRestWatchlistMarkets()
        {           
            try
            {               
				if ((Watchlists != null) && (WatchlistIndex < Watchlists.Count))
                {                    
                    AddStatusMessage(String.Format("Retrieving watchlist markets for watchlist called {0}",
                                                          Watchlists[WatchlistIndex].WatchlistName));
                    var response = await igRestApiClient.instrumentsForWatchlist(Watchlists[WatchlistIndex].WatchlistId);
                    if (response != null) 
                    {
                        if (response && (response.Response.markets != null) && (response.Response.markets.Count > 0))
                        {
                            WatchlistMarkets.Clear();
							foreach (var wim in response.Response.markets.Select(LoadMarket))
                            {
                                WatchlistMarkets.Add(wim);
                            }

                            // Get unique epics for these orders ( we don't want to subscribe to the same epic twice )
                            var uniqueEpics = (from dbo in WatchlistMarkets
                                               where dbo.Model.StreamingPricesAvailable == true
                                               select dbo.Model.Epic).Distinct().ToArray();

                            if (uniqueEpics.Length != 0)
                            {
                                SubscribeL1WatchlistPrices(uniqueEpics);
                                SubscribeToCharts(uniqueEpics);
                            }
                            else
                            {
								AddStatusMessage("There are no watchlist instruments with streaming prices enabled");
                            }
                        }
                        else
                        {
                            AddStatusMessage("HttpStatusCode error: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        AddStatusMessage("GetRestWatchlistMarkets : null response from server");
                    }
                }
            }
            catch (Exception ex)
            {
                AddStatusMessage(ex.Message);
            }
        }       

		private static IgPublicApiData.WatchlistMarketModel LoadMarket(WatchlistMarket wl)
		{
			return new IgPublicApiData.WatchlistMarketModel
			{
				Model = new IgPublicApiData.InstrumentModel
				{
					High = wl.high,
					Low = wl.low,
					Epic = wl.epic,
					Bid = wl.bid,
					Offer = wl.offer,
					PctChange = wl.percentageChange,
					NetChange = wl.netChange,
					InstrumentName = wl.instrumentName,
					StreamingPricesAvailable = wl.streamingPricesAvailable,
					MarketStatus = wl.marketStatus
				}
			};
		}

        // <Summary>
        // Lightstreamer Subscribe to L1 Prices...
        // </Summary>
        private void SubscribeL1WatchlistPrices(string[] watchlistItems)
        {                                   
            try
            {                                     
                if (igStreamApiClient != null) 
                {                       
					_watchlistL1PricesSubscribedTableKey = igStreamApiClient.SubscribeToMarketDetails(watchlistItems, _l1PricesSubscription);
                    AddStatusMessage("Successfully subscribed to Watchlist : " + Watchlists[WatchlistIndex].WatchlistName);                        
                }                                   
            }
            catch (Exception ex)
            {
                AddStatusMessage("Exception when trying to subscribe to Watchlist l1 prices: " + ex.Message);               
            }            
        }

        // <Summary>
        // Lightstreamer Subscribe to L1 Prices...
        // </Summary>
        private void SubscribeToCharts(string[] chartEpics)
        {
            try
            {
                if (igStreamApiClient != null)
                {                    
                    ChartMarketData.Clear();                    
                    foreach (var epic in chartEpics)
                    {
                        IgPublicApiData.ChartModel ccd = new IgPublicApiData.ChartModel();
                        ccd.ChartEpic = epic;                       
                        ChartMarketData.Add(ccd);

                        AddStatusMessage("Subscribing to Chart Data (CandleStick ): " + ccd.ChartEpic);
                    }

                    _chartSubscribedTableKey = igStreamApiClient.SubscribeToChartCandleData( chartEpics, ChartScale.OneMinute, _chartSubscription);
                   
                }
            }
            catch (Exception ex)
            {
                AddStatusMessage("Exception when trying to subscribe to Chart Candle Data: " + ex.Message);
            }
        } 
    }
}
