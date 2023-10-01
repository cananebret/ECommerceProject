using ECommerce.Core.Interfaces;
using ECommerce.Domain.Contexts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class CartService : ICartService
    {
        private readonly ECommerceContext _context;
        public CartService(ECommerceContext context)
        {
            _context = context;
        }

        public CartModel GetCart(Guid userId)
        {
            var carts = _context.Carts
                .Where(i => i.UserId == userId && i.IsActive);

            if (carts == null || !carts.Any())
            {
                throw new Exception("Sepet aktif değildir");
            }

            return carts
                .Select(i => new CartModel
                {
                    Email = i.User.Email,
                    Qty = i.Qty,
                    Amount = i.Amount,
                    CartItems = i.CartItems
                    .Select(y => new CartItemModel
                    {
                        ProductName = y.Product.Name,
                        Amount = y.Product.Amount,
                        Qty = y.Qty
                    }).ToList()

                }).FirstOrDefault();
        }

        public ServiceResult EditCart(EditCartModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var cartItem = _context.CartItems
                .Include(i => i.Product)
                .FirstOrDefault(i => i.Cart.UserId == model.UserId && i.Cart.CartItems.Any(i => i.ProductId == model.ProductId) && !i.Cart.Deleted && i.Cart.IsActive);

            if (cartItem == null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            cartItem.Qty = model.Qty;

            _context.CartItems.Update(cartItem);
            _context.SaveChanges();

            serviceResult.Message = "Sepet güncellendi";

            return serviceResult;
        }

        public ServiceResult Delete(EditCartModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var cart = _context.Carts
                .Include(i => i.CartItems).ThenInclude(i => i.Product)
                 .FirstOrDefault(i => i.UserId == model.UserId && i.CartItems.Any(i => i.ProductId == model.ProductId) && !i.Deleted && i.IsActive);

            if (cart == null)
            {
                throw new Exception("Sepet bulunamadı");
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            serviceResult.Message = "Sepet güncellendi";

            return serviceResult;
        }

        public bool CheckCartLimit(Guid productId, int qty)
        {
            var product = _context.Products.FirstOrDefault(i => i.Id == productId && !i.Deleted && i.IsActive);

            if (product != null && product.Stock < qty)
                return false;

            return true;
        }
    }
}
