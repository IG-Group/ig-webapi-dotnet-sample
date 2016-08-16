using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.get.otc.v1
{

public class PositionsResponse{
	///<Summary>
	///List of positions
	///</Summary>
	public List<OpenPosition> positions { get; set; }
}
}
