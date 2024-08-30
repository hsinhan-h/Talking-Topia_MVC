using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class MemberCoupon
{
    public int MemberCouponId { get; set; }

    public int MemberId { get; set; }

    public bool IsUsed { get; set; }

    public DateTime Cdate { get; set; }

    public int CouponId { get; set; }

    public virtual Coupon Coupon { get; set; }

    public virtual Member Member { get; set; }
}
