using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

[Table("SaleInvoice")]
public partial class SaleInvoice
{
    [Key]
    [Column("SaleInvoice_ID")]
    public int SaleInvoiceId { get; set; }

    [Column("Total Receivables")]
    public int TotalReceivables { get; set; }

    [Column("SaleOrder ID")]
    public int SaleOrderId { get; set; }

    [Column("prod_ID")]
    public int ProdId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("CustomerID")]
    public int CustomerId { get; set; }
}
