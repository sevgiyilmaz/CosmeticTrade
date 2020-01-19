using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class User : BaseEntity
    {
        public User()
        {
            IsLocked = true;
            this.Commentaries = new HashSet<Commentary>();
            this.Orders = new HashSet<Order>();
            this.Roles = new HashSet<Role>();
        }

        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }


        [MaxLength(20, ErrorMessage = "Surname cannot exceed 20 characters.")]
        [Required(ErrorMessage = "SurName cannot be empty.")]
        public string Surname { get; set; }

        [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]        
        [Required(ErrorMessage = "Username cannot be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Email cannot be empty.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool ConfirmMail { get; set; } = false;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[MaxLength(500, ErrorMessage = "BillAddress cannot exceed 500 characters.")]
        //[Required(ErrorMessage = "BillAddress cannot be empty.")]
        //public string BillAddress { get; set; }

        [Required(ErrorMessage ="ShipAddress cannot be empty.")]
        [MaxLength(500, ErrorMessage = "ShipAddress cannot exceed 500 characters.")]
        public string ShipAddress { get; set; }
        public bool IsLocked { get; set; }


        public virtual ICollection<Commentary> Commentaries { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
