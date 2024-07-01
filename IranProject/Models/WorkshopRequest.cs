using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class WorkshopRequest
{
    public int WorkshopRequestId { get; set; }

    public int UserId { get; set; }

    public int SaloonId { get; set; }

    public int CategoryId { get; set; }

    public int WorkshopTimeId { get; set; }

    public DateOnly Date { get; set; }

    public string Status { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Saloon Saloon { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual WorkshopTime WorkshopTime { get; set; } = null!;
}
