using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountactivity.transaction
{

public class TransactionHistoryResponse{
	///<Summary>
	///List of transactions
	///</Summary>
	public List<Transaction> transactions { get; set; }
}
}
