using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Linq.Expressions;

namespace MeasurementsWebAPI.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MeasurementsDBContext _dbContext;
        
        public Repository(MeasurementsDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        public async Task<T> Delete(object id)
        {
            var entityToDelete = await _dbContext.Set<T>().FindAsync(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
            return entityToDelete;
        }

        public void Delete(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entityToDelete);
            }
            _dbContext.Set<T>().Remove(entityToDelete);
            _dbContext.SaveChanges();
        }

        public async Task<T> Get(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Insert(T entity, Expression<Func<T, object>> predicate)
        {
            
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return await _dbContext.Set<T>().OrderBy(predicate).LastOrDefaultAsync();
        }

        public async Task<T> Update(T entityToUpdate)
        {
            _dbContext.Set<T>().Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entityToUpdate;
        }
    }
}
