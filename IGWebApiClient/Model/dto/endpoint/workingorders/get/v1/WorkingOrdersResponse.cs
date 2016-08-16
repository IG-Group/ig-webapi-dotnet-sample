using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.workingorders.get.v1
{

public class WorkingOrdersResponse{
	///<Summary>
	///List of working orders
	///</Summary>
	public List<WorkingOrder> workingOrders { get; set; }
}
}
