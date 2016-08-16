using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.settings
{

public class UpdateAccountServiceRequest{
	///<Summary>
	///New trailing stop preference.
	///</Summary>
	public bool trailingStopsEnabled { get; set; }
}
}
