using MeasurementsModels.Dtos;
using MeasurementsWebAPI.BusinessLogic.Interfaces;
using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeasurementsWebAPI.ServiceAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly IAtmBusinessManager _atmBusinessManager;
        
        public AtmController(IAtmBusinessManager atmBusinessManager)
        {
            _atmBusinessManager = atmBusinessManager;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AtmDto>>> Get()
        {
            try
            {
                var atms = await _atmBusinessManager.GetAll();

                if (atms == null)
                {
                    return NotFound();
                }
                else
                {
                    var atmDtos = atms.ConvertToDto();
                    return Ok(atmDtos);
                }
                
            }
            catch (Exception)
            {
                var errorMessage = "Error retrieving data from database!";                
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtmDto>> Get(int id)
        {
            try
            {
                var atm = await _atmBusinessManager.Get(id);

                if (atm == null)
                {
                    return NotFound();
                }
                else
                {
                    var atmDto = atm.ConvertToDto();
                    return Ok(atmDto);
                }
            }
            catch (Exception)
            {
                var errorMessage = $"Failed to retrieve ATM with ID {id}!";
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }        

        [HttpPost]
        public async Task<ActionResult<AtmDto>> Post([FromBody] AtmDto atmDto)
        {
            try
            {
                var atm = await _atmBusinessManager.Insert(atmDto.ConvertFromDto());

                if (atm == null)
                {
                    return NotFound();
                }
                else
                {
                    var newAtmDto = atm.ConvertToDto();
                    return Ok(newAtmDto);
                }
            }
            catch (Exception)
            {
                var errorMessage = $"Failed to insert new ATM!";
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<AtmDto>> Post(int id, AtmDto atmDto)
        {
            try
            {
                _atmBusinessManager.GetHash(id,atmDto.ConvertFromDto());

                return Ok(atmDto);
            }
            catch (Exception)
            {
                var errorMessage = $"Failed to insert new ATM!";
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<AtmDto>> Patch(int id, AtmDto atmDto)
        {
            try
            {
                var atm = await _atmBusinessManager.Update(atmDto.ConvertFromDto());

                if (atm == null)
                {
                    return NotFound();
                }
                else
                {
                    var newAtmDto = atm.ConvertToDto();
                    return Ok(newAtmDto);
                }
            }
            catch (Exception)
            {
                var errorMessage = $"Failed to update ATM with ID {id}!";
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AtmDto>> Delete(int id)
        {
            try
            {
                var atm = await _atmBusinessManager.Delete(id);

                if (atm == null)
                {
                    return NotFound();
                }
                else
                {
                    var atmDto = atm.ConvertToDto();
                    return Ok(atmDto);
                }
            }
            catch (Exception)
            {

                var errorMessage = $"Failed to delete ATM with ID {id}!";
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }
    }
}
