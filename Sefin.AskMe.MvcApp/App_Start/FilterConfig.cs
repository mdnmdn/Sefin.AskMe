using System.Web;
using System.Web.Mvc;

namespace Sefin.AskMe.MvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
