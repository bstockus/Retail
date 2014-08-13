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
    [NavBarNameAction("Services")]
    public class ServicesController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: Services
        public ActionResult Index() {
            return View(db.Services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null) {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        [CustomersDropDownAction]
        [EmployeesDropDownAction]
        [ProductsDropDownAction]
        public ActionResult Create() {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Customer, int Employee, int Product, string Description) {
            Service service = new Service();
            Customer _customer = db.Customers.Find(Customer);
            Employee _employee = db.Employees.Find(Employee);
            Product _product = db.Products.Find(Product);
            service.Date = DateTime.Now;
            service.Description = Description;
            service.IsOpen = true;
            service.Customer = _customer;
            service.Employee = _employee;
            service.Product = _product;
            try {
                db.Services.Add(service);
                db.SaveChanges();
            } catch (Exception e) {
                System.Diagnostics.Debugger.Break();
            }

            return RedirectToAction("Details", new { id = service.Id });
        }

        // POST: Services/Close/5
        [HttpPost]
        public ActionResult Close(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null) {
                return HttpNotFound();
            }
            service.IsOpen = false;
            service.Customer = service.Customer;
            service.Employee = service.Employee;
            service.Product = service.Product;
            db.Entry(service).State = EntityState.Modified;
            
            db.SaveChanges();

            return RedirectToAction("Details", new { id = service.Id });

        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null) {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string Description) {
            Service service = db.Services.Find(Id);
            service.Customer = service.Customer;
            service.Employee = service.Employee;
            service.Product = service.Product;
            service.Description = Description;
            try {
                db.SaveChanges();
            } catch (Exception e) {
                System.Diagnostics.Debugger.Break();
            }

            return RedirectToAction("Details", new { id = service.Id });
        }

        // GET: Incidents/Survey/5
        public ActionResult Survey(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null) {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Incidents/Survey
        [HttpPost, ActionName("Survey")]
        public ActionResult SurveySubmit(int? serviceId, string contactMe, string contactBy) {

            if (contactMe == "yes") {
                if (contactBy == "phone") {
                    ViewBag.SurveyMessage = "A customer service representative will contact you within the next 24 hours by phone.";
                } else {
                    ViewBag.SurveyMessage = "A customer service representative will contact you within the next 24 hours by email.";
                }
            } else {
                ViewBag.SurveyMessage = "";
            }

            return View("SurveyResults");
        }

        public PartialViewResult GetOpenServices(int Employee) {
            Employee _employee = db.Employees.Find(Employee);
            IEnumerable<Service> services = db.Services.ToList();
            IEnumerable<Service> _services = services.Where(s => ((s.Employee == _employee) && s.IsOpen));
            return PartialView(_services);
        }

        public PartialViewResult GetAvailableSurveys() {
            IEnumerable<Service> services = db.Services.ToList();
            IEnumerable<Service> _services = services.Where(s => !s.IsOpen);
            return PartialView(_services);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
