using Retail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class EmployeesDropDownActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                var employeesSelectListItems = new List<SelectListItem>();
                var employees = context.Employees.AsEnumerable();
                foreach (Employee employee in employees) {
                    employeesSelectListItems.Add(new SelectListItem() {
                        Text = employee.LastName + ", " + employee.FirstName,
                        Value = employee.Id.ToString()
                    });
                }
                filterContext.Controller.ViewBag.EmployeesSelectListItems = employeesSelectListItems;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}