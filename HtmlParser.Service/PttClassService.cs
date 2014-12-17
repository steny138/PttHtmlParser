using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Model;
namespace HtmlParser.Service
{
    public interface IPttClassService
    {
        /// <summary>將分類看板頁序列化為物件</summary>
        /// <param name="doc">原始資料</param>
        /// <returns>分類看版物件列表</returns>
        List<PttClass> parseClass(HtmlAgilityPack.HtmlDocument doc);
    }

    public class PttClassService : IPttClassService
    {

        #region IPttClassService Members

        public List<PttClass> parseClass(HtmlAgilityPack.HtmlDocument doc)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
