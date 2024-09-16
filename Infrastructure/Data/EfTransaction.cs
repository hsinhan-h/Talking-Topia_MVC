using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _transaction.Commit();
            _transaction.Dispose();
        }
        public async Task CommitAsync()
        {
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
