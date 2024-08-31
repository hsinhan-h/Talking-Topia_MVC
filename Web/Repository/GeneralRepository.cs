using Web.Entities;

namespace Web.Repository
{
    public class GeneralRepository : IRepository
    {
        private readonly TalkingTopiaContext _context;
        public GeneralRepository(TalkingTopiaContext context)
        {
            _context = context;
        }

        public void Create<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Added;
        }

        public void Update<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Modified;
        }

        public void Delete<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Deleted;
        }

        //public T Get<T>(int id) where T : class
        //{
        //    return _context.Set<T>().Find(id);
        //}

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
