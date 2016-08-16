using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountactivity.activity
{

public class Activity{
	///<Summary>
	///Instrument epic identifier
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Activity history identifier
	///</Summary>
	public string activityHistoryId { get; set; }
	///<Summary>
	///The date of the activity item in format DD/MM/YY for en_GB locale
	///</Summary>
	public string date { get; set; }
	///<Summary>
	///The time that the activity item occurred, in format hh:mm
	///</Summary>
	public string time { get; set; }
	///<Summary>
	///The high-level activity description, e.g. "Order"
	///</Summary>
	public string activity { get; set; }
	///<Summary>
	///The market name of the activity item, e.g. "FTSE 100"
	///This will be much longer for a sprint market, e.g. "FTSE 100 to be below 6598.4 at 12:42:05 on 13/08/13"
	///</Summary>
	public string marketName { get; set; }
	///<Summary>
	///The period of the activity item, e.g. "DFB" or "02-SEP-11".
	///This will be the expiry time/date for sprint markets, e.g. "13/08/13 12:42:05"
	///</Summary>
	public string period { get; set; }
	///<Summary>
	///The description of the result of the activity, e.g. "Guaranteed Position opened: KYG46BAQ"
	///</Summary>
	public string result { get; set; }
	///<Summary>
	///The channel the activity occurred on, e.g. "WEB" or "Mobile"
	///</Summary>
	public string channel { get; set; }
	///<Summary>
	///The currency, e.g. a pound symbol.
	///</Summary>
	public string currency { get; set; }
	///<Summary>
	///The size of the activity item, e.g. "+1" OR "-3.85".
	///There will be no direction symbol if the activity is for a sprint market
	///</Summary>
	public string size { get; set; }
	///<Summary>
	///The market level that the activity item occurred at, e.g. "5253.5"
	///</Summary>
	public string level { get; set; }
	///<Summary>
	///The stop level of the activity item, if any, e.g. "5233.5" or "-"
	///</Summary>
	public string stop { get; set; }
	///<Summary>
	///The type of stop if applicable to the activity item, either "G" for guaranteed stop, or "N" for
	///non-guaranteed stop, or T(50) for a trailing stop of step size 50
	///</Summary>
	public string stopType { get; set; }
	///<Summary>
	///The limit level of the activity item if any, e.g. "5233.5" or "-"
	///</Summary>
	public string limit { get; set; }
	///<Summary>
	///The action status of the activity item. The value of the action status can be any one of these.
	///"ACCEPT"  - Manual accept or auto accept.
	///"REJECT"  - Manual reject or declined.
	///"MANUAL"  - Gone manual and in pending. Cannot determine if accepted or rejected.
	///"NOT_SET" - Default value which should have been overwritten by more specific status. Possibly caused by an error in processing by order server.
	///</Summary>
	public string actionStatus { get; set; }
}
}
