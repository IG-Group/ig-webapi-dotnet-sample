using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.get.otc.v1
{

public class OpenPositionData{
	///<Summary>
	///Size of the contract
	///</Summary>
	public decimal? contractSize { get; set; }
	///<Summary>
	///Date the position was opened
	///</Summary>
	public string createdDate { get; set; }
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Deal size
	///</Summary>
	public decimal? dealSize { get; set; }
	///<Summary>
	///Deal direction
	///</Summary>
	public string direction { get; set; }
	///<Summary>
	///Limit level
	///</Summary>
	public decimal? limitLevel { get; set; }
	///<Summary>
	///Level at which the position was opened
	///</Summary>
	public decimal? openLevel { get; set; }
	///<Summary>
	///Position currency ISO code
	///</Summary>
	public string currency { get; set; }
	///<Summary>
	///True if position is risk controlled
	///</Summary>
	public bool controlledRisk { get; set; }
	///<Summary>
	///Stop level
	///</Summary>
	public decimal? stopLevel { get; set; }
	///<Summary>
	///Trailing step size
	///</Summary>
	public decimal? trailingStep { get; set; }
	///<Summary>
	///Trailing stop distance
	///</Summary>
	public decimal? trailingStopDistance { get; set; }
}
}
