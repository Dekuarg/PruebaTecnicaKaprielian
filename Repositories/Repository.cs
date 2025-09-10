using NHibernate.Linq;
using PruebaTecnicaKaprielian.Extensions;
using PruebaTecnicaKaprielian.Interfaces;
using System.Linq.Expressions;

namespace PruebaTecnicaKaprielian.Repositories
{
    public class Repository<T> :IRepository<T> where T : class
    {
        protected NHibernate.ISession Session { get { return _unitOfWork.Session; } }
        private readonly UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task AddAsync(T entity)
        {            
         await Session.SaveAsync(entity); 
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await Session
                .CreateCriteria<T>()
                .ListAsync<T>();
        }

        private IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public async Task<T> FindByAsync(Expression<Func<T, bool>> expression)
        {
            return await FilterBy(expression).SingleOrDefaultAsync();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            await Session.UpdateAsync(entity);
            await Session.FlushAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Session.DeleteAsync(entity);
            await Session.FlushAsync();

        }
    }
}
