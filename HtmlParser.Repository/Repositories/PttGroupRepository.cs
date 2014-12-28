using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Repository;
using HtmlParser.Repository.Interface;
namespace HtmlParser.Repository.Repositories
{
    public interface IPttGroupRepository : Interface.IRepository<group>
    {

    }
    public class PttGroupRepository : RepositoryBase<group>, IPttGroupRepository
    {
        public PttGroupRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

}
