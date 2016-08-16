using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountbalance
{

public class AccountBalance{
	///<Summary>
	///Balance of funds in the account
	///</Summary>
	public decimal? balance { get; set; }
	///<Summary>
	///Minimum deposit amount required for margins
	///</Summary>
	public decimal? deposit { get; set; }
	///<Summary>
	///Profit and loss amount
	///</Summary>
	public decimal? profitLoss { get; set; }
	///<Summary>
	///Amount available for trading
	///</Summary>
	public decimal? available { get; set; }
}
}
