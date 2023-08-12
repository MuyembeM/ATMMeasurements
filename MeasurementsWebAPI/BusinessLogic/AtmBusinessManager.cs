using MeasurementsWebAPI.BusinessLogic;
using MeasurementsWebAPI.BusinessLogic.Interfaces;
using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.DataAccess.Interfaces;
using System.Linq.Expressions;


namespace MeasurementsWebAPI.BusinessManager
{
    public class AtmBusinessManager : IAtmBusinessManager
    {
        private readonly IAtmRepository _repository;
        
        public AtmBusinessManager(IAtmRepository repository)
        {
            _repository = repository;
        }

        public async Task<Atm> Delete(int id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Atm> Get(int id)
        {
            try
            {
                return await _repository.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<Atm>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Atm> Insert(Atm atm)
        {
            try
            {
                return await _repository.Insert(atm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Atm> Update(Atm atm)
        {
            try
            {
                return await _repository.Update(atm);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
