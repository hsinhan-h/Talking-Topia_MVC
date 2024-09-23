
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Web.Entities;
using Web.Repository;

namespace Web.Services
{
    public class ResumeDataService
    {
        private readonly IRepository _repository;
        public ResumeDataService(IRepository repository)
        {
            _repository = repository;
        }
        //public async Task<TutorResumeListViewModel> GetEducationAsync(int memberId)
        //{
        //    var resumeValues = from e in _repository.GetAll<Education>()
        //                       join member in _repository.GetAll<Member>() on e.EducationId equals member.EducationId
        //                       join w in _repository.GetAll<WorkExperience>() on member.MemberId equals w.MemberId
        //                       where member.MemberId == 2
        //                       select new TutorResumeViewModel
        //                       {
        //                           SchoolName = e.SchoolName,
        //                           StudyEndYear = e.StudyEndYear,
        //                           StudyStartYear = e.StudyStartYear,
        //                           DepartmentName = e.DepartmentName,
        //                           //WorkEndDate = w.WorkEndDate,
        //                           //WorkStartDate = w.WorkStartDate,
        //                           //WorkName= w.WorkName,
        //                       };

        //    return new TutorResumeListViewModel()
        //    {
        //        TutorResumeList = await resumeValues.ToListAsync(),
        //    };
        //}
        public async Task<TutorResumeViewModel> AddResumeAsync(TutorResumeViewModel qVM, int memberId)
        {
            await _repository.BeginTransActionAsync();
            try
            {
                // 檢查會員是否存在
                var existingMember = await _repository.GetMemberByIdAsync(memberId);
                if (existingMember == null)
                {
                    return new TutorResumeViewModel
                    {
                        Success = false,
                        Message = "找不到該會員，請檢查會員資料。",
                    };
                }

                // 使用已存在的會員資料
                var member = new Entities.Member
                {
                    MemberId = memberId,
                    IsVerifiedTutor = false,
                    HeadShotImage = qVM.HeadShotImage,
                    Cdate = DateTime.Now,
                    Udate = null,
                    // 使用資料庫中的值來取代硬編碼的 "N/A"
                    FirstName = existingMember.FirstName ?? "N/A", // 若資料庫沒有 FirstName，則使用 "N/A"
                    LastName = existingMember.LastName ?? "N/A",
                    Password = existingMember.Password ?? "N/A",
                    Email = existingMember.Email ?? "N/A",
                    Nickname = existingMember.Nickname ?? "N/A",
                    Phone = existingMember.Phone ?? "N/A",
                    Gender = existingMember.Gender,
                    AccountType = 1,
                    IsTutor = false
                };
                _repository.Update(member); 

                // 創建教育經歷
                var education = new Entities.Education
                {
                    SchoolName = qVM.SchoolName,
                    StudyStartYear = qVM.StudyStartYear,
                    StudyEndYear = qVM.StudyEndYear,
                    DepartmentName = qVM.DepartmentName,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(education);

                // 創建工作經驗
                var workExperience = new Entities.WorkExperience
                {
                    WorkExperienceFile = qVM.WorkExperienceFile,
                    WorkStartDate = qVM.WorkStartDate,
                    WorkEndDate = qVM.WorkEndDate,
                    WorkName = qVM.WorkName,
                    MemberId = member.MemberId,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(workExperience);

                // 創建課程類別
                var coursecategory = new Entities.CourseCategory
                {
                    CategorytName = qVM.SelectedCategory,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(coursecategory);
                await _repository.SaveChangesAsync();

                // 創建課程主題
                var courseSubject = new Entities.CourseSubject
                {
                    SubjectName = qVM.SelectedSubcategory,
                    CourseCategoryId = coursecategory.CourseCategoryId,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(courseSubject);

                // 創建專業執照
                for (int i = 0; i < qVM.ProfessionalLicenseName.Count; i++)
                {
                    var professionalLicense = new Entities.ProfessionalLicense
                    {
                        ProfessionalLicenseName = qVM.ProfessionalLicenseName[i],
                        ProfessionalLicenseUrl = qVM.ProfessionalLicenseUrl[i],
                        MemberId = member.MemberId,
                        Cdate = DateTime.Now
                    };
                    _repository.Create(professionalLicense);
                }

                await _repository.SaveChangesAsync();
                await _repository.CommitAsync();

                return new TutorResumeViewModel
                {
                    Success = true,
                    Message = "會員履歷新增成功",
                };
            }
            catch (Exception ex)
            {
                // 發生錯誤時回滾並返回錯誤訊息
                await _repository.RollbackAsync();
                var errorMessage = $"資料處理發生錯誤: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $" | 內層錯誤: {ex.InnerException.Message}";
                }

                return new TutorResumeViewModel
                {
                    Success = false,
                    Message = errorMessage
                };
            }
        }


    }

}

