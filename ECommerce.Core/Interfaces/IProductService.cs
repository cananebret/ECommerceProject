using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductListModel> GetAllProducts(Guid categoryId);
        ServiceResult AddProduct(CreateProductModel model);
        ProductListModel GetProductDetail(Guid productId);
    }
}
