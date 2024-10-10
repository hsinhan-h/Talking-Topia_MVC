using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    public class EfTransaction : ITransaction
    {
        protected readonly TalkingTopiaDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public EfTransaction(TalkingTopiaDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>(); 
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }
            var repo = new EfRepository<T>(_dbContext);
            _repositories.Add(typeof(T), repo);
            return repo;
        }
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}
