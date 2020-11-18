using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; private set; }

        public Announcement Announcement { get; private set; }

        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name ="Comment text")]
        [StringLength(300, ErrorMessage = "Your comment's length must be less than 300 symbols")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        public Account Commentator { get; private set; }


        public Comment()
        {

        }
    }
}