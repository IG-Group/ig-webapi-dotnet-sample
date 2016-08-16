using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.prices.v1
{

public class PriceSnapshot{
	///<Summary>
	///Snapshot time
	///</Summary>
	public string snapshotTime { get; set; }
	///<Summary>
	///Open price
	///</Summary>
	public Price openPrice { get; set; }
	///<Summary>
	///Close price
	///</Summary>
	public Price closePrice { get; set; }
	///<Summary>
	///High price
	///</Summary>
	public Price highPrice { get; set; }
	///<Summary>
	///Low price
	///</Summary>
	public Price lowPrice { get; set; }
	///<Summary>
	///Last traded volume. This will generally be 0 for non exchange-traded instruments
	///</Summary>
	public decimal? lastTradedVolume { get; set; }
}
}
