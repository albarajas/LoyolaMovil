using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity toCreate);

        TEntity Retrieve();

        bool Delete(TEntity toDelete);

        bool Update(TEntity toUpdate);

    }
}
