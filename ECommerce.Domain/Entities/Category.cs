using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Category : BaseInfoEntity
    {
        public string Name { get; set; }

        public Guid MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }

        public virtual List<SubCategories> SubCategories { get; set; }
    }
}
