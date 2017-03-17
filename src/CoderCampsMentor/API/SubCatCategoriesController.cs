using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderCampsMentor.Models;
using CoderCampsMentor.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderCampsMentor.API
{
    [Route("api/[controller]")]
    public class SubCatCategoriesController : Controller
    {
        public ISubCatCategoriesService _subCatCatService;

        public SubCatCategoriesController(ISubCatCategoriesService subCatCatService)
        {
            _subCatCatService = subCatCatService;
        }

        [HttpGet("{id}")]
        public SubCategory Get(int id)
        {
            return _subCatCatService.GetSubCategory(id);
        }
    }
}
