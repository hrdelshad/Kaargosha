using System;
using Microsoft.AspNetCore.Identity;

namespace Kargosha.Data.Domain.Identity
{
	public class UserLogin : IdentityUserLogin<int>
	{
		public User User { get; set; }
		public DateTime LoggedOn { get; set; }
	}
}
