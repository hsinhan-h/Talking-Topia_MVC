namespace ApplicationCore.Interfaces
{
    public interface ITransaction : ITransactionAsync
    {
        void BeginTransAction();
        void Commit();
        void Rollback();

    }
}
