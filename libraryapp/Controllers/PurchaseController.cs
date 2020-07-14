using Antlr.Runtime.Tree;
using DatabaseModel;
using libraryapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libraryapp.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        private LibraryBDEntities db = new LibraryBDEntities();
        public ActionResult NewPurchase()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var temppur = db.PurTemDetailsTables.ToList();

            return View(temppur);
        }



        [HttpPost]
        public ActionResult AddItem(int BID, int Qty, float Price)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            //int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));

            var find = db.PurTemDetailsTables.Where(i => i.BookID == BID).FirstOrDefault();
            if (find == null)
            {
                if (BID > 0 && Qty > 0 && Price > 0)
                {
                    var newitem = new PurTemDetailsTable()
                    {
                        BookID = BID,
                        Qty = Qty,
                        UnitPrice = Price
                    };
                    db.PurTemDetailsTables.Add(newitem);
                    db.SaveChanges();
                    ViewBag.Message = "Dodano pomyślnie";
                }
            }
            else
            {
                ViewBag.Message = "Sprawdź ponownie";
            }
            return RedirectToAction("NewPurchase");
        }

        public ActionResult DeleteConfirm(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var book = db.PurTemDetailsTables.Find(id);
            if (book != null)
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                ViewBag.Message = "Usunięto pomyślnie";
                return RedirectToAction("NewPurchase");
            }
            ViewBag.Message = "Wystąpił błąd";
            return View("NewPurchase");
        }


        [HttpPost]
        public ActionResult GetBooks()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            List<BookMV> list = new List<BookMV>();
            var bookList = db.BookTables.ToList();
            foreach (var item in bookList)
            {
                list.Add(new BookMV { BookTitle = item.BookTitle, BookID = item.BookID });
            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }
    }
}
