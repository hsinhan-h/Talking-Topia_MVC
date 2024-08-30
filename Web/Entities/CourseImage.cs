using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class CourseImage
{
    public int CourseImageId { get; set; }

    public int CourseId { get; set; }

    public string ImageUrl { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Course Course { get; set; }
}
