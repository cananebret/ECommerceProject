using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}
