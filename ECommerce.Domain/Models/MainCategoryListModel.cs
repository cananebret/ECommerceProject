using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class MainCategoryListModel
    {
        public string Name { get; set; }

        public virtual List<CategoryListModel> Categories { get; set; }
    }
}
