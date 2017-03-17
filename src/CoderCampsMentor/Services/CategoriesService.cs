using CoderCampsMentor.Data;
using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using CoderCampsMentor.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IGenericRepository _repo;
        private ApplicationDbContext _db;

        public CategoriesService(IGenericRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = (from c in _repo.Query<Category>()
                                         select new Category
                                         {
                                             Id = c.Id,
                                             CategoryName = c.CategoryName
                                         }).ToList();
            return categories;
        }

        public Category GetCategory(int id)
        {
            Category category = (from c in _repo.Query<Category>()
                                 where c.Id == id
                                 select c).FirstOrDefault();
            return category;
        }

        public CategoryWithUsers GetCategoryWithUsers(int id)
        {
            CategoryWithUsers category = (from c in _repo.Query<Category>()
                                          where c.Id == id
                                          select new CategoryWithUsers
                                          {
                                              Id = c.Id,
                                              CategoryName = c.CategoryName,
                                              ApplicationUsers = (from au in _repo.Query<UserCategory>()
                                                                  where au.CategoryId == c.Id
                                                                  select au.ApplicationUser).ToList()
                                          }).FirstOrDefault();
            return category;
        }

        public void AddCategory(Category category)
        {
            _repo.Add(category);
        }

        public void EditCategory(Category category)
        {
            _repo.Update(category);
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategory(id);

            _repo.Delete(category);
        }
    }
}
