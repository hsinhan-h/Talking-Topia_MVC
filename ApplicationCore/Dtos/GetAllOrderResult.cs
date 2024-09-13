using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class GetAllOrderResult
    {
        public List<GetOrderItem> GetOrderItems { get; set; }
    }
    public class GetOrderItem
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string PaymentType { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal? CouponPrice { get; set; }
        public string? TaxIdNumber { get; set; }
        public short InvoiceType { get; set; }
        public string? VATNumber { get; set; }
        public string? SentVatemail { get; set; }
        public short OrderStatusId { get; set; }
    }
}
