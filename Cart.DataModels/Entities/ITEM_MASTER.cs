using Cart.DataModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;


[Table("ITEM_MASTER")]

public class ItemMaster : BaseModel
{

    [Column("ID")]
    public long Id { get; set; }

    [Column("ACCOUNT_ID")]
    public long AccountId { get; set; }

    [Column("CODE")]
    public string Code { get; set; }


    [Column("DESCRIPTION")]
    public string Description { get; set; }
}