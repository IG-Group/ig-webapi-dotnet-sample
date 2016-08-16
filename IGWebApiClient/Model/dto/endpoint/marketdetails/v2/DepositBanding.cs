using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class DepositBanding{
	///<Summary>
	///Boundaries
	///</Summary>
	public List<string> boundaries { get; set; }
	///<Summary>
	///Margin factor
	///</Summary>
	public List<string> factors { get; set; }
	///<Summary>
	///Currency
	///</Summary>
	public string currency { get; set; }
}
}
