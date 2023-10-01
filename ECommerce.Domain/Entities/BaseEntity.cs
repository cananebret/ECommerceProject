using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

    public class BaseInfoEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;

        public bool Deleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
