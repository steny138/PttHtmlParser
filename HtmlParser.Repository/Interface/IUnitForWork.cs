using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Interface
{
    interface IUnitForWork : IDisposable  
    {
        /// <summary>
        /// Commit Save
        /// </summary>
        void Save();
    }
}
