﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class CreateCategoryModel
    {
        public string Name { get; set; }
        public Guid MainCategoryId { get; set; }
    }
}
