using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage.add
{

public class AddCardRequest{
	///<Summary>
	///Card number
	///</Summary>
	public string cardNumber { get; set; }
	///<Summary>
	///Cardholder name
	///</Summary>
	public string holderName { get; set; }
	///<Summary>
	///Start date
	///todo should not be required to be null
	///</Summary>
	public string startDate { get; set; }
	///<Summary>
	///Expiry date
	///</Summary>
	public string expiryDate { get; set; }
	///<Summary>
	///Currency
	///</Summary>
	public string currencyCode { get; set; }
}
}
