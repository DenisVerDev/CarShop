using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarBrand
    {
        [Key]
        public int Id { get; private set; }

        [Display(Name ="Car brand")]
        public string BrandName { get; private set; }

        public CarBrand()
        {

        }
    }
}