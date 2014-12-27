using HtmlParser.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace HtmlParser.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IDatabaseFactory _databaseFactory;
        public PttBigdataEntities _dbcontext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        public PttBigdataEntities DataContext
        {
            get { return _dbcontext ?? (_dbcontext = _databaseFactory.Get()); }
        }

        #region IUnitForWork Members

        public void Save()
        {
            
            DataContext.SaveChanges();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        #endregion
    }
}
