using CarShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.VerificationAttributes
{
    public class EmailUniqueAttributes:ValidationAttribute
    {
        public bool IsUnique { get; set; }

        public override bool IsValid(object value)
        {
            string email = (string)value;
            try
            {
                using (CarShopDb db = new CarShopDb())
                {
                    if(IsUnique) return !db.Accounts.Where(x => x.Email == email).Any();
                    else return db.Accounts.Where(x => x.Email == email).Any();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

    public class PhoneUniqueAttributes : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            string phone = (string)value;
            try
            {
                using (CarShopDb db = new CarShopDb())
                {
                    return !db.Accounts.Where(x => x.PhoneNumber == phone).Any();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


}