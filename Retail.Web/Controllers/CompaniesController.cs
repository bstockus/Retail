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
    public class CompaniesController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: Companies/Edit
        public ActionResult Edit() {
            return View(db.Companies.Find(1));
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TaxRate")] Company company) {
            if (ModelState.IsValid) {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                CompanyNameActionAttribute.FlushCachedCompanyName();
                return RedirectToAction("Index", "Home");
            }
            return View(company);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
