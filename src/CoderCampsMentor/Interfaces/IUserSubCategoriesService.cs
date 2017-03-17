using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Interfaces
{
    public interface IUserSubCategoriesService
    {
        void EditUserSubCategories(UserWithSubCategories applicationUser);
        UserWithSubCategories GetUserSubCategories(string id);
    }
}