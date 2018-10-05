using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity toCreate);

        TEntity Retrieve(Expression<Func<TEntity, bool>> criteria);

        bool Update(TEntity toUpdate);

        bool Delete(TEntity toDelete);

        List<TEntity> Filter(Expression<Func<TEntity, bool>> criteria);
    }
}
