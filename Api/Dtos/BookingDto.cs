namespace Api.Dtos
{
    public class BookingDto
    {
        public int BookingID { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string CourseTitle { get; set; }
        public string TutorName { get; set; }
        public string StudentName { get; set; }
        public string Surplus { get; set; }
        public int MonthCount { get; set; }
        public int YearCount { get; set; }
    }
}
