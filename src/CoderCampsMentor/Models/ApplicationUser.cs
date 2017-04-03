using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoderCampsMentor.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public int Experience { get; set; }
        public string GithubLink { get; set; }
        public string Occupation { get; set; }
        public string Birthday { get; set; }
        public ICollection<UserCategory> UserCategory { get; set; }
        public ICollection<UserSubCategory> UserSubCategories { get; set; }
    }
}
