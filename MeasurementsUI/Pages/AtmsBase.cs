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

        public string ErrorMessage { get; set; }

        public IEnumerable<Atm> Atms { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Atms = await AtmService.GetAll();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            
        }

        protected async Task DeleteAtm_Click(int id)
        {
            try
            {
                var model = await AtmService.DeleteAtm(id);

                if (model != null)
                {
                    RemoveAtm(id);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
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
