using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.application.operation
{

public class DeveloperUpdateApplicationRequest{
	///<Summary>
	///The API key of the application to edit
	///</Summary>
	public string apiKey { get; set; }
	///<Summary>
	///The new status for this application
	///</Summary>
	public string status { get; set; }
	///<Summary>
	///Maximum number of trading operations per minute for a given account using this application
	///</Summary>
	public int allowanceAccountTrading { get; set; }
	///<Summary>
	///Maximum number of restful invocations per minute for a given account using this application
	///</Summary>
	public int allowanceAccountOverall { get; set; }
}
}
