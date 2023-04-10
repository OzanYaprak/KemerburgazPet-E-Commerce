using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Abstract
{
    public interface IGenericDAL<TEntity>
    {
        TEntity GetByID(int id);

        TEntity GetOne(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        //IEnumerable kısmını List yaparsak, metotların sonuna tolist koymamıza gerek kalmaz.

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
