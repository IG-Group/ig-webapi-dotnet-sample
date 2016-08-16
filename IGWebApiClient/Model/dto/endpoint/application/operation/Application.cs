using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.application.operation
{

public class Application{
	///<Summary>
	///Application name
	///</Summary>
	public string name { get; set; }
	///<Summary>
	///API key
	///</Summary>
	public string apiKey { get; set; }
	///<Summary>
	///Application status
	///</Summary>
	public string status { get; set; }
	///<Summary>
	///Overall request per minute allowance
	///</Summary>
	public int allowanceApplicationOverall { get; set; }
	///<Summary>
	///Per account trading request per minute allowance
	///</Summary>
	public int allowanceAccountTrading { get; set; }
	///<Summary>
	///Per account request per minute allowance
	///</Summary>
	public int allowanceAccountOverall { get; set; }
	///<Summary>
	///Historical price data data points per minute allowance
	///</Summary>
	public int allowanceAccountHistoricalData { get; set; }
	///<Summary>
	///True if access to equity prices is permitted
	///</Summary>
	public bool allowEquities { get; set; }
	///<Summary>
	///True if quote orders are permitted
	///</Summary>
	public bool allowQuoteOrders { get; set; }
}
}
