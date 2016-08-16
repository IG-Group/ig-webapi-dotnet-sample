using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.browse.sprintmarkets
{

public class SprintMarketsListItem{
	///<Summary>
	///The epic of the instrument
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///The name to show to the dealer
	///</Summary>
	public string displayName { get; set; }
	///<Summary>
	///Market status
	///</Summary>
	public string marketStatus { get; set; }
}
}
