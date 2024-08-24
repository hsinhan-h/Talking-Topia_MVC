namespace Web.Entities
{
    public class TutorTimeSlot
    {
        public int TutorTimeSlotId { get; set; }
        public int MemberID { get; set; }
        public int Weekday { get; set; }
        public int CourseHourId { get; set; }
        public int BookingId { get; set; }

    }
}
