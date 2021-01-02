using Cart.DataModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;


[Table("ACCOUNT")]

public class Account : BaseModel
{

    [Column("ID")]
    public long Id { get; set; }


    [Column("CODE")]
    public string Code { get; set; }


    [Column("DESCRIPTION")]
    public string Description { get; set; }
}