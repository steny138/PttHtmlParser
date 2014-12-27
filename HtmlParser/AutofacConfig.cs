using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HtmlParser.Service;
using HtmlParser.Repository.Interface;
using HtmlParser.Repository;
using HtmlParser.Repository.Repositories;

namespace HtmlParser.Console
{
    public class AutofacConfig
    {
        public static IContainer Bootstrapper()
        {
            ContainerBuilder builder = new ContainerBuilder();


            //builder.RegisterType
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            
            //Repository
            builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();
            //Service
            builder.RegisterAssemblyTypes(typeof(PttBoardService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType<PttClassRepository>().AsImplementedInterfaces();
            //builder.RegisterType<PttGroupRepository>().AsImplementedInterfaces();
            //builder.RegisterType<PttBoardRepository>().AsImplementedInterfaces();
            //builder.RegisterType<PttThemeRepository>().AsImplementedInterfaces();
            //builder.RegisterType<PttClassService>().AsImplementedInterfaces();
            //builder.RegisterType<PttGroupService>().AsImplementedInterfaces();
            //builder.RegisterType<PttBoardService>().AsImplementedInterfaces();
            //builder.RegisterType<PttThemeService>().AsImplementedInterfaces();
            builder.RegisterType<PttBigdataEntities>().InstancePerLifetimeScope();
            
            //builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }
    }
}
