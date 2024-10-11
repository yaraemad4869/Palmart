using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Palmart.Models
{
	public class ClothesColorSize : ClothesProduct
	{
		[MaxLength(20)]
		public string Color { get; set; }
		[MaxLength(10)]
		public string Size { get; set; }
	}
}
