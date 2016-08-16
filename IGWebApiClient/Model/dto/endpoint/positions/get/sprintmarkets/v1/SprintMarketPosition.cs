using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.get.sprintmarkets.v1
{

public class SprintMarketPosition{
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Instrument epic
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Market name
	///</Summary>
	public string marketName { get; set; }
	///<Summary>
	///Market status
	///</Summary>
	public string marketStatus { get; set; }
	///<Summary>
	///Time the position was created as UTC (not timezone-adjusted)
	///</Summary>
	public long createTime { get; set; }
	///<Summary>
	///Formatted and timezone-adjusted create time as per the locale
	///</Summary>
	public string formattedCreateTime { get; set; }
	///<Summary>
	///Expiry time as UTC (not timezone-adjusted)
	///</Summary>
	public decimal? expiryTime { get; set; }
	///<Summary>
	///Formatted and timezone-adjusted expiry time as per the locale
	///</Summary>
	public string formattedExpiryTime { get; set; }
	///<Summary>
	///Strike price (opening level)
	///</Summary>
	public decimal? strikeLevel { get; set; }
	///<Summary>
	///Size
	///</Summary>
	public decimal? size { get; set; }
	///<Summary>
	///Direction
	///</Summary>
	public string direction { get; set; }
	///<Summary>
	///Latest level (DealingRest puts the BID price into this).
	///</Summary>
	public decimal? latestLevel { get; set; }
	///<Summary>
	///Payout amount as a number with no formatting.
	///</Summary>
	public decimal? payoutAmount { get; set; }
	///<Summary>
	///Currency of the payout
	///</Summary>
	public string payoutCurrencyISO { get; set; }
	///<Summary>
	///Long formatted name for the position.
	///</Summary>
	public string fastBinaryInstrumentName { get; set; }
}
}
