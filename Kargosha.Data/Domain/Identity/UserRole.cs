﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Kargosha.Data.Domain.Identity
{
	public class UserRole : IdentityUserRole<int>
	{
		public User User { get; set; }
		public Role Role { get; set; }
		public DateTime GivenOn { get; set; }
	}
 }
