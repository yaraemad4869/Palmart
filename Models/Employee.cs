using System.ComponentModel.DataAnnotations;
using Palmart.Data.Enums;

namespace Palmart.Models
{
    public class Employee
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(20)]
		public string FName { get; set; }
		[MaxLength(20)]
		public string LName { get; set; }
		[MaxLength(12)]
		public string PhoneNumber { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(20)]
		public string Password { get; set; }
		[EnumDataType(typeof(Gender))]
		public Gender Gender { get; set; }
		[EnumDataType(typeof(EmployeeRole))]
		public EmployeeRole EmployeeRole { get; set; }
		public DateTime HiringDate { get; set; }
		public ICollection<Order>? orders { get; set; }
		public ICollection<Brand>? brands { get; set; }
        public ICollection<EmployeeContact>? employeeContacts { get; set; }

    }
}
