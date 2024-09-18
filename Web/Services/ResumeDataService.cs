
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
        public async Task<TutorResumeViewModel> AddResumeAsync(TutorResumeViewModel qVM)
        {
            await _repository.BeginTransActionAsync();
            try
            {
                var member = new Member
                {
                    IsVerifiedTutor = false,
                    HeadShotImage = qVM.HeadShotImage,
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
                    IsTutor = true
                };
                _repository.Create(member);

                var education = new Education
                {
                    SchoolName = qVM.SchoolName,
                    StudyStartYear = qVM.StudyStartYear,
                    StudyEndYear = qVM.StudyEndYear,
                    DepartmentName = qVM.DepartmentName,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(education);

                var workExperience = new WorkExperience
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

                var coursecategory = new CourseCategory
                {
                    CategorytName = qVM.SelectedCategory,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(coursecategory);
                await _repository.SaveChangesAsync();

                var courseSubject = new CourseSubject
                {
                    SubjectName = qVM.SelectedSubcategory,
                    CourseCategoryId = coursecategory.CourseCategoryId, 
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(courseSubject);

                for (int i = 0; i < qVM.ProfessionalLicenseName.Count; i++)
                {
                    var professionalLicense = new ProfessionalLicense
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
                // 詳細記錄例外的完整錯誤訊息
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

