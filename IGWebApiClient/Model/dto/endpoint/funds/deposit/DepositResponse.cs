using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.deposit
{

public class DepositResponse{
	public enum Status {

      	///<Summary>
	///Success
	///</Summary>

      SUCCESS,
      	///<Summary>
	///Failure
	///</Summary>

      FAILURE,}
	///<Summary>
	///Issuer's access control server URL
	///todo exapand
	///</Summary>
	public string url { get; set; }
	///<Summary>
	///Merchant-specific data
	///todo example
	///</Summary>
	public string merchantSpecificData { get; set; }
	///<Summary>
	///URL-encoded PaymentAuthRequestMessage
	///todo expand
	///</Summary>
	public string pares { get; set; }
	///<Summary>
	///Status
	///</Summary>
	public string status { get; set; }
}
}
