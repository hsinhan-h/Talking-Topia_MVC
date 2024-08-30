using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class CourseSubject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; }

    public int CourseCategoryId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual CourseCategorite CourseCategory { get; set; }

    public virtual ICollection<MemberPreference> MemberPreferences { get; set; } = new List<MemberPreference>();
}
