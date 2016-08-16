using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage.type
{

public class AddEditCardResponse{
	public enum Status {

      	///<Summary>
	///Success
	///</Summary>

      SUCCESS,
      	///<Summary>
	///Invalid card details
	///</Summary>

      DETAILS_INVALID,
      	///<Summary>
	///Card not supported
	///</Summary>

      CARD_NOT_SUPPORTED,
      	///<Summary>
	///Account cannot add card
	///</Summary>

      ACCOUNT_CANNOT_ADD_CARD,
      	///<Summary>
	///Card number limit reached
	///</Summary>

      CARD_NUMBER_LIMIT_REACHED,
      	///<Summary>
	///General failure
	///</Summary>

      FAILURE,}
	///<Summary>
	///Status
	///</Summary>
	public string status { get; set; }
}
}
