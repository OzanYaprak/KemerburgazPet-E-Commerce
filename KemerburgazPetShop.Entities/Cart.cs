using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Entities
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserID { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
