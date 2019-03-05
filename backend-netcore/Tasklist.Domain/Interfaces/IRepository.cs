using System.Linq;
using Tasklist.Domain.Entities;

namespace Tasklist.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        long SaveOrUpdate(TEntity entity);

        bool Delete(TEntity entity);

        bool Delete(long id);

        IQueryable<TEntity> Query();

        TEntity GetById(long id);

        IQueryable<TEntity> QueryAsNoTracking();
    }
}
