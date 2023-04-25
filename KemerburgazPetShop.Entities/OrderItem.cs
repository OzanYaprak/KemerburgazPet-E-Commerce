using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Entities
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
