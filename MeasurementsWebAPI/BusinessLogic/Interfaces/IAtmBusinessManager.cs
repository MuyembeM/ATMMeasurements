using MeasurementsModels.Dtos;
using MeasurementsWebAPI.BusinessLogic.Models;
using System.Linq.Expressions;

namespace MeasurementsWebAPI.BusinessLogic.Interfaces
{
    public interface IAtmBusinessManager
    {
        Task<IEnumerable<Atm>> GetAll();
        Task<Atm> Get(int id);
        Task<Atm> Insert(Atm atm);
        Task<Atm> Update(Atm atm);
        Task<Atm> Delete(int id);
        void GetHash(int id, Atm atm);
    }
}
