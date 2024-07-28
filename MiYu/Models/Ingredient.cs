using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Weight { get; set; }

    public string? Unit { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
