using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string UserID);
        void AddToCart(string UserID, int productID, int quantity);
        Cart GetCartByUserID(string UserID);
        void DeleteFromCart(string UserID, int productID);
        void ClearCart(string cartID);
    }
}
