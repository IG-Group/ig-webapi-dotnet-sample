using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.retrieve
{

public class WatchlistInstrumentsResponse{
	///<Summary>
	///List of watchlist markets
	///</Summary>
	public List<WatchlistMarket> markets { get; set; }
}
}
