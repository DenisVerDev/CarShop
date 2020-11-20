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

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<CarBodyStyle> CarBodyStyles { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarEngineType> CarEngineTypes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarTransmissionType> CarTransmissionTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}