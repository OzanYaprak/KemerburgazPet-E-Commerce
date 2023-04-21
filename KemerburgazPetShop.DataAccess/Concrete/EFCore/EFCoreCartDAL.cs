using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Concrete.EFCore
{
    public class EFCoreCartDAL : EFCoreGenericDAL<Cart, PetShopContext>, ICartDAL
    {

    }
}
