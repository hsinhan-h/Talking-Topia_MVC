using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class WorkExperience
{
    public int WorkExperienceId { get; set; }

    public string WorkExperienceFile { get; set; }

    public DateTime WorkStartDate { get; set; }

    public DateTime WorkEndDate { get; set; }

    public string WorkName { get; set; }

    public int MemberId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Member Member { get; set; }
}
