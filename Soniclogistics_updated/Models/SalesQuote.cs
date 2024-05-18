using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

[Table("Sales_quote")]
public partial class SalesQuote
{
    [Key]
    [Column("SQID")]
    public int Sqid { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("Operational Unit")]
    public int OperationalUnit { get; set; }

    [Column("prod_ID")]
    public int ProdId { get; set; }

    [Column("UOM")]
    [StringLength(10)]
    [Unicode(false)]
    public string Uom { get; set; } = null!;

    [Column("Unit_Selling_Price")]
    public int UnitSellingPrice { get; set; }

    [Column("Total_Price")]
    public int TotalPrice { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Discription { get; set; }

    [Column("Create date", TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [Column("expire date", TypeName = "datetime")]
    public DateTime ExpireDate { get; set; }
}
