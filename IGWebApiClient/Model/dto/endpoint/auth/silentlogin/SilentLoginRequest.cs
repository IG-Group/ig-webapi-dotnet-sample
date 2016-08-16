using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.auth.silentlogin
{

public class SilentLoginRequest{
	///<Summary>
	///Whether this is a newly created client logging into demo for the very first time after account creation.
	///</Summary>
	public bool firstTimeDemoLogin { get; set; }
}
}
