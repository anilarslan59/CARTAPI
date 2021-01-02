using Microsoft.EntityFrameworkCore;
using System;

namespace Cart.Datalibrary
{
    public class CartDataContext : DbContext
    {
        public CartDataContext(DbContextOptions<CartDataContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<RecordStatus> RecordStatuses { get; set; }
        public DbSet<DataModels.Entities.Cart> Carts { get; set; }
    }
}
