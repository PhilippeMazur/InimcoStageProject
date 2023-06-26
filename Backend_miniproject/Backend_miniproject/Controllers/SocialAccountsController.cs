using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.BLL.Interfaces;
using MiniProject.BLL.Services;
using MiniProject.DAL.Model;
using System.Linq;

namespace Backend_miniproject.Controllers
{
    [Route("api/Persons/[controller]")]
    [ApiController]
    public class SocialAccountsController : ControllerBase
    {
        private ISocialAccountsService _socialAccountService;

        public SocialAccountsController(ISocialAccountsService socialAccountService)
        {
            _socialAccountService = socialAccountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var accounts = _socialAccountService.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skill = _socialAccountService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SocialAccounts account)
        {
            var person = _socialAccountService.Create(account);
            if(person == null)
            {
                return NotFound();
            } else
            {
                return Created("", account);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SocialAccounts account)
        {
            if (_socialAccountService.GetById(id) != null)
            {
                var person = _socialAccountService.Update(id, account);
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_socialAccountService.GetById(id) != null)
            {
                _socialAccountService.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
