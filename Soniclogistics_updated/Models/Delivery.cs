using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

[Table("Delivery")]
public partial class Delivery
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Delivery Status")]
    [StringLength(50)]
    [Unicode(false)]
    public string DeliveryStatus { get; set; } = null!;

    [Column("SaleOrder ID")]
    public int SaleOrderId { get; set; }
}
