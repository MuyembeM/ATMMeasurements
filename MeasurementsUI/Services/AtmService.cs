using MeasurementsModels.Dtos;
using MeasurementsUI.Extensions;
using MeasurementsUI.Models;
using MeasurementsUI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeasurementsUI.Services
{
    public class AtmService : IAtmService
    {
        private readonly HttpClient _httpClient;

        public AtmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Atm> DeleteAtm(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/v1/atm/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var atmDto = await response.Content.ReadFromJsonAsync<AtmDto>();
                    var atm = atmDto.ConvertFromDto();
                    return atm;
                }
                return default(Atm);
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
                var response = await _httpClient.GetAsync("api/v1/atm");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Atm>();
                    }

                    var atmDtos = await response.Content.ReadFromJsonAsync<IEnumerable<AtmDto>>();
                    var atms = atmDtos.ConvertFromDto();
                    return atms;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<Atm> GetAtm(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/v1/atm/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Atm);
                    }

                    var atmDto = await response.Content.ReadFromJsonAsync<AtmDto>();
                    var atm = atmDto.ConvertFromDto();
                    return atm;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Atm> GetAtmHash(AtmDto atmDto)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(atmDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/v1/atm/{atmDto.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    atmDto = await response.Content.ReadFromJsonAsync<AtmDto>();
                    var atm = atmDto.ConvertFromDto();
                    return atm;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Atm> InsertAtm(AtmDto atmDto)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(atmDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/v1/atm/", content);

                if (response.IsSuccessStatusCode)
                {
                    atmDto = await response.Content.ReadFromJsonAsync<AtmDto>();
                    var atm = atmDto.ConvertFromDto();
                    return atm;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Atm> UpdateAtm(AtmDto atmDto)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(atmDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/v1/atm/{atmDto.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    atmDto = await response.Content.ReadFromJsonAsync<AtmDto>();
                    var atm = atmDto.ConvertFromDto();
                    return atm;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
