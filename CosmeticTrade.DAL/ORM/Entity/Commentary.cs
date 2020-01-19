using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Commentary:BaseEntity
    {
        [MaxLength(500,ErrorMessage = "Commentary name cannot exceed 500 characters.")]
        [Required(ErrorMessage = "Commentary name cannot be empty.")]
        public string Description { get; set; }

        public bool? Like { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
