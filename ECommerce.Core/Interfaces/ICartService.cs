using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface ICartService
    {
        CartModel GetCart(Guid userId);
        ServiceResult EditCart(EditCartModel model);
        bool CheckCartLimit(Guid productId, int qty);

        ServiceResult Delete(EditCartModel model);
    }
}
