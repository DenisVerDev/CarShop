using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; private set; }

        public CarBrand CarBrand { get; private set; }

        public string ModelName { get; private set; }
    }
}