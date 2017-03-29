using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Services
{
    public interface IProfileCategoriesService
    {
        UserWithCategories GetUserCategories(string id);
    }
}