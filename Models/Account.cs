using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field must be filled")]
        [Display(Name ="Name", Description ="First name")]
        [StringLength(25,ErrorMessage = "Name's length should be less than 25 symbols")]
        [DataType(DataType.Text,ErrorMessage ="Name must consist only letters")]
        public string FirstName { get; set; }

        [Display(Name="Surname")]
        [StringLength(25, ErrorMessage = "Surname's length should be less than 25 symbols")]
        [DataType(DataType.Text, ErrorMessage = "Name must consist only letters")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Email", Description = "User's email address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Password", Description = "User's password")]
        [StringLength(25, ErrorMessage = "Password's length should be less than 25 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Confirm Password", Description = "User's password")]
        [StringLength(25, ErrorMessage = "Password's length should be less than 25 symbols")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please, enter correct password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Display(Name="User last online")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:y-m-d}")]
        public DateTime LastOnline { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Is you a company")]
        public bool IsCompany { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "User's phone number")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "User's phone number")]
        [Range(0,5)]
        public double Rate { get; set; }
    }
}