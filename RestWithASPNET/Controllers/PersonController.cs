using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Services.Interfaces;

namespace RestWithASPNET.Controllers
{    
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _appService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var personList = _appService.FindAll();
            return Ok(personList);
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
        public IActionResult Post([FromBody]PersonVO person)
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
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var result = _appService.Update(person);

            if (result == null)
                return NoContent();
            else
                return new ObjectResult(result);
        }
    }
}
