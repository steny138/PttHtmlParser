using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Interface
{
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// 回傳整個資料表結果
        /// </summary>
        IEnumerable<T> GetAll();
        /// <summary>
        /// 查詢資料表
        /// </summary>
        /// <param name="id">條件</param>
        T GetById(string id);
        /// <summary>
        /// 依照傳入條件搜尋結果的第一筆資料
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T GetFistByCondition(Expression<Func<T, bool>> where);
        /// <summary>
        /// 依照傳入條件搜尋結果
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="enetity"></param>
        void Add(T entity);
        /// <summary>
        /// 更改資料
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 刪除某筆資料
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 依照傳入條件刪除資料
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<T, bool>> where);
    }
}
