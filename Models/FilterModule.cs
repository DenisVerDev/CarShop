using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class FilterModule //filter model on app's main page
    {
        public CarBrand CarBrand { get; set; }
        public CarModel CarModel { get; set; }
        public CarBodyStyle BodyStyle { get; set; }
        public CarEngineType EngineType { get; set; }
        public CarTransmissionType TransmissionType { get; set; }
        [Display(Name ="Is new?")]
        public bool CurrentState { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}