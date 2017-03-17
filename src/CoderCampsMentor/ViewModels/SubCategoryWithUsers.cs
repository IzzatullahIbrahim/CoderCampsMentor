using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.ViewModels
{
    public class SubCategoryWithUsers
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
