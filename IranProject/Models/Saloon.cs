using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class Saloon
{
    public int SaloonId { get; set; }

    public string SaloonName { get; set; } = null!;

    public virtual ICollection<WorkshopRequest> WorkshopRequests { get; set; } = new List<WorkshopRequest>();
}
