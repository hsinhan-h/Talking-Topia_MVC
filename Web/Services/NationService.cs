using ApplicationCore.Entities;

namespace Web.Services
{
    public class NationService
    {
        private readonly IRepository _repository;

        public NationService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Web.Entities.Nation>> GetNationsAsync()
        {
            var nations = await _repository.GetAll<Web.Entities.Nation>().ToListAsync();
            return nations;
        }

        public async Task<List<string>> GetNationNamesAsync()
        {
            var nationNames = await _repository.GetAll<Web.Entities.Nation>()
                .Select(n => n.NationName)
                .ToListAsync();
            return nationNames;
        }
    }
}
