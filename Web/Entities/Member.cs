using System;
using System.Collections.Generic;

namespace Web.Entities;

public partial class Member
{
    public int MemberId { get; set; }

    public string HeadShotImage { get; set; }

    public int? NationId { get; set; }

    public bool IsVerifiedTutor { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Nickname { get; set; }

    public string Phone { get; set; }

    public DateTime? Birthday { get; set; }

    public short Gender { get; set; }

    public string NativeLanguage { get; set; }

    public string SpokenLanguage { get; set; }

    public string BankCode { get; set; }

    public string BankAccount { get; set; }

    public int? EducationId { get; set; }

    public string TutorIntro { get; set; }

    public string Account { get; set; }

    public int AccountType { get; set; }

    public DateTime Cdate { get; set; }

    public DateTime? Udate { get; set; }

    public bool IsTutor { get; set; }

    public virtual ICollection<ApplyList> ApplyLists { get; set; } = new List<ApplyList>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Education Education { get; set; }

    public virtual ICollection<MemberPreference> MemberPreferences { get; set; } = new List<MemberPreference>();

    public virtual Nation Nation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProfessionalLicense> ProfessionalLicenses { get; set; } = new List<ProfessionalLicense>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<TutorTimeSlot> TutorTimeSlots { get; set; } = new List<TutorTimeSlot>();

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}
