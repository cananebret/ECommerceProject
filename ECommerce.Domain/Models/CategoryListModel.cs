using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CategoryListModel
    {
        public string Name { get; set; }
        public string MainCategory { get; set; }
        public List<SubCategoryListModel> SubCategories { get; set; }
    }
}
