using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TotallyNotRobots.Movies.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace TotallyNotRobots.Movies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Dependencies();
            ConfigureAuth(app);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
