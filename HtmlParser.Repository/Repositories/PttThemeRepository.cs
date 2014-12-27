using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Repository;
using HtmlParser.Repository.Interface;
namespace HtmlParser.Repository.Repositories
{
    public interface IPttThemeRepository : Interface.IRepository<@class>
    {
        
    }
    public class PttThemeRepository : RepositoryBase<@class>, IPttThemeRepository
    {
        public PttThemeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

}
