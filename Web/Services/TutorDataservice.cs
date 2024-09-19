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
        private async Task<bool> Isteacher(int? memberId)
        {
            if (memberId == null)
            {
                return false;
            }

            var istutor = await (from member in _repository.GetAll<Entities.Member>()
                                 where member.MemberId == memberId
                                 select member.IsTutor).FirstOrDefaultAsync();

            return istutor;

        }
        private async Task<TutorDataViewModel> GetTutorDataAsync(int? memberId)
        {

            if (await Isteacher(memberId))
            {
                var member = await _repository.GetAll<Entities.Member>()
                            .Where(m => m.MemberId == memberId)
                            .FirstOrDefaultAsync();

                var tutorTimeSlot = await _repository.GetAll<Entities.TutorTimeSlot>()
                    .Where(t => t.TutorId == memberId)
                    .FirstOrDefaultAsync();

                var nation = await _repository.GetAll<Entities.Nation>()
                    .Where(n => n.NationId == member.NationId)
                    .FirstOrDefaultAsync();

                var education = await _repository.GetAll<Entities.Education>()
                    .Where(edu => edu.EducationId == member.EducationId)
                    .Select(edu => new Educational
                    {
                        SchoolName = edu.SchoolName,
                        StudyStartYear = edu.StudyStartYear,
                        StudyEndYear = edu.StudyEndYear
                    }).ToListAsync();

                var workExperience = await _repository.GetAll<Entities.WorkExperience>()
                    .Where(wexp => wexp.MemberId == memberId)
                    .Select(wexp => new WorkExp
                    {
                        WorkName = wexp.WorkName
                    }).ToListAsync();

                var license = await (from memb in _repository.GetAll<Entities.Member>()
                                     join proLi in _repository.GetAll<Entities.ProfessionalLicense>()
                                     on memb.MemberId equals proLi.MemberId into licenseGroup
                                     from proLi in licenseGroup.DefaultIfEmpty()
                                     where memb.MemberId == memberId
                                     select new LicenseData
                                     {
                                         ProfessionalLicenseName = proLi.ProfessionalLicenseName ?? "Default License"
                                     }).ToListAsync();

                // 最後手動組合 ViewModel
                var tutorData = new TutorDataViewModel
                {
                    TutorId = tutorTimeSlot?.TutorId ?? 0,
                    NationID = nation?.NationId ?? 0,
                    NativeLanguage = member.NativeLanguage,
                    SpokenLanguage = member.SpokenLanguage,
                    BankAccount = member.BankAccount,
                    BankCode = member.BankCode,
                    EducationalBackground = education,
                    WorkBackground = workExperience,
                    License = license
                };

                return tutorData;
            }
            return null;
        }
        private async Task<TutorDataViewModel> GetTutorCourseDataAsync(int? memberId)
        {
            var tutorCourseData = new TutorDataViewModel
            {
                Course = new List<CategoryData>()
            };

            if (await Isteacher(memberId))
            {
                var member = await _repository.GetAll<Entities.Member>()
                    .Where(m => m.MemberId == memberId)
                    .FirstOrDefaultAsync();

                if (member == null)
                {
                    return null;
                }
                var memberPreferences = await _repository.GetAll<Entities.MemberPreference>()
                    .Where(mp => mp.MemberId == member.MemberId)
                    .ToListAsync();
                var categoryDataList = new List<CategoryData>();

                if (memberPreferences != null && memberPreferences.Any())
                {
                    foreach (var preference in memberPreferences)
                    {
                        var courseSubject = await _repository.GetAll<Entities.CourseSubject>()
                            .Where(cs => cs.SubjectId == preference.SubjecId)
                            .FirstOrDefaultAsync();

                        if (courseSubject != null)
                        {
                            var courseCategory = await _repository.GetAll<Entities.CourseCategory>()
                                .Where(cc => cc.CourseCategoryId == courseSubject.CourseCategoryId)
                                .FirstOrDefaultAsync();

                            if (courseCategory != null)
                            {
                                categoryDataList.Add(new CategoryData
                                {
                                    CategoryName = courseCategory.CategorytName,
                                    SubjectName = courseSubject.SubjectName
                                });
                            }
                        }
                    }
                }
                tutorCourseData.Course = categoryDataList;
            }

            return tutorCourseData;
        }
        private async Task<TutorDataViewModel> GetCoursestatusAsync(int? memberId)
        {
            var tutorCourseData = new TutorDataViewModel();

            if (await Isteacher(memberId))
            {
                var member = await _repository.GetAll<Entities.Member>()
                    .Where(m => m.MemberId == memberId)
                    .FirstOrDefaultAsync();

                if (member == null)
                {
                    return new TutorDataViewModel();
                }

                var applyList = await _repository.GetAll<Entities.ApplyList>()
                    .Where(a => a.MemberId == memberId)
                    .FirstOrDefaultAsync();

                if (applyList != null && applyList.ApplyStatus)
                {
                    tutorCourseData.Coursestatus = CourseStatus.已審核;
                }
                else
                {
                    tutorCourseData.Coursestatus = CourseStatus.未審核;
                }
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
            var tutortime = new TutorDataViewModel
            {
                AvailableReservation = new List<AvailReservation>()
            };
            if (!await Isteacher(memberId))
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

        //public async Task<TutorDataViewModel> CreatTutorData()
        //{
        //    return (new TutorDataViewModel());

        //}
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
                    Success = true,
                    Message = "會員資料新增成功",

                };
            }
            catch (Exception ex)
            {
                // 若發生錯誤則回滾交易
                await _repository.RollbackAsync();
                return new TutorDataViewModel
                {
                    Success = false,
                    Message = $"資料處理發生錯誤: {ex.Message}"
                };
            }
        }
    }
}
