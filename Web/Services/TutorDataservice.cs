using Web.Entities;
using static Web.Services.TutorDataservice;

namespace Web.Services
{
    public class TutorDataservice
    {
        private readonly IRepository _repository;
        public TutorDataservice(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<TutorDataViewModel> GetTutorDataAsync(int memberId, string subjectName)
        {
            var isVerifiedTutor = await (from member in _repository.GetAll<Member>()
                                         where member.MemberId == memberId
                                         select member.IsVerifiedTutor).FirstOrDefaultAsync();
            if (isVerifiedTutor) { 
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
                                       License = (from subject in _repository.GetAll<CourseSubject>()
                                                  join prefersubject in _repository.GetAll<MemberPreference>()
                                                  on subject.SubjectId equals prefersubject.SubjecId
                                                  join memb in _repository.GetAll<Member>()
                                                  on prefersubject.MemberId equals memb.MemberId
                                                  join license in _repository.GetAll<ProfessionalLicense>()
                                                  on memb.MemberId equals license.MemberId
                                                  where prefersubject.MemberId == memberId
                                                    && subject.SubjectName == subjectName
                                                  select new LicenseData
                                                  {
                                                      ProfessionalLicenseName = license.ProfessionalLicenseName,
                                                      ProfessionalLicenseUrl = license.ProfessionalLicenseUrl
                                                  }).ToList()
                                   }).FirstOrDefaultAsync();
                return tutorData;
            }
            return null;
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
        public async Task<TutorDataViewModel> GetCoursestatusAsync(int memberId)
        {
            var isVerifiedTutor = await (from member in _repository.GetAll<Member>()
                                         where member.MemberId == memberId
                                         select member.IsVerifiedTutor).FirstOrDefaultAsync();
            var tutorCourseData = new TutorDataViewModel();
            tutorCourseData.Coursestatus = await (from member in _repository.GetAll<Member>()
                                                  join memberPreference in _repository.GetAll<MemberPreference>()
                                                      on member.MemberId equals memberPreference.MemberId
                                                  join courseSubject in _repository.GetAll<CourseSubject>()
                                                      on memberPreference.SubjecId equals courseSubject.SubjectId
                                                  join courseCategory in _repository.GetAll<CourseCategory>()
                                                      on courseSubject.CourseCategoryId equals courseCategory.CourseCategoryId
                                                  join course in _repository.GetAll<Course>()
                                                      on courseCategory.CourseCategoryId equals course.CategoryId
                                                  select course.CoursesStatus == 1 ? CourseStatus.已審核 : CourseStatus.未審核).FirstOrDefaultAsync();
            return tutorCourseData;
        }
        public enum CourseStatus
        {
            未審核 = 0,
            已審核 = 1
        }
    }
}
