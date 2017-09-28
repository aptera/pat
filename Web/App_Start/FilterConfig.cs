using System.Web;
using System.Web.Mvc;

namespace TotallyNotRobots.Movies
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
