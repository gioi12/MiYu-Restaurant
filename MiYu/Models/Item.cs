using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Weight { get; set; }

    public string? Unit { get; set; }

    public virtual ICollection<StorageItem> StorageItems { get; set; } = new List<StorageItem>();
}
