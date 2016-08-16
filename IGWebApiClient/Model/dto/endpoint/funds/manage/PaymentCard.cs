using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.funds.manage
{

public class PaymentCard{
	///<Summary>
	///Card identifier
	///</Summary>
	public string id { get; set; }
	///<Summary>
	///Card type
	///</Summary>
	public string cardType { get; set; }
	///<Summary>
	///Last four digits of the card number
	///</Summary>
	public string presentationNumber { get; set; }
	///<Summary>
	///Cardholder name.
	///</Summary>
	public string holderName { get; set; }
	///<Summary>
	///Start date of the card in the format of mm/yy (may be null)
	///</Summary>
	public string startDate { get; set; }
	///<Summary>
	///Expiry date of the card in the format of mm/yy
	///</Summary>
	public string expiryDate { get; set; }
	///<Summary>
	///Currency
	///</Summary>
	public string currencyCode { get; set; }
	///<Summary>
	///Issue number of the card (may be null)
	///</Summary>
	public string issueNumber { get; set; }
	///<Summary>
	///</Summary>
	public bool fundsReceived { get; set; }
	///<Summary>
	///Minimum amount in the card currency which can be deposited to this card
	///</Summary>
	public decimal minimumAmountDeposit { get; set; }
	///<Summary>
	///Maximum amount in the card currency which can be deposited to this card
	///</Summary>
	public decimal maximumAmountDeposit { get; set; }
}
}
