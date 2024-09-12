using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class ShoppingCartBooking
{
    /// <summary>
    /// 課程預定Id
    /// </summary>
    public int BookingId { get; set; }

    /// <summary>
    /// 課程Id
    /// </summary>
    public int? CourseId { get; set; }

    /// <summary>
    /// 預約日期
    /// </summary>
    public DateOnly? BookingDate { get; set; }

    /// <summary>
    /// 預約時間
    /// </summary>
    public short? BookingTime { get; set; }

    /// <summary>
    /// 會員Id
    /// </summary>
    public int? MemberId { get; set; }

    public int? TempShoppingCartId { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime Cdate { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? Udate { get; set; }

    public virtual ShoppingCart? TempShoppingCart { get; set; }
}
