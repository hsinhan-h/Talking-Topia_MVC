namespace ApplicationCore.Interfaces
{
    public interface ITransactionAsync :IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
