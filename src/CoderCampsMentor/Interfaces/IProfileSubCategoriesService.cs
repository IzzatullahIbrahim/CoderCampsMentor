using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Interfaces
{
    public interface IProfileSubCategoriesService
    {
        UserWithSubCategories GetUserSubCategories(string id);
    }
}