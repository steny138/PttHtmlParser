using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository
{
    public class UnitForWork : Interface.IUnitForWork
    {
        private PttBigdataEntities _dbcontext;

        public UnitForWork(PttBigdataEntities dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        protected PttBigdataEntities DataContext
        {
            get { return _dbcontext; }//?? (dbcontext = databaseFactory.Get()); }
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
