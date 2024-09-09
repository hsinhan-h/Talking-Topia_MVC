

namespace Web.Repository
{
    public interface IRepository
    {
        void Create<T>(T value) where T : class;
        void Delete<T>(T value) where T : class;
        void Dispose();
        //T Get<T>(int id) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        void SaveChanges();
        void Update<T>(T value) where T : class;
        T FirstOrDefault<T>(Func<T, bool> predicate) where T : class;
        Task SaveChangesAsync();
    }
}