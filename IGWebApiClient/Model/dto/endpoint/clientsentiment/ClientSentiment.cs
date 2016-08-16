using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.clientsentiment
{

public class ClientSentiment{
	///<Summary>
	///Market identifier
	///</Summary>
	public string marketId { get; set; }
	///<Summary>
	///Percentage long positions
	///</Summary>
	public decimal? longPositionPercentage { get; set; }
	///<Summary>
	///Percentage short positions
	///</Summary>
	public decimal? shortPositionPercentage { get; set; }
}
}
