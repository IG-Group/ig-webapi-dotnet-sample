using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage.edit
{

public class EditCardRequest{
	///<Summary>
	///Start date
	///todo should not be required to be notnull
	///</Summary>
	public string startDate { get; set; }
	///<Summary>
	///Expiry date
	///</Summary>
	public string expiryDate { get; set; }
}
}
