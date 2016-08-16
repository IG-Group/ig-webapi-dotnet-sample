using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountactivity.transaction
{

public class Transaction{
	///<Summary>
	///Transaction date, format dd-MMM-yyyy
	///</Summary>
	public string date { get; set; }
	///<Summary>
	///Instrument name
	///</Summary>
	public string instrumentName { get; set; }
	///<Summary>
	///Period in milliseconds
	///</Summary>
	public string period { get; set; }
	///<Summary>
	///Profit and loss
	///</Summary>
	public string profitAndLoss { get; set; }
	///<Summary>
	///Transaction type
	///</Summary>
	public string transactionType { get; set; }
	///<Summary>
	///Reference
	///</Summary>
	public string reference { get; set; }
	///<Summary>
	///Level at which the order was opened
	///</Summary>
	public string openLevel { get; set; }
	///<Summary>
	///Level at which the order was closed
	///</Summary>
	public string closeLevel { get; set; }
	///<Summary>
	///Formatted order size, including the direction (+ for buy, - for sell)
	///</Summary>
	public string size { get; set; }
	///<Summary>
	///Order currency
	///</Summary>
	public string currency { get; set; }
	///<Summary>
	///True if this was a cash transaction
	///</Summary>
	public bool cashTransaction { get; set; }
}
}
