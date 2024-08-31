using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class ShoppingCart
{
    public int ShoppingCartId { get; set; }

    public int CourseId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public int MemberId { get; set; }

    public short CourseType { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? BookingTime { get; set; }

    public virtual Course Course { get; set; }

    public virtual Member Member { get; set; }

    public virtual ICollection<ShoppingCartBooking> ShoppingCartBookings { get; set; } = new List<ShoppingCartBooking>();
}
