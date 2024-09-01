
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
        public async Task<TutorResumeListViewModel> GetEducationAsync(int memberId)
        {
            var resumeValues = from e in _repository.GetAll<Education>()
                               join member in _repository.GetAll<Member>() on e.EducationId equals member.EducationId
                               join w in _repository.GetAll<WorkExperience>() on member.MemberId  equals w.MemberId
                               where member.MemberId == 2
                               select new TutorResumeViewModel
                               {
                                   SchoolName = e.SchoolName,
                                   StudyEndYear = e.StudyEndYear,
                                   StudyStartYear = e.StudyStartYear,
                                   DepartmentName = e.DepartmentName,
                                   WorkEndDate = w.WorkEndDate,
                                   WorkStartDate = w.WorkStartDate,
                                   WorkName= w.WorkName,
                               };

            return new TutorResumeListViewModel()
            {
                TutorResumeList = await resumeValues.ToListAsync(),
            };
        }
    }
}