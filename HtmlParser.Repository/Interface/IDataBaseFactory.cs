using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Interface
{
    public interface IDatabaseFactory : IDisposable
    {
        PttBigdataEntities Get();
    }
}
