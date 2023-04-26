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
    public class EFCoreCartDAL : EFCoreGenericDAL<Cart, PetShopContext>, ICartDAL
    {
        public override void Update(Cart entity)
        {
            using (var contex = new PetShopContext())
            {
                contex.Carts.Update(entity);
                contex.SaveChanges();
            }
        }

        public Cart GetByUserID(string userID)
        {
            using (var context = new PetShopContext())
            {
                return context.Carts.Include(a => a.CartItems).ThenInclude(a => a.Product).FirstOrDefault(a => a.UserID == userID);
            }
        }

        public void DeleteFromCart(int cartId, int productID)
        {
            using (var context = new PetShopContext())
            {
                var cmd = @"delete from CartItem where CartID=@p0 And ProductID=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productID);
            }
        }

        public void ClearCart(string cartID)
        {
            using (var context = new PetShopContext())
            {
                var cmd = @"delete from CartItem where CartID=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartID);
            }
        }
    }
}
