using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Shared.DTOs;
using Academy2018_.NET_Homework5.Shared.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.API.Controllers
{
    [Produces("application/json")]
    [Route("api/AirplaneTypes")]
    public class AirplaneTypesController : Controller
    {
        private readonly IService<AirplaneTypeDto> _airplaneTypesService;

        public AirplaneTypesController(IService<AirplaneTypeDto> airplaneTypesService)
        {
            _airplaneTypesService = airplaneTypesService;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_airplaneTypesService.GetAll());
        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_airplaneTypesService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/AirplaneTypes
        [HttpPost]
        public IActionResult Post([FromBody]AirplaneTypeDto dto)
        {
            try
            {
                var createdId = _airplaneTypesService.Add(dto);
                return CreatedAtAction("Get",
                    _airplaneTypesService.GetById(createdId));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (NullBodyException)
            {
                return BadRequest();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
        
        // PUT: api/AirplaneTypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AirplaneTypeDto dto)
        {
            try
            {
                _airplaneTypesService.Update(id, dto);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _airplaneTypesService.Delete(id);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
