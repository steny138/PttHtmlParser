using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Model;
using HtmlAgilityPack;
using System.Globalization;
using System.Text.RegularExpressions;
namespace HtmlParser.Service
{
    public interface IPttBoardService
    {
        /// <summary>取得看板所有資訊</summary>
        /// <param name="boardName">看板名稱</param>
        /// <returns>看板內的所有文章</returns>
        List<PttTheme> parse(string boardName);
        /// <summary>取得看板資訊</summary>
        /// <param name="boardName">看板名稱</param>
        /// <param name="fromDate">取得多久以前到現在</param>
        /// <returns>看板內符合的文章</returns>
        List<PttTheme> parse(string boardName, DateTime fromDate);
        /// <summary>取得看板資訊</summary>
        /// <param name="boardName">看板名稱</param>
        /// <param name="fromDate">取得多久以前到現在</param>
        /// <returns>看板內符合的文章</returns>
        List<PttTheme> parse(string boardName, int maxPage);

        /// <summary>從最新的文章開始取幾頁</summary>
        /// <param name="boardName">看板名稱</param>
        /// <param name="pageCount">頁數</param>
        /// <returns>看板內符合的文章</returns>
        List<PttTheme> parseFromNewThemeUntilPageCount(string boardName, int pageCount);
       
        /// <summary>取得看板資訊</summary>
        PttTheme parseBoard(HtmlNode node);


    }
    public class PttBoardService : IPttBoardService
    {
        private const string PTT_BOARD_URL_FORMAT = "https://www.ptt.cc/bbs/{0}/index{1}.html";
        private readonly string[] DATETIME_LIST = { "M/dd", "MM/dd", "MM/d", "M/d" };
        
        public List<PttTheme> parse(string boardName)
        {
            return parse(boardName, null, null, 0, 0);
        }
        
        public List<PttTheme> parse(string boardName, DateTime fromDate)
        {
            return parse(boardName, fromDate, null, 0, 0);
        }
        
        public List<PttTheme> parse(string boardName, int maxPage)
        {
            return parse(boardName, null, null, 0, maxPage);
        }

        public List<PttTheme> parseFromNewThemeUntilPageCount(string boardName, int pageCount)
        {
            int maxPage = getMaxPageInTheBoard(boardName);
            return parse(boardName, null, null, maxPage - pageCount > 0 ? maxPage - pageCount : 0, maxPage);
        }

        public PttTheme parseBoard(HtmlNode node)
        {
            PttTheme theme = new PttTheme();
            
            foreach (HtmlNode cNode in node.SelectNodes("div[@class]").AsEnumerable())
            {
                switch (cNode.Attributes["class"].Value)
                {
                    case "nrec":
                        theme.popularity = cNode.SelectSingleNode("span") == null ? string.Empty : cNode.SelectSingleNode("span").InnerText;
                        break;
                    case "mark":
                        break;
                    case "title":
                        if (cNode.InnerText.Contains("本文已被刪除") || Regex.IsMatch(cNode.InnerText, "已被[0-9A-Za-z]+刪除"))
                        {
                            return null;
                        }
                        try
                        {
                            theme.code = cNode.SelectSingleNode("a").Attributes["href"].Value.Split('/').Last().Replace(".html", string.Empty);
                            theme.title = cNode.SelectSingleNode("a").InnerText;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        break;
                    case "meta":
                        theme.issueDate = DateTime.ParseExact(cNode.SelectSingleNode("div[@class='date']").InnerText,
                            DATETIME_LIST, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
                        
                        theme.author = cNode.SelectSingleNode("div[@class='author']").InnerText;
                        break;
                }
            }
            return theme;
        }

        private List<PttTheme> parse(string boardName, DateTime? fromDate, DateTime? toDate, int initPage, int maxPage)
        {
            List<PttTheme> result = new List<PttTheme>();
            int ePage = 0;
            int sPage = 1;


            if (maxPage > 0)
            {
                ePage = maxPage;
            }
            else
            {
                ePage = getMaxPageInTheBoard(boardName);
            }

            if (initPage > 0) sPage = initPage;

            //最新的在上面
            for (int i = ePage; i >= sPage; i--)
            {
                HtmlDocument newDoc = HtmlParser.Core.Utility.downLoadHtmlDoc(string.Format(PTT_BOARD_URL_FORMAT, boardName, i), Encoding.UTF8);

                var collection = newDoc.DocumentNode.SelectNodes("//*[@id=\"main-container\"]/div[contains(@class,'r-list-container')]/div[@class='r-ent']");

                foreach (HtmlNode node in collection.AsEnumerable().Reverse())
                {
                    PttTheme theme = parseBoard(node);

                    if (theme == null) continue;
                    
                    theme.boardName = boardName;

                    if (isIncludeDateRegion(fromDate, toDate, theme.issueDate))
                    {
                        result.Add(theme);
                    }
                }                
            }

            return result;
        }

        private int getMaxPageInTheBoard(string boardName)
        {
            HtmlDocument doc = HtmlParser.Core.Utility.downLoadHtmlDoc(string.Format(PTT_BOARD_URL_FORMAT, boardName, string.Empty), Encoding.UTF8);
            return int.Parse(doc.DocumentNode.SelectSingleNode("//*[@id=\"action-bar-container\"]/div/div[2]/a[2]").Attributes["href"].Value.Split('/').Last().Replace(".html", string.Empty).Replace("index", string.Empty)) + 1;
        }

        private bool isIncludeDateRegion(DateTime? fromDate, DateTime? toDate, DateTime theDate)
        {
            bool result = false;

            if (fromDate.HasValue && toDate.HasValue)
            {
                if (theDate.CompareTo(fromDate.Value) >= 1 && theDate.CompareTo(toDate.Value) <= 1)
                {
                    result = true;
                }

            }
            else if (!fromDate.HasValue && toDate.HasValue)
            {
                if (theDate.CompareTo(toDate.Value) <= 1)
                {
                    result = true;
                }
            }
            else if (fromDate.HasValue && !toDate.HasValue)
            {
                if (theDate.CompareTo(fromDate.Value) >= 1)
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }

            return result;
        }



        
    }
}
