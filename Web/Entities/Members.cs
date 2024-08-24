namespace Web.Entities
{
    public class Members
    {
        public int MemberId { get; set; }
        public string HeadShotImage { get; set; }
        public int NationId { get; set; }
        public string NationImage { get; set; }
        public bool IsVerifiedTutor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public short Gender { get; set; }
        public string NativeLanguage { get; set; }
        public string SpokenLanguage { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }
        public int EducationId { get; set; }
        public string TutorIntro { get; set; }

    }
}
