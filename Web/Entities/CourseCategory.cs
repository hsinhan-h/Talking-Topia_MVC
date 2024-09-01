using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class CourseCategory
{
    /// <summary>
    /// 課程類別Id
    /// </summary>
    public int CourseCategoryId { get; set; }

    /// <summary>
    /// 課程類別名稱
    /// </summary>
    public string CategorytName { get; set; }

    /// <summary>
    /// 課程Id
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime Cdate { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? Udate { get; set; }

    public virtual Course Course { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
}
