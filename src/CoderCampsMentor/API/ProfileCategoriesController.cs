using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderCampsMentor.Interfaces;
using CoderCampsMentor.ViewModels;
using CoderCampsMentor.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderCampsMentor.API
{
    [Route("api/[controller]")]
    public class ProfileCategoriesController : Controller
    {
        private IProfileCategoriesService _pcService;

        public ProfileCategoriesController(IProfileCategoriesService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet("{id}")]
        public UserWithCategories Get(string id)
        {
            return _pcService.GetUserCategories(id);
        }
    }
}
