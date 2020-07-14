using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseModel;

namespace libraryapp.Controllers
{
    public class SupplierTablesController : Controller
    {
        private LibraryBDEntities db = new LibraryBDEntities();

        // GET: SupplierTables
        public ActionResult Index()
        {
            var supplierTables = db.SupplierTables.Include(s => s.UserTable);
            return View(supplierTables.ToList());
        }

        // GET: SupplierTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplierTable = db.SupplierTables.Find(id);
            if (supplierTable == null)
            {
                return HttpNotFound();
            }
            return View(supplierTable);
        }

        // GET: SupplierTables/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName");
            return View();
        }

        // POST: SupplierTables/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,UserID,ContactNo,Email,Description")] SupplierTable supplierTable)
        {
            if (ModelState.IsValid)
            {
                db.SupplierTables.Add(supplierTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", supplierTable.UserID);
            return View(supplierTable);
        }

        // GET: SupplierTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplierTable = db.SupplierTables.Find(id);
            if (supplierTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", supplierTable.UserID);
            return View(supplierTable);
        }

        // POST: SupplierTables/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,UserID,ContactNo,Email,Description")] SupplierTable supplierTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", supplierTable.UserID);
            return View(supplierTable);
        }

        // GET: SupplierTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplierTable = db.SupplierTables.Find(id);
            if (supplierTable == null)
            {
                return HttpNotFound();
            }
            return View(supplierTable);
        }

        // POST: SupplierTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierTable supplierTable = db.SupplierTables.Find(id);
            db.SupplierTables.Remove(supplierTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
