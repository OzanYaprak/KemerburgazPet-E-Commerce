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


        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
