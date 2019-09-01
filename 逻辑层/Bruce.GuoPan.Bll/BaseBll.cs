using Bruce.GuoPan.Data.DataProvider;
using Bruce.GuoPan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Bll
{
    public class BaseBll<T> where T : BaseEntity, new()
    {
        private readonly NliteRepository<T> _baseRepostory;
        public BaseBll()
        {
            _baseRepostory = new NliteRepository<T>();
        }

        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="whereExpression"></param>
        public void delete(Expression<Func<T, bool>> whereExpression)
        {
            _baseRepostory.delete(whereExpression);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _baseRepostory.Insert(item);
            }
        }

        /// <summary>
        /// 单个实体新增
        /// </summary>
        /// <param name="entity"></param>
        public int Insert(T entity)
        {
            return _baseRepostory.Insert(entity);
        }

        /// <summary>
        /// 条件更新
        /// </summary>
        /// <param name="whereExpression"></param>
        public void update(Expression<Func<T, bool>> whereExpression)
        {
            _baseRepostory.update(whereExpression);
        }

        public void Update(T entity)
        {
            _baseRepostory.Update(entity);
        }

        public List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return _baseRepostory.GetList(whereExpression);
        }

        public List<T> GetAll()
        {
            return _baseRepostory.GetAll();
        }

        public T GetOne(int id)
        {
            return _baseRepostory.GetOne(id);
        }

        public DataTable GetDataTable(string sql)
        {
            return _baseRepostory.GetDataTable(sql);
        }
    }
}
