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
    public class ProductManager : IProductService
    {
        private IProductDAL _productRepository;

        public ProductManager(IProductDAL productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().Take(8).ToList();
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetByID(id);
        }

        public List<Product> GetPopularProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
