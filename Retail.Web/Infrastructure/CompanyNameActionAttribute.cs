using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Retail.Web.Models;

namespace Retail.Web.Infrastructure {
    public class CompanyNameActionAttribute : FilterAttribute, IActionFilter {

        private static string CACHED_COMPANY_NAME = null;

        private static string CompanyName {
            get {
                if (CACHED_COMPANY_NAME == null) {
                    using (var context = new RetailDbContext()) {
                        Company company = context.Companies.First();
                        CACHED_COMPANY_NAME = company.Name;
                    }
                }
                return CACHED_COMPANY_NAME;
            }
        }

        public static void FlushCachedCompanyName() {
            CACHED_COMPANY_NAME = null;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            filterContext.Controller.ViewData.Add("CompanyName", CompanyNameActionAttribute.CompanyName);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}