using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.workingorders.edit.v2
{

public class EditWorkingOrderRequest{
	///<Summary>
	///Time in force type
	///</Summary>
	public string timeInForce { get; set; }
	///<Summary>
	///Good till date - format is yyyy/mm/dd hh:mm:ss
	///</Summary>
	public string goodTillDate { get; set; }
	///<Summary>
	///Stop distance
	///</Summary>
	public decimal? stopDistance { get; set; }
	///<Summary>
	///Limit distance
	///</Summary>
	public decimal? limitDistance { get; set; }
	///<Summary>
	///Deal type
	///</Summary>
	public string type { get; set; }
	///<Summary>
	///Limit level
	///</Summary>
	public decimal? level { get; set; }
}
}
