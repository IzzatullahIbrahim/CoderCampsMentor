using CoderCampsMentor.Data;
using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using CoderCampsMentor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class UserCategoriesService : IUserCategoriesService
    {
        private IGenericRepository _repo;
        private ApplicationDbContext _db;

        public UserCategoriesService(IGenericRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public UserWithCategories GetUserCategories(string id)
        {
            UserWithCategories appUser = (from au in _repo.Query<ApplicationUser>()
                                          where au.Id == id
                                          select new UserWithCategories
                                          {
                                              Id = au.Id,
                                              FirstName = au.FirstName,
                                              Picture = au.Picture,
                                              LastName = au.LastName,
                                              Location = au.Location,
                                              Categories = (from uc in _repo.Query<UserCategory>()
                                                            where uc.ApplicationUserId == au.Id
                                                            select uc.Category).ToList(),
                                          }).FirstOrDefault();
            return appUser;
        }

        public void EditUserCategories(UserWithCategories applicationUser)
        {
            foreach (Category category in applicationUser.Categories)
            {
                _db.UserCategories.Add(new UserCategory { ApplicationUserId = applicationUser.Id, CategoryId = category.Id });
            }
            _db.SaveChanges();
        }
    }
}
