using PruebaTecnicaKaprielian.Interfaces;
using PruebaTecnicaKaprielian.Models;

namespace PruebaTecnicaKaprielian.Repositories
{
    public class ClientesRepository : Repository<Clientes>
    {
        public ClientesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
