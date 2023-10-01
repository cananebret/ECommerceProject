using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CartModel
    {
        public string Email { get; set; }
        public virtual List<CartItemModel> CartItems { get; set; }
        public int Qty { get { return CartItems.Count(); } set { } }
        public decimal Amount { get { return CartItems.Sum(x => x.Amount); } set { } }

    }
}
