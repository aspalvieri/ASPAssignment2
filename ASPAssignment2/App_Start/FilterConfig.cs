﻿using System.Web;
using System.Web.Mvc;

namespace ASPAssignment2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //force request use ssl
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
