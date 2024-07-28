using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? TimeStart { get; set; }

    public int? OrderMenuId { get; set; }

    public int StatusId { get; set; }

    public int? TableId { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string? CustormerId { get; set; }

    public string? EmployeeId { get; set; }

    public decimal? Price { get; set; }

    public int? VoucherId { get; set; }

    public virtual Customer? Custormer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderMenu> OrderMenus { get; set; } = new List<OrderMenu>();

    public virtual Status Status { get; set; } = null!;

    public virtual Table? Table { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
