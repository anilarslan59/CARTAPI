using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.DataModels.RequestModels
{
    public class GetStockControlRequestModel
    {
        public string CompanyCode { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
    }
}
