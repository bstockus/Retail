using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class NavBarNameActionAttribute : FilterAttribute, IActionFilter {

        public string Name { get; set; }

        public NavBarNameActionAttribute(string name) {
            this.Name = name;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            filterContext.Controller.ViewBag.NavBarName = this.Name;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}