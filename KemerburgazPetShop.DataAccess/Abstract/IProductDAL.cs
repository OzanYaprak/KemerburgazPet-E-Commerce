using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Abstract
{
    public interface IProductDAL : IGenericDAL<Product>
    {
        IEnumerable<Product> GetPopularProducts();

        Product GetProductDetails(int id);
    }
}
