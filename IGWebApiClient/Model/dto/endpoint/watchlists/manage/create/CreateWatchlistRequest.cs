using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.manage.create
{

public class CreateWatchlistRequest{
	///<Summary>
	///Watchlist name
	///</Summary>
	public string name { get; set; }
	///<Summary>
	///List of market epics to be associated to this new watchlist
	///</Summary>
	public List<string> epics { get; set; }
}
}
