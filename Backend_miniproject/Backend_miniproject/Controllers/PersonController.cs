using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.BLL.Interfaces;
using MiniProject.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Backend_miniproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.GetAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _personService.Create(person);
            return Created("",person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person updatedPerson)
        {
            if(_personService.GetById(id) != null)
            {
                var person = _personService.Update(id, updatedPerson);
                return Ok(updatedPerson);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_personService.GetById(id) != null) {
                _personService.Delete(id);
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}
