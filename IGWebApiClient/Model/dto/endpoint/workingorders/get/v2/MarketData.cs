using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.workingorders.get.v2
{

public class MarketData{
	///<Summary>
	///Instrument name
	///</Summary>
	public string instrumentName { get; set; }
	///<Summary>
	///Exchange identifier for this instrument
	///</Summary>
	public string exchangeId { get; set; }
	///<Summary>
	///Instrument expiry period
	///</Summary>
	public string expiry { get; set; }
	///<Summary>
	///</Summary>
	public string marketStatus { get; set; }
	///<Summary>
	///Instrument epic identifier
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Instrument type
	///</Summary>
	public string instrumentType { get; set; }
	///<Summary>
	///Instrument lot size
	///</Summary>
	public decimal? lotSize { get; set; }
	///<Summary>
	///High price
	///</Summary>
	public decimal? high { get; set; }
	///<Summary>
	///Low price
	///</Summary>
	public decimal? low { get; set; }
	///<Summary>
	///Price percentage change
	///</Summary>
	public decimal? percentageChange { get; set; }
	///<Summary>
	///Price net change
	///</Summary>
	public decimal? netChange { get; set; }
	///<Summary>
	///Bid
	///</Summary>
	public decimal? bid { get; set; }
	///<Summary>
	///Offer
	///</Summary>
	public decimal? offer { get; set; }
	///<Summary>
	///Last instrument price update time
	///</Summary>
	public string updateTime { get; set; }
	///<Summary>
	///Instrument price delay (minutes)
	///</Summary>
	public int delayTime { get; set; }
	///<Summary>
	///True if streaming prices are available
	///</Summary>
	public bool streamingPricesAvailable { get; set; }
	///<Summary>
	///multiplying factor to determine actual pip value for the levels used by the instrument
	///</Summary>
	public int scalingFactor { get; set; }
}
}
