using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Cart : BaseInfoEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }

        public virtual List<CartItems> CartItems { get; set; }
    }
}
