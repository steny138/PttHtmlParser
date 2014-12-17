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
    public interface IPttClassService
    {
        /// <summary>將分類看板頁序列化為物件</summary>
        /// <param name="doc">原始資料</param>
        /// <returns>分類看版物件列表</returns>
        List<PttClass> parseClass(HtmlDocument doc);
    }

    public class PttClassService : IPttClassService
    {

        #region IPttClassService Members

        public List<PttClass> parseClass(HtmlDocument doc)
        {
            List<PttClass> result = new List<PttClass>();
            var collection = doc.DocumentNode.SelectNodes("//*[@id=\"prodlist\"]/dl/dd");

            foreach (HtmlNode node in collection.Elements())
            {
                PttClass pClass = new PttClass();
                foreach (HtmlNode cNode in node.ChildNodes)
                {
                    if (!Regex.IsMatch(cNode.InnerText, @"^\s+$") || cNode.Attributes.Count > 0)
                    {
                        //tag name
                        switch (cNode.Name)
                        {
                            //case "img":
                            //    break;
                            case "a":
                            {
                                pClass.code = cNode.Attributes["href"].Value.Split('/').Last().Split('.').First();
                                pClass.name = cNode.InnerText;
                                break;
                            }
                            case "text":{
                                pClass.desc += cNode.InnerText;
                                break;
                            }
                            
                        }
                    }
                }
                result.Add(pClass);
            }

            return result;
        }

        #endregion
    }
}
