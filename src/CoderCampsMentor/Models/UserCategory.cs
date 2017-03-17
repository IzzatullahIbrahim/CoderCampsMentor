using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Models
{
    public class UserCategory
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
