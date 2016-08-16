using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountswitch
{

public class AccountSwitchRequest{
	///<Summary>
	///The identifier of the account being switched to
	///</Summary>
	public string accountId { get; set; }
	///<Summary>
	///True if the specified account is to be set as the new default account.
	///Omitting this argument results in the default account not being changed
	///</Summary>
	public bool defaultAccount { get; set; }
}
}
