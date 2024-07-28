using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Table
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Floor { get; set; }

    public virtual ICollection<BookingOrder> BookingOrders { get; set; } = new List<BookingOrder>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
