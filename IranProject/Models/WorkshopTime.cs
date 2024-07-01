using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class WorkshopTime
{
    public int WorkshopTimeId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<WorkshopRequest> WorkshopRequests { get; set; } = new List<WorkshopRequest>();
}
