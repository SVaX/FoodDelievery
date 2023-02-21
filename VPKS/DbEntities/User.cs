using System;
using System.Collections.Generic;

namespace VPKS.DbEntities;

public partial class User
{
    public long UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long Balance { get; set; }

    public string PermissionLevel { get; set; } = null!;

    public string Email { get; set; } = null!;
}
