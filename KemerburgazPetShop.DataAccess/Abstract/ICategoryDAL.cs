using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Abstract
{
    public interface ICategoryDAL : IGenericDAL<Category>
    {
        void DeleteFromCategory(int categoryID, int productID);

        Category GetByIDWithProducts(int id);
    }
}
