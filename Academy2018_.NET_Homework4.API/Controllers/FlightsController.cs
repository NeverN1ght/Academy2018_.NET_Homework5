using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Shared.DTOs;
using Academy2018_.NET_Homework5.Shared.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Academy2018_.NET_Homework5.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        private readonly IService<FlightDto> _flightsService;

        public FlightsController(IService<FlightDto> flightsService)
        {
            _flightsService = flightsService;
        }

        // GET: api/Flights
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_flightsService.GetAll());
        }

        // GET: api/Flights/5
        [HttpGet("{number}")]
        public IActionResult Get(string number)
        {
            try
            {
                return Ok(_flightsService.GetById(number));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDto dto)
        {
            try
            {
                var createdId = _flightsService.Add(dto);
                return CreatedAtAction("Get",
                    _flightsService.GetById(createdId));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (NullBodyException)
            {
                return BadRequest();
            }
        }
        
        // PUT: api/Flights/5
        [HttpPut("{number}")]
        public IActionResult Put(string number, [FromBody] FlightDto dto)
        {
            try
            {
                _flightsService.Update(number, dto);
                return Ok();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (NullBodyException)
            {
                return BadRequest();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{number}")]
        public IActionResult Delete(string number)
        {
            try
            {
                _flightsService.Delete(number);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
