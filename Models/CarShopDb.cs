using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class CarShopDb : DbContext
    {
        public CarShopDb() :base("connstr")
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<CarBodyStyle> CarBodyStyles { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarEngineType> CarEngineTypes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarTransmissionType> CarTransmissionTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}