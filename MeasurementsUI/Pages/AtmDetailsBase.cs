using MeasurementsModels.Dtos;
using MeasurementsUI.Extensions;
using MeasurementsUI.Models;
using MeasurementsUI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MeasurementsUI.Pages
{
    public class AtmDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; } = 0;

        [Inject]
        public IAtmService AtmService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Atm Atm { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (Id > 0)
                    Atm = await AtmService.GetAtm(Id);
                else
                    Atm = new Atm();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task UpdateATM()
        {
            var model = await AtmService.UpdateAtm(Atm.ConvertToDto());

            if (model != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }

        protected async Task SaveATM()
        {
            
            var model = await AtmService.InsertAtm(Atm.ConvertToDto());

            if (model != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }

        protected async Task GetAtmHash_Click()
        {
            var model = await AtmService.GetAtmHash(Atm.ConvertToDto());

            if (model != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }
    }
}
