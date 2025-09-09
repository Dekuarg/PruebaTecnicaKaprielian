namespace PruebaTecnicaKaprielian.Interfaces
{
    public interface IUnitOfWork
    {
        NHibernate.ISession GetCurrentSession();
        Task Commit();
        void BeginTransaction();
    }
}
