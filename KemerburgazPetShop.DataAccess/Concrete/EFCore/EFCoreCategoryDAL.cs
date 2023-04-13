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
    public class EFCoreCategoryDAL : EFCoreGenericDAL<Category, PetShopContext>, ICategoryDAL
    {
        public void DeleteFromCategory(int categoryID, int productID)
        {
            using (var context = new PetShopContext())
            {
                var cmd = @"delete from ProductCategory where ProductID=@p0 And CategoryID=@p1";
                context.Database.ExecuteSqlRaw(cmd,productID,categoryID);
            }
        }

        public Category GetByIDWithProducts(int id)
        {
            using (var context = new PetShopContext())
            {
                return context.Categories.Where(a => a.CategoryID == id).Include(a => a.ProductCategories).ThenInclude(a => a.Product).FirstOrDefault();
            }
        }
    }
}
