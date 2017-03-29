using CoderCampsMentor.Interfaces;
using CoderCampsMentor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.API
{
    [Route("api/[controller]")]
    public class ProfileSubCategoriesController
    {
        private IProfileSubCategoriesService _pscService;

        public ProfileSubCategoriesController(IProfileSubCategoriesService pscService)
        {
            _pscService = pscService;
        }

        [HttpGet("{id}")]
        public UserWithSubCategories Get(string id)
        {
            return _pscService.GetUserSubCategories(id);
        }
    }
}
