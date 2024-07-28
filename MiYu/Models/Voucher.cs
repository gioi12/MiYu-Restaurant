using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public string? Code { get; set; }

    public decimal Discount { get; set; }

    public int? Remaining { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
