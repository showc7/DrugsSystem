using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DrugsSystem.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitalizeAutomapper();
        }

        protected void InitalizeAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                App_Start.AutoMapperWebConfiguration.Configure(cfg);
            });
        }
    }
}
