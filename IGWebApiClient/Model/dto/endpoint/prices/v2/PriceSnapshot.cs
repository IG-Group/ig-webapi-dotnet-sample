using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.prices.v2
{

public class PriceSnapshot{
	///<Summary>
	///Snapshot time, format is yyyy/MM/dd hh:mm:ss
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
	///Last traded volume. This will generally be null for non exchange-traded instruments
	///</Summary>
	public decimal? lastTradedVolume { get; set; }
}
}
