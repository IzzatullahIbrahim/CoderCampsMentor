using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Interfaces
{
    public interface IUserCategoriesService
    {
        void EditUserCategories(UserWithCategories applicationUser);
        UserWithCategories GetUserCategories(string id);
    }
}