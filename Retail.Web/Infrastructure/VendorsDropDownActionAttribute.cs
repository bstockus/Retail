using Retail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class VendorsDropDownActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                var vendorsSelectListItems = new List<SelectListItem>();
                var vendors = context.Vendors.AsEnumerable();
                foreach (Vendor vendor in vendors) {
                    vendorsSelectListItems.Add(new SelectListItem() {
                        Text = vendor.Name,
                        Value = vendor.Id.ToString()
                    });
                }
                filterContext.Controller.ViewBag.VendorsSelectListItems = vendorsSelectListItems;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}