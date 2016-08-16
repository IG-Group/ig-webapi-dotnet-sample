using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.deposit
{

public class DepositRequest{
	///<Summary>
	///Source card identifier
	///</Summary>
	public string cardId { get; set; }
	///<Summary>
	///Card cw2 number
	///</Summary>
	public string cvv2 { get; set; }
	///<Summary>
	///Client password
	///</Summary>
	public char[] password { get; set; }
	///<Summary>
	///Deposit amount
	///</Summary>
	public decimal amount { get; set; }
}
}
