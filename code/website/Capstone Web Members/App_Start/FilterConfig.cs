﻿using System.Web;
using System.Web.Mvc;

namespace Capstone_Web_Members
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
