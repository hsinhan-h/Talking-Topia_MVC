using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Nation
{
    public int NationId { get; set; }

    public string NationName { get; set; }

    public string FlagImage { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
