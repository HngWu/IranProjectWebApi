using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class User
{
    public int UserId { get; set; }

    public int UserTypeId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Fullname { get; set; }

    public int? Tel { get; set; }

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

    public virtual UserType UserNavigation { get; set; } = null!;

    public virtual ICollection<WorkshopRequest> WorkshopRequests { get; set; } = new List<WorkshopRequest>();
}
