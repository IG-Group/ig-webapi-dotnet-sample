using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class CurrencyData{
	///<Summary>
	///Code, to be used when placing orders
	///</Summary>
	public string code { get; set; }
	///<Summary>
	///Symbol, for display purposes
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
