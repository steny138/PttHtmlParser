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
        PttGroupCollection parseGroup(HtmlDocument doc);
    }

    public class PttGroupService : IPttGroupService
    {

        #region IPttGroupService Members

        public PttGroupCollection parseGroup(HtmlDocument doc)
        {
            PttGroupCollection result = new PttGroupCollection();
            var collection = doc.DocumentNode.SelectNodes("//*[@id=\"prodlist\"]/dl/dd");

            foreach (HtmlNode node in collection.Elements())
            {
                if (node.ChildNodes["img"].Attributes["src"].Value.IndexOf("f.gif") > -1)
                {
                    PttBoard pBoard = new PttBoard();
                    foreach (HtmlNode cNode in node.ChildNodes)
                    {
                        if (!Regex.IsMatch(cNode.InnerText, @"^\s+$") || cNode.Attributes.Count > 0)
                        {
                            //tag name
                            switch (cNode.Name)
                            {
                                case "a":
                                    {
                                        pBoard.code = cNode.Attributes["href"].Value.Split('/').Last().Split('.').First();
                                        pBoard.name = cNode.InnerText;
                                        break;
                                    }
                                case "text":
                                    {
                                        pBoard.desc += cNode.InnerText;
                                        break;
                                    }

                            }
                        }
                    }
                    result.boards.Add(pBoard);
                }
                else
                {
                    PttGroup pGroup = new PttGroup();
                    foreach (HtmlNode cNode in node.ChildNodes)
                    {
                        if (!Regex.IsMatch(cNode.InnerText, @"^\s+$") || cNode.Attributes.Count > 0)
                        {
                            //tag name
                            switch (cNode.Name)
                            {
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
                    result.groups.Add(pGroup);
                }
            }

            return result;
        }

        #endregion
    }
}
