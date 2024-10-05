namespace Api.Dtos
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
    }
    public class DeleteBookingDto
    {
        public int BookingID { get; set; }
    }
}
