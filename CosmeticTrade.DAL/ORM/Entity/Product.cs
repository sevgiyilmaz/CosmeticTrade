using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.Commentaries = new HashSet<Commentary>();
            this.OrderDetails = new HashSet<OrderDetail>();
            Random rnd = new Random();
            this.Code = rnd.Next(1000, 9999).ToString();
            this.Insales = true;
        }

        [MaxLength(100, ErrorMessage = " Product Name cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Product Name cannot be empty.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }

        [MaxLength(20, ErrorMessage = "Brand cannot exceed 20 characters.")]
        [Required(ErrorMessage = "Brand cannot be empty.")]
        public string Brand { get; set; }

        [MaxLength(10, ErrorMessage = " Product Code cannot exceed 10 characters.")]
        [Required(ErrorMessage = "Product Code cannot be empty.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Price cannot be empty.")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [NotMapped]
        public IEnumerable<HttpPostedFileBase> Img { get; set; }

        [NotMapped]
        public string ImageIds { get; set; }

        public bool Insales { get; set; }

        public short Stock { get; set; } = 0;

        //[Required(ErrorMessage = "Category cannot be empty.")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Commentary> Commentaries { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
