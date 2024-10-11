using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palmart.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Palmart.Data.Enums;

namespace Palmart.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
		[MaxLength(30)]
		public string Name { get; set; }
		[MaxLength(60)]
		public string? Description { get; set; }
		[MaxLength(15)]
		public string CountryOfOrigin { get; set; }
		[EnumDataType(typeof(Category))]
		public Category Category { get; set; }
		[EnumDataType(typeof(BrandStatus))]
		public BrandStatus BrandStatus { get; set; }
        public bool? NotAppropiate { get; set; }
        public bool? Boycott { get; set; }
        [ForeignKey("employee")]
        public int EmpID { get; set; }
        public Employee employee { get; set; }
		[ForeignKey("user")]
		public int UserID { get; set; }
		public User user { get; set; }
		public ICollection<Product>? products { get; set; }
    }
}
