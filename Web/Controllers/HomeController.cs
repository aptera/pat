using System.Web.Mvc;

namespace TotallyNotRobots.Movies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Movies");
        }
    }
}