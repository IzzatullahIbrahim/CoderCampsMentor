using System.Collections.Generic;
using CoderCampsMentor.Models;
using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Interfaces
{
    public interface ISubCategoriesService
    {
        void AddSubCategory(SubCategory subCategory);
        void DeleteSubCategory(int id);
        void EditSubCategory(SubCategory subCategory);
        List<SubCategory> GetSubCategories();
        SubCategory GetSubCategory(int id);
        SubCategoryWithUsers GetSubCategoryWithUsers(int id);
    }
}