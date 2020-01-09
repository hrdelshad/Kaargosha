﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Kargosha.Data.Domain.Identity
{
	public class User : IdentityUser<int>
	{
		public String FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }
		public DateTime RegisteredOn { get; set; }

		public ICollection<UserRole> Roles { get; set; }
		public ICollection<UserLogin> Logins { get; set; }
		public ICollection<UserClaim> Claims { get; set; }
		public ICollection<UserToken> Tokens { get; set; }
	}
}
