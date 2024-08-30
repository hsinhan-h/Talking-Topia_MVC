using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public string PaymentType { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal? CouponPrice { get; set; }

    public string TaxIdNumber { get; set; }

    public short InvoiceType { get; set; }

    public string Vatnumber { get; set; }

    public string SentVatemail { get; set; }

    public short OrderStatusId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Member Member { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
