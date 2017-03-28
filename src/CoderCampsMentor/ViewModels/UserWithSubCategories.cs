using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.ViewModels
{
    public class UserWithSubCategories
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
