using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kargosha.Data.DTOs.Account
{
	public class LoginAccount
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		public bool RememberMe { get; set; }

	}
}
