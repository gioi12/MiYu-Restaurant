using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public int EmployeeTypeId { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual Account EmployeeNavigation { get; set; } = null!;

    public virtual EmployeeType EmployeeType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
