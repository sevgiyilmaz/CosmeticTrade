using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmeticTrade.MVCWebUI.Models.DTO.Account
{
    public class LoginDTO
    {
        [DisplayName("Your UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }        

        [DisplayName("Your Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }       
    }
}