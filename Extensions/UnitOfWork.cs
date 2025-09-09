using MySqlX.XDevAPI;
using NHibernate;
using PruebaTecnicaKaprielian.Interfaces;

namespace PruebaTecnicaKaprielian.Extensions
{
    public class UnitOfWork(NHibernate.ISession session) : IUnitOfWork 
    {
        public NHibernate.ISession Session { get; } = session;

        public void BeginTransaction()
        {
            Session.BeginTransaction();
        }

        public async Task Commit()
        {
            var currentTransaction = Session.GetCurrentTransaction();

            if (currentTransaction == null)
                return;

            try
            {
                await currentTransaction.CommitAsync();
            }
            catch (Exception)
            {
                await currentTransaction.RollbackAsync();
            }
        }

        public NHibernate.ISession GetCurrentSession()
        {
            return Session;
        }
    }
}
