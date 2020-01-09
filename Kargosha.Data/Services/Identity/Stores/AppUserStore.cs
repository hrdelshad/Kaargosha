using Kargosha.Data.Context;
using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kargosha.Data.Services.Identity.Stores
{
	public class AppUserStore : UserStore<User, Role, KargoshaDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
	{
		public AppUserStore(KargoshaDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}
