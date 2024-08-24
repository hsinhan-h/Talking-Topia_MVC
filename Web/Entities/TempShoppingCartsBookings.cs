namespace Web.Entities
{
    public class TempShoppingCartsBookings
    {
        public int BookingId { get; set; }
        public int CourseId { get; set; }
        public DateTime BookingDate { get; set; }
        public short BookingTime { get; set; }
        public int MemberId { get; set; }
        public int TempShoppingCartId { get; set; }

    }
}
