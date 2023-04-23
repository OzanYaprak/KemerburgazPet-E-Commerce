using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Abstract
{
    public interface ICartDAL : IGenericDAL<Cart>
    {
        void DeleteFromCart(int cartId, int productID);
        Cart GetByUserID(string userID);
    }
}
