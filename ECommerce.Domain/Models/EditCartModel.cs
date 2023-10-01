using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class EditCartModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Qty { get; set; }
    }
}
