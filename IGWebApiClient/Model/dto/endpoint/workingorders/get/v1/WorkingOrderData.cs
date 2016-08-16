using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.workingorders.get.v1
{

public class WorkingOrderData{
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Deal direction
	///</Summary>
	public string direction { get; set; }
	///<Summary>
	///Instrument epic identifier
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Order size
	///</Summary>
	public decimal? size { get; set; }
	///<Summary>
	///Price at which to execute the trade
	///</Summary>
	public decimal? level { get; set; }
	///<Summary>
	///Working order expiry date and time. If set, format is dd/MM/yy HH:mm
	///</Summary>
	public string goodTill { get; set; }
	///<Summary>
	///Date and time when the order was created. Format is yyyy/MM/dd kk:mm:ss:SSS
	///</Summary>
	public string createdDate { get; set; }
	///<Summary>
	///True if controlled risk
	///</Summary>
	public bool controlledRisk { get; set; }
	///<Summary>
	///Trailing trigger increment
	///</Summary>
	public decimal? trailingTriggerIncrement { get; set; }
	///<Summary>
	///Trailing stop distance
	///</Summary>
	public decimal? trailingTriggerDistance { get; set; }
	///<Summary>
	///Trailing stop distance
	///</Summary>
	public decimal? trailingStopDistance { get; set; }
	///<Summary>
	///Trailing stop increment
	///</Summary>
	public decimal? trailingStopIncrement { get; set; }
	///<Summary>
	///Request type
	///</Summary>
	public string requestType { get; set; }
	///<Summary>
	///Stop level
	///</Summary>
	public decimal? contingentStop { get; set; }
	///<Summary>
	///Currency ISO code
	///</Summary>
	public string currencyCode { get; set; }
	///<Summary>
	///Limit level
	///</Summary>
	public decimal? contingentLimit { get; set; }
	///<Summary>
	///True if this is a DMA working order
	///</Summary>
	public bool dma { get; set; }
}
}
