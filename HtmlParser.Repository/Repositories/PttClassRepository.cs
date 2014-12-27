using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Repository;
using HtmlParser.Repository.Interface;
namespace HtmlParser.Repository.Repositories
{
    public interface IPttClassRepository : Interface.IRepository<@class>
    {

    }
    public class PttClassRepository :RepositoryBase<@class>, IPttClassRepository
    {
        public PttClassRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

}
