using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            Account account = null;
            try
            {
                int id = (int)Session["AccountId"];
                using(CarShopDb db = new CarShopDb())
                {
                    account = db.Accounts.Where(x => x.Id == id).FirstOrDefault();
                    if(account == null) return View("~/Views/Shared/Error.cshtml"); //TODO make error page
                }
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml"); //TODO make error page
            }

            return View(account);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Account acc)
        {
            if(acc == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                acc.LastOnline = DateTime.Now;
                try
                {
                    using (CarShopDb db = new CarShopDb())
                    {  
                        db.Accounts.Add(acc);
                        db.SaveChanges();
                    }
                    Session.Add("AccountId", acc.Id);
                    Session.Add("AccountName", acc.FirstName+acc.SecondName);
                    return RedirectToAction("Index","Account");
                }
                catch (Exception ex)
                {
                    return View("~/Views/Shared/Error.cshtml"); //TODO make error page
                }
            }
            return View(acc);
        }

    }
}