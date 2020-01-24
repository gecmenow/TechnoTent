using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.UserModels
{
    public class EditUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [RequiredIf("NewPassword", true, ErrorMessage = "hello")]
        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}