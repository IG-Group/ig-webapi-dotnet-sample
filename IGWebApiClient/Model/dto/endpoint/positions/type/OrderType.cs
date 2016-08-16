using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.type
{

	public enum OrderType {


   	///<Summary>
	///Quote orders get executed at the specified level.
	///The level has to be accompanied by a valid quote id. This type is only available subject to agreement with IG.
	///</Summary>

   QUOTE,

   	///<Summary>
	///Market orders get executed at the price seen by the IG at the time of booking the trade.
	///A level cannot be specified. Not applicable to BINARY instruments
	///</Summary>

   MARKET,

   	///<Summary>
	///Fill or Kill Limit order, i.e. a market order where the limit determines the price at which to kill the order
	///</Summary>

   LIMIT,}

}
