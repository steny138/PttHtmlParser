using Autofac.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository
{
    public class DatabaseFactory : Disposable, Interface.IDatabaseFactory
    {
        private PttBigdataEntities dataContext;
        public PttBigdataEntities Get()
        {
            return dataContext ?? (dataContext = new PttBigdataEntities());
        }
        protected override void Dispose(bool isDisposing)
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
