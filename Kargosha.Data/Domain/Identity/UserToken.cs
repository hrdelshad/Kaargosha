using System;
using Microsoft.AspNetCore.Identity;

namespace Kargosha.Data.Domain.Identity
{
	public class UserToken : IdentityUserToken<int>
	{
		public User User { get; set; }
		public DateTime GeneratedOn { get; set; }
	}
}
