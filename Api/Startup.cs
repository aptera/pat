using Microsoft.Owin;
using Owin;
using System.Web.Http;
using TotallyNotRobots.Movies.Api;

[assembly: OwinStartup(typeof(Startup))]
namespace TotallyNotRobots.Movies.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Dependencies(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SwaggerConfig.Register(GlobalConfiguration.Configuration);
            UpdateDatabase(app);
        }
    }
}
