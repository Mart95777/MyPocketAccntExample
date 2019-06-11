using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCurrencyPocketbook.Models;
using Microsoft.AspNet.Identity;

namespace MyCurrencyPocketbook.Controllers
{
    //[Authorize]
    public class PocketAccountController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PocketAccount
        public ActionResult Index()
        {
            return View();
        }


        // GET: PocketAccount/Details
        public ActionResult Details()
        {

            var userId = User.Identity.GetUserId();
            var pocketAccount = db.PocketAccounts.Where(c => c.PocketAccountNumber == userId).First();

            return View(pocketAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var userId = User.Identity.GetUserId();
            var pocketAccount = db.PocketAccounts.Find(id);

            return View("Details", pocketAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.PocketAccounts.ToList());
        }

        // GET: PocketAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PocketAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PocketAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PocketAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PocketAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PocketAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
