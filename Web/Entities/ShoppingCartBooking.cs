using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class ShoppingCartBooking
{
    public int BookingId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? BookingDate { get; set; } = default(DateOnly?);

    public short? BookingTime { get; set; }

    public int? MemberId { get; set; }

    public int? TempShoppingCartId { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual ShoppingCart TempShoppingCart { get; set; }
}
