using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.withdraw
{

public class WithdrawResponse{
	public enum Status {

      	///<Summary>
	///Success
	///</Summary>

      SUCCESS,
      	///<Summary>
	///Pending manual authorisation
	///</Summary>

      PENDING,
      	///<Summary>
	///Failure
	///</Summary>

      FAILURE,}
	///<Summary>
	///Status
	///</Summary>
	public string status { get; set; }
}
}
