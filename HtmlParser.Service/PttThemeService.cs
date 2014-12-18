using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlParser.Core;
using HtmlParser.Model;
using System.Globalization;


namespace HtmlParser.Service
{
    public interface IPttThemeService
    {
        /// <summary>讀取指定看板的指定文章內容</summary>
        /// <param name="boardName">看板名稱</param>
        /// <param name="themeId">文章代號</param>
        /// <returns>指定文章物件</returns>
        PttTheme parse(string boardName, string themeId);
        /// <summary>讀取指定看板的指定文章內容</summary>
        /// <param name="initTheme">目的文章物件</param>
        /// <returns>指定文章物件</returns>
        PttTheme parse(PttTheme initTheme);
    }
    public class PttThemeService : IPttThemeService
    {
        private const string PTT_THEME_URL_FORMAT = "https://www.ptt.cc/bbs/{0}/{1}.html";

        public PttTheme parse(string boardName, string themeId)
        {
            PttTheme result = new PttTheme();
            result.boardName = boardName;
            result.code = themeId;
            result = parse(result);
            return result;
        }
        
        public PttTheme parse(PttTheme initTheme)
        {
            HtmlDocument doc = Utility.downLoadHtmlDoc(string.Format(PTT_THEME_URL_FORMAT, initTheme.boardName, initTheme.code), Encoding.UTF8);
            try
            {
                if (doc != null)
                {
                    HtmlNode mainNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"main-content\"]");
                    initTheme.author = mainNode.SelectSingleNode("div[@class='article-metaline'][1]/span[@class='article-meta-value']").InnerText; //author
                    initTheme.title = mainNode.SelectSingleNode("div[@class='article-metaline'][2]/span[@class='article-meta-value']").InnerText; //title
                    initTheme.issueDate = parseExact(mainNode.SelectSingleNode("div[@class='article-metaline'][3]/span[@class='article-meta-value']").InnerText); //time

                    //content
                    initTheme.content = mainNode.ChildNodes["#text"].InnerText;

                    initTheme.url = mainNode.SelectSingleNode("span[@class='f2'][2]/a").InnerText;

                    //推文
                    foreach(HtmlNode pushNode in mainNode.SelectNodes("div[@class='push']").AsEnumerable())
                    {
                        PttThemePush push = new PttThemePush();
                        push.author = pushNode.SelectSingleNode("span[contains(@class,'push-userid')]").InnerText ;
                        push.content = pushNode.SelectSingleNode("span[contains(@class,'push-content')]").InnerText;
                        push.pushType = choosePushType(pushNode.SelectSingleNode("span[contains(@class,'push-tag')]").InnerText);
                        push.pushDate = parseExact(pushNode.SelectSingleNode("span[contains(@class,'push-ipdatetime')]").InnerText);
                        initTheme.pushContents.Add(push);
                    }
                }

            }
            catch (NullReferenceException)
            {
                return null;
            }
            return initTheme;
        }

        private DateTime parseExact(string strDate)
        {
            string[] dateFormater = { "ddd MMM d HH:mm:ss yyyy" , "MM/dd HH:ss", "M/dd HH:ss", "M/d HH:ss", "MM/d HH:ss" };
            return DateTime.ParseExact(strDate.Trim(), dateFormater, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
        }

        private PushType choosePushType(string strType)
        {
            switch (strType)
            {
                case "噓":
                    return PushType.boos;
                case "→":
                    return PushType.normal;
                case "推" :
                    return PushType.push;
                default :
                    return PushType.normal;
            }
        }
        
    }
}
