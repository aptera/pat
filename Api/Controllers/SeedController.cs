using System.Web.Http;

namespace TotallyNotRobots.Movies.Api.Controllers
{
    [RoutePrefix("api/v1/seed")]
    public class SeedController : ApiController
    {
        [Route("")]
        public void PostData()
        {
            Startup.UpdateDatabase();
        }
    }
}
