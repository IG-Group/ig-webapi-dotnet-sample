using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class MarketRolloverData{
	///<Summary>
	///Last rollover date (GMT)
	///</Summary>
	public string lastRolloverTime { get; set; }
	///<Summary>
	///Rollover info
	///</Summary>
	public string rolloverInfo { get; set; }
}
}
