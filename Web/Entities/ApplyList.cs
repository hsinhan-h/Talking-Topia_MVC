using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class ApplyList
{
    public int ApplyId { get; set; }

    public int MemberId { get; set; }

    public bool ApplyStatus { get; set; }

    public DateTime ApplyDateTime { get; set; }

    public DateTime ApprovedDateTime { get; set; }

    public DateTime? UpdateStatusDateTime { get; set; }

    public string RejectReason { get; set; }

    public virtual Member Member { get; set; }
}
