using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string UserTypeName { get; set; } = null!;

    public virtual User? User { get; set; }
}
