using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.confirms
{

public class AffectedDeal{
	public enum Status {

      	///<Summary>
	///Opened
	///</Summary>

      OPENED,
      	///<Summary>
	///Amended
	///</Summary>

      AMENDED,
      	///<Summary>
	///Partially closed
	///</Summary>

      PARTIALLY_CLOSED,
      	///<Summary>
	///Fully closed
	///</Summary>

      FULLY_CLOSED,
      	///<Summary>
	///Deleted
	///</Summary>

      DELETED,}
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Deal status
	///</Summary>
	public string status { get; set; }
}
}
