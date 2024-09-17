using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    public class EfTransaction : ITransaction
    {
        protected readonly TalkingTopiaContext _dbContext;
        private IDbContextTransaction _transaction;
        public EfTransaction(TalkingTopiaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransAction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public async Task BeginTransActionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            if (_transaction == null) throw new InvalidOperationException("Transaction has not been started.");
            _transaction.Commit();
            _transaction.Dispose();
        }
        public async Task CommitAsync()
        {
            if (_transaction == null) throw new InvalidOperationException("Transaction has not been started.");
            await _transaction.CommitAsync();
            _transaction.Dispose();
        }
        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
        }
    }
}
