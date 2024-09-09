
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
                // 創建 Member 實體並保存
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
                _repository.SaveChanges();

                // 創建 Education 實體
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
                _repository.SaveChanges();

                // 創建 WorkExperience 實體並設置 MemberId
                var workExperience = new WorkExperience
                {
                    WorkExperienceFile = qVM.WorkExperienceFile,
                    WorkStartDate = qVM.WorkStartDate,
                    WorkEndDate =qVM.WorkEndDate,
                    WorkName = qVM.WorkName,
                    MemberId = member.MemberId,
                    Cdate = DateTime.Now,
                    Udate = null
                };
                _repository.Create(workExperience);
                _repository.SaveChanges();

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

