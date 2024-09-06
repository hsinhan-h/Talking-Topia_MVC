using Web.Entities;

namespace Web.Services
{
    public class TutorDataservice
    {
        private readonly IRepository _repository;
        public TutorDataservice(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<TutorDataViewModel> GetTutorDataAsync(int memberId)
        {
            var tutorData = await (from member in _repository.GetAll<Member>()
                                   where member.MemberId == memberId
                                   select new TutorDataViewModel
                                   {
                                       NativeLanguage = member.NativeLanguage,
                                       SpokenLanguage = member.SpokenLanguage,
                                       BankAccount = member.BankAccount,
                                       BankCode = member.BankCode,
                                       EducationalBackground = _repository.GetAll<Education>()
                                           .Where(edu => edu.EducationId == member.EducationId)
                                           .Select(edu => new Educational
                                           {
                                               SchoolName = edu.SchoolName,
                                               StudyStartYear = edu.StudyStartYear,
                                               StudyEndYear = edu.StudyEndYear
                                           }).ToList(),
                                       WorkBackground = _repository.GetAll<WorkExperience>()
                                           .Where(wexp => wexp.MemberId == memberId)
                                           .Select(wexp => new WorkExp
                                           {
                                               WorkStartDate = wexp.WorkStartDate,
                                               WorkEndDate = wexp.WorkEndDate,
                                               WorkName = wexp.WorkName
                                           }).ToList(),
                                       License = _repository.GetAll<ProfessionalLicense>()
                                           .Where(license => license.MemberId == memberId)
                                           .Select(liecenseitem => new LicenseData
                                           {
                                               ProfessionalLicenseName = liecenseitem.ProfessionalLicenseName,
                                               ProfessionalLicenseUrl = liecenseitem.ProfessionalLicenseUrl
                                           }).ToList(),
                                   }).FirstOrDefaultAsync(); 

            return tutorData; 
        }
        public async Task<TutorDataViewModel> GetTutorCourseDataAsync(int memberId)
        {
            var isVerifiedTutor = await (from member in _repository.GetAll<Member>()
                                         where member.MemberId == memberId
                                         select member.IsVerifiedTutor).FirstOrDefaultAsync();

            var tutorCourseData = new TutorDataViewModel
            {
                Course = new List<CategoryData>() 
            };

            if (isVerifiedTutor)
            {
                tutorCourseData.Course = await (from member in _repository.GetAll<Member>()
                                                join memberPreference in _repository.GetAll<MemberPreference>()
                                                    on member.MemberId equals memberPreference.MemberId
                                                join courseSubject in _repository.GetAll<CourseSubject>()
                                                    on memberPreference.SubjecId equals courseSubject.SubjectId
                                                join courseCategory in _repository.GetAll<CourseCategory>()
                                                    on courseSubject.CourseCategoryId equals courseCategory.CourseCategoryId
                                                where member.MemberId == memberId
                                                select new CategoryData
                                                {
                                                    CategoryName = courseCategory.CategorytName,
                                                    SubjectName = courseSubject.SubjectName,
                                                }).ToListAsync();
            }

            return tutorCourseData;
        }
    }
}
