using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; private set; }

        public Announcement Announcement { get; private set; }

        public Account Account { get; private set; }

        public Basket()
        {

        }
    }
}