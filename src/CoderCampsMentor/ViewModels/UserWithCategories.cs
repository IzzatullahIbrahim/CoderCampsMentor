using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.ViewModels
{
    public class UserWithCategories
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int Experience { get; set; }
        public string GithubLink { get; set; }
        public string Occupation { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public List<Category> Categories { get; set; }
    }
}
