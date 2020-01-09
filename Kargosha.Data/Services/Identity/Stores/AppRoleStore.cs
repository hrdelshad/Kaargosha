using Kargosha.Data.Context;
using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kargosha.Data.Services.Identity.Stores
{
	public class AppRoleStore : RoleStore<Role, KargoshaDbContext, int, UserRole, RoleClaim>
	{
		public AppRoleStore(KargoshaDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}
