using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.Reposity
{
    public interface IRepository<TKEY, T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);

        T GetById(TKEY id);

        bool Create(T model);

        bool Delete(T model);
        bool IsExist(Expression<Func<T, bool>> expression);
        bool Save();
    }
}
