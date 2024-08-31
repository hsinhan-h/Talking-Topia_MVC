using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public int CategoryId { get; set; }

    public int SubjectId { get; set; }

    public int TutorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public decimal TwentyFiveMinUnitPrice { get; set; }

    public decimal FiftyMinUnitPrice { get; set; }

    public string Description { get; set; }

    public bool IsEnabled { get; set; }

    public string ThumbnailUrl { get; set; }

    public string VideoUrl { get; set; }

    public short CoursesStatus { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CourseCategorite> CourseCategorites { get; set; } = new List<CourseCategorite>();

    public virtual ICollection<CourseImage> CourseImages { get; set; } = new List<CourseImage>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
