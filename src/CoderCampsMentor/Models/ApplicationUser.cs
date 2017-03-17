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

        public ICollection<UserCategory> UserCategory { get; set; }
        public ICollection<UserSubCategory> UserSubCategories { get; set; }
    }
}