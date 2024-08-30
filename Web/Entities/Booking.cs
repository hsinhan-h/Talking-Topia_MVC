using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CourseId { get; set; }

    public DateTime BookingDate { get; set; }

    public short BookingTime { get; set; }

    public int StudentId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Course Course { get; set; }

    public virtual Member Student { get; set; }

    public virtual ICollection<TutorTimeSlot> TutorTimeSlots { get; set; } = new List<TutorTimeSlot>();
}
