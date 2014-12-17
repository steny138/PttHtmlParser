using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Model;
using HtmlParser.Service;
using HtmlAgilityPack;
using HtmlParser.Core;

namespace HtmlParser
{
    public class Program
    {
        private const string PTT_URL_FORMAT = "https://www.ptt.cc/bbs/{0}.html";
        public static void Main(string[] args)
        {
            HtmlDocument doc = Utility.downLoadHtmlDoc("https://www.ptt.cc/bbs/index.html", Encoding.Default);

            if (doc != null && doc.ParseErrors.Count() > 0)
            {
                Console.WriteLine("解析失敗!!");
            }

            
            IPttClassService cService = new PttClassService();
            IPttGroupService gService = new PttGroupService();
            try
            {
                foreach (PttClass pClass in cService.parseClass(doc))
                {
                    Console.WriteLine("{0} : {1} - {2}", pClass.code, pClass.name.Trim(), pClass.desc);
                    PttGroupCollection collection = gService.parseGroup(
                        Utility.downLoadHtmlDoc(string.Format(PTT_URL_FORMAT, pClass.code),
                            Encoding.Default));
                    
                    foreach (PttGroup pGroup in collection.groups)
                    {
                        Console.WriteLine("{0} : {1} - {2}", pGroup.code, pGroup.name.Trim(), pGroup.desc);
                    }
                    Console.WriteLine("---------------------------------------------");
                    foreach (PttBoard pBoard in collection.boards)
                    {
                        Console.WriteLine("{0} : {1} - {2}", pBoard.code, pBoard.name.Trim(), pBoard.desc);
                    }

                    
                    Console.WriteLine("*********************************************");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("發生錯誤!!");
            }
            Console.ReadLine(); 

        }
    }
}
