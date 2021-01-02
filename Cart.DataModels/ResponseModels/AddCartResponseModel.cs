using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.DataModels.ResponseModels
{
    public class AddCartResponseModel
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
