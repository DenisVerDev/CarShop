using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarEngineType
    {
        [Key]
        public int Id { get; private set; }

        [Display(Name ="Car's engine type")]
        public string EngineType { get;  set; }

        public CarEngineType()
        {

        }
    }
}