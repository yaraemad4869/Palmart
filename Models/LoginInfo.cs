using Palmart.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Palmart.Models
{
	public class LoginInfo
	{
		[Key]
		[MaxLength(50)]
		public string? Email { get; set; }
		[MaxLength(20)]
		public string? Password { get; set; }
		[EnumDataType(typeof(UserType))]
		public UserType? UserType { get; set; } = UserType.Client;
	}
}
