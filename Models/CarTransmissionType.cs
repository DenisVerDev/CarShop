using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarTransmissionType
    {
        [Key]
        public int Id { get; private set; }

        [Display(Name ="Car's transmission type")]
        public string TransmissionType { get;  set; }

        public CarTransmissionType()
        {

        }
    }
}