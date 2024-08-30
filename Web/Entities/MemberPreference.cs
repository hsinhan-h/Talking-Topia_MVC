using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class MemberPreference
{
    public int MemberPreferenceId { get; set; }

    public int MemberId { get; set; }

    public int SubjecId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Member Member { get; set; }

    public virtual CourseSubject Subjec { get; set; }
}
