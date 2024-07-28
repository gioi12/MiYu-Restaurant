using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Time { get; set; }

    public string? EmployeeId { get; set; }

    public int? Number { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<BookingOrder> BookingOrders { get; set; } = new List<BookingOrder>();

    public virtual Status? Status { get; set; }
}
