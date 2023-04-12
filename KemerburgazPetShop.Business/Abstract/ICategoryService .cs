using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetByID(int id);
        Category GetByIDWithProducts(int id);


        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
