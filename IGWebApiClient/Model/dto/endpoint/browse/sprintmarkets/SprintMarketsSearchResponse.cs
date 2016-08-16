using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.browse.sprintmarkets
{

public class SprintMarketsSearchResponse{
	///<Summary>
	///The list of fast markets.
	///</Summary>
	public List<SprintMarketsListItem> sprintMarkets { get; set; }
}
}
