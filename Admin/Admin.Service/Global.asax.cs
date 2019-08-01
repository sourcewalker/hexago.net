﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Admin.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InjectionConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MappingConfig.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}