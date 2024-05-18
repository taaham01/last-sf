using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    public int Contact { get; set; }

    [StringLength(10)]
    public string Email { get; set; } = null!;

    [Column("address")]
    [StringLength(300)]
    [Unicode(false)]
    public string Address { get; set; } = null!;
}
