using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class SurveyAnswer
{
    public int SurveyAnswerId { get; set; }

    public int SurveyId { get; set; }

    public int UserId { get; set; }

    public int SurveyOptionId { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual SurveyOption SurveyOption { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
