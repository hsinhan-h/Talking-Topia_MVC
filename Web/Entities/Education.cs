using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Education
{
    public int EducationId { get; set; }

    public string SchoolName { get; set; }

    public int StudyStartYear { get; set; }

    public int StudyEndYear { get; set; }

    public string DepartmentName { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
