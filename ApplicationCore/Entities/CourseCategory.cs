using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class CourseCategory
{
    /// <summary>
    /// 課程類別Id
    /// </summary>
    public int CourseCategoryId { get; set; }

    /// <summary>
    /// 課程類別名稱
    /// </summary>
    public string CategorytName { get; set; } = null!;

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime Cdate { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? Udate { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
