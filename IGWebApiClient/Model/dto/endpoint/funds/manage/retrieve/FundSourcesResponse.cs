using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage.retrieve
{

public class FundSourcesResponse{
	///<Summary>
	///List of payment cards
	///</Summary>
	public List<PaymentCard> paymentCards { get; set; }
	///<Summary>
	///Maximum number of payment cards
	///todo need this?
	///</Summary>
	public int maxNumberOfPaymentCards { get; set; }
	///<Summary>
	///List of available currencies
	///</Summary>
	public List<string> availableCurrencies { get; set; }
}
}
