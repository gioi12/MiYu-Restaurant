using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Account
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Phone { get; set; } = null!;

    public bool? Gender { get; set; }

    public string? Mail { get; set; }

    public string? Address { get; set; }

    public int? StatusId { get; set; }

    public int? RoleId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Status? Status { get; set; }
}
