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

        public void InitializeCart(string userID)
        {
            _cartRepository.Create(new Cart() { UserID= userID });
        }
    }
}
