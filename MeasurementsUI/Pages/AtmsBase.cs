using MeasurementsModels.Dtos;
using MeasurementsUI.Models;
using MeasurementsUI.Services;
using MeasurementsUI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MeasurementsUI.Pages
{
    public class AtmsBase : ComponentBase
    {
        [Inject]
        public IAtmService AtmService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Atm> Atms { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Atms = await AtmService.GetAll();
        }

        protected async Task DeleteAtm_Click(int id)
        {
            var model = await AtmService.DeleteAtm(id);

            if (model != null)
            {
                RemoveAtm(id);
            }           

        }

        private Atm GetAtm(int id)
        {
            return Atms.FirstOrDefault(x => x.Id == id);
        }

        private void RemoveAtm(int id)
        {
            var tempList = Atms.ToList();
            var atm = GetAtm(id);

            if (tempList.Remove(atm))
                Atms = tempList.AsEnumerable();
        }
    }
}
