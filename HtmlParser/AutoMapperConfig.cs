using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Console
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Automapper's profile
        /// </summary>
        public static void Configure()
        {
            /*
             * 有關於AutoMapper的設定對應, 全寫在這裡讓物件對應一致化
             * 設定完之後, 必須在程式起始Call AutoMapperConfig.Configure()
             * Configuration可以細分也可以寫在一起, 全看設計者的情況
             */
            AutoMapper.Mapper.Initialize(x =>
            {
                x.AddProfile<HtmlParser.Repository.Configuration.ClassConfiguration>();
            });
        }
    }
}
