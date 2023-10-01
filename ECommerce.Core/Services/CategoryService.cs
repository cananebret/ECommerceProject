using ECommerce.Core.Interfaces;
using ECommerce.Domain.Contexts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ECommerceContext _context;
        public CategoryService(ECommerceContext context)
        {
            _context = context;
        }

        public IQueryable<MainCategoryListModel> GetAllMainCategories()
        {
            return _context.MainCategories
                .Include(i => i.Categories)
                .OrderBy(i => i.Name)
                .Select(i => new MainCategoryListModel
                {
                    Name = i.Name,
                    Categories = i.Categories.Select(y => new CategoryListModel { Name = y.Name }).ToList()
                });
        }

        public IQueryable<CategoryListModel> GetAllCategories()
        {
            return _context.Categories
                .Include(i => i.MainCategory)
                .Include(i => i.SubCategories)
                .Where(i => !i.Deleted && i.IsActive).OrderBy(i => i.Name)
                .Select(i => new CategoryListModel
                {
                    Name = i.Name,
                    MainCategory = i.MainCategory.Name,
                    SubCategories = i.SubCategories
                    .Select(y =>
                    new SubCategoryListModel
                    {
                        Name = y.Name
                    }).OrderBy(y => y.Name).ToList()
                });
        }

        public IQueryable<SubCategoryListModel> GetAllSubCategories()
        {
            return _context.SubCategories
                .Where(i => !i.Deleted && i.IsActive)
                .OrderBy(i => i.Name)
                .Select(i => new SubCategoryListModel
                {
                    Name = i.Name
                });
        }

        public ServiceResult AddMainCategory(CreateMainCategoryModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var mainCategory = new MainCategory
            {
                Name = model.Name,
            };

            _context.MainCategories.Add(mainCategory);
            _context.SaveChanges();

            serviceResult.Message = "Kaydedildi";

            return serviceResult;
        }

        public ServiceResult AddCategory(CreateCategoryModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var category = new Category
            {
                Name = model.Name,
                MainCategoryId = model.MainCategoryId,
                IsActive = true,
                Deleted = false
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            serviceResult.Message = "Kaydedildi";

            return serviceResult;
        }

        public bool IsMainCategoryExist(string name)
        {
            return _context.MainCategories.Any(i => i.Name == name);
        }
        public bool IsMainCategoryExist(Guid mainCategoryId)
        {
            return _context.MainCategories.Any(i => i.Id == mainCategoryId);
        }

        public bool IsCategoryExist(CreateCategoryModel model)
        {
            return _context.Categories.Any(i => i.Name == model.Name && i.MainCategoryId == model.MainCategoryId && !i.Deleted && i.IsActive);
        }

        public bool IsCategoryExist(Guid id)
        {
            return _context.Categories.Any(i => i.MainCategoryId == id && !i.Deleted && i.IsActive);
        }
    }
}
