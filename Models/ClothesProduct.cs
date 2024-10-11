using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Palmart.Data.Enums;

namespace Palmart.Models
{
	public class ClothesProduct : Product
	{
		//[ForeignKey("product")]
		//public int ProductID { get; set; }
		//public Product product { get; set; }
		public string Material { get; set; }
		[EnumDataType(typeof(ClothesType))]
		public ClothesType Type { get; set; }
		[EnumDataType(typeof(AgeGroup))]
		public AgeGroup AgeGroup { get; set; }
		[EnumDataType(typeof(Gender))]
		public Gender Gender { get; set; }
		[EnumDataType(typeof(Season))]
		public Season? Season { get; set; }
	}
}
