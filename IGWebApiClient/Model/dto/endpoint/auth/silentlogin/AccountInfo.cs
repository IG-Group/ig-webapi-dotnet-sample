using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.auth.silentlogin
{

public class AccountInfo{
	///<Summary>
	///Balance of funds in the account
	///</Summary>
	public decimal? balance { get; set; }
	///<Summary>
	///Minimum deposit amount required for margins
	///</Summary>
	public decimal? deposit { get; set; }
	///<Summary>
	///Account profit and loss amount
	///</Summary>
	public decimal? profitLoss { get; set; }
	///<Summary>
	///Account funds available for trading amount
	///</Summary>
	public decimal? available { get; set; }
}
}
