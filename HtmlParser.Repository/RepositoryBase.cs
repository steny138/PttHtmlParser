using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository
{
    public class RepositoryBase<T> :Interface.IRepository<T> where T : class
    {
        private PttBigdataEntities _dbContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(PttBigdataEntities dataContext)
        {
            _dbContext = dataContext;
            dbset = _dbContext.Set<T>();
        }

        #region IRepository<T> Members

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        public virtual T GetFistByCondition(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbset.Remove(obj);
            }
        }

        #endregion
    }
}
