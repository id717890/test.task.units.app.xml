using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using app_for_xml.infrastructure.services;

namespace app_for_xml
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Logger.InitLogger();
        }
    }
}
