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
    [NavBarNameAction("Customers")]
    public class ContactListsController : Controller {
        private RetailDbContext db = new RetailDbContext();

        // GET: ContactLists
        public ActionResult Index() {
            return View(db.ContactLists.ToList());
        }

        // GET: ContactLists/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null) {
                return HttpNotFound();
            }
            return View(contactList);
        }

        // GET: ContactLists/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ContactLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ContactList contactList) {
            if (ModelState.IsValid) {
                db.ContactLists.Add(contactList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactList);
        }

        // GET: ContactLists/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null) {
                return HttpNotFound();
            }
            return View(contactList);
        }

        // POST: ContactLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ContactList contactList) {
            if (ModelState.IsValid) {
                db.Entry(contactList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactList);
        }

        // GET: ContactLists/EditList/5
        public ActionResult EditList(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null) {
                return HttpNotFound();
            }
            return View(contactList);
        }

        // GET: ContactLists/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null) {
                return HttpNotFound();
            }
            return View(contactList);
        }

        // POST: ContactLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            ContactList contactList = db.ContactLists.Find(id);
            db.ContactLists.Remove(contactList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmptyContactList(int id) {
            ContactList contactList = db.ContactLists.Find(id);
            contactList.Customers.RemoveAll(x => true);
            db.SaveChanges();
            return RedirectToAction("EditList", new { id = id });
        }

        [ChildActionOnly]
        public PartialViewResult ContactListIncludedCustomers(int id) {


            ContactList contactList = db.ContactLists.Find(id);

            var contacts = contactList.Customers;
            ViewBag.ContactListId = id;
            ViewBag.IsCustomersInListView = true;
            return PartialView("_CustomersTable", contacts);
        }

        [ChildActionOnly]
        public PartialViewResult ContactListNotIncludedCustomers(int id) {


            ContactList contactList = db.ContactLists.Find(id);
            var contacts = contactList.Customers;
            var customers = db.Customers.AsEnumerable();
            var notContacts = customers.Where(x => !(contacts.Contains(x)));
            ViewBag.ContactListId = id;
            ViewBag.IsCustomersInListView = false;
            return PartialView("_CustomersTable", notContacts);
        }

        public ActionResult RemoveContactFromList(int listId, int contactId) {
            ContactList contactList = db.ContactLists.Find(listId);
            Customer contact = db.Customers.Find(contactId);
            contactList.Customers.Remove(contact);
            db.SaveChanges();

            return RedirectToAction("EditList", new { id = listId });
        }

        public ActionResult AddContactToList(int listId, int contactId) {
            ContactList contactList = db.ContactLists.Find(listId);
            Customer contact = db.Customers.Find(contactId);
            contactList.Customers.Add(contact);
            db.SaveChanges();

            return RedirectToAction("EditList", new { id = listId });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
