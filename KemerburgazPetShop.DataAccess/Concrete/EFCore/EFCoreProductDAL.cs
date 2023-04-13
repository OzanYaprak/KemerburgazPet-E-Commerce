using Azure;
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
        public Product GetByIDWithCategories(int id)
        {
            using (var context = new PetShopContext())
            {
                return context.Products
                    .Where(a => a.ProductID == id)
                    .Include(a => a.ProductCategories)
                    .ThenInclude(a => a.Category)
                    .FirstOrDefault();
            }
        }
        public int GetCountByCategory(string category)
        {
            using (var context = new PetShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(a => a.ProductCategories)
                        .ThenInclude(a => a.Category)
                        .Where(a => a.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }

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

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new PetShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(a => a.ProductCategories)
                        .ThenInclude(a => a.Category)
                        .Where(a => a.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == category.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Product entity, int[] categoryIDs)
        {
            using (var context = new PetShopContext())
            {
                var product = context.Products
                    .Include(a => a.ProductCategories)
                    .FirstOrDefault(a=>a.ProductID == entity.ProductID);

                if (product!=null)
                {
                    product.ProductName = entity.ProductName;
                    product.ProductPrice = entity.ProductPrice;
                    product.ProductDescription = entity.ProductDescription;
                    product.ImageURL = entity.ImageURL;

                    product.ProductCategories = categoryIDs.Select(a => new ProductCategory()
                    {
                        CategoryID = a,
                        ProductID = entity.ProductID,
                    }).ToList();

                    context.SaveChanges();

                }
            }
        }
    }
}
