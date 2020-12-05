using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InitView();
            return View();
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

        [HttpPost]
        public JsonResult Filter(FilterModule fm)
        {
            return Json(fm, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetModels(string brandname)
        {
            if (brandname == null) return Json("error", JsonRequestBehavior.AllowGet);

            try
            {
                using (CarShopDb db = new CarShopDb())
                {
                    var models = db.CarModels.Where(x => x.CarBrand.BrandName == brandname).ToArray();
                    return Json(models, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult About()
        {
            return View();
        }
    }
}