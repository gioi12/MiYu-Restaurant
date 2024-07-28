using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Attendence
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int StatusId { get; set; }

    public string? Description { get; set; }

    public string? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
