using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.settings
{

public class AccountSettingsResponse{
	///<Summary>
	///Trailing stops: whether the user wants to be allowed to define trailing stop rules for his trade operations
	///</Summary>
	public bool trailingStopsEnabled { get; set; }
}
}
