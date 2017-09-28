using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using TotallyNotRobots.Movies.Web.ApiClient;

namespace TotallyNotRobots.Movies.Web
{
    public partial class Startup
    {
        public void Dependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(Startup).Assembly);
            builder.RegisterModelBinders(typeof(Startup).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            RegisterTypes(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ConfiguredApiClient>().As<IApi>().InstancePerRequest();
        }
    }
}