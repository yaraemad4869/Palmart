using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
using Palmart.Data.Enums;

namespace Palmart.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
		[DisplayName("First Name")]
		public string FName { get; set; }
		[MaxLength(20)]
		[DisplayName("Last Name")]
		public string LName { get; set; }
		[MaxLength(30)]
		public string Username { get; set; }
		[MaxLength(14)]
		[DisplayName("Phone Number")]
		public string PhoneNumber {  get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(20)]
		public string Password { get; set; }
		[EnumDataType(typeof(Gender))]
		public Gender Gender { get; set; }
		[EnumDataType(typeof(UserType))]
		public UserType UserType { get; set; } = UserType.Client;
		[MaxLength(50)]
		public string Address { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;
		public ICollection<Review>? reviews { get; set; }
        public ICollection<Report>? reports { get; set; }
        public ICollection<Wishlist>? wishlist { get; set; }
        public ICollection<Order>? orders { get; set; }
        public ICollection<Payment>? payment { get; set; }
        public ICollection<Brand>? brands { get; set; }
        public ICollection<Contact>? contacts { get; set; }


    }
}
