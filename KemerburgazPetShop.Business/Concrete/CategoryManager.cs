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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDAL _categoryRepository;

        public CategoryManager(ICategoryDAL categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int categoryID, int productID)
        {
            _categoryRepository.DeleteFromCategory(categoryID, productID);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetByID(int id)
        {
            return _categoryRepository.GetByID(id);
        }

        public Category GetByIDWithProducts(int id)
        {
            return _categoryRepository.GetByIDWithProducts(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
