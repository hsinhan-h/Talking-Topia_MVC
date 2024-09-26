namespace ApplicationCore.Interfaces
{
    public interface ITransaction : ITransactionAsync
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

    }
}
