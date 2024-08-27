namespace Web.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public decimal UnitPriceNTD { get; set; }
        public short Quantity { get; set; }
        public int DiscountId { get; set; }
        public decimal DiscountPriceNTD { get; set; }
        public decimal TotalPriceNTD { get; set; }

    }
}
