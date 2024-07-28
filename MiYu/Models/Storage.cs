using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Storage
{
    public int Id { get; set; }

    public string AccountId { get; set; } = null!;

    public DateTime? Time { get; set; }

    public int? StatusId { get; set; }

    public virtual Status? Status { get; set; }

    public virtual ICollection<StorageItem> StorageItems { get; set; } = new List<StorageItem>();
}
