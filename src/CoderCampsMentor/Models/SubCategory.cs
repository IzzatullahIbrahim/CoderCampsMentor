﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public string subCatImageUrl { get; set; }

        public Category Category { get; set; }

        public ICollection<UserSubCategory> UserSubCategories { get; set; }
    }
}
