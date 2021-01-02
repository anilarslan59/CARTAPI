using Cart.DataModels.RequestModels;
using Cart.DataModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Datalibrary.CartManagement
{
    public interface ICartManagementUnitOfWork
    {
        AddCartResponseModel Add(AddCartListRequestModel model);
    }
}
