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
        List<Product> GetProductsByCategory(string category, int page,int pageSize);

        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetByIDWithCategories(int id);
        void Update(Product entity, int[] categoryIDs);
    }
}
