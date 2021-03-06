﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string catImageUrl { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

        public ICollection<UserCategory> UserCategories { get; set; }
    }
}
