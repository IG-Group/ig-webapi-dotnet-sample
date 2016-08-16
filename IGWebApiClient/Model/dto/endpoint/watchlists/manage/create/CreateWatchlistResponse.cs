using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.watchlists.manage.create
{

public class CreateWatchlistResponse{
	public enum Status {

      	///<Summary>
	///Success
	///</Summary>

      SUCCESS,
      	///<Summary>
	///Partially successful
	///</Summary>

      SUCCESS_NOT_ALL_INSTRUMENTS_ADDED,}
	///<Summary>
	///Identifier of the watchlist just created, if successful
	///</Summary>
	public string watchlistId { get; set; }
	///<Summary>
	///Result status of the watchlist creation request
	///</Summary>
	public string status { get; set; }
}
}
