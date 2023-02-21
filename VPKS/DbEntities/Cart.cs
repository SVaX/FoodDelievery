using System;
using System.Collections.Generic;

namespace VPKS.DbEntities;

public partial class Cart
{
    public long CartId { get; set; }

    public long IdOrder { get; set; }

    public long IdFood { get; set; }

    public long Quantity { get; set; }

    public virtual Food IdFoodNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
