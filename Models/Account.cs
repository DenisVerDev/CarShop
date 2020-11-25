using CarShop.VerificationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Models
{
    public class Account
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage ="This field must be filled")]
        [Display(Name ="Name", Description = "Your first name or your company name")]
        [StringLength(25,ErrorMessage = "Name's length should be less than 25 symbols")]
        [DataType(DataType.Text,ErrorMessage ="Name must consist only letters")]
        public string FirstName { get; set; }

        [Display(Name="Surname")]
        [StringLength(25, ErrorMessage = "Surname's length should be less than 25 symbols")]
        [DataType(DataType.Text, ErrorMessage = "Surname must consist only letters")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Email", Description = "User's email address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="This should be your email address")]
        [EmailAddress(ErrorMessage = "The Email field does not contain a valid email address")]
        [EmailUniqueAttributes(ErrorMessage ="This email has already used")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Password", Description = "User's password")]
        [StringLength(25, MinimumLength =8, ErrorMessage = "Password's length should be 8-25 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match!")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Display(Name="Last online")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:y-m-d}")]
        public DateTime LastOnline { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Is you a company?")]
        public bool IsCompany { get; set; }

        [Display(Name = "Your phone number")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Phone number must contain only numbers")]
        [StringLength(15,MinimumLength=4 ,ErrorMessage ="Phone number length should contain 4-15 numbers")]
        [Phone(ErrorMessage = "The phone number field does not contain a valid phone number")]
        [PhoneUniqueAttributes(ErrorMessage = "This phone has already used")]
        public string PhoneNumber { get; set; }

        [Display(Name = "User's rate")]
        [Range(0,5)]
        public double Rate { get; set; }

        public Account()
        {

        }
    }
}