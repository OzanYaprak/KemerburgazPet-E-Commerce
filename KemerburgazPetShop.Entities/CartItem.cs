using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Entities
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public Cart Cart { get; set; }
        public int CartID { get; set; }

        public int Quantity { get; set; }
    }
}
