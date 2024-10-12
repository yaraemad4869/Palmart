using Palmart.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Palmart.Models
{
	public class LoginInfo
	{
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(20)]
		public string Password { get; set; }
		
	}
}
