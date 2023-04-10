using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Concrete.EFCore
{
    public class EFCoreProductDAL : EFCoreGenericDAL<Product, PetShopContext>, IProductDAL
    {
        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new PetShopContext())
            {
                return context.Products.Where(a => a.ProductID == id)
                    .Include(a => a.ProductCategories)
                    .ThenInclude(a => a.Category)
                    .FirstOrDefault();
            }
        }
    }
}
