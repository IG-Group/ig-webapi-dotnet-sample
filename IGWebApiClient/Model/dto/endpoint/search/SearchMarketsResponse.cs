using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.search
{

public class SearchMarketsResponse{
	///<Summary>
	///List of markets
	///</Summary>
	public List<Market> markets { get; set; }
}
}
