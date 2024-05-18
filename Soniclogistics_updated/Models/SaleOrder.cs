using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

[Table("SaleOrder")]
public partial class SaleOrder
{
    [Key]
    [Column("SaleOrder ID")]
    public int SaleOrderId { get; set; }

    [Column("SQID")]
    public int Sqid { get; set; }

    [Column("Operational Unit")]
    [StringLength(50)]
    [Unicode(false)]
    public string OperationalUnit { get; set; } = null!;

    [Column("Sup_id")]
    public int SupId { get; set; }

    [Column("prod_ID")]
    public int ProdId { get; set; }

    public DateOnly? OrderDate { get; set; }

    [Column("Unit Price")]
    public int UnitPrice { get; set; }

    [Column("address")]
    [StringLength(300)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Currency { get; set; } = null!;
}
