﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarBodyStyle
    {
        [Key]
        public int Id { get; private set; }

        [Display(Name ="Car body style")]
        public string BodyStyle { get; private set; }

        public CarBodyStyle()
        {

        }
    }
}