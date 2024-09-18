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
                                           License = (from memb in _repository.GetAll<Entities.Member>()
                                                      join license in _repository.GetAll<Entities.ProfessionalLicense>()
                                                      on memb.MemberId equals license.MemberId
                                                      where memb.MemberId == memberId
                                                      select new LicenseData
                                                      {
                                                          ProfessionalLicenseName = license.ProfessionalLicenseName,
                                                      }).ToList()
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
        public async Task<TutorDataViewModel> CreateTutorData(TutorDataViewModel qVM)
{
    // 開始一個資料庫交易
    await _repository.BeginTransActionAsync();
    try
    {
        // 新增 Member 資料
        var member = new Entities.Member
        {
            NativeLanguage = qVM.NativeLanguage,
            SpokenLanguage = qVM.SpokenLanguage,
            BankAccount = qVM.BankAccount,
            BankCode = qVM.BankCode,
            Cdate = DateTime.Now,
            Udate = null,
            FirstName = "N/A",
            LastName = "N/A",
            Password = "N/A",
            Email = "N/A",
            Nickname = "N/A",
            Phone = "N/A",
            Gender = 0,
            AccountType = 1,
            IsTutor = true,
            IsVerifiedTutor = false,
        };

        // 使用 Repository 來新增資料
        _repository.Create(member);
        await _repository.SaveChangesAsync();

        // 提交交易
        await _repository.CommitAsync();

        // 返回成功結果
        return new TutorDataViewModel 
        {
            //Success = true,
            //Message = "會員資料新增成功",

        };
    }
    catch (Exception ex)
    {
        // 若發生錯誤則回滾交易
        await _repository.RollbackAsync();
        return new TutorDataViewModel
        {
            //Success = false,
            //Message = $"資料處理發生錯誤: {ex.Message}"
        };
    }
}
    }
}
