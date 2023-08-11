using MeasurementsWebAPI.BusinessLogic.Models;
using System.Linq.Expressions;

namespace MeasurementsWebAPI.DataAccess.Interfaces
{
    public interface IAtmRepository
    {
        Task<IEnumerable<Atm>> GetAll();        
        Task<Atm?> Get(int id);
        Task<Atm> Insert(Atm atm);
        Task<Atm> Update(Atm atm);
        Task<Atm> Delete(int id);
    }
}
