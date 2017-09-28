using Swashbuckle.Application;
using System.Web.Http;

namespace TotallyNotRobots.Movies.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c => { c.SingleApiVersion("v1", "Api"); })
                .EnableSwaggerUi();
        }
    }
}
