using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Coupon
{
    /// <summary>
    /// 優惠折扣Id
    /// </summary>
    public int CouponId { get; set; }

    /// <summary>
    /// 優惠折扣名稱
    /// </summary>
    public string CouponName { get; set; }

    /// <summary>
    /// 折扣代碼
    /// </summary>
    public string CouponCode { get; set; }

    /// <summary>
    /// 折扣方式
    /// </summary>
    public int DiscountType { get; set; }

    /// <summary>
    /// 折扣
    /// </summary>
    public int? Discount { get; set; }

    /// <summary>
    /// 折扣到期日
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime Cdate { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? Udate { get; set; }
}
