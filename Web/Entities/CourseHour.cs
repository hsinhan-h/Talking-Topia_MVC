using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class CourseHour
{
    public int CourseHourId { get; set; }

    public string Hour { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual ICollection<TutorTimeSlot> TutorTimeSlots { get; set; } = new List<TutorTimeSlot>();
}
