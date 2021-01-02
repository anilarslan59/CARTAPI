using Cart.DataModels.RequestModels;
using Cart.DataModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Modules.In.Contracts
{
    public interface ICartWorkflow
    {
        AddCartResponseModel Add(AddCartListRequestModel model);
    }
}
