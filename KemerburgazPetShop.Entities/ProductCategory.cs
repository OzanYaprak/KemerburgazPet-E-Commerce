using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Entities
{
    public class ProductCategory
    {

        public int CategoryID { get; set; }
        public Category Category { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
