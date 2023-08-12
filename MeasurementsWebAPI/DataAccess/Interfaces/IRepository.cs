using MeasurementsWebAPI.BusinessLogic.Models;
using System.Linq.Expressions;

namespace MeasurementsWebAPI.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();        
        Task<T> Get(object id);
        Task<T> Insert(T entity, Expression<Func<T, object>> predicate);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
    }
}
