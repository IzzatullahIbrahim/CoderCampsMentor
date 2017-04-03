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
    public class UserSubCategoriesService : IUserSubCategoriesService
    {
        private IGenericRepository _repo;
        private ApplicationDbContext _db;

        public UserSubCategoriesService(IGenericRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public UserWithSubCategories GetUserSubCategories(string id)
        {
            UserWithSubCategories appUser = (from au in _repo.Query<ApplicationUser>()
                                             where au.Id == id
                                             select new UserWithSubCategories
                                             {
                                                 Id = au.Id,
                                                 FirstName = au.FirstName,
                                                 LastName = au.LastName,
                                                 Picture = au.Picture,
                                                 Location = au.Location,
                                                 Email = au.Email,
                                                 Bio = au.Bio,
                                                 Experience = au.Experience,
                                                 GithubLink = au.GithubLink,
                                                 Occupation = au.Occupation,
                                                 Birthday = au.Birthday,
                                                 PhoneNumber = au.PhoneNumber,
                                                 SubCategories = (from usc in _repo.Query<UserSubCategory>()
                                                                  where usc.ApplicationUserId == au.Id
                                                                  select usc.SubCategory).ToList()
                                             }).FirstOrDefault();
            return appUser;
        }

        public void EditUserSubCategories(UserWithSubCategories applicationUser)
        {
            foreach (SubCategory subCategory in applicationUser.SubCategories)
            {
                _db.UserSubCategories.Add(new UserSubCategory { ApplicationUserId = applicationUser.Id, SubCategoryId = subCategory.Id });
            }
            _db.SaveChanges();
        }
    }
}
