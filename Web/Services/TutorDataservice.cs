using Microsoft.EntityFrameworkCore.Internal;
using Web.Entities;
using Web.Services;
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
        public async Task<TutorDataViewModel> GetTutorDataAsync(int memberId, string categorytName)
        {

            var isVerifiedTutor = await (from member in _repository.GetAll<Member>()
                                         where member.MemberId == memberId
                                         select member.IsVerifiedTutor).FirstOrDefaultAsync();
            if (isVerifiedTutor) { 
                var tutorData = await (from member in _repository.GetAll<Member>()
                                       join nation in _repository.GetAll<Nation>()
                                       on member.NationId equals nation.NationId
                                       where member.MemberId == memberId
                                   select new TutorDataViewModel
                                   {
                                       NationID = nation.NationId,
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
                                       License = (from category in _repository.GetAll<CourseCategory>()
                                                  join subject in _repository.GetAll<CourseSubject>()
                                                  on category.CourseCategoryId equals subject.CourseCategoryId
                                                  join prefersubject in _repository.GetAll<MemberPreference>()
                                                  on subject.SubjectId equals prefersubject.SubjecId
                                                  join memb in _repository.GetAll<Member>()
                                                  on prefersubject.MemberId equals memb.MemberId
                                                  join license in _repository.GetAll<ProfessionalLicense>()
                                                  on memb.MemberId equals license.MemberId
                                                  where prefersubject.MemberId == memberId
                                                    && category.CategorytName == categorytName//要修改關聯
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
            if (isVerifiedTutor)
            {
                tutorCourseData.Coursestatus = await (from member in _repository.GetAll<Member>()
                                                  join applylist in _repository.GetAll<ApplyList>()
                                                      on member.MemberId equals applylist.MemberId
                                                  select applylist.ApplyStatus ? CourseStatus.已審核 : CourseStatus.未審核).FirstOrDefaultAsync();
            }
            return tutorCourseData;
        }
        //取得可預約時段的方法
        public async Task<TutorDataViewModel> GetTutorReserveTimeAsync(int memberId)
        {
            var isVerifiedTutor = await (from member in _repository.GetAll<Member>()
                                         where member.MemberId == memberId
                                         select member.IsVerifiedTutor).FirstOrDefaultAsync();
            var tutortime = new TutorDataViewModel
            {
                AvailableReservation = new List<AvailReservation>()
            };
            if (isVerifiedTutor)
            {
                tutortime.AvailableReservation = await (from member in _repository.GetAll<Member>()
                                                        join tutorTimeSloot in _repository.GetAll<TutorTimeSlot>()
                                                        on member.MemberId equals tutorTimeSloot.TutorId
                                                        join coursehour in _repository.GetAll<CourseHour>()
                                                        on tutorTimeSloot.CourseHourId equals coursehour.CourseHourId
                                                        select new AvailReservation
                                                        {
                                                            Weekday = tutorTimeSloot.Weekday,
                                                            Coursehours = coursehour.Hour,
                                                        }).ToListAsync();
            }

            return tutortime;
        }
        public async Task<TutorDataViewModel> GetAllInformationAsync()
        {
            int memberId = 1;
            string categorytName = "程式設計";

            var tutorData = await GetTutorDataAsync(memberId, categorytName);
            if (tutorData == null)
            {
                return new TutorDataViewModel();
            }

            var tutorCourseData = await GetTutorCourseDataAsync(memberId);
            if (tutorCourseData == null)
            {
                return new TutorDataViewModel();
            }

            var tutorCourseStatus = await GetCoursestatusAsync(memberId);
            if (tutorCourseStatus == null)
            {
                return new TutorDataViewModel();
            }

            tutorData.Course = tutorCourseData.Course;
            tutorData.Coursestatus = tutorCourseStatus.Coursestatus;
            return tutorData;
        }

        public enum CourseStatus
        {
            未審核 = 0,
            已審核 = 1,

        }
       
    }
}
