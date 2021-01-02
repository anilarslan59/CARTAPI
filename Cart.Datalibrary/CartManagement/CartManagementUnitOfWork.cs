using Cart.Datalibrary.StockManagement;
using Cart.DataModels.RequestModels;
using Cart.DataModels.ResponseModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Datalibrary.CartManagement
{
    public class CartManagementUnitOfWork : ICartManagementUnitOfWork
    {

        private readonly IStockManagementUnitOfWork _stockManagementUnitOfWork;
        private CartDwhDataContext _dbContext;
        public CartManagementUnitOfWork(CartDwhDataContext cartDwhDataContext, IStockManagementUnitOfWork stockManagementUnitOfWork)
        {
            _dbContext = cartDwhDataContext;
            _stockManagementUnitOfWork = stockManagementUnitOfWork;
        }

        public AddCartResponseModel Add(AddCartListRequestModel model)
        {
            try
            {
                if(model.UserName == string.Empty)
                {
                    return new AddCartResponseModel
                    {
                        StatusCode = StatusCodes.Status200OK,
                        IsSuccess = false,
                        Message = "UserName Must Be Not NUll!"
                    };
                }
                var mongoDbModel = new DataModels.DwhEntities.CartModel
                {
                    ItemList = new List<DataModels.DwhEntities.AddCartRequestModel>(),
                    UserName = model.UserName
                };
                foreach (var i in model.ItemList)
                {
                    if(i.CompanyCode == string.Empty)
                    {
                        return new AddCartResponseModel
                        {
                            IsSuccess = false,
                            StatusCode = StatusCodes.Status200OK,
                            Message = "CompanyCode Must Be Not Null!"
                        };
                    }
                    if(i.ItemCode == string.Empty)
                    {
                        return new AddCartResponseModel
                        {
                            IsSuccess = false,
                            StatusCode = StatusCodes.Status200OK,
                            Message = "ItemCode Must Be Not Null!"
                        };
                    }
                    if (i.Quantity == 0)
                    {
                        return new AddCartResponseModel
                        {
                            IsSuccess = false,
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Quantity Must Be Greater Than Zero!"
                        };
                    }
                    if(i.ItemCode != string.Empty && i.Quantity > 0)
                    {
                        var stockControlReqModel = new GetStockControlRequestModel
                        {
                            CompanyCode = i.CompanyCode,
                            ItemCode = i.ItemCode,
                            Quantity = i.Quantity
                        };
                        var q = _stockManagementUnitOfWork.GetStock(stockControlReqModel);
                        if(q.ResponseCode == "ERROR")
                        {
                            return new AddCartResponseModel
                            {
                                StatusCode = StatusCodes.Status200OK,
                                IsSuccess = false,
                                Message = $" {i.ItemCode} Stock Not Found! Stock Quantity: {q.ResponseQuantity.ToString()} Cart Quantity: { i.Quantity.ToString()}"
                            };
                        }
                    }
                    mongoDbModel.ItemList.Add(new DataModels.DwhEntities.AddCartRequestModel
                    {
                        CompanyCode = i.CompanyCode,
                        ItemCode = i.ItemCode,
                        Quantity = i.Quantity
                    });
                }

                try
                {
                    _dbContext.CartDwhRepository.Create(mongoDbModel);
                }
                catch
                {
                    return new AddCartResponseModel
                    {
                        StatusCode = StatusCodes.Status200OK,
                        IsSuccess = true,
                        Message = "Add Cart Failed!"
                    };
                }
                return new AddCartResponseModel
                {
                    StatusCode = StatusCodes.Status200OK,
                    IsSuccess = true,
                    Message = "Add Cart Success!"
                };
            }
            catch
            {
                return new AddCartResponseModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    IsSuccess = true,
                    Message = "Bad Request!"
                };
            }
        }
    }
}
