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
    [NavBarNameAction("Sales")]
    public class SalesController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: Sales
        public ActionResult Index() {
            return View(db.Sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null) {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        [CustomersDropDownAction]
        [EmployeesDropDownAction]
        public ActionResult Create() {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Customer, int Employee) {

            Customer _customer = db.Customers.Where(c => c.Id == Customer).First();
            Employee _employee = db.Employees.Where(e => e.Id == Employee).First();

            Sale sale = new Sale();
            sale.Customer = _customer;
            sale.Employee = _employee;
            sale.Date = DateTime.Now;
            sale.SubTotal = 0.00M;
            sale.Discount = 0.00M;
            sale.Tax = 0.00M;
            sale.Total = 0.00M;

            db.Sales.Add(sale);
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = sale.Id });
        }

        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null) {
                return HttpNotFound();
            }
            return View(sale);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
