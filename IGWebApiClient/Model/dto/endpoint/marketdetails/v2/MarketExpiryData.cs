using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class MarketExpiryData{
	///<Summary>
	///Last dealing date (GMT)
	///</Summary>
	public string lastDealingDate { get; set; }
	///<Summary>
	///Settlement information
	///</Summary>
	public string settlementInfo { get; set; }
}
}
