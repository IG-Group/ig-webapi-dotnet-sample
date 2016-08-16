using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.retrieve
{

public class ListOfWatchlistsResponse{
	///<Summary>
	///List of watchlists
	///</Summary>
	public List<Watchlist> watchlists { get; set; }
}
}
