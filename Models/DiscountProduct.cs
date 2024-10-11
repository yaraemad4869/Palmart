using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Palmart.Models
{
	public class DiscountProduct
	{
		[ForeignKey("discount")]
		public int DiscountID { get; set; }
		public Discount discount { get; set; }
		[ForeignKey("product")]
		public int ProductID { get; set; }
		public Product product { get; set; }

	}
}
