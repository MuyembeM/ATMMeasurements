using MeasurementsModels.Dtos;
using MeasurementsUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeasurementsUI.Services.Interfaces
{
    public interface IAtmService
    {
        Task<IEnumerable<Atm>> GetAll();
        Task<Atm> GetAtm(int id);
        Task<Atm> DeleteAtm(int id);
        Task<Atm> UpdateAtm(AtmDto atm);
        Task<Atm> InsertAtm(AtmDto atm);
        Task<AtmDto> GetAtmHash(AtmDto atm);
    }
}
