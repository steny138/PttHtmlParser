using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Model;
using HtmlParser.Service;
using HtmlAgilityPack;
using HtmlParser.Core;
using Autofac;

namespace HtmlParser.Console
{
    public class Program
    {
        private const string PTT_URL_FORMAT = "https://www.ptt.cc/bbs/{0}.html";
        private const string PTT_BOARD_URL_FORMAT = "https://www.ptt.cc/bbs/{0}/index.html";
        public static void Main(string[] args)
        {
            //Initital
            AutoMapperConfig.Configure();
            var container = AutofacConfig.Bootstrapper();
            var scope = container.BeginLifetimeScope();
            IPttClassService cService = scope.Resolve<IPttClassService>();
            IPttGroupService gService = scope.Resolve<IPttGroupService>();
            IPttBoardService bService = scope.Resolve<IPttBoardService>();
            IPttThemeService tService = scope.Resolve<IPttThemeService>();
            try
            {
                #region test code

                /*
                HtmlDocument doc = Utility.downLoadHtmlDoc("https://www.ptt.cc/bbs/index.html", Encoding.Default);

                if (doc != null && doc.ParseErrors.Count() > 0)
                {
                    System.Console.WriteLine("解析失敗!!");
                }
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
                
                List<PttTheme> themes = bService.parse("NBA", 10);
                foreach (PttTheme theme in themes)
                {

                }
                 * */
                /*
                List<PttTheme> themes = bService.parseFromNewThemeUntilPageCount("NBA", 1);
                foreach (PttTheme theme in themes)
                {
                    var newTheme = tService.parse(theme);
                    Console.WriteLine("*********************************************");
                    Console.WriteLine(newTheme.title);
                    Console.WriteLine(newTheme.content);
                    Console.WriteLine("*********************************************");
                }
                //PttTheme theme = tService.parse("NBA", "M.1418823312.A.FD5");
                //Console.WriteLine(theme.content);
                //Console.WriteLine("push count : {0}", theme.pushContents.Count);
                 */
                #endregion

                #region test db entity
                /*
                using (var db = new HtmlParser.Repository.PttBigdataEntities())
                {
                    db.Database.Log = (log) => System.Console.WriteLine(log);
                    //var user = new HtmlParser.Repository.user();
                    //user.userId = "test";
                    //user.username = "Testname2";
                    //user.password = "1234";
                    //user.modify_staff = "steny";
                    //user.modify_time = DateTime.Now;
                    //user.email = "test@steny.com.tw";
                    //user.create_staff = "steny";
                    //user.create_time = DateTime.Now;
                    ////db.user.Add(user);
                    //db.Entry(user).State = System.Data.Entity.EntityState.Modified;

                    var user2 = db.user.Where(x => x.userId == "test").SingleOrDefault();
                    
                    user2.modify_staff = "steny3";
                    //user2.modify_time =new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    //db.user.Attach(user2);
                    //db.Entry(user2).State = System.Data.Entity.EntityState.Modified;
                   
                    db.SaveChanges();
                }
                */
                #endregion

                #region insert all ptt board to mysql

                //得到所有的分類
                HtmlDocument doc = Utility.downLoadHtmlDoc("https://www.ptt.cc/bbs/index.html", Encoding.Default);

                if (doc != null && doc.ParseErrors.Count() > 0)
                {
                    System.Console.WriteLine("解析失敗!!");
                }

                foreach (PttClass pClass in cService.parseClass(doc))
                {
                    //可以先寫入CLASS
                    var pClassDb = AutoMapper.Mapper.Map<HtmlParser.Repository.@class>(pClass);

                    int result = cService.Add(pClassDb);

                    if (result == 1)
                    {
                        PttGroupCollection collection = gService.parseGroup(
                            Utility.downLoadHtmlDoc(string.Format(PTT_URL_FORMAT, pClass.code),
                                Encoding.Default));
                    }
                    else
                    {
                        System.Console.WriteLine("Insert Class {0} Error", pClass.code);
                    }

                    //foreach (PttGroup pGroup in collection.groups)
                    //{
                    //    Console.WriteLine("{0} : {1} - {2}", pGroup.code, pGroup.name.Trim(), pGroup.desc);
                    //}
                    //Console.WriteLine("---------------------------------------------");
                    //foreach (PttBoard pBoard in collection.boards)
                    //{
                    //    Console.WriteLine("{0} : {1} - {2}", pBoard.code, pBoard.name.Trim(), pBoard.desc);
                    //}
                }
                #endregion

            }
            catch(Exception ex)
            {
                System.Console.WriteLine("發生錯誤!!");
            }
            System.Console.ReadLine(); 

        }


        public static void AddGroupCollection(PttGroupCollection collection, IPttGroupService gService)
        {

            foreach (PttBoard board in collection.boards)
            {
                var pBoardDb = AutoMapper.Mapper.Map<HtmlParser.Repository.board>(board);
                //gService.Add(pBoardDb);
            }
            foreach (PttGroup group in collection.groups)
            {
                var pGroupDb = AutoMapper.Mapper.Map<HtmlParser.Repository.group>(group);
                ///gService.Add(pGroupDb);
                PttGroupCollection newCollection = gService.parseGroup(
                        Utility.downLoadHtmlDoc(string.Format(PTT_URL_FORMAT, group.code),
                            Encoding.Default));
                AddGroupCollection(newCollection, gService);
            }


        }
    }
}
