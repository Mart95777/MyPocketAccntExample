using MyCurrencyPocketbook.Models;
using MyCurrencyPocketbook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCurrencyPocketbook.Controllers
{

    [Authorize]
    public class TransactionController : Controller
    {

        //private ApplicationDbContext db = new ApplicationDbContext();
        private IApplicationDbContext db;

        public TransactionController()
        {
            db = new ApplicationDbContext();
        }

        public TransactionController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Transaction, AddToPocket
        public ActionResult AddToPocket(int pocketAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToPocket(Transaction transaction)
        {
            if(ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                var service = new PocketAccountService(db);
                service.UpdateBalance(transaction.PocketAccountId);

                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}