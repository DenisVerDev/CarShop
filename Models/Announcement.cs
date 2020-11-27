using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "This field must be filled")]
        public CarBrand CarBrand { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        public CarModel CarModel { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        public CarBodyStyle BodyStyle { get; set; }

        [Display(Name ="Car's mileage")]
        public double Mileage { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name ="Car's engine capacity(in liters)")]
        public double EngineCapacity { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        public CarEngineType EngineType { get; set; }

        public CarTransmissionType TransmissionType { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name ="Used or new")]
        public bool CurrentState { get; set; }

        [Display(Name ="Car's description")]
        [StringLength(300,ErrorMessage ="Description's length must be less than 300 symbols")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Car's price")]
        [DataType(DataType.Currency,ErrorMessage ="You should enter currency($)")]
        public double Price { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Announcer's location")]
        [StringLength(100, ErrorMessage = "Your location name length must be less than 100 symbols")]
        public string GeoLocation { get; set; }

        [Display(Name = "Announcer")]
        public Account Announcer { get; set; }

        public string ImagePath { get; set; }

        public Announcement()
        {

        }
    }
}