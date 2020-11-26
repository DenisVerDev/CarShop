using CarShop.VerificationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class LoginModule
    {
        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Email", Description = "User's email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "This should be your email address")]
        [EmailAddress(ErrorMessage = "The Email field does not contain a valid email address")]
        [EmailUniqueAttributes(ErrorMessage ="There is no such account",IsUnique =false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "Password", Description = "User's password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password's length should be 8-25 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}