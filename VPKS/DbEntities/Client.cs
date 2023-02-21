using System;
using System.Collections.Generic;

namespace VPKS.DbEntities;

public partial class Client
{
    public long ClientId { get; set; }

    public string Adress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
