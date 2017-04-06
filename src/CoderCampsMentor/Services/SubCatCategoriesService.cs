using CoderCampsMentor.Interfaces;
using CoderCampsMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    public class SubCatCategoriesService : ISubCatCategoriesService
    {
        private IGenericRepository _repo;

        public SubCatCategoriesService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public SubCategory GetSubCategory(int id)
        {
            SubCategory subCategory = (from sc in _repo.Query<SubCategory>()
                                       where sc.Id == id
                                       select new SubCategory
                                       {
                                           Id = sc.Id,
                                           SubCategoryName = sc.SubCategoryName,
                                           Category = sc.Category,
                                           subCatImageUrl = sc.subCatImageUrl
                                       }).FirstOrDefault();
            return subCategory;
        }
    }
}
