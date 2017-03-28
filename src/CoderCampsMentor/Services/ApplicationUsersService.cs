using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private IGenericRepository _repo;

        public ApplicationUsersService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<ApplicationUser> GetAppUsers()
        {
            List<ApplicationUser> appUsers = (from au in _repo.Query<ApplicationUser>()
                                              select new ApplicationUser
                                              {
                                                  Id = au.Id,
                                                  FirstName = au.FirstName,
                                                  LastName = au.LastName,
                                                  Picture = au.Picture,
                                                  UserName = au.UserName,
                                                  Location = au.Location
                                              }).ToList();
            return appUsers;
        }
        public ApplicationUser GetUser(string id)
        {
            ApplicationUser user = (from u in _repo.Query<ApplicationUser>()
                                    where u.UserName == id
                                    select new ApplicationUser
                                    {
                                        Id = u.Id,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        Email = u.Email,
                                        ConcurrencyStamp = u.ConcurrencyStamp,
                                        Picture = u.Picture,
                                        UserName = u.UserName,
                                        Location = u.Location

                                    }).FirstOrDefault();
            return user;
        }
        public void UpdateUser(ApplicationUser user)
        {
            _repo.Update(user);
        }
        public void SaveProfile(ApplicationUser user, string id)
        {
            var input = (from u in _repo.Query<ApplicationUser>()
                         where u.Id == id
                         select u).FirstOrDefault();
            input.Picture = user.Picture;
            input.FirstName = user.FirstName;
            input.LastName = user.LastName;
            input.PhoneNumber = user.PhoneNumber;
            input.UserName = user.UserName;
            _repo.SaveChanges();
        }
    }
}
