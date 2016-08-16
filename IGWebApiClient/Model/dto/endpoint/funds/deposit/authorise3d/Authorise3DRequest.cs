using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.deposit.authorise3d
{

public class Authorise3DRequest{
	///<Summary>
	///Payment Authentication Response string
	///todo expand
	///</Summary>
	public string pares { get; set; }
	///<Summary>
	///Comma separated merchant specific details, such as: merchantReference,cardScheme,siteId
	///todo example
	///</Summary>
	public string merchantSpecificData { get; set; }
}
}
