using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.confirms
{

	public enum Reason {


   	///<Summary>
	///an error has occurred but no detailed information is available.
	///Check transaction history or contact support for further information
	///</Summary>

   GENERAL_ERROR,

   	///<Summary>
	///The operation completed successfully
	///</Summary>

   SUCCESS,

   	///<Summary>
	///The requested market was not found
	///</Summary>

   INSTRUMENT_NOT_FOUND,

   	///<Summary>
	///The requested operation has been attempted on the wrong direction
	///</Summary>

   WRONG_SIDE_OF_MARKET,

   	///<Summary>
	///The market is currently closed
	///</Summary>

   MARKET_CLOSED,

   	///<Summary>
	///The market is currently offline
	///</Summary>

   MARKET_OFFLINE,

   	///<Summary>
	///The order has been rejected as it is a duplicate of a previously issued order
	///</Summary>

   DUPLICATE_ORDER_ERROR,

   	///<Summary>
	///The market is currently closed with edits
	///</Summary>

   MARKET_CLOSED_WITH_EDITS,

   	///<Summary>
	///The market can only be traded over the phone
	///</Summary>

   MARKET_PHONE_ONLY,

   	///<Summary>
	///The market has been rolled to the next period
	///</Summary>

   MARKET_ROLLED,

   	///<Summary>
	///The order has not been found
	///</Summary>

   ORDER_NOT_FOUND,

   	///<Summary>
	///The order requires a stop
	///</Summary>

   STOP_REQUIRED_ERROR,

   	///<Summary>
	///The order size is too small
	///</Summary>

   MINIMUM_ORDER_SIZE_ERROR,

   	///<Summary>
	///The market level has moved and has been rejected
	///</Summary>

   LEVEL_TOLERANCE_ERROR,

   	///<Summary>
	///The account has not enough funds available for the requested trade
	///</Summary>

   INSUFFICIENT_FUNDS,

   	///<Summary>
	///The market does not allow opening shorting positions
	///</Summary>

   MARKET_NOT_BORROWABLE,

   	///<Summary>
	///The level of the attached stop or limit is not valid
	///</Summary>

   ATTACHED_ORDER_LEVEL_ERROR,

   	///<Summary>
	///The trailing stop value is invalid
	///</Summary>

   ATTACHED_ORDER_TRAILING_STOP_ERROR,

   	///<Summary>
	///The order is locked and cannot be edited by the user
	///</Summary>

   ORDER_LOCKED,

   	///<Summary>
	///The manual order timeout limit has been reached
	///</Summary>

   MANUAL_ORDER_TIMEOUT,

   	///<Summary>
	///The submitted strike level is invalid
	///</Summary>

   STRIKE_LEVEL_TOLERANCE,

   	///<Summary>
	///The market does not allow stop or limit attached orders
	///</Summary>

   STOP_OR_LIMIT_NOT_ALLOWED,

   	///<Summary>
	///Ivalid attempt to submit a spreadbet trade on a CFD account
	///</Summary>

   REJECT_SPREADBET_ORDER_ON_CFD_ACCOUNT,

   	///<Summary>
	///The market or the account do not allow for trailing stops
	///</Summary>

   TRAILING_STOP_NOT_ALLOWED,

   	///<Summary>
	///Ability to force open in different currencies on same market not allowed
	///</Summary>

   FORCE_OPEN_ON_SAME_MARKET_DIFFERENT_CURRENCY,

   	///<Summary>
	///Opening CR position in opposite direction to existing CR position not allowed.
	///</Summary>

   OPPOSING_DIRECTION_ORDERS_NOT_ALLOWED,

   	///<Summary>
	///The position has not been found
	///</Summary>

   POSITION_NOT_FOUND,

   	///<Summary>
	///The epic is due to expire shortly, client should deal in the next available contract.
	///</Summary>

   MARKET_CLOSING,

   	///<Summary>
	///The working order has been set to expire on a past date
	///</Summary>

   GOOD_TILL_DATE_IN_THE_PAST,

   	///<Summary>
	///The account is not enabled to trade
	///</Summary>

   ACCOUNT_NOT_ENABLED_TO_TRADING,

   	///<Summary>
	///The expiry of the position would have fallen after the closing time of the market
	///</Summary>

   SPRINT_MARKET_EXPIRY_AFTER_MARKET_CLOSE,

   	///<Summary>
	///The requested market is not allowed to this account
	///</Summary>

   MARKET_UNAVAILABLE_TO_CLIENT,

   	///<Summary>
	///The operation resulted in an unknown result condition.
	///Check transaction history or contact support for further information
	///</Summary>

   UNKNOWN,}

}
