using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderCampsMentor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CoderCampsMentor.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderCampsMentor.API
{
    [Route("api/[controller]")]
    public class ApplicationUsersController : Controller
    {
        private IApplicationUsersService _auService;
        private UserManager<ApplicationUser> _manager;

        public ApplicationUsersController(IApplicationUsersService auService, UserManager<ApplicationUser> manager)
        {
            _auService = auService;
            _manager = manager;
        }

        [HttpGet]
        [Authorize]
        public List<ApplicationUser> Get()
        {
            return _auService.GetAppUsers();
        }
        [HttpGet("{id}")]
        [Authorize]
        public ApplicationUser GetSingleDetail(string id)
        {
            return _auService.GetUser(User.Identity.Name);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var uid = _manager.GetUserId(User);
                _auService.SaveProfile(user, uid);
                return Ok();
            }
            else if (user.Id == null)
            {
                return BadRequest();
            }
            else
            {
                _auService.UpdateUser(user);
                return Ok();
            }
        }
    }
}
