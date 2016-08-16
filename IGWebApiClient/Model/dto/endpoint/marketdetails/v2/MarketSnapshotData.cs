using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class MarketSnapshotData{
	///<Summary>
	///Market status
	///</Summary>
	public string marketStatus { get; set; }
	///<Summary>
	///Net price change on the day
	///</Summary>
	public decimal? netChange { get; set; }
	///<Summary>
	///Percentage price change on the day
	///</Summary>
	public decimal? percentageChange { get; set; }
	///<Summary>
	///Price last update time (hh:mm:ss)
	///</Summary>
	public string updateTime { get; set; }
	///<Summary>
	///Price delay
	///</Summary>
	public int delayTime { get; set; }
	///<Summary>
	///Bid price
	///</Summary>
	public decimal? bid { get; set; }
	///<Summary>
	///Offer price
	///</Summary>
	public decimal? offer { get; set; }
	///<Summary>
	///Highest price on the day
	///</Summary>
	public decimal? high { get; set; }
	///<Summary>
	///Lowest price on the day
	///</Summary>
	public decimal? low { get; set; }
	///<Summary>
	///Binary odds
	///</Summary>
	public decimal? binaryOdds { get; set; }
	///<Summary>
	///Number of decimal positions for market levels
	///</Summary>
	public int decimalPlacesFactor { get; set; }
	///<Summary>
	///Multiplying factor to determine actual pip value for the levels used by the instrument
	///</Summary>
	public int scalingFactor { get; set; }
	///<Summary>
	///the number of points to add on each side of the market as an additional spread when
	///placing a guaranteed stop trade.
	///</Summary>
	public decimal? controlledRiskExtraSpread { get; set; }
}
}
