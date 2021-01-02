using Cart.Datalibrary.Dwh;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Datalibrary
{
    public class CartDwhDataContext
    {
        private readonly string _cnnString;
        private readonly string _databaseName;

        public CartDwhRepository CartDwhRepository { get; private set; }
        public CartDwhDataContext(string cnnString, string databaseName)
        {
            _cnnString = cnnString;
            _databaseName = databaseName;

            CartDwhRepository = new CartDwhRepository(cnnString, databaseName);
        }
    }
}
