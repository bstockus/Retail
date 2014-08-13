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
    public class SaleItemsController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: SaleItems
        public ActionResult Index() {
            return View(db.SaleItems.ToList());
        }

        // GET: SaleItems/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null) {
                return HttpNotFound();
            }
            return View(saleItem);
        }

        // GET: SaleItems/Create
        public ActionResult Create() {
            return View();
        }

        // POST: SaleItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UnitPrice,ItemPrice")] SaleItem saleItem) {
            if (ModelState.IsValid) {
                db.SaleItems.Add(saleItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleItem);
        }

        // GET: SaleItems/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null) {
                return HttpNotFound();
            }
            return View(saleItem);
        }

        // POST: SaleItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UnitPrice,ItemPrice")] SaleItem saleItem) {
            if (ModelState.IsValid) {
                db.Entry(saleItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleItem);
        }

        // GET: SaleItems/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null) {
                return HttpNotFound();
            }
            return View(saleItem);
        }

        // POST: SaleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            SaleItem saleItem = db.SaleItems.Find(id);
            db.SaleItems.Remove(saleItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SaleItems/AddSaleItemModal/5
        [ProductsDropDownAction]
        public PartialViewResult AddSaleItemModal(int id) {

            Sale sale = db.Sales.Find(id);

            SaleItem saleItem = new SaleItem();
            saleItem.Sale = sale;

            return PartialView("_AddSaleItemModal", saleItem);

        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
