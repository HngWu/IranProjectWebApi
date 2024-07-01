using System;
using System.Collections.Generic;

namespace IranProject.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public string SurveyName { get; set; } = null!;

    public string Question { get; set; } = null!;

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

    public virtual ICollection<SurveyOption> SurveyOptions { get; set; } = new List<SurveyOption>();
}
