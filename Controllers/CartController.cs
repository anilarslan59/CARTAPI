using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.DataModels.RequestModels;
using Cart.DataModels.ResponseModels;
using Cart.Modules.In.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Produces("application/json")]
    public class CartController : Controller
    {
        private ICartWorkflow _cartWorkflow;

        public CartController(ICartWorkflow accountWorkFlow)
        {
            _cartWorkflow = accountWorkFlow;
        }


        [HttpPost]
        public IActionResult Add([FromBody]AddCartListRequestModel model)
        {
            try
            {
                var response = _cartWorkflow.Add(model);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new AddCartResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}