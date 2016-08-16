using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.prices.v2
{

public class PriceList{
	///<Summary>
	///Price list
	///</Summary>
	public List<PriceSnapshot> prices { get; set; }
	///<Summary>
	///the instrument type of this instrument
	///</Summary>
	public string instrumentType { get; set; }
	///<Summary>
	///Historical price data allowance
	///</Summary>
	public Allowance allowance { get; set; }
}
}
