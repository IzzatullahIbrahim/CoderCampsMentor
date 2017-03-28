using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoderCampsMentor.ViewModels;
using Microsoft.AspNetCore.Identity;
using CoderCampsMentor.Models;
using CoderCampsMentor.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderCampsMentor.API
{
    [Route("api/[controller]")]
    public class CommsController : Controller
    {
        private ICommService _service;
        private UserManager<ApplicationUser> _manager;

        public CommsController(ICommService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<CommViewModel> Get()
        {
            return _service.GetAllComms();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetCommById(id));
        }

        [HttpGet("AdminGet/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminGet(int id)
        {
            return Ok(_service.GetCommById(id));
        }

        [HttpGet("GetAdminFirstFive")]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<CommViewModel> GetAdminFirstFive()
        {
            return _service.GetAdminFirstFive();
        }

        [HttpGet("GetUserNewMessageCount/")]
        public int GetUserNewMessageCount()
        {
            string uid = _manager.GetUserId(User);
            int count = _service.GetCountCurrentUserNewMessages(uid);
            return count;
        }

        [HttpGet("GetCommsByUserName")]
        [Authorize]
        public IEnumerable<CommViewModel> GetCommsByUserName()
        {
            string uid = _manager.GetUserName(User);
            IList<CommViewModel> commView = _service.GetCommsByUserName(uid);
            return commView;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Comm comm)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveComm(comm, uid);
            return Ok(comm);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.DeleteComm(id);
            return Ok();
        }

        [HttpDelete("AdminGet/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(int id)
        {
            _service.DeleteComm(id);
            return Ok();
        }

    }
}
