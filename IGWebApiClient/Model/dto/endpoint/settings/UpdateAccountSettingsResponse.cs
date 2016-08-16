using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.settings
{

public class UpdateAccountSettingsResponse{
	public enum UpdateStatus {

      SUCCESS,}
	///<Summary>
	///Indicates if the request was successful.
	///</Summary>
	public string status { get; set; }
}
}
