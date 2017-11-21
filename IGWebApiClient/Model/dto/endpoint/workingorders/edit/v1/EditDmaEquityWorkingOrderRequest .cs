using System.Collections.Generic;
using dto.endpoint.auth.session;

namespace dto.endpoint.workingorders.edit.v1
{

public class EditDmaEquityWorkingOrderRequest{
        ///<Summary>
        ///Instrument epic
        ///</Summary>
        public string epic { get; set; }
        ///<Summary>
        ///Deal direction
        ///</Summary>
        public string direction { get; set; }
        ///<Summary>
        ///Order size
        ///</Summary>
        public decimal? size { get; set; }
        ///<Summary>
        ///Deal level
        ///</Summary>
        public decimal? level { get; set; }
        ///<Summary>
        ///Deal type
        ///</Summary>
        public string type { get; set; }
        ///<Summary>
        ///Time in force type
        ///</Summary>
        public string timeInForce { get; set; }
        ///<Summary>
        ///Stop level
        ///</Summary>
        public decimal? stopLevel { get; set; }
        ///<Summary>
        ///Limit level
        ///</Summary>
        public decimal? limitLevel { get; set; }
    }
}
