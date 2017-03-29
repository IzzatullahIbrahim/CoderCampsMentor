using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using CoderCampsMentor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class ProfileSubCategoriesService : IProfileSubCategoriesService
    {
        private IGenericRepository _repo;

        public ProfileSubCategoriesService(IGenericRepository repo)
        {
            _repo = repo;
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
                                                 SubCategories = (from usc in _repo.Query<UserSubCategory>()
                                                                  where usc.ApplicationUserId == au.Id
                                                                  select usc.SubCategory).ToList()
                                             }).FirstOrDefault();
            return appUser;
        }
    }
}
