using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO; 
using HtmlAgilityPack;

namespace HtmlParser.Core
{
    public class Utility
    {
        /// <summary>載入提供的網址的HTML並轉換成HTML Document</summary>
        /// <param name="url">網址</param>
        /// <param name="encoding">編碼類型</param>
        public static HtmlDocument downLoadHtmlDoc(string url, Encoding encoding)
        {
            WebClient client = new WebClient();
            HtmlDocument doc = new HtmlDocument();
            using (MemoryStream ms = new MemoryStream(client.DownloadData(url)))
            {
                //使用UTF8反而會變亂碼，要用Default
                doc.Load(ms, encoding);
            }
            return doc;
        }

        public static void writeLog(string content)
        {

        }
    }
}
