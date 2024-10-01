namespace Web.Dtos
{
    public class ShoppingCartDtos
    {
        public string Payment { get; set; }

        public string TaxIdNumber { get; set; }

        public List<ShoppingCartVM> scVM { get; set; }
    }

    public class OrderDto
    {
        public int MemberId { get; set; }
    }

    public class ShoppingCartVM
    {

        public int CourseId { get; set; }

        public string TrackingNumber { get; set; }

        public string HeadShotImage { get; set; }

        public string FullName { get; set; }

        public string CourseTitle { get; set; }

        public string CourseSubject { get; set; }

        public string CourseCategory { get; set; }

        public int CourseLength { get; set; }

        public int CourseQuantity { get; set; }

        public int UnitPrice { get; set; }

        public int TFUnitPrice { get; set; }

        public int FTUnitPrice { get; set; }

        public double Discount { get; set; }

        public int SubtotalNTD { get; set; }

        public string Coupon { get; set; }

        public string PaymentType { get; set; }
    }
}
