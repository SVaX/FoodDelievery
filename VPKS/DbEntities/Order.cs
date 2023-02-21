using System;
using System.Collections.Generic;

namespace VPKS.DbEntities;

public partial class Order
{
    public long OrderId { get; set; }

    public long IdClient { get; set; }

    public long Cost { get; set; }

    public DateTime Date { get; set; }

    public string Adress { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual Client IdClientNavigation { get; set; } = null!;
}
