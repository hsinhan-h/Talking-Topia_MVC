using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Coupon
{
    public int CouponId { get; set; }

    public string CouponName { get; set; }

    public string CouponCode { get; set; }

    public int DiscountType { get; set; }

    public int? Discount { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }
}
