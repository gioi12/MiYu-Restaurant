using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class StorageItem
{
    public int Id { get; set; }

    public int? StorageId { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Storage? Storage { get; set; }
}
