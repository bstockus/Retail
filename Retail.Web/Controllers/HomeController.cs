using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Retail.Web.Infrastructure;

namespace Retail.Web.Controllers {

    [NavBarNameAction("Home")]
    public class HomeController : Controller {
        
        [EmployeesDropDownAction]
        public ActionResult Index() {
            return View();
        }
    }
}