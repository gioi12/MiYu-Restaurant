using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
