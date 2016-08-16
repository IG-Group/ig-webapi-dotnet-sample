using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

	public enum TrailingStopsPreference {


   	///<Summary>
	///Trailing stops are not allowed for the current user and/or market
	///</Summary>

   NOT_AVAILABLE,

   	///<Summary>
	///Trailing stops are allowed for the current user and/or market
	///</Summary>

   AVAILABLE,}

}
