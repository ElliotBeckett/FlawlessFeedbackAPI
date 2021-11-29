using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Models
{
    public class UserInfo
    {
        public int UserInfoID { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }

        [Display(Name = "User password")]
        [Required(ErrorMessage = "A password is required")]
        public string UserPass { get; set; }

        public int UserRoleID { get; set; }

        //Navigation Properties
        public virtual UserRole UserRole { get; set; }
    }
}