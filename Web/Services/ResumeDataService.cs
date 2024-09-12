
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
        public async Task<(bool Success, string Message)> AddResumeAsync(TutorResumeViewModel qVM)
        {
            try
            {
                var member = new Member
                {
                    IsVerifiedTutor = true,
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
                    IsTutor = false
                };
                _repository.Create(member);
                await _repository.SaveChangesAsync(); 

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
                await _repository.SaveChangesAsync(); 

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
                await _repository.SaveChangesAsync();

                var coursecategory = new CourseCategory
                {
                    CategorytName = qVM.SelectedCategory,
                    Cdate = DateTime.Now,
                    Udate = null

                };
                _repository.Create(coursecategory);
                await _repository.SaveChangesAsync();

                foreach (var licenseName in qVM.ProfessionalLicenseName)
                {
                    var professionalLicense = new ProfessionalLicense
                    {
                        ProfessionalLicenseName = licenseName,
                        Cdate = DateTime.Now
                    };
                    _repository.Create(professionalLicense);
                }
                foreach (var licenseurl in qVM.ProfessionalLicenseUrl)
                {
                    var professionalLicenseurl = new ProfessionalLicense
                    {
                        ProfessionalLicenseName = licenseurl
                    };
                    _repository.Create(professionalLicenseurl);
                }
                await _repository.SaveChangesAsync();

                var courseSubject = new CourseSubject
                {
                    SubjectName = qVM.SelectedSubcategory,
                    CourseCategoryId= coursecategory.CourseCategoryId,
                    Cdate = DateTime.Now,
                    Udate = null

                };
                _repository.Create(courseSubject);
                await _repository.SaveChangesAsync();

                return (true, "新增資料成功");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? "無其他詳細錯誤訊息";
                return (false, $"錯誤訊息: {ex.Message}. 內部錯誤訊息: {innerException}");
            }
        }

    }

}

