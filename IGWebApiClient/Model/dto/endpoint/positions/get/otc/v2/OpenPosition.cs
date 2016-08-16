using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.get.otc.v2
{

public class OpenPosition{
	///<Summary>
	///Open position data
	///</Summary>
	public OpenPositionData position { get; set; }
	///<Summary>
	///Market data
	///</Summary>
	public MarketData market { get; set; }
}
}
