using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Retail.Web.Models;

namespace Retail.Web.Controllers {
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

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
