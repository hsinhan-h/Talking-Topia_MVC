using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class TutorTimeSlot
{
    public int TutorTimeSlotId { get; set; }

    public int TutorId { get; set; }

    public int Weekday { get; set; }

    public int CourseHourId { get; set; }

    public int BookingId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Booking Booking { get; set; }

    public virtual CourseHour CourseHour { get; set; }

    public virtual Member Tutor { get; set; }
}
