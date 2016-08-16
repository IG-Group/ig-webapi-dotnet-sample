using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountswitch
{

public class AccountSwitchResponse{
	///<Summary>
	///Whether the account is allowed to set trailing stops on his trades
	///</Summary>
	public bool trailingStopsEnabled { get; set; }
}
}
