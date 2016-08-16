using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class InstrumentData{
	///<Summary>
	///Instrument identifier
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Expiry
	///</Summary>
	public string expiry { get; set; }
	///<Summary>
	///Name
	///</Summary>
	public string name { get; set; }
	///<Summary>
	///True if force open is allowed
	///</Summary>
	public bool forceOpenAllowed { get; set; }
	///<Summary>
	///True if stops and limits are allowed
	///</Summary>
	public bool stopsLimitsAllowed { get; set; }
	///<Summary>
	///Lot size
	///</Summary>
	public decimal? lotSize { get; set; }
	///<Summary>
	///Unit
	///</Summary>
	public string unit { get; set; }
	///<Summary>
	///Type
	///</Summary>
	public string type { get; set; }
	///<Summary>
	///True if controlled risk trades are allowed
	///</Summary>
	public bool controlledRiskAllowed { get; set; }
	///<Summary>
	///True if streaming prices are available, i.e. the market is open and the client has appropriate permissions
	///</Summary>
	public bool streamingPricesAvailable { get; set; }
	///<Summary>
	///Market identifier
	///</Summary>
	public string marketId { get; set; }
	///<Summary>
	///Available currencies
	///</Summary>
	public List<CurrencyData> currencies { get; set; }
	///<Summary>
	///For sprint markets only, the minimum value to be specified as the expiry of a sprint markets trade
	///</Summary>
	public int sprintMarketsMinimumExpiryTime { get; set; }
	///<Summary>
	///For sprint markets only, the maximum value to be specified as the expiry of a sprint markets trade
	///</Summary>
	public int sprintMarketsMaximumExpiryTime { get; set; }
	///<Summary>
	///Margin deposit requirement bands
	///</Summary>
	public List<DepositBand> marginDepositBands { get; set; }
	///<Summary>
	///margin requirement factor
	///</Summary>
	public decimal? marginFactor { get; set; }
	///<Summary>
	///size unit for the margin requirements
	///</Summary>
	public string marginFactorUnit { get; set; }
	///<Summary>
	///Slippage factor
	///</Summary>
	public SlippageFactorData slippageFactor { get; set; }
	///<Summary>
	///Opening hours
	///</Summary>
	public OpeningHours openingHours { get; set; }
	///<Summary>
	///Expiry details
	///</Summary>
	public MarketExpiryData expiryDetails { get; set; }
	///<Summary>
	///Rollover details
	///</Summary>
	public MarketRolloverData rolloverDetails { get; set; }
	///<Summary>
	///Reuters news code
	///</Summary>
	public string newsCode { get; set; }
	///<Summary>
	///Chart code
	///</Summary>
	public string chartCode { get; set; }
	///<Summary>
	///Country
	///</Summary>
	public string country { get; set; }
	///<Summary>
	///Value of one pip
	///</Summary>
	public string valueOfOnePip { get; set; }
	///<Summary>
	///Meaning of one pip
	///</Summary>
	public string onePipMeans { get; set; }
	///<Summary>
	///Contract size
	///</Summary>
	public string contractSize { get; set; }
	///<Summary>
	///List of special information notices
	///</Summary>
	public List<string> specialInfo { get; set; }
}
}
