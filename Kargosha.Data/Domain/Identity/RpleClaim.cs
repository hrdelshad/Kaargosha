using Microsoft.AspNetCore.Identity;
using System;

namespace Kargosha.Data.Domain.Identity
{
	public class RoleClaim : IdentityRoleClaim<int>
	{
		public DateTime GivenOn { get; set; }
		public Role Role { get; set; }
	}
}
