using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cart.DataModels.Entities
{

    [Table("CART")]

    public class Cart : BaseModel
    {
        [Column("ID")]
        public long Id { get; set; }


        [Column("ACCOUNT_ID")]
        public long AccountId { get; set; }


        [Column("ITEM_MASTER_ID")]
        public long ItemMasterId { get; set; }


        [Column("COMPANY_ID")]
        public long CompanyId { get; set; }


        [Column("QUANTITY")]
        public int Quantity { get; set; }
    }
}
