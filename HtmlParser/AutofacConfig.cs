using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace HtmlParser.Console
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            ContainerBuilder builder = new ContainerBuilder();
            

            //Repository

            //Service
            var service = Assembly.Load("");
            builder.RegisterAssemblyTypes(service).AsImplementedInterfaces();
        }

    }
}
