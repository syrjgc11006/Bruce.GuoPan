using Bruce.GuoPan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Data.DataProvider
{
    public partial interface IRepository<T> where T : BaseEntity, new()
    {
        int Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void update(Expression<Func<T, bool>> whereExpression);

        void delete(Expression<Func<T, bool>> whereExpression);

        List<T> GetList(Expression<Func<T, bool>> whereExpression);

        List<T> GetAll();
    }
}
