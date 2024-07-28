using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Customer
{
    public int CustomerTypeId { get; set; }

    public string CustomerId { get; set; } = null!;

    public virtual Account CustomerNavigation { get; set; } = null!;

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
