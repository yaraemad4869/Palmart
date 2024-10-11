using System.ComponentModel.DataAnnotations;

namespace Palmart.Models
{
	public class Discount
	{
		[Key]
		public int ID { get; set; }
		public string DisValue { get; set; }
		[MaxLength(50)]
		public string? Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ICollection<DiscountProduct>? discountProducts { get; set; }
	}
}
