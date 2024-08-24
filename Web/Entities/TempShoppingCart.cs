namespace Web.Entities
{
    public class TempShoppingCart
    {
        public int TempShoppingCartId { get; set; }
        public int CourseId { get; set; }
        public decimal UnitPriceNTD { get; set; }
        public short Quantity { get; set; }
        public decimal DiscountPriceNTD { get; set; }
        public decimal TotalPriceNTD { get; set; }
        public int MemberId { get; set; }

    }
}
