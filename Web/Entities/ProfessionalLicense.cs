using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class ProfessionalLicense
{
    public int ProfessionalLicenseId { get; set; }

    public string ProfessionalLicenseName { get; set; }

    public int MemberId { get; set; }

    public string ProfessionalLicenseUrl { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public virtual Member Member { get; set; }
}
