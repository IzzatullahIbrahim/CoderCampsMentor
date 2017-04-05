using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class CatSubCategoriesService : ICatSubCategoriesService
    {

            private IGenericRepository _repo;

            public CatSubCategoriesService(IGenericRepository repo)
            {
                _repo = repo;
            }

            public Category GetCatSubCat(int id)
            {
                Category category = (from c in _repo.Query<Category>()
                                     where c.Id == id
                                     select new Category
                                     {
                                         Id = c.Id,
                                         CategoryName = c.CategoryName,
                                         SubCategories = c.SubCategories,
                                         catImageUrl = c.catImageUrl
                                     }).FirstOrDefault();
                return category;
            }
        }
}
