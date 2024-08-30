using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int CourseId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public short CourseType { get; set; }

    public string CourseTitle { get; set; }

    public string CourseCategory { get; set; }

    public string CourseSubject { get; set; }

    public virtual Course Course { get; set; }

    public virtual Order Order { get; set; }
}
