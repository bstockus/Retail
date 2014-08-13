using Retail.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Infrastructure {
    public class ProductsDropDownActionAttribute : FilterAttribute, IActionFilter {

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            using (var context = new RetailDbContext()) {
                var productsSelectListItems = new List<SelectListItem>();
                var products = context.Products.AsEnumerable();
                foreach (Product product in products) {
                    productsSelectListItems.Add(new SelectListItem() {
                        Text = product.Name,
                        Value = product.Id.ToString()
                    });
                }
                filterContext.Controller.ViewBag.ProductsSelectListItems = productsSelectListItems;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {

        }
    }
}