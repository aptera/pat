using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TotallyNotRobots.Movies.Models;

namespace TotallyNotRobots.Movies.Api
{
    public partial class Startup
    {
        public static IContainer ServiceLocator { get; private set; }

        public void Dependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            RegisterTypes(builder);
            var container = builder.Build();
            ServiceLocator = container;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<MovieDBContext>().As<MovieDBContext>().InstancePerRequest();
        }
    }
}