using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.deposit.surcharge
{

public class SurchargeRequest{
	///<Summary>
	///Card identifier
	///</Summary>
	public string cardId { get; set; }
	///<Summary>
	///Amount
	///</Summary>
	public decimal amount { get; set; }
	///<Summary>
	///Currency
	///</Summary>
	public string currencyCode { get; set; }
}
}
