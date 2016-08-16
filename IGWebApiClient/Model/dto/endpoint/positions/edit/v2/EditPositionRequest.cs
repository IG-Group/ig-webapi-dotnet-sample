using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.edit.v2
{

public class EditPositionRequest{
	///<Summary>
	///Stop level
	///</Summary>
	public decimal? stopLevel { get; set; }
	///<Summary>
	///Limit level
	///</Summary>
	public decimal? limitLevel { get; set; }
	///<Summary>
	///Trailing stop
	///</Summary>
	public bool trailingStop { get; set; }
	///<Summary>
	///Trailing stop distance
	///</Summary>
	public decimal? trailingStopDistance { get; set; }
	///<Summary>
	///Trailing stop step increment
	///</Summary>
	public decimal? trailingStopIncrement { get; set; }
}
}
