
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

        private async Task<Entities.Education> GetEducationByIdAsync(int educationId)
        {
            var education = await _repository.GetAll<Entities.Education>()
                                             .FirstOrDefaultAsync(e => e.EducationId == educationId);

            if (education == null)
            {
                return null;
            }
            return education;
        }
        private async Task<Entities.WorkExperience> GetWorkExperienceByMemberIdAsync(int memberId)
        {
            var workexp = await _repository.GetAll<Entities.WorkExperience>()
                                             .FirstOrDefaultAsync(w => w.MemberId == memberId);

            if (workexp == null)
            {
                return null;
            }
            return workexp;
        }
        private async Task<Entities.ApplyCourse> GetApplyCouseByMemberIdAsync(int memberId)
        {
            var applyCourseHasMember = await _repository.GetAll<Entities.ApplyCourse>()
                                             .FirstOrDefaultAsync(w => w.MemberId == memberId);

            if (applyCourseHasMember == null)
            {
                return null;
            }
            return applyCourseHasMember;
        }
        private async Task<Entities.ProfessionalLicense> GetProfessionalLicenseByMemberIdAsync(string licenseName, int memberId)
        {
            return await _repository.GetAll<Entities.ProfessionalLicense>()
                           .FirstOrDefaultAsync(pl => pl.ProfessionalLicenseName == licenseName && pl.MemberId == memberId);
        }

        
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

                // 更新會員資料
                existingMember.IsVerifiedTutor = false;
                existingMember.HeadShotImage = qVM.HeadShotImage;
                existingMember.Cdate = DateTime.Now;
                existingMember.Udate = null;
                existingMember.FirstName = existingMember.FirstName ?? "N/A";
                existingMember.LastName = existingMember.LastName ?? "N/A";
                existingMember.Password = existingMember.Password ?? "N/A";
                existingMember.Email = existingMember.Email ?? "N/A";
                existingMember.Nickname = existingMember.Nickname ?? "N/A";
                existingMember.Phone = existingMember.Phone ?? "N/A";
                existingMember.Gender = (short)(existingMember.Gender != 0 ? existingMember.Gender : 0);
                existingMember.AccountType = (existingMember.AccountType != 0 ? existingMember.AccountType : 0);
                existingMember.IsTutor = false;

                // 創建或更新教育經歷
                Entities.Education education;

                // 如果 Member 已有 EducationId，則更新教育經歷
                if (existingMember.EducationId.HasValue)
                {
                    // 根據 EducationId 查詢現有的教育經歷
                    education = await GetEducationByIdAsync(existingMember.EducationId.Value);
                    if (education == null)
                    {
                        return new TutorResumeViewModel
                        {
                            Success = false,
                            Message = "找不到該會員的教育經歷。",
                        };
                    }

                    // 更新現有教育經歷
                    education.SchoolName = qVM.SchoolName;
                    education.StudyStartYear = qVM.StudyStartYear;
                    education.StudyEndYear = qVM.StudyEndYear;
                    education.DepartmentName = qVM.DepartmentName;
                    education.Udate = DateTime.Now; 
                    _repository.Update(education);
                }
                else
                {
                    // 創建新的教育經歷
                    education = new Entities.Education
                    {
                        SchoolName = qVM.SchoolName,
                        StudyStartYear = qVM.StudyStartYear,
                        StudyEndYear = qVM.StudyEndYear,
                        DepartmentName = qVM.DepartmentName,
                        Cdate = DateTime.Now,  
                        Udate = DateTime.Now   
                    };

                    _repository.Create(education);
                    await _repository.SaveChangesAsync(); 

                    existingMember.EducationId = education.EducationId;
                }

                // 創建工作經驗
                var workExperience = await GetWorkExperienceByMemberIdAsync(existingMember.MemberId);

                if (workExperience != null)
                {
                    // 如果有工作經歷，則更新
                    workExperience.WorkExperienceFile = qVM.WorkExperienceFile;
                    workExperience.WorkStartDate = qVM.WorkStartDate;
                    workExperience.WorkEndDate = qVM.WorkEndDate;
                    workExperience.WorkName = qVM.WorkName;
                    workExperience.Udate = DateTime.Now;
                    _repository.Update(workExperience);
                }
                else
                {
                    // 如果沒有工作經歷，則創建新的
                    workExperience = new Entities.WorkExperience
                    {
                        WorkExperienceFile = qVM.WorkExperienceFile,
                        WorkStartDate = qVM.WorkStartDate,
                        WorkEndDate = qVM.WorkEndDate,
                        WorkName = qVM.WorkName,
                        MemberId = existingMember.MemberId,  // 關聯到會員的 MemberId
                        Cdate = DateTime.Now,
                        Udate = DateTime.Now,
                    };
                    _repository.Create(workExperience);
                }




                var applyCourse = await GetApplyCouseByMemberIdAsync(existingMember.MemberId);
                if (applyCourse != null)
                {
                    // 如果找到 ApplyCourse 記錄，進行更新
                    
                        applyCourse.ApplyCourseCategoryId = qVM.CourseList.ApplyCourseCategoryId;
                        applyCourse.ApplySubCategoryId = qVM.CourseList.ApplySubCategoryId;

                        // 更新 ApplyCourse 表中的其他欄位，根據需求
                        applyCourse.Udate = DateTime.Now; // 更新日期
                        _repository.Update(applyCourse);
                    
                }

                // 創建課程類別
                else
                {
                    // 如果沒有找到 ApplyCourse 記錄，則創建新的 ApplyCourse 記錄
                   
                        var newApplyCourse = new Entities.ApplyCourse
                        {
                            MemberId = existingMember.MemberId,  // 關聯到會員的 MemberId
                            ApplyCourseCategoryId = qVM.CourseList.ApplyCourseCategoryId,
                            ApplySubCategoryId = qVM.CourseList.ApplySubCategoryId,
                            Cdate = DateTime.Now,  // 創建日期
                            Udate = DateTime.Now   // 更新日期
                        };

                        _repository.Create(newApplyCourse);
                    
                }
                for (int i = 0; i < qVM.ProfessionalLicenseName.Count; i++)
                {
                    // 檢查此會員是否已有相同名稱的專業執照
                    var existingLicense = await GetProfessionalLicenseByMemberIdAsync(qVM.ProfessionalLicenseName[i], existingMember.MemberId);

                    if (existingLicense == null)
                    {
                        // 創建新的執照
                        var professionalLicense = new Entities.ProfessionalLicense
                        {
                            ProfessionalLicenseName = qVM.ProfessionalLicenseName[i],
                            ProfessionalLicenseUrl = qVM.ProfessionalLicenseUrl[i],
                            MemberId = existingMember.MemberId,
                            Cdate = DateTime.Now
                        };
                        _repository.Create(professionalLicense);
                    }
                    else
                    {
                        // 更新現有的執照
                        existingLicense.ProfessionalLicenseUrl = qVM.ProfessionalLicenseUrl[i];
                        existingLicense.Udate = DateTime.Now;
                        _repository.Update(existingLicense);
                    }
                }
                await _repository.SaveChangesAsync();
                await _repository.CommitAsync();
                return new TutorResumeViewModel
                {
                    Success = true,
                    Message = "履歷已成功新增/更新。",
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

