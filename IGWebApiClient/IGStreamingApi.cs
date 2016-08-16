using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lightstreamer.DotNet.Client;

namespace IGWebApiClient
{
    public enum StreamingDirectionEnum
    {
        BUY,
        SELL
    }

    public enum StreamingStatusEnum
    {
        OPEN,
        UPDATED,
        AMENDED,
        CLOSED,
        DELETED,
    }

    public enum StreamingDealStatusEnum
    {
        ACCEPTED,
        REJECTED,
    }

    public enum TradeSubscriptionTypeEnum
    {
        WOU = 0,
        OPU = 1,
        TRADE = 2,
    }

	public class AffectedDeals
	{
		public string dealId;
		public string status;
	}

	public enum ChartScale
	{
		OneSecond,
		OneMinute,
		FiveMinute,
		OneHour,
	}

    public class LsTradeSubscriptionData
    {
        public StreamingDirectionEnum? direction;
        public string limitLevel; // if this is null we get an exception  - should be a decimal
        public string dealId;
        public string affectedDealId;
        public string stopLevel; // should be decimal but throws an exception if null.
        public string expiry;
        public string size; // should be decimal ...
        public StreamingStatusEnum? status;
        public string epic;
        public string level; // decimal
        public bool? guaranteedStop;
        public string dealReference;
        public StreamingDealStatusEnum? dealStatus;
	    public List<AffectedDeals> affectedDeals;
    }   

    public class L1LsPriceData
    {
        public decimal? MidOpen;
        public decimal? High;
        public decimal? Low;
        public decimal? Change;
        public decimal? ChangePct;
        public string UpdateTime;
        public int? MarketDelay;
        public string MarketState;
        public decimal? Bid;
        public decimal? Offer;       
    }

    public class StreamingAccountData
    {
        public decimal? ProfitAndLoss;
        public decimal? Deposit;
        public decimal? UsedMargin;
        public decimal? AmountDue;
        public decimal? AvailableCash;
    }   

    public class MarketStatus
    {
        public string marketstatus { get; set; }       
    }
   
	public class HandyTableListenerAdapter : TableListenerAdapterBase
    {              
		public L1LsPriceData L1LsPriceUpdateData(int itemPos, string itemName, IUpdateInfo update)
        {
            var lsL1PriceData = new L1LsPriceData();
            try
            {
                var midOpen = update.GetNewValue("MID_OPEN");
                var high = update.GetNewValue("HIGH");
                var low = update.GetNewValue("LOW");
                var change = update.GetNewValue("CHANGE");
                var changePct = update.GetNewValue("CHANGE_PCT");
                var updateTime = update.GetNewValue("UPDATE_TIME");
                var marketDelay = update.GetNewValue("MARKET_DELAY");
                var marketState = update.GetNewValue("MARKET_STATE");
                var bid = update.GetNewValue("BID");
                var offer = update.GetNewValue("OFFER");

                if (!String.IsNullOrEmpty(midOpen))               
                {
                    lsL1PriceData.MidOpen = Convert.ToDecimal(midOpen);
                }
                if (!String.IsNullOrEmpty(high))        
                {
                    lsL1PriceData.High = Convert.ToDecimal(high);
                }
                if (!String.IsNullOrEmpty(low))  
                {
                    lsL1PriceData.Low = Convert.ToDecimal(low);
                }
                if (!String.IsNullOrEmpty(change))
                {
                    lsL1PriceData.Change = Convert.ToDecimal(change);
                }
                if (!String.IsNullOrEmpty(changePct))
                {
                    lsL1PriceData.ChangePct = Convert.ToDecimal(changePct);
                }
                if (!String.IsNullOrEmpty(updateTime))               
                {
                    lsL1PriceData.UpdateTime = updateTime;
                }
                if (!String.IsNullOrEmpty(marketDelay))
                {
                    lsL1PriceData.MarketDelay = Convert.ToInt32(marketDelay);
                }
                if (!String.IsNullOrEmpty(marketState))
                {              
                    lsL1PriceData.MarketState = marketState;
                }
                if (!String.IsNullOrEmpty(bid))
                {
                    lsL1PriceData.Bid = Convert.ToDecimal(bid);
                }
                if (!String.IsNullOrEmpty(offer))
                {
                    lsL1PriceData.Offer = Convert.ToDecimal(offer);
                }
            }
            catch (Exception)
            {                
            }
            return lsL1PriceData;
        }

        public StreamingAccountData StreamingAccountDataUpdates(int itemPos, string itemName, IUpdateInfo update)
        {
            var streamingAccountData = new StreamingAccountData();
            try
            {
                var pnl = update.GetNewValue("PNL");
                var deposit = update.GetNewValue("DEPOSIT");
                var usedMargin = update.GetNewValue("USED_MARGIN");
                var amountDue = update.GetNewValue("AMOUNT_DUE");
                var availableCash = update.GetNewValue("AVAILABLE_CASH");
                                       
                if (!String.IsNullOrEmpty(pnl))
                {
                    streamingAccountData.ProfitAndLoss = Convert.ToDecimal(pnl);
                }
                if (!String.IsNullOrEmpty(deposit))
                {
                    streamingAccountData.Deposit = Convert.ToDecimal(deposit);
                }
                if (!String.IsNullOrEmpty(usedMargin))
                {
                    streamingAccountData.UsedMargin = Convert.ToDecimal(usedMargin);
                }
                if (!String.IsNullOrEmpty(amountDue))
                {
                    streamingAccountData.AmountDue = Convert.ToDecimal(amountDue);
                }
                if (!String.IsNullOrEmpty(availableCash))
                {
                    streamingAccountData.AmountDue = Convert.ToDecimal(availableCash);
                }
               
            }
            catch (Exception)
            {
            }
            return streamingAccountData;
        }
               
        public string L1PriceUpdates(int itemPos, string itemName, IUpdateInfo update)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Item Position: " + itemPos);
            sb.AppendLine("Item Name: " + itemName);

            try
            {
                var midOpen = update.GetNewValue("MID_OPEN");
                var high = update.GetNewValue("HIGH");
                var low = update.GetNewValue("LOW");
                var change = update.GetNewValue("CHANGE");
                var changePct = update.GetNewValue("CHANGE_PCT");
                var updateTime = update.GetNewValue("UPDATE_TIME");
                var marketDelay = update.GetNewValue("MARKET_DELAY");
                var marketState = update.GetNewValue("MARKET_STATE");
                var bid = update.GetNewValue("BID");
                var offer = update.GetNewValue("OFFER");

                if (!String.IsNullOrEmpty(midOpen))
                {
                    sb.AppendLine("mid open: " + midOpen);
                }
                if (!String.IsNullOrEmpty(high))
                {
                    sb.AppendLine("high: " + high);
                }
                if (!String.IsNullOrEmpty(low))
                {
                    sb.AppendLine("low: " + low);
                }
                if (!String.IsNullOrEmpty(change))
                {
                    sb.AppendLine("change: " + change);
                }
                if (!String.IsNullOrEmpty(changePct))
                {
                    sb.AppendLine("change percent: " + changePct);
                }
                if (!String.IsNullOrEmpty(updateTime))
                {
                    sb.AppendLine("update time: " + updateTime);
                }
                if (!String.IsNullOrEmpty(marketDelay))
                {
                    sb.AppendLine("market delay: " + marketDelay);
                }
                if (!String.IsNullOrEmpty(marketState))
                {
                    sb.AppendLine("market state: " + marketState);
                }
                if (!String.IsNullOrEmpty(bid))
                {
                    sb.AppendLine("bid: " + bid);
                }
                if (!String.IsNullOrEmpty(offer))
                {
                    sb.AppendLine("offer: " + offer);
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("Exception in L1 Prices");
                sb.AppendLine(ex.Message);
            }
            return sb.ToString();
        }
	}
       
	public class TableListenerAdapterBase : IHandyTableListener
	{
        public virtual void OnRawUpdatesLost(int itemPos, string itemName, int lostUpdates)
        {
        }

        public virtual void OnSnapshotEnd(int itemPos, string itemName)
        {
        }

        public virtual void OnUnsubscr(int itemPos, string itemName)
        {
        }

        public virtual void OnUnsubscrAll()
        {
        }

        public virtual void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
		}

		protected decimal? StringToNullableDecimal(string value)
		{
			decimal number;
			return decimal.TryParse(value, out number) ? number : (decimal?)null;
		}

		protected int? StringToNullableInt(string value)
		{
			int number;
			return int.TryParse(value, out number) ? number : (int?)null;
		}

		protected DateTime? EpocStringToNullableDateTime(string value)
		{
			ulong epoc;
			if (!ulong.TryParse(value, out epoc))
			{
				return null;
			}
			return new DateTime(1970,1,1,0,0,0,0).AddMilliseconds(epoc);
		}
		
	}

	public abstract class TableListenerAdapterBase<T> : TableListenerAdapterBase
	{
		public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
		{
			OnUpdate(new UpdateArgs<T> { UpdateData = LoadUpdate(update), ItemPosition = itemPos, ItemName = itemName });
		}

		protected abstract T LoadUpdate(IUpdateInfo update);

		public event EventHandler<UpdateArgs<T>> Update;

		protected virtual void OnUpdate(UpdateArgs<T> e)
		{
			var handler = Update;
			if (handler != null) handler(this, e);
		}
	}

	public class AccountDetailsTableListerner : TableListenerAdapterBase<StreamingAccountData>
	{
		protected override StreamingAccountData LoadUpdate(IUpdateInfo update)
		{

			try
			{
				var streamingAccountData = new StreamingAccountData
				{
					ProfitAndLoss = StringToNullableDecimal(update.GetNewValue("PNL")),
					Deposit = StringToNullableDecimal(update.GetNewValue("DEPOSIT")),
					UsedMargin = StringToNullableDecimal(update.GetNewValue("USED_MARGIN")),
					AmountDue = StringToNullableDecimal(update.GetNewValue("AMOUNT_DUE")),
					AvailableCash = StringToNullableDecimal(update.GetNewValue("AVAILABLE_CASH"))
				};
				return streamingAccountData;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	public class MarketDetailsTableListerner : TableListenerAdapterBase<L1LsPriceData>
	{
		protected override L1LsPriceData LoadUpdate(IUpdateInfo update)
		{
			try
			{
				var lsL1PriceData = new L1LsPriceData
				{
					MidOpen = StringToNullableDecimal(update.GetNewValue("MID_OPEN")),
					High = StringToNullableDecimal(update.GetNewValue("HIGH")),
					Low = StringToNullableDecimal(update.GetNewValue("LOW")),
					Change = StringToNullableDecimal(update.GetNewValue("CHANGE")),
					ChangePct = StringToNullableDecimal(update.GetNewValue("CHANGE_PCT")),
					UpdateTime = update.GetNewValue("UPDATE_TIME"),
					MarketDelay = StringToNullableInt(update.GetNewValue("MARKET_DELAY")),
					MarketState = update.GetNewValue("MARKET_STATE"),
					Bid = StringToNullableDecimal(update.GetNewValue("BID")),
					Offer = StringToNullableDecimal(update.GetNewValue("OFFER"))
				};
				return lsL1PriceData;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	public class ChartTickTableListerner : TableListenerAdapterBase<ChartTickData>
	{
		protected override ChartTickData LoadUpdate(IUpdateInfo update)
		{
			try
			{
				var updateData = new ChartTickData
				{
					Bid = StringToNullableDecimal(update.GetNewValue("BID")),
					Offer = StringToNullableDecimal(update.GetNewValue("OFR")),
					LastTradedPrice = StringToNullableDecimal(update.GetNewValue("LTP")),
					LastTradedVolume = StringToNullableDecimal(update.GetNewValue("LTV")),
					IncrimetalTradingVolume = StringToNullableDecimal(update.GetNewValue("TTV")),
					UpdateTime = EpocStringToNullableDateTime(update.GetNewValue("UTM")),
					DayMidOpenPrice = StringToNullableDecimal(update.GetNewValue("DAY_OPEN_MID")),
					DayChange = StringToNullableDecimal(update.GetNewValue("DAY_NET_CHG_MID")),
					DayChangePct = StringToNullableDecimal(update.GetNewValue("DAY_PERC_CHG_MID")),
					DayHigh = StringToNullableDecimal(update.GetNewValue("DAY_HIGH")),
					DayLow = StringToNullableDecimal(update.GetNewValue("DAY_LOW"))
				};
				return updateData;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
	
	public class ChartDataBase
	{
		
		/// <summary>
		/// Last traded volume
		/// </summary>
		public decimal? LastTradedVolume { get; set; }
		/// <summary>
		/// Incremental trading volume
		/// </summary>
		public decimal? IncrimetalTradingVolume { get; set; }
		/// <summary>
		/// Update time (as milliseconds from the Epoch)
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		/// Mid open price for the day
		/// </summary>
		public decimal? DayMidOpenPrice { get; set; }
		/// <summary>
		/// Change from open price to current (MID price)
		/// </summary>

		public decimal? DayChange { get; set; }
		/// <summary>
		/// Daily percentage change (MID price)
		/// </summary>
		public decimal? DayChangePct { get; set; }
		/// <summary>
		/// Daily high price (MID)
		/// </summary>
		public decimal? DayHigh { get; set; }
		/// <summary>
		/// Daily low price (MID)
		/// </summary>
		public decimal? DayLow { get; set; }
	}

	public class ChartTickData : ChartDataBase
	{
		/// <summary>
		/// Bid price
		/// </summary>
		public decimal? Bid { get; set; }
		/// <summary>
		/// Offer price
		/// </summary>
		public decimal? Offer { get; set; }
		/// <summary>
		/// Last traded price
		/// </summary>
		public decimal? LastTradedPrice { get; set; }
	}

	public class ChartCandleTableListerner : TableListenerAdapterBase<ChartCandelData>
	{
		protected override ChartCandelData LoadUpdate(IUpdateInfo update)
		{
			try
			{
				var updateData = new ChartCandelData
				{
					Bid = new HlocData{High = StringToNullableDecimal(update.GetNewValue("BID_HIGH")), Low = StringToNullableDecimal(update.GetNewValue("BID_LOW")), Open = StringToNullableDecimal(update.GetNewValue("BID_OPEN")), Close = StringToNullableDecimal(update.GetNewValue("BID_CLOSE"))},
					Offer = new HlocData { High = StringToNullableDecimal(update.GetNewValue("OFR_HIGH")), Low = StringToNullableDecimal(update.GetNewValue("OFR_LOW")), Open = StringToNullableDecimal(update.GetNewValue("OFR_OPEN")), Close = StringToNullableDecimal(update.GetNewValue("OFR_CLOSE")) },
					LastTradedPrice = new HlocData { High = StringToNullableDecimal(update.GetNewValue("LTP_HIGH")), Low = StringToNullableDecimal(update.GetNewValue("LTP_LOW")), Open = StringToNullableDecimal(update.GetNewValue("LTP_OPEN")), Close = StringToNullableDecimal(update.GetNewValue("LTP_CLOSE")) },
					LastTradedVolume = StringToNullableDecimal(update.GetNewValue("LTV")),
					IncrimetalTradingVolume = StringToNullableDecimal(update.GetNewValue("TTV")),
					UpdateTime = EpocStringToNullableDateTime(update.GetNewValue("UTM")),
					DayMidOpenPrice = StringToNullableDecimal(update.GetNewValue("DAY_OPEN_MID")),
					DayChange = StringToNullableDecimal(update.GetNewValue("DAY_NET_CHG_MID")),
					DayChangePct = StringToNullableDecimal(update.GetNewValue("DAY_PERC_CHG_MID")),
					DayHigh = StringToNullableDecimal(update.GetNewValue("DAY_HIGH")),
					DayLow = StringToNullableDecimal(update.GetNewValue("DAY_LOW")),
					TickCount = StringToNullableInt(update.GetNewValue("CONS_TICK_COUNT"))
				};
				var conEnd = StringToNullableInt(update.GetNewValue("CONS_END"));
				updateData.EndOfConsolidation = conEnd.HasValue ? conEnd > 0 : (bool?) null;
				return updateData;
        }
			catch (Exception)
			{
				return null;
			}
		}
	}

	public class ChartCandelData : ChartDataBase
	{
		public HlocData Offer { get; set; }
		public HlocData Bid { get; set; }
		public HlocData LastTradedPrice { get; set; }
		public bool? EndOfConsolidation { get; set; }
		public int? TickCount { get; set; }
    }


	public class HlocData
	{
		public decimal? High { get; set; }
		public decimal? Low { get; set; }
		public decimal? Open { get; set; }
		public decimal? Close { get; set; }
	}

	public class UpdateArgs<T> : EventArgs
	{
		public T UpdateData { get; set; }
		public int ItemPosition { get; set; }
		public string ItemName { get; set; }
	}

    public class IGStreamingApiClient : IConnectionListener
    {

        private LSClient lsClient;

        public IGStreamingApiClient()
        {
            try
            {
                lsClient = new LSClient();
            }
            catch (Exception)
            {
                
            }
        }

        public bool Connect(string username, string cstToken, string xSecurityToken, string apiKey, string lsHost)
        {
            bool connectionEstablished = false;

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.Adapter = "DEFAULT";
            connectionInfo.User = username;
			connectionInfo.Password = string.Format("CST-{0}|XST-{1}", cstToken, xSecurityToken);
            connectionInfo.PushServerUrl = lsHost;
            try
            {
                if (lsClient != null)
                {
                    lsClient.OpenConnection(connectionInfo, this);
                    connectionEstablished = true;
                }
            }
            catch (Exception)
            {
                connectionEstablished = false;
            }
            return connectionEstablished;
        }

		[Obsolete("Use 'Disconnect' instead, this will be removed in future versions")]
        public void disconnect()
        {
			Disconnect();
		}

		public void Disconnect()
		{
            if (lsClient != null)
            {
                lsClient.CloseConnection();
            }
        }

        /// <summary>
        /// account details subscription
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="tableListener"></param>
		[Obsolete("Use 'SubscribeToAccountDetails' instead, this will be removed in future versions")]
        public void subscribeToAccountDetails(string accountId, IHandyTableListener tableListener)
        {
			SubscribeToAccountDetails(accountId, tableListener);
        }

        /// <summary>
        /// account details subscription
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="tableListener"></param>
		[Obsolete("Use 'SubscribeToAccountDetails' instead, this will be removed in future versions")]
		public void subscribeToAccountDetails(string accountId, IHandyTableListener tableListener, IEnumerable<string> fields)
		{
			SubscribeToAccountDetails(accountId, tableListener, fields);
		}

		[Obsolete("Use 'SubscribeToAccountDetails' instead, this will be removed in future versions")]
		public SubscribedTableKey subscribeToAccountDetailsKey(string accountId, IHandyTableListener tableListener)
        {
			return SubscribeToAccountDetails(accountId, tableListener);
        }

		public SubscribedTableKey SubscribeToAccountDetails(string accountId, IHandyTableListener tableListener)
		{
			return SubscribeToAccountDetails(accountId, tableListener, new[] { "PNL", "DEPOSIT", "USED_MARGIN", "AMOUNT_DUE", "AVAILABLE_CASH" });
		}

		[Obsolete("Use 'SubscribeToAccountDetails' instead, this will be removed in future versions")]
		public SubscribedTableKey subscribeToAccountDetailsKey(string accountId, IHandyTableListener tableListener,
			IEnumerable<string> fields)
        {
			return SubscribeToAccountDetails(accountId, tableListener, fields);
        }

		public SubscribedTableKey SubscribeToAccountDetails(string accountId, IHandyTableListener tableListener, IEnumerable<string> fields)
        {
            ExtendedTableInfo extTableInfo = new ExtendedTableInfo(
				new[] { "ACCOUNT:" + accountId },
                "MERGE",
				fields.ToArray(),
                true
                );

            return lsClient.SubscribeTable(extTableInfo, tableListener, false);
        }


        /// <summary>
        /// L1 Prices subscription
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="tableListener"></param>
		public SubscribedTableKey SubscribeToMarketDetails(IEnumerable<string> epics, IHandyTableListener tableListener)
        {
			return SubscribeToMarketDetails(epics, tableListener,
				new[] { 
                    "MID_OPEN", "HIGH", "LOW", "CHANGE", "CHANGE_PCT", "UPDATE_TIME", 
                    "MARKET_DELAY", "MARKET_STATE", "BID", "OFFER" 
                    
                    /*, "BID_QUOTE_ID", "OFR_QUOTE_ID"*/
                });
        }

        /// <summary>
        /// L1 Prices subscription
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="tableListener"></param>
		[Obsolete("Use 'SubscribeToMarketDetails' instead, this will be removed in future versions")]
		public SubscribedTableKey subscribeToMarketDetails(IEnumerable<string> epics, IHandyTableListener tableListener, IEnumerable<string> fields)
        {
			return SubscribeToMarketDetails(epics, tableListener, fields);
		}

		public SubscribedTableKey SubscribeToMarketDetails(IEnumerable<string> epics, IHandyTableListener tableListener, IEnumerable<string> fields)
            {

			string[] items = epics.Select(e => string.Format("L1:{0}", e)).ToArray();
			ExtendedTableInfo extTableInfo = new ExtendedTableInfo(
				items,
				"MERGE",
				fields.ToArray(),
				true
				);
			return lsClient.SubscribeTable(extTableInfo, tableListener, false);
		}

		public SubscribedTableKey SubscribeToChartTicks(IEnumerable<string> epics, IHandyTableListener tableListener)
		{
			return SubscribeToChartTicks(epics, tableListener,
				new[] { 
                    "BID", "OFR", "LTP", "LTV", "TTV", "UTM", 
                    "DAY_OPEN_MID", "DAY_NET_CHG_MID", "DAY_PERC_CHG_MID", "DAY_HIGH", "DAY_LOW"
                });
		}

		public SubscribedTableKey SubscribeToChartTicks(IEnumerable<string> epics, IHandyTableListener tableListener, string[] fields)
		{
			string[] items = epics.Select(e => string.Format("CHART:{0}:TICK", e)).ToArray();
			ExtendedTableInfo extTableInfo = new ExtendedTableInfo(
				items,
				"DISTINCT",
				fields,
				true
				);
			return lsClient.SubscribeTable(extTableInfo, tableListener, false);
		}

		public SubscribedTableKey SubscribeToChartCandleData(IEnumerable<string> epics, ChartScale scale, IHandyTableListener tableListener)
		{
			return SubscribeToChartCandleData(epics, scale, tableListener,
				new[] { 
                    "LTV", "TTV", "UTM", 
					"DAY_OPEN_MID", "DAY_NET_CHG_MID", "DAY_PERC_CHG_MID", "DAY_HIGH", "DAY_LOW", 
					"OFR_OPEN", "OFR_HIGH", "OFR_LOW", "OFR_CLOSE",
					"BID_OPEN", "BID_HIGH", "BID_LOW", "BID_CLOSE",
					"LTP_OPEN", "LTP_HIGH", "LTP_LOW", "LTP_CLOSE",
					"CONS_END", "CONS_TICK_COUNT",
                });
            }


		public SubscribedTableKey SubscribeToChartCandleData(IEnumerable<string> epics, ChartScale scale, IHandyTableListener tableListener, string[] fields)
		{
			string[] items = epics.Select(e => string.Format("CHART:{0}:{1}", e, GetScale(scale))).ToArray();
            ExtendedTableInfo extTableInfo = new ExtendedTableInfo(
                items,
                "MERGE",
                fields,
                true
                );
            return lsClient.SubscribeTable(extTableInfo, tableListener, false);
        }

		private string GetScale(ChartScale scale)
		{
			switch (scale)
			{
				case ChartScale.OneSecond:
					return "SECOND";
				case ChartScale.OneMinute:
					return "1MINUTE";
				case ChartScale.FiveMinute:
					return "5MINUTE";
				case ChartScale.OneHour:
					return "HOUR";
				default:
					throw new ArgumentOutOfRangeException("scale");
			}
		}

        /// <summary>
        /// trade subscription details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="tableListener"></param>
		[Obsolete("Use 'SubscribeToTradeSubscription' instead, this will be removed in future versions")]
		public SubscribedTableKey subscribeToTradeSubscription(string accountId, IHandyTableListener tableListener)
		{
			return SubscribeToTradeSubscription(accountId, tableListener);
		}

		public SubscribedTableKey SubscribeToTradeSubscription(string accountId, IHandyTableListener tableListener)
        {
            return subscribeToTradeSubscription(accountId, tableListener,
				new[] { 
                    "CONFIRMS", "OPU", "WOU"
                });
        }

		private SubscribedTableKey subscribeToTradeSubscription(string accountId, IHandyTableListener tableListener,
			string[] fields)
		{
			return SubscribeToTradeSubscription(accountId, tableListener, fields);
		}
		public SubscribedTableKey SubscribeToTradeSubscription(string accountId, IHandyTableListener tableListener, IEnumerable<string> fields)
        {
            ExtendedTableInfo extTableInfo = new ExtendedTableInfo(
				new[] { "TRADE:" + accountId },
                "DISTINCT",
				fields.ToArray(),
                true
                );
            return lsClient.SubscribeTable(extTableInfo, tableListener, false);
        }

        public void UnsubscribeTableKey(SubscribedTableKey stk)
        {
            try
            {              
                if (lsClient != null)
                {
                    lsClient.UnsubscribeTable(stk);
                }
            }
            catch (Exception)
            {
                
            }
        }


        public virtual void OnActivityWarning(bool warningOn)
        {

        }

        public virtual void OnClose()
        {
            if (lsClient != null)
            {
                lsClient.CloseConnection();
            }
        }

        public virtual void OnConnectionEstablished()
        {

        }

        public virtual void OnDataError(PushServerException e)
        {

        }

        public virtual void OnEnd(int cause)
        {

        }

        public virtual void OnFailure(PushConnException e)
        {

        }

        public virtual void OnFailure(PushServerException e)
        {

        }

        public virtual void OnNewBytes(long bytes)
        {

        }

        public virtual void OnSessionStarted(bool isPolling)
        {            
        }

    }

}
