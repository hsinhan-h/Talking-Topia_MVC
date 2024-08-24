namespace Web.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string PaymentId { get; set; }
        public decimal PriceNTD { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CouponId { get; set; }
        public decimal CouponPrice { get; set; }
        public string TaxIdNumber { get; set; }
        public short InvoiceType { get; set; }
        public string VATNumber { get; set; }
        public string SentVATEmail { get; set; }
        public string PaymentMethod { get; set; }

    }
}
