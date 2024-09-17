using ApplicationCore.Entities;
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

        //Read 
        public async Task<TutorDataViewModel> GetTutorDataAsync(int? memberId)
        {

            var istutor = await (from member in _repository.GetAll<Entities.Member>()
                                         where member.MemberId == memberId
                                         select member.IsTutor).FirstOrDefaultAsync();
            if (istutor)
            {
                var tutorData = await (from member in _repository.GetAll<Entities.Member>()
                                       join tutortimslot in _repository.GetAll<Entities.TutorTimeSlot>()
                                       on member.MemberId equals tutortimslot.TutorId
                                       join nation in _repository.GetAll<Entities.Nation>()
                                       on member.NationId equals nation.NationId
                                       where member.MemberId == memberId
                                       select new TutorDataViewModel
                                       {
                                           TutorId = tutortimslot.TutorId,
                                           NationID = nation.NationId,
                                           NativeLanguage = member.NativeLanguage,
                                           SpokenLanguage = member.SpokenLanguage,
                                           BankAccount = member.BankAccount,
                                           BankCode = member.BankCode,
                                           EducationalBackground = _repository.GetAll<Entities.Education>()
                                               .Where(edu => edu.EducationId == member.EducationId)
                                               .Select(edu => new Educational
                                               {
                                                   SchoolName = edu.SchoolName,
                                                   StudyStartYear = edu.StudyStartYear,
                                                   StudyEndYear = edu.StudyEndYear
                                               }).ToList(),
                                           WorkBackground = _repository.GetAll<Entities.WorkExperience>()
                                               .Where(wexp => wexp.MemberId == memberId)
                                               .Select(wexp => new WorkExp
                                               {
                                                   //WorkStartDate = wexp.WorkStartDate,
                                                   //WorkEndDate = wexp.WorkEndDate,
                                                   WorkName = wexp.WorkName
                                               }).ToList(),
                                           //License = (from category in _repository.GetAll<CourseCategory>()
                                           //           join subject in _repository.GetAll<CourseSubject>()
                                           //           on category.CourseCategoryId equals subject.CourseCategoryId
                                           //           join prefersubject in _repository.GetAll<MemberPreference>()
                                           //           on subject.SubjectId equals prefersubject.SubjecId
                                           //           join memb in _repository.GetAll<Member>()
                                           //           on prefersubject.MemberId equals memb.MemberId
                                           //           join license in _repository.GetAll<ProfessionalLicense>()
                                           //           on memb.MemberId equals license.MemberId
                                           //           where prefersubject.MemberId == memberId
                                           //             && category.CategorytName == categorytName//要修改關聯
                                           //           select new LicenseData
                                           //           {
                                           //               ProfessionalLicenseName = license.ProfessionalLicenseName,
                                           //               ProfessionalLicenseUrl = license.ProfessionalLicenseUrl
                                           //           }).ToList()
                                       }).FirstOrDefaultAsync();
                return tutorData;
            }
            return null;
        }
        public async Task<TutorDataViewModel> GetTutorCourseDataAsync(int? memberId)
        {
            var istutor = await (from member in _repository.GetAll<Entities.Member>()
                                 where member.MemberId == memberId
                                 select member.IsTutor).FirstOrDefaultAsync();

            var tutorCourseData = new TutorDataViewModel
            {
                Course = new List<CategoryData>()
            };

            if (istutor)
            {
                tutorCourseData.Course = await (from member in _repository.GetAll<Entities.Member>()
                                                join memberPreference in _repository.GetAll<Entities.MemberPreference>()
                                                    on member.MemberId equals memberPreference.MemberId
                                                join courseSubject in _repository.GetAll<Entities.CourseSubject>()
                                                    on memberPreference.SubjecId equals courseSubject.SubjectId
                                                join courseCategory in _repository.GetAll<Entities.CourseCategory>()
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
        public async Task<TutorDataViewModel> GetCoursestatusAsync(int? memberId)
        {
            var istutor = await (from member in _repository.GetAll<Entities.Member>()
                                 where member.MemberId == memberId
                                 select member.IsTutor).FirstOrDefaultAsync();
            var tutorCourseData = new TutorDataViewModel();
            if (!istutor)
            {
                return tutorCourseData;
            }
            if (istutor)
            {
                tutorCourseData.Coursestatus = await (from member in _repository.GetAll<Entities.Member>()
                                                      join applylist in _repository.GetAll<Entities.ApplyList>()
                                                          on member.MemberId equals applylist.MemberId
                                                      select applylist.ApplyStatus ? CourseStatus.已審核 : CourseStatus.未審核).FirstOrDefaultAsync();
            }
            return tutorCourseData;
        }
        
        public async Task<TutorDataViewModel> GetAllInformationAsync(int? memberId)
        {
           
            var tutorData = await GetTutorDataAsync(memberId);
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
        //取得可預約時段的方法
        public async Task<TutorDataViewModel> GetTutorReserveTimeAsync(int? memberId)
        {
            var istutor = await (from member in _repository.GetAll<Entities.Member>()
                                 where member.MemberId == memberId
                                 select member.IsTutor).FirstOrDefaultAsync();
            var tutortime = new TutorDataViewModel
            {
                AvailableReservation = new List<AvailReservation>()
            };
            if (!istutor)
            {
                return tutortime;
            }

            // 如果是認證講師，查詢可用的預約時間
            tutortime.AvailableReservation = await (from member in _repository.GetAll<Entities.Member>()
                                                    join tutorTimeSloot in _repository.GetAll<Entities.TutorTimeSlot>()
                                                    on member.MemberId equals tutorTimeSloot.TutorId
                                                    join coursehour in _repository.GetAll<Entities.CourseHour>()
                                                    on tutorTimeSloot.CourseHourId equals coursehour.CourseHourId
                                                    where member.MemberId == memberId
                                                    select new AvailReservation
                                                    {
                                                        Weekday = tutorTimeSloot.Weekday,
                                                        Coursehours = coursehour.Hour,
                                                    }).ToListAsync();

            return tutortime;
        }


        //Creat
        public TutorDataViewModel CreatTutorData()
        {
            return (new TutorDataViewModel());

        }
    }   
}
