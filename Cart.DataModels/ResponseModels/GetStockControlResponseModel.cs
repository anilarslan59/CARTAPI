using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.DataModels.ResponseModels
{
    public class GetStockControlResponseModel
    {
        public string ResponseCode { get; set; }
        public int ResponseQuantity { get; set; }
    }
}
