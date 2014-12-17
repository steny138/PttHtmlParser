using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Model;
using HtmlAgilityPack;
namespace HtmlParser.Service
{
    public interface IPttBoardService
    {
        /// <summary>將看板頁序列化為物件</summary>
        /// <param name="doc">原始資料</param>
        /// <returns>看版物件列表</returns>
        List<PttBoard> parse(HtmlDocument doc);
    }
    public class PttBoardService : IPttBoardService
    {
        private const string PTT_BOARD_URL_FORMAT = "https://www.ptt.cc/bbs/{0}/index{1}.html";
        public List<PttBoard> parse(HtmlDocument doc)
        {
            List<PttBoard> result = new List<PttBoard>();
            //先取頁數
            int page = int.Parse(doc.DocumentNode.SelectSingleNode("//*[@id=\"action-bar-container\"]/div/div[2]/a[2]").Attributes["href"].Value.Split('/').Last().Replace(".html", string.Empty).Replace("index", string.Empty)) + 1;

            for (int i = 1; i <= 10; i++)
            {
                HtmlDocument newDoc = HtmlParser.Core.Utility.downLoadHtmlDoc(string.Format(PTT_BOARD_URL_FORMAT, "NBA", i), Encoding.UTF8);

                var collection = newDoc.DocumentNode.SelectNodes("//*[@id=\"main-container\"]/div[contains(@class,'r-list-container')]/div[@class='r-ent']");

                foreach (HtmlNode node in collection.AsEnumerable())
                {
                    PttBoard board = new PttBoard();
                    foreach (HtmlNode cNode in node.SelectNodes("div[@class]").AsEnumerable())
                    {
                        switch (cNode.Attributes["class"].Value)
                        {
                            case "nrec":

                                break;
                            case "mark":
                                break;
                            case "title":
                                board.code = cNode.SelectSingleNode("a").Attributes["href"].Value.Split('/').Last().Replace(".html", string.Empty);
                                board.name = cNode.SelectSingleNode("a").InnerText;
                                break;
                            case "meta":
                                board.manager = cNode.SelectSingleNode("div[@class='author']").InnerText;
                                break;
                        }
                    }
                    result.Add(board);
                }
            }

            

            return result;
        }
    }
}
