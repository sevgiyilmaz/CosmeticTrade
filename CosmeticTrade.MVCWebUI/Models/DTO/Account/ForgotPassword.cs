using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmeticTrade.MVCWebUI.Models.DTO.Account
{
    public class ForgotPassword
    {        
        [DisplayName("Your Email")]
        [EmailAddress(ErrorMessage = "Email address is not available")]
        [MaxLength(30, ErrorMessage = "Email cannot exceed 30 characters.")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}