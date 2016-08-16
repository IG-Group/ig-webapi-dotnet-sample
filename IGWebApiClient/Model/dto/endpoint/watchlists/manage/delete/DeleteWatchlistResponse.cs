using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.manage.delete
{

public class DeleteWatchlistResponse{
	public enum Status {

      	///<Summary>
	///Success
	///</Summary>

      SUCCESS,}
	///<Summary>
	///Status
	///</Summary>
	public string status { get; set; }
}
}
