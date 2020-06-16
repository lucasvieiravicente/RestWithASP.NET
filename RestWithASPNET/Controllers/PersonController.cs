using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Services.Interfaces;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _appService;

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appService.FindAll());
        }

        [HttpGet("{personId}")]        
        public IActionResult Get(Guid personId)
        {
            var person = _appService.FindById(personId);

            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return new ObjectResult(_appService.Create(person));
        }

        [HttpDelete("{personId}")]
        public IActionResult Delete(Guid personId)
        {
            _appService.Delete(personId);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return new ObjectResult(_appService.Update(person));
        }
    }
}
