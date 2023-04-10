using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Business.Abstract
{
    public interface IProductService
    {
        Product GetByID(int id);
        List<Product> GetAll();
        List<Product> GetPopularProducts();
        List<Product> GetProductsByCategory(string category,int page,int pageSize);
        Product GetProductDetails(int id);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}
