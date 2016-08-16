using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.auth.silentlogin
{

public class SilentLoginResponse{
	///<Summary>
	///Account type
	///</Summary>
	public string accountType { get; set; }
	///<Summary>
	///Active account summary
	///</Summary>
	public AccountInfo accountInfo { get; set; }
	///<Summary>
	///Account currency
	///</Summary>
	public string currencyIsoCode { get; set; }
	///<Summary>
	///Active account identifier
	///</Summary>
	public string currentAccountId { get; set; }
	///<Summary>
	///Whether the Client has active demo accounts.
	///</Summary>
	public bool hasActiveDemoAccounts { get; set; }
	///<Summary>
	///Whether the Client has active live accounts.
	///</Summary>
	public bool hasActiveLiveAccounts { get; set; }
	///<Summary>
	///Lightstreamer endpoint for subscribing to account and price updates
	///</Summary>
	public string lightstreamerEndpoint { get; set; }
	///<Summary>
	///Client account summaries
	///</Summary>
	public List<AccountDetails> accounts { get; set; }
	///<Summary>
	///Client identifier
	///</Summary>
	public string clientId { get; set; }
}
}
