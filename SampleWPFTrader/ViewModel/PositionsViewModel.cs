using System;
using System.Collections.ObjectModel;
using System.Linq;
using IGWebApiClient;
using Lightstreamer.DotNet.Client;
using SampleWPFTrader.Model;

namespace SampleWPFTrader.ViewModel
{
    public class PositionsViewModel : ViewModelBase
    {
        // A list of all positions ( which might contain the same epics, but different trade sizes, different prices when purchased etc )
        private ObservableCollection<IgPublicApiData.PositionModel> _positions;

        private IgPublicApiData.PositionModel _currentPosition;

        // LS subscriptions...
        private L1PricesSubscription _l1PricesSubscription;
        private SubscribedTableKey _l1PositionPricesTableKey;

        private bool _positionsTabSelected;
        public bool PositionsTabSelected
        {
            get
            {
                return _positionsTabSelected;
            }
            set
            {
                if (_positionsTabSelected != value)
                {
                    _positionsTabSelected = value;
                    RaisePropertyChanged("PositionsTabSelected");

                    if (_positionsTabSelected)
                    {
                        if (LoggedIn)
                        {
                            GetRestPositions();
                        }
                        else
                        {
                            UpdatePositionMessage("Please log in first");
                        }
                    }
                    else
                    {
                        UnsubscribeFromPositions();
                    }
                }
            }
        }

        private void UnsubscribeFromPositions()
        {
            if ((igStreamApiClient != null) && (_l1PositionPricesTableKey != null) && (LoggedIn))
            {
                igStreamApiClient.UnsubscribeTableKey(_l1PositionPricesTableKey);
                _l1PositionPricesTableKey = null;

                UpdatePositionMessage("PositionViewModel : Unsubscribing from Positions");
            }
        }

        public PositionsViewModel()
        {
            InitialiseViewModel();

            _positions = new ObservableCollection<IgPublicApiData.PositionModel>();

            // Initialise LS subscriptions                      
            _l1PricesSubscription = new L1PricesSubscription(this);

            // initialise the LS SubscriptionTableKeys           
            _l1PositionPricesTableKey = new SubscribedTableKey();

            // Important to initialise to null.
            _l1PositionPricesTableKey = null;
        }

        public ObservableCollection<IgPublicApiData.PositionModel> Positions
        {
            get { return _positions; }
            set { _positions = value; }
        }

        public IgPublicApiData.PositionModel CurrentPosition
        {
            get
            {
                return _currentPosition;
            }

            set
            {
                if (_currentPosition != value)
                {
                    _currentPosition = value;
                    RaisePropertyChanged("CurrentPosition");
                }
            }
        }

        public void UpdatePositionMessage(string message)
        {
            ApplicationViewModel.getInstance().UpdateDebugMessage(message);
        }

        public void SubscribeToL1PositionPrices(string[] positionSubs)
        {
            try
            {
                if (igStreamApiClient != null)
                {
                    _l1PositionPricesTableKey = igStreamApiClient.SubscribeToMarketDetails(positionSubs, _l1PricesSubscription);
                    UpdatePositionMessage("Successfully subscribed to positions");
                }
            }
            catch (Exception ex)
            {
                UpdatePositionMessage("Problem subscribing to positions: " + ex.Message);
            }
        }

        public async void GetRestPositions()
        {
            UpdatePositionMessage("Retrieving open positions");
            if (igRestApiClient != null)
            {
                var positionsResponse = await igRestApiClient.getOTCOpenPositionsV2();
                if (positionsResponse && (positionsResponse.Response != null))
                {
                    Positions.Clear();
                    if (positionsResponse.Response.positions.Count != 0)
                    {
                        foreach (var position in positionsResponse.Response.positions)
                        {
                            var igpd = new IgPublicApiData.PositionModel();
                            igpd.Model = new IgPublicApiData.InstrumentModel();

                            igpd.Model.Bid = position.market.bid;
                            igpd.Model.Offer = position.market.offer;
                            igpd.Model.Epic = position.market.epic;
                            igpd.Model.InstrumentName = position.market.instrumentName;
                            igpd.DealSize = position.position.size;
                            igpd.Direction = position.position.direction;
                            igpd.StopLevel = position.position.stopLevel;
                            igpd.LimitLevel = position.position.limitLevel;
                            igpd.Model.StreamingPricesAvailable = position.market.streamingPricesAvailable;
                            igpd.Model.MarketStatus = position.market.marketStatus;
                            igpd.CreatedDate = position.position.createdDate;

                            // This is our list of all positions that the client has...
                            if (Positions != null)
                            {
                                Positions.Add(igpd);
                            }
                        }

                        //
                        // this is a list of unique epics ( don't forget we don't want to subscribe to the same epic twice, or subscribe to an instrument
                        // which has streaming prices disabled.
                        //
                        string[] uc = (from dbo in Positions
                                       where dbo.Model.StreamingPricesAvailable == true
                                       select dbo.Model.Epic).Distinct().ToArray();

                        if (uc.Length != 0)
                        {
                            SubscribeToL1PositionPrices(uc);
                        }
                        else
                        {
                            UpdatePositionMessage("There are no positions with streaming prices enabled");
                        }
                    }
                    else
                    {
                        UpdatePositionMessage("GetRestPositions: no Positions found");
                    }
                }
                else
                {
                    UpdatePositionMessage("GetRestPositions: HttpStatusCode is not ok: " + positionsResponse.StatusCode);
                }
            }
        }

        public class L1PricesSubscription : HandyTableListenerAdapter
        {
            private readonly PositionsViewModel _positionsViewModel;
            public L1PricesSubscription(PositionsViewModel pvm)
            {
                _positionsViewModel = pvm;
            }

            public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
            {
                try
                {
                    var posUpdate = L1LsPriceUpdateData(itemPos, itemName, update);
                    var epic = itemName.Replace("L1:", "");

                    foreach (var position in _positionsViewModel.Positions)
                    {
                        if (position.Model.Epic == epic)
                        {
                            position.Model.Bid = posUpdate.Bid;
                            position.Model.MarketStatus = posUpdate.MarketState;
                            position.Model.Offer = posUpdate.Offer;
                            position.Model.NetChange = posUpdate.Change;
                            position.Model.PctChange = posUpdate.ChangePct;
                            position.Model.Low = posUpdate.Low;
                            position.Model.High = posUpdate.High;
                            position.Model.Open = posUpdate.MidOpen;
                            position.Model.LsItemName = itemName;
                        }
                    }

                }
                catch (Exception ex)
                {
                    _positionsViewModel.UpdatePositionMessage(ex.Message);
                }
            }
        }
    }

}
