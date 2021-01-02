using SLOT.Infrastructure.DataLibrary.Dwh;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Datalibrary.Dwh
{
    public class CartDwhRepository : BaseDwhRepository<DataModels.DwhEntities.CartModel>
    {

        public CartDwhRepository(string mongoDBConnectionString, string dbName) : base(mongoDBConnectionString, dbName)
        {

        }
    }
}
