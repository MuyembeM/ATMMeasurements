using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Linq.Expressions;

namespace MeasurementsWebAPI.DataAccess
{
    public class AtmRepository : IAtmRepository
    {
        private readonly MeasurementsDBContext _dbContext;
        
        public AtmRepository(MeasurementsDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        public async Task<Atm> Delete(int id)
        {
            var entityToDelete = await _dbContext.Atms.FindAsync(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
            return entityToDelete;
        }

        public void Delete(Atm entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Atms.Attach(entityToDelete);
            }
            _dbContext.Atms.Remove(entityToDelete);
            _dbContext.SaveChanges();
        }

        public async Task<Atm?> Get(int id)
        {
            return await _dbContext.Atms.FindAsync(id);
        }

        public async Task<IEnumerable<Atm>> GetAll()
        {
            return await _dbContext.Atms.ToListAsync();
        }

        public async Task<Atm> Insert(Atm atm)
        {
            _dbContext.Atms.Add(atm);
            _dbContext.SaveChanges();
            return await _dbContext.Atms.OrderBy(x=>x.Id).LastOrDefaultAsync();
        }

        public async Task<Atm> Update(Atm entityToUpdate)
        {
            _dbContext.Atms.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entityToUpdate;
        }
    }
}
