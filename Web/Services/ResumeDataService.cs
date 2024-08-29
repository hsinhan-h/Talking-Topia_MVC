using Web.Entities;

namespace Web.Services
{
    public class ResumeDataService
    {
        public async Task<MemberProfileListViewModel> GetResumeData(string account)
        {
            // 二筆假資料
            var resumedata = new List<MemberProfileViewModel>
            {

                new MemberProfileViewModel
                {
                    ImageUrl = "image/apply_teacher/feature-price.webp",
                    Nickname = "Sunny",
                    Birthday = new DateTime(1990, 5, 12),
                    Gender = "Female",
                    NationName = "Taiwan",
                    NativeLanguage = "Chinese",
                    SpokenLanguage = "English, Japanese",
                    Account = "sunny123",
                    FirstName = "Anna",
                    LastName = "Wang",
                    Email = "anna.wang@example.com",
                    Phone = "0987654321",
                    Address = "台北市信義區信義路101號",
                    CousePrefer ="中文",
                    //CousePrefer = new List<CouseListViewModel>
                    //{
                    //    new CouseListViewModel { CategorytName = "Language", SubjectName = "English" },
                    //    new CouseListViewModel { CategorytName = "Language", SubjectName = "Japanese" }
                    //},
                    SchoolName = "National Taiwan University",
                    StudyStartYear = 2008,
                    StudyEndYear = 2012,
                    DepartmentName = "Foreign Languages and Literatures",
                    ProfessionalLicenseName = "TOEIC 900",
                    WorkStartDate = new DateTime(2013, 6, 1),
                    WorkEndDate = new DateTime(2018, 6, 1),
                    WorkExperience = "Worked as an English teacher at a language school for 5 years.",
                    CategorytName = "Language",
                    ApplyStatus = "Approved",
                    TutorIntro = "I have over 5 years of teaching experience in English and Japanese.",
                    ReservationTime = new List<ReservationTimeListViewModel>
                    {
                        new ReservationTimeListViewModel { Weekday = 1, CourseHourId = 9 },
                        new ReservationTimeListViewModel { Weekday = 3, CourseHourId = 14 }
                    },
                    BankAccount ="xxx13246dd",
                    BankCode ="asdqwergf",
                    ProfessionalLicenses = new List<LicenseViewModel>
                    {
                        new LicenseViewModel
                        {
                            LicenseName = "TOEIC 900",
                            LicenseFile = "image/apply_teacher/feature-price.webp"
                        },
                        new LicenseViewModel
                        {
                            LicenseName = "JLPT N1",
                            LicenseFile = "image/apply_teacher/feature-price-2.webp"
                        },
                        new LicenseViewModel
                        {
                            LicenseName = "TESOL",
                            LicenseFile = "image/apply_teacher/feature-price-3.webp"
                        }
                    },
                },
                new MemberProfileViewModel
                {
                    ImageUrl = "image/apply_teacher/feature-price.webp",
                    Nickname = "Tommy",
                    Birthday = new DateTime(1985, 8, 24),
                    Gender = "Male",
                    NationName = "Japan",
                    NativeLanguage = "Japanese",
                    SpokenLanguage = "Chinese, English",
                    Account = "tommy85",
                    FirstName = "Tomoya",
                    LastName = "Suzuki",
                    Email = "tomoya.suzuki@example.com",
                    Phone = "0978123456",
                    Address = "東京都新宿區新宿2丁目15-18",
                    CousePrefer ="中文",//待討論
                    //CousePrefer = new List<CouseListViewModel>
                    //{
                    //    new CouseListViewModel { CategorytName = "Technology", SubjectName = "Programming" },
                    //    new CouseListViewModel { CategorytName = "Technology", SubjectName = "Web Development" }
                    //},
                    SchoolName = "University of Tokyo",
                    StudyStartYear = 2004,
                    StudyEndYear = 2008,
                    DepartmentName = "Computer Science",
                    ProfessionalLicenseName = "AWS Certified Solutions Architect",
                    WorkStartDate = new DateTime(2009, 4, 1),
                    WorkEndDate = new DateTime(2020, 3, 31),
                    WorkExperience = "Worked as a full-stack developer and team leader for 11 years.",
                    CategorytName = "Technology",
                    ApplyStatus = "Pending",
                    TutorIntro = "I specialize in teaching programming and web development with over a decade of industry experience.",
                    ReservationTime = new List<ReservationTimeListViewModel>
                    {
                        new ReservationTimeListViewModel { Weekday = 2, CourseHourId = 10 },
                        new ReservationTimeListViewModel { Weekday = 5, CourseHourId = 16 }
                    },
                    BankAccount ="xxeeerr6dd",
                    BankCode ="aeafegfaggf",
                    ProfessionalLicenses = new List<LicenseViewModel>
                    {
                        new LicenseViewModel
                        {
                            LicenseName = "TOEIC 900",
                            LicenseFile = "image/apply_teacher/feature-price.webp"
                        },
                        new LicenseViewModel
                        {
                            LicenseName = "JLPT N1",
                            LicenseFile = "image/apply_teacher/feature-price-2.webp"
                        },
                        new LicenseViewModel
                        {
                            LicenseName = "TESOL",
                            LicenseFile = "image/apply_teacher/feature-price-3.webp"
                        }
                    },
                }

            };

            var selectedMember = resumedata.FirstOrDefault(x => x.Account == account);

            if (selectedMember == null)
            {
                throw new Exception("會員資料未找到");
            }

            // 將找到的會員資料填寫到 ViewModel 中
            var result = new MemberProfileListViewModel
            {
                MemberDataList = new List<MemberProfileViewModel>
                {
                    new MemberProfileViewModel
                    {
                        ImageUrl = selectedMember.ImageUrl,
                        Nickname = selectedMember.Nickname,
                        Birthday = selectedMember.Birthday,
                        Gender = selectedMember.Gender,
                        NationName = selectedMember.NationName,
                        NativeLanguage = selectedMember.NativeLanguage,
                        SpokenLanguage = selectedMember.SpokenLanguage,
                        Account = selectedMember.Account,
                        FirstName = selectedMember.FirstName,
                        LastName = selectedMember.LastName,
                        Email = selectedMember.Email,
                        Phone = selectedMember.Phone,
                        Address = selectedMember.Address,
                        CousePrefer = selectedMember.CousePrefer,
                        SchoolName = selectedMember.SchoolName,
                        StudyStartYear = selectedMember.StudyStartYear,
                        StudyEndYear = selectedMember.StudyEndYear,
                        DepartmentName = selectedMember.DepartmentName,
                        ProfessionalLicenseName = selectedMember.ProfessionalLicenseName,
                        WorkStartDate = selectedMember.WorkStartDate,
                        WorkEndDate = selectedMember.WorkEndDate,
                        WorkExperience = selectedMember.WorkExperience,
                        CategorytName = selectedMember.CategorytName,
                        ApplyStatus = selectedMember.ApplyStatus,
                        TutorIntro = selectedMember.TutorIntro,
                        BankAccount = selectedMember.BankAccount,
                        BankCode = selectedMember.BankCode,
                        ProfessionalLicenses = selectedMember.ProfessionalLicenses
                    }
                }
            };

            return result;
        }
    }
}
