using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountactivity.activity
{

public class ActivityHistoryResponse{
	///<Summary>
	///List of activities
	///</Summary>
	public List<Activity> activities { get; set; }
}
}
