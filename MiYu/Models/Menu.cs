using System;
using System.Collections.Generic;

namespace MiYu.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int? IngredientId { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual ICollection<OrderMenu> OrderMenus { get; set; } = new List<OrderMenu>();
}
