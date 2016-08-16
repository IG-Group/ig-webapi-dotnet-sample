using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.marketdetails.v2
{

public class DealingRulesData{
	///<Summary>
	///Minimum step distance
	///</Summary>
	public DealingRuleData minStepDistance { get; set; }
	///<Summary>
	///Minimum deal size
	///</Summary>
	public DealingRuleData minDealSize { get; set; }
	///<Summary>
	///Minimum controlled risk stop distance
	///</Summary>
	public DealingRuleData minControlledRiskStopDistance { get; set; }
	///<Summary>
	///Minimum stop or limit distance
	///</Summary>
	public DealingRuleData minNormalStopOrLimitDistance { get; set; }
	///<Summary>
	///Maximum stop or limit distance
	///</Summary>
	public DealingRuleData maxStopOrLimitDistance { get; set; }
	///<Summary>
	///The client's market order preference for creating or closing positions.
	///This should be ignored when editing positions and when creating, editing and deleting working orders.
	///</Summary>
	public string marketOrderPreference { get; set; }
	///<Summary>
	///determines whether the user is allowed to set trailing stops for this particular market
	///</Summary>
	public string trailingStopsPreference { get; set; }
}
}
