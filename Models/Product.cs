using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmart.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
		[MaxLength(15)]
		public string Name { get; set; }
		[MaxLength(50)]
		public string? Description { get; set; }
		[MaxLength(50)]
		public string Image {  get; set; }
        public DateTime AdditionDate { get; set; }

        [ForeignKey("brand")]
        public int BrandID { get; set; }
        public Brand brand { get; set; }
        [Range(1,5)]
        public decimal Rating { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
       
		public ICollection<Review>? reviews { get; set; }
        public ICollection<Report>? reports { get; set; }
		public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<DiscountProduct>? DiscountProducts { get; set; }
        public ICollection<Wishlist>? wishlists { get; set; }


    }
}
