using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface ICategoryService
    {
        ServiceResult AddMainCategory(CreateMainCategoryModel model);
        bool IsMainCategoryExist(string name);
        IQueryable<MainCategoryListModel> GetAllMainCategories();
        IQueryable<CategoryListModel> GetAllCategories();
        IQueryable<SubCategoryListModel> GetAllSubCategories();
        bool IsCategoryExist(CreateCategoryModel model);
        ServiceResult AddCategory(CreateCategoryModel model);
        bool IsMainCategoryExist(Guid mainCategoryId);

        bool IsCategoryExist(Guid id);

    }
}
