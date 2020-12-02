using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index(int id)
        {
            if (id < 0) return HttpNotFound();
            Announcement a = null;
            try
            {
                using(CarShopDb db = new CarShopDb())
                {
                    a = db.Announcements.Where(x => x.Id == id).FirstOrDefault();
                    if(a == null) return View("~/Views/Shared/Error.cshtml"); //TODO make error page
                }
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml"); //TODO make error page
            }

            CultureInfo culture = new CultureInfo("en-Us");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            return View(a);
        }

        public void InitView()
        {
            using (CarShopDb db = new CarShopDb())
            {
                ViewBag.CarBrands = new SelectList(db.CarBrands.ToArray(), "BrandName", "BrandName");
                CarBrand carbrandfirst = db.CarBrands.First();
                CarModel[] models = db.CarModels.Where(x => x.CarBrand.BrandName == carbrandfirst.BrandName).ToArray();
                ViewBag.CarModels = new SelectList(models, "ModelName", "ModelName");
                ViewBag.CarEgineTypes = new SelectList(db.CarEngineTypes.ToArray(), "EngineType", "EngineType");
                ViewBag.CarBodyStyles = new SelectList(db.CarBodyStyles.ToArray(), "BodyStyle", "BodyStyle");
                ViewBag.CarTransmissionTypes = new SelectList(db.CarTransmissionTypes.ToArray(), "TransmissionType", "TransmissionType");
            }
        }

        public ActionResult Create()
        {
            if (Session["AccountId"] == null) return View("~/Views/Shared/Error.cshtml"); //TODO make error page
            InitView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Announcement a, HttpPostedFileBase mainimage)
        {
            if(a == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (CarShopDb db = new CarShopDb())
                    {
                        int id = (int)Session["AccountId"];
                        Account acc = db.Accounts.Where(x => x.Id == id).FirstOrDefault();
                        if (acc != null)
                        {
                            a.Announcer = acc;
                            a.BodyStyle = db.CarBodyStyles.Where(x => x.BodyStyle == a.BodyStyle.BodyStyle).FirstOrDefault();
                            a.CarBrand = db.CarBrands.Where(x => x.BrandName == a.CarBrand.BrandName).FirstOrDefault();
                            a.CarModel = db.CarModels.Where(x => x.ModelName == a.CarModel.ModelName).FirstOrDefault();
                            a.EngineType = db.CarEngineTypes.Where(x => x.EngineType == a.EngineType.EngineType).FirstOrDefault();
                            a.TransmissionType = db.CarTransmissionTypes.Where(x => x.TransmissionType == a.TransmissionType.TransmissionType).FirstOrDefault();
                            if (a.CarBrand != null && a.CarModel != null && a.BodyStyle != null && a.EngineType != null)
                            {
                                db.Announcements.Add(a);
                                db.SaveChanges();
                                if (mainimage != null)
                                {
                                    string path = Server.MapPath("~/AnnImages/" + a.Id);
                                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                                    mainimage.SaveAs(Server.MapPath(String.Format("~/AnnImages/{0}/{1}", a.Id, mainimage.FileName)));
                                }
                                return RedirectToAction("Index", "Announcement", new { id = a.Id });
                            }
                            else return View("~/Views/Shared/Error.cshtml"); //TODO make error page
                        }
                        else return HttpNotFound();

                    }
                }
                catch (Exception ex)
                {
                    return View("~/Views/Shared/Error.cshtml"); //TODO make error page
                }
            }
            InitView();
            return View(a);
        }

        [HttpGet]
        public JsonResult GetModels(string brandname)
        {
            if(brandname == null) return Json("error", JsonRequestBehavior.AllowGet);
            
            try
            {
                using(CarShopDb db = new CarShopDb())
                {
                    var models = db.CarModels.Where(x => x.CarBrand.BrandName == brandname).ToArray();
                    return Json(models, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}