using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage.transfer
{

public class TransferFundsRequest{
	///<Summary>
	///Target account identifier
	///</Summary>
	public string toAccountId { get; set; }
	///<Summary>
	///Source account identifier
	///</Summary>
	public string fromAccountId { get; set; }
	///<Summary>
	///Transfer amount
	///</Summary>
	public decimal amount { get; set; }
}
}
