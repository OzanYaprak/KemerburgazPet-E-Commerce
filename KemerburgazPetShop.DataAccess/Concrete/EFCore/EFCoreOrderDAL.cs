using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Concrete.EFCore
{
    public class EFCoreOrderDAL : EFCoreGenericDAL<Order, PetShopContext>, IOrderDAL
    {
        public List<Order> GetOrders(string userID)
        {
            using (var context = new PetShopContext())
            {
                var orders = context.Orders.Include(a=>a.OrderItems).ThenInclude(a=>a.Product).AsQueryable();

                if (!string.IsNullOrEmpty(userID))
                {
                    orders = orders.Where(a => a.UserID == userID);
                }

                return orders.ToList();
            }
        }
    }
}
