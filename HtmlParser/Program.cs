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
        public static void Main(string[] args)
        {
            HtmlDocument doc = Utility.downLoadHtmlDoc("https://www.ptt.cc/bbs/index.html", Encoding.Default);

            if (doc != null && doc.ParseErrors.Count() > 0)
            {
                Console.WriteLine("解析失敗!!");
            }

            
            IPttClassService service = new PttClassService();
            try
            {
                service.parseClass(doc);
            }
            catch(Exception)
            {
                Console.WriteLine("發生錯誤!!");
            }
            Console.ReadLine(); 

        }
    }
}
