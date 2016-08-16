using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v1
{

public class CurrencyData{
	///<Summary>
	///Code
	///</Summary>
	public string code { get; set; }
	///<Summary>
	///Name
	///</Summary>
	public string name { get; set; }
	///<Summary>
	///Symbol
	///</Summary>
	public string symbol { get; set; }
	///<Summary>
	///Base exchange rate
	///</Summary>
	public decimal? baseExchangeRate { get; set; }
	///<Summary>
	///True if this is the default currency
	///</Summary>
	public bool isDefault { get; set; }
}
}
