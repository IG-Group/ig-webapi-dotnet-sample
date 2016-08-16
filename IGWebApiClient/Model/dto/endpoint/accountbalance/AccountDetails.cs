using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.accountbalance
{

public class AccountDetails{
	public enum AccountStatus {

      	///<Summary>
	///Enabled
	///</Summary>

      ENABLED,
      	///<Summary>
	///Disabled
	///</Summary>

      DISABLED,
      	///<Summary>
	///Suspended from dealing
	///</Summary>

      SUSPENDED_FROM_DEALING,}
	public enum AccountType {

      	///<Summary>
	///CFD account
	///</Summary>

      CFD,
      	///<Summary>
	///Spread bet account
	///</Summary>

      SPREADBET,
      	///<Summary>
	///Physical account
	///</Summary>

      PHYSICAL,}
	///<Summary>
	///Account identifier
	///</Summary>
	public string accountId { get; set; }
	///<Summary>
	///Account name
	///</Summary>
	public string accountName { get; set; }
	///<Summary>
	///Account alias
	///</Summary>
	public string accountAlias { get; set; }
	///<Summary>
	///Account status
	///</Summary>
	public string status { get; set; }
	///<Summary>
	///Account type
	///</Summary>
	public string accountType { get; set; }
	///<Summary>
	///True if this the default login account
	///</Summary>
	public bool preferred { get; set; }
	///<Summary>
	///Account balances
	///</Summary>
	public AccountBalance balance { get; set; }
	///<Summary>
	///Account currency
	///</Summary>
	public string currency { get; set; }
	///<Summary>
	///True if account can be transferred to
	///</Summary>
	public bool canTransferFrom { get; set; }
	///<Summary>
	///True if account can be transferred from
	///</Summary>
	public bool canTransferTo { get; set; }
}
}
