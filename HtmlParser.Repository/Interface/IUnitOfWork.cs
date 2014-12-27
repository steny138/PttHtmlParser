using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Interface
{
    public interface IUnitOfWork : IDisposable  
    {
        /// <summary>
        /// Commit Save
        /// </summary>
        void Save();
    }
}
