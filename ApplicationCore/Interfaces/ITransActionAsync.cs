namespace ApplicationCore.Interfaces
{
    public interface ITransactionAsync
    {
        Task BeginTransActionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
