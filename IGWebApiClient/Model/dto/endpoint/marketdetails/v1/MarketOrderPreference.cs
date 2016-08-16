using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v1
{

	public enum MarketOrderPreference {


   	///<Summary>
	///Market orders are not allowed for the current site and/or instrument
	///</Summary>

   NOT_AVAILABLE,

   	///<Summary>
	///Market orders are allowed for the account type and instrument, and the user has enabled market orders in their preferences but decided the default state is off.
	///</Summary>

   AVAILABLE_DEFAULT_OFF,

   	///<Summary>
	///Market orders are allowed for the account type and instrument, and the user has enabled market orders in their preferences and has decided the default state is on.
	///</Summary>

   AVAILABLE_DEFAULT_ON,}

}
