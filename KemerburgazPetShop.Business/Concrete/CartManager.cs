using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDAL _cartRepository;

        public CartManager(ICartDAL cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string UserID, int productID, int quantity)
        {
            var cart = GetCartByUserID(UserID);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(a=>a.ProductID == productID);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductID = productID,
                        Quantity = quantity,
                        CartID = cart.CartID
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartRepository.Update(cart);
            }
        }

        public void ClearCart(string cartID)
        {
            _cartRepository.ClearCart(cartID);
        }

        public void DeleteFromCart(string UserID, int productID)
        {
            var cart = GetCartByUserID(UserID);
            if (cart != null)
            {
                var cartId = cart.CartID;

                _cartRepository.DeleteFromCart(cartId, productID);
            }
        }

        public Cart GetCartByUserID(string UserID)
        {
            return _cartRepository.GetByUserID(UserID);
        }

        public void InitializeCart(string userID)
        {
            _cartRepository.Create(new Cart() { UserID= userID });
        }
    }
}
