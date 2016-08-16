using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.create.sprintmarkets.v1
{

public class CreateSprintMarketPosition{
	///<Summary>
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///</Summary>
	public string expiry { get; set; }
	///<Summary>
	///Order Type for the trade. Currently the only allowed type is QUOTE
	///</Summary>
	public string orderType { get; set; }
	///<Summary>
	///</Summary>
	public string currencyCode { get; set; }
	///<Summary>
	///</Summary>
	public string direction { get; set; }
	///<Summary>
	///</Summary>
	public decimal? size { get; set; }
	///<Summary>
	///</Summary>
	public decimal? strikeLevel { get; set; }
	///<Summary>
	///</Summary>
	public decimal? binaryOdds { get; set; }
	///<Summary>
	///</Summary>
	public string expiryTime { get; set; }
	///<Summary>
	///</Summary>
	public decimal? quoteId { get; set; }
}
}
