namespace Web.Entities
{
    public class ProfessionalLicense
    {
        public int ProfessionalLicenseId { get; set; }
        public string ProfessionalLicenseName { get; set; }
        public int MemberId { get; set; }
        public string ProfessionalLicenseFile { get; set; }

    }
}
