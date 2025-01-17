﻿using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class EmployeeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
