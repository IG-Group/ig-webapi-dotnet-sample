using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.positions.close.v1
{

public class ClosePositionRequest{
	///<Summary>
	///Deal identifier
	///</Summary>
	public string dealId { get; set; }
	///<Summary>
	///Instrument epic identifier
	///</Summary>
	public string epic { get; set; }
	///<Summary>
	///Instrument expiry
	///</Summary>
	public string expiry { get; set; }
	///<Summary>
	///Deal direction
	///</Summary>
	public string direction { get; set; }
	///<Summary>
	///Deal size
	///</Summary>
	public decimal? size { get; set; }
	///<Summary>
	///Closing deal level
	///</Summary>
	public decimal? level { get; set; }
	///<Summary>
	///Order type
	///</Summary>
	public string orderType { get; set; }
	///<Summary>
        ///Time in force
        ///</Summary>
        public string timeInForce { get; set; }
	///<Summary>
	///Lightstreamer price quote identifier
	///</Summary>
	public string quoteId { get; set; }
}
}
