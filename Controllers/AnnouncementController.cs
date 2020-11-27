using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Create(AnnouncementModule a)
        {
            if(a == null)
            {
                return HttpNotFound();
            }
            if (a.Announcement.EngineCapacity != 0 && a.Announcement.GeoLocation != null && a.Announcement.Mileage != 0 && a.Announcement.Price != 0)
            {
                try
                {
                    using (CarShopDb db = new CarShopDb())
                    {
                        int id = (int)Session["AccountId"];
                        Account acc = db.Accounts.Where(x => x.Id == id).FirstOrDefault();
                        if (acc != null)
                        {
                            a.Announcement.Announcer = acc;
                            a.Announcement.BodyStyle = db.CarBodyStyles.Where(x => x.BodyStyle == a.BodyStyle).FirstOrDefault();
                            a.Announcement.CarBrand = db.CarBrands.Where(x => x.BrandName == a.CarBrand).FirstOrDefault();
                            a.Announcement.CarModel = db.CarModels.Where(x => x.ModelName == a.CarModel).FirstOrDefault();
                            a.Announcement.EngineType = db.CarEngineTypes.Where(x => x.EngineType == a.EngineType).FirstOrDefault();
                            a.Announcement.TransmissionType = db.CarTransmissionTypes.Where(x => x.TransmissionType == a.TransmissionType).FirstOrDefault();
                            if (a.Announcement.CarBrand != null && a.Announcement.CarModel != null && a.Announcement.BodyStyle != null && a.Announcement.EngineType != null)
                            {
                                db.Announcements.Add(a.Announcement);
                                db.SaveChanges();
                                return RedirectToAction("Index", "Announcement", new { id = a.Announcement.Id });
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
    }
}