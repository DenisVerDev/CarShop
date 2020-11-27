using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class AnnouncementModule
    {
        public Announcement Announcement { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string BodyStyle { get; set; }
        public string EngineType { get; set; }
        public string TransmissionType { get; set; }
    }
}