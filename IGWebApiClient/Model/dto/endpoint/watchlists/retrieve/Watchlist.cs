using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.retrieve
{

public class Watchlist{
	///<Summary>
	///Watchlist indentifier
	///</Summary>
	public string id { get; set; }
	///<Summary>
	///Watchlist name
	///</Summary>
	public string name { get; set; }
	///<Summary>
	///True if this watchlist can be altered by the user
	///</Summary>
	public bool editable { get; set; }
	///<Summary>
	///True if this watchlist can be deleted by the user
	///</Summary>
	public bool deleteable { get; set; }
	///<Summary>
	///True if this watchlist doesn't belong to the user, but rather is a system
	///predefined one
	///</Summary>
	public bool defaultSystemWatchlist { get; set; }
}
}
