using Cart.DataModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;


[Table("STOCK")]

public class Stock : BaseModel
{

    [Column("ID")]
    public long Id { get; set; }

    [Column("ACCOUNT_ID")]
    public long AccountId { get; set; }

    [Column("ITEM_MASTER_ID")]
    public long ItemMasterId { get; set; }

    [Column("QUANTITY")]
    public int Quantity { get; set; }
}