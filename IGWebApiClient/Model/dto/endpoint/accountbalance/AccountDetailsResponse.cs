using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountbalance
{

public class AccountDetailsResponse{
	///<Summary>
	///List of client accounts
	///</Summary>
	public List<AccountDetails> accounts { get; set; }
}
}
