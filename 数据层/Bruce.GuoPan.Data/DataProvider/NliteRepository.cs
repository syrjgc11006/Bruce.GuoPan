using Bruce.GuoPan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Data.DataProvider
{
    public class NliteRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly object _syncObj = new object();
        private readonly BruceContext _context;

        public NliteRepository(string connection = "GuoPanDb")
        {
            if (_context == null)
            {
                lock (_syncObj)
                {
                    if (_context == null)
                    {
                        _context = new BruceContext(connection);
                    }
                }
            }
        }

        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="whereExpression"></param>
        public void delete(Expression<Func<T, bool>> whereExpression)
        {
            _context.Set<T>().Delete(whereExpression);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _context.Set<T>().Insert(item);
            }
        }

        /// <summary>
        /// 单个实体新增
        /// </summary>
        /// <param name="entity"></param>
        public int Insert(T entity)
        {
            return _context.Set<T>().Insert(entity);
        }

        /// <summary>
        /// 条件更新
        /// </summary>
        /// <param name="whereExpression"></param>
        public void update(Expression<Func<T, bool>> whereExpression)
        {
            _context.Set<T>().Update(whereExpression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return _context.Set<T>().Where(whereExpression).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetOne(int id)
        {
            return _context.Set<T>().FirstOrDefault(m => m.Id == id);
        }

        public DataTable GetDataTable(string sql)
        {
            return _context.DbHelper.ExecuteDataTable(sql);
        }
    }
}
