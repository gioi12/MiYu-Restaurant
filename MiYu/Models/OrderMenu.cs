using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class OrderMenu
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MenuId { get; set; }

    public int Quantity { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
