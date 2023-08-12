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

        public AtmViewModel Atm { get; set; } = new AtmViewModel();

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (Id > 0)
                    Atm.Atm = await AtmService.GetAtm(Id);
                else
                {
                    Atm.Atm = new Atm();
                    
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task UpdateATM()
        {
            try
            {
                if (Atm.Atm != null)
                {
                    var model = await AtmService.UpdateAtm(Atm.Atm.ConvertToDto());

                    if (model != null)
                    {
                        NavigationManager.NavigateTo("/");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task SaveATM()
        {
            try
            {
                if (Atm.Atm != null)
                {
                    var model = await AtmService.InsertAtm(Atm.Atm.ConvertToDto());

                    if (model != null)
                    {
                        NavigationManager.NavigateTo("/");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
                       

        }

        protected async Task GetAtmHash_Click()
        {
            try
            {
                if (Atm.Atm != null)
                {
                    var model = await AtmService.GetAtmHash(Atm.Atm.ConvertToDto());

                    if (model != null)
                    {
                        Atm.AtmHash = model.Hash;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            

        }
    }
}
