using Retail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class CustomersDropDownActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                var customersSelectListItems = new List<SelectListItem>();
                var customers = context.Customers.AsEnumerable();
                foreach (Customer customer in customers) {
                    customersSelectListItems.Add(new SelectListItem() {
                        Text = customer.LastName + ", " + customer.FirstName,
                        Value = customer.Id.ToString()
                    });
                }
                filterContext.Controller.ViewBag.CustomersSelectListItems = customersSelectListItems;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}