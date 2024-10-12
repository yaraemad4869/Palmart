<<<<<<< HEAD
﻿using Palmart.Data.Enums;
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
=======
﻿using Palmart.Data.Enums;
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
>>>>>>> e14596fa2815c3abeeab24a806a31c2f1350cfcd
