using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class CourseCategorite
{
    public int CourseCategoryId { get; set; }

    public string CategorytName { get; set; }

    public int CourseId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Course Course { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
}
