using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CartItemModel
    {
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
    }
}
