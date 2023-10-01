using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class MainCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}
