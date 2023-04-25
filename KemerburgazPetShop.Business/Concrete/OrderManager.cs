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
    public class OrderManager : IOrderService
    {
        private IOrderDAL _orderRepository;
        public OrderManager(IOrderDAL orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Create(Order entity)
        {
            _orderRepository.Create(entity);
        }
    }
}
