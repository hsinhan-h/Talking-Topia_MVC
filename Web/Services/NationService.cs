namespace Web.Services
{
    public class NationService
    {
        private readonly IRepository _repository;

        public NationService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Nation>> GetNations()
        {
            var nations = await _repository.GetAll<Nation>().ToListAsync();
            return nations;
        }
    }
}
