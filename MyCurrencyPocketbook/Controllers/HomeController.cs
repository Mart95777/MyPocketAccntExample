using Microsoft.AspNet.Identity;
using MyCurrencyPocketbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace MyCurrencyPocketbook.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            try
            {
                var pocketAccountId = db.PocketAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
                ViewBag.PocketAccountId = pocketAccountId;
                var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(userId);
            }
            catch
            {
                //return RedirectToRoute()
                //return View("/Account/login");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddAccountNote1()
        {
            ViewBag.AddAccountNoteMessage = "Add a note below:";
            return View();
        }

        [HttpPost]
        public ActionResult AddAccountNote1(string addedNote)
        {
            ViewBag.AddAccountNoteMessage = "A note added!";
            return PartialView("NoteThanks");
        }

        public ActionResult Demo1(string optionId)
        {
            if(optionId == null)
            {
                optionId = "null!";
            }
            var justString = "This is just a string. The option is: " + optionId;
            return Content(justString);
        }

        public ActionResult Demo2(string optionId)
        {
            if (optionId == null)
            {
                optionId = "null!";
            }
            var justString = "This is just a string. The option is: " + optionId;
            return Content(justString);
        }

        public ActionResult EndingPageText()
        {
            return Content("This is ending text on Layout.");
        }
    }
}