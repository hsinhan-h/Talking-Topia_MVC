
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
            var resumeValues = await _repository.GetAll<Education>()
                .Where(e => e.EducationId == memberId) 
                .Select(r => new TutorResumeViewModel
                {
                    SchoolName = r.SchoolName
                }).ToListAsync();

            return new TutorResumeListViewModel()
            {
                TutorResumeList = resumeValues,
            };
        }
    }
}