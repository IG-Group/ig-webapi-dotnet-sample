using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.edit.v1
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
}
}
