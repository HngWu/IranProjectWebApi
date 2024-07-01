using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class SurveyOption
{
    public int SurveyOptionId { get; set; }

    public string SurveyOptionName { get; set; } = null!;

    public int SurveyId { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
}
