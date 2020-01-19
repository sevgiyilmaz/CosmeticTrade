using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmeticTrade.MVCWebUI.Models.DTO.Account
{
    public class RegisterDTO
    {
        [DisplayName("Your Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Your SurName")]
        [Required(ErrorMessage = "SurName is required")]
        public string SurName { get; set; }

        [DisplayName("Your UserName")]
        //Deneme
        //[Remote("IsUserName","Validation",ErrorMessage="UserName already exist")]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [DisplayName("Your Email")]
        [EmailAddress(ErrorMessage = "Email address is not available")]
        [MaxLength(30, ErrorMessage = "Email cannot exceed 30 characters.")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [MaxLength(500,ErrorMessage ="ShipAddress cannot exceed 500 characters.")]
        [Required(ErrorMessage = "ShipAddress is required")]
        public string ShipAddress { get; set; }

        [DisplayName("Your Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Your Password Again")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Your passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}