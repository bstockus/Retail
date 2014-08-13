using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Retail.Web.Models;
using Retail.Web.Infrastructure;

namespace Retail.Web.Controllers {
    [NavBarNameAction("Products")]
    public class ProductsController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: Products
        public ActionResult Index() {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [CategoriesDropDownAction]
        [VendorsDropDownAction]
        public ActionResult Create() {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Category, string Name, string Description, decimal Price, int Vendor) {
            Product product = new Product();
            Category _category = db.Categories.Where(c => c.Id == Category).First();
            Vendor _vendor = db.Vendors.Where(v => v.Id == Vendor).First();
            product.Category = _category;
            product.Name = Name;
            product.Description = Description;
            product.Price = Price;
            product.Vendor = _vendor;
            try {
                db.Products.Add(product);
                db.SaveChanges();
            } catch (Exception e) {
                System.Diagnostics.Debugger.Break();
            }

            return RedirectToAction("Details", new { id = product.Id });
        }

        // GET: Products/Edit/5
        [CategoriesDropDownAction]
        [VendorsDropDownAction]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Category, int Id, string Name, string Description, decimal Price, int Vendor) {
            Product product = db.Products.Where(p => p.Id == Id).First();
            Category _category = db.Categories.Where(c => c.Id == Category).First();
            Vendor _vendor = db.Vendors.Where(v => v.Id == Vendor).First();
            product.Category = _category;
            product.Name = Name;
            product.Description = Description;
            product.Price = Price;
            product.Vendor = _vendor;
            try {
                db.SaveChanges();
            } catch (Exception e) {
                System.Diagnostics.Debugger.Break();
            }
            
            return RedirectToAction("Details", new { id = product.Id });
        }

        [ChildActionOnly]
        public ActionResult SalesForProduct(Product product) {

            var sales = product.SaleItems.Select(x => x.Sale).Distinct();


            return PartialView("_SalesForProduct", sales);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
