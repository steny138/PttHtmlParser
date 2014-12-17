using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlParser.Model;

namespace HtmlParser.Service
{
    public interface IPttGroupService
    {
        /// <summary>將分類看板頁序列化為物件</summary>
        /// <param name="doc">原始資料</param>
        /// <returns>分類看版物件列表</returns>
        List<PttGroup> parseGroup(HtmlDocument doc);
    }

    public class PttGroupService : IPttGroupService
    {

        #region IPttGroupService Members

        public List<PttGroup> parseGroup(HtmlDocument doc)
        {
            List<PttGroup> result = new List<PttGroup>();
            var collection = doc.DocumentNode.SelectNodes("//*[@id=\"prodlist\"]/dl/dd");

            foreach (HtmlNode node in collection.Elements())
            {
                PttGroup pGroup = new PttGroup();
                foreach (HtmlNode cNode in node.ChildNodes)
                {
                    if (!Regex.IsMatch(cNode.InnerText, @"^\s+$") || cNode.Attributes.Count > 0)
                    {
                        //tag name
                        switch (cNode.Name)
                        {
                            case "img":
                                {
                                    cNode.Attributes["src"].Value.IndexOf("folder.gif");
                                    cNode.Attributes["src"].Value.IndexOf("f.gif");
                                }
                                break;
                            case "a":
                                {
                                    pGroup.code = cNode.Attributes["href"].Value.Split('/').Last().Split('.').First();
                                    pGroup.name = cNode.InnerText;
                                    break;
                                }
                            case "text":
                                {
                                    pGroup.desc += cNode.InnerText;
                                    break;
                                }

                        }
                    }
                }
                result.Add(pGroup);
            }

            return result;
        }

        #endregion
    }
}
