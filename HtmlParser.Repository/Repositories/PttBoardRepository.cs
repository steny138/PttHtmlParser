using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Repository;
using HtmlParser.Repository.Interface;
namespace HtmlParser.Repository.Repositories
{
    public interface IPttBoardRepository : Interface.IRepository<board>
    {

    }
    public class PttBoardRepository : RepositoryBase<board>, IPttBoardRepository
    {
        public PttBoardRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

}
