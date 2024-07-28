using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class BookingOrder
{
    public int Id { get; set; }

    public int? BookingId { get; set; }

    public int? TableId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Table? Table { get; set; }
}
