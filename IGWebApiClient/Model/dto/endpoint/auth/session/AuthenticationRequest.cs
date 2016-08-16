using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.auth.session
{

public class AuthenticationRequest{
	///<Summary>
	///Client login identifier
	///</Summary>
	public string identifier { get; set; }
	///<Summary>
	///Client login password
	///</Summary>
	public string password { get; set; }
}
}
