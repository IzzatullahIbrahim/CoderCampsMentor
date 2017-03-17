using System.Collections.Generic;
using CoderCampsMentor.Models;

namespace CoderCampsMentor.Interfaces
{
    public interface IApplicationUsersService
    {
        List<ApplicationUser> GetAppUsers();
        ApplicationUser GetUser(string id);
        void SaveProfile(ApplicationUser user, string id);
        void UpdateUser(ApplicationUser user);
    }
}