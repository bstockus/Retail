using Retail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class CategoriesDropDownActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                var categorySelectListItems = new List<SelectListItem>();
                var categories = context.Categories.AsEnumerable();
                foreach (Category category in categories) {
                    categorySelectListItems.Add(new SelectListItem() {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
                }
                filterContext.Controller.ViewBag.CategoriesSelectListItems = categorySelectListItems;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}