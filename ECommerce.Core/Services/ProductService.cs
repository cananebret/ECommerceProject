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
    public class ProductService : IProductService
    {
        private readonly ECommerceContext _context;
        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        public IQueryable<ProductListModel> GetAllProducts(Guid categoryId)
        {
            return _context.Products
                .Include(i => i.Category)
                .Where(i => !i.Deleted && i.IsActive && i.CategoryId == categoryId)
                .Select(i => new ProductListModel
                {
                    Id=i.Id,
                    Name = i.Name,
                    Amount = i.Amount,
                    Stock = i.Stock,
                    CategoryId = i.CategoryId,
                    CategoryName = i.Category.Name
                }).OrderBy(i => i.Name);
        }

        public ProductListModel GetProductDetail(Guid productId)
        {
            var product = _context.Products
                .Include(i => i.Category)
                .FirstOrDefault(i => i.Id == productId && !i.Deleted);

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            if (!product.IsActive)
            {
                throw new Exception("Ürün aktif değildir.");
            }

            return _context.Products
                .Include(i => i.Category)
                .Where(i => i.Id == productId)
                .Select(i => new ProductListModel
                {
                    Id=i.Id,
                    Name = i.Name,
                    Amount = i.Amount,
                    Stock = i.Stock,
                    CategoryId = i.CategoryId,
                    CategoryName = i.Category.Name
                }).OrderBy(i => i.Name).FirstOrDefault();
        }

        public ServiceResult AddProduct(CreateProductModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var product = new Product
            {
                Name = model.Name,
                Amount = model.Amount,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                IsActive = true,
                Deleted = false,
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            serviceResult.Message = "Kaydedildi";

            return serviceResult;
        }

    }
}
