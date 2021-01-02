using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.DataModels.DwhEntities
{
    public class CartModel : BaseDwhModel
    {
        public List<AddCartRequestModel> ItemList { get; set; }
        public string UserName { get; set; }
    }

    public class AddCartRequestModel
    {
        public string CompanyCode { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
    }
}
