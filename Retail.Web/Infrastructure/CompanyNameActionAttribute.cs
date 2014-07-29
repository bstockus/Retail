using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Retail.Web.Models;

namespace Retail.Infrastructure {
    public class CompanyNameActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                Company company = context.Companies.First();
                filterContext.Controller.ViewBag.CompanyName = company.Name;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}