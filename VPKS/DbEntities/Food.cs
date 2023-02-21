using System;
using System.Collections.Generic;

namespace VPKS.DbEntities;

public partial class Food
{
    public long FoodId { get; set; }

    public string Name { get; set; } = null!;

    public long Weight { get; set; }

    public long Calories { get; set; }

    public long Cost { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
