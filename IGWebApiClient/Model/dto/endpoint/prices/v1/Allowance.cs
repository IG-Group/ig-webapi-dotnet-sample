using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.prices.v1
{

public class Allowance{
	///<Summary>
	///The number of data points still available to fetch within the current allowance period
	///</Summary>
	public int remainingAllowance { get; set; }
	///<Summary>
	///The number of data points the API key and account combination is allowed to fetch in any given allowance period
	///</Summary>
	public int totalAllowance { get; set; }
	///<Summary>
	///The number of seconds till the current allowance period will end and the remaining allowance field is reset
	///</Summary>
	public int allowanceExpiry { get; set; }
}
}
