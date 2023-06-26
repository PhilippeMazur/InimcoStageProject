using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.BLL.Interfaces;
using MiniProject.BLL.Services;
using MiniProject.DAL.Model;
using System.Linq;
using System.Security.Principal;

namespace Backend_miniproject.Controllers
{
    [Route("api/Person/[controller]")]
    [ApiController]
    public class SocialSkillsController : ControllerBase
    {
        private ISocialSkillsService _socialSkillService;

        public SocialSkillsController(ISocialSkillsService socialSkillsService)
        {
            _socialSkillService = socialSkillsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var skills = _socialSkillService.GetAll();
            
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skill = _socialSkillService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SocialSkills skill)
        {
            var person = _socialSkillService.Create(skill);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Created("", skill);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SocialSkills skill)
        {
            if (_socialSkillService.GetById(id) != null)
            {
                var person = _socialSkillService.Update(id, skill);
                return Ok(skill);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_socialSkillService.GetById(id) != null)
            {
                _socialSkillService.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
