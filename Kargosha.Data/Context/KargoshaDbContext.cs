using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kargosha.Data.Context
{

	public class KargoshaDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
	{
		public KargoshaDbContext(DbContextOptions<KargoshaDbContext> options) : base(options)
		{

		}

		// برای تغییر نام جداول به نامهای مورد نظر خود
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			builder.Entity<User>(modelBuilder =>
			{
				modelBuilder.ToTable("Users");
			});

			builder.Entity<Role>(modelBuilder =>
			{
				modelBuilder.ToTable("Roles");
			});

			builder.Entity<UserClaim>(modelBuilder =>
			{
				modelBuilder.ToTable("UserClaims");
				modelBuilder
					.HasOne(userClaim => userClaim.User)
					.WithMany(user => user.Claims)
					.HasForeignKey(userClaim => userClaim.UserId);
			});
			builder.Entity<UserRole>(modelBuilder =>
			{
				modelBuilder.ToTable("UserRoles");

				modelBuilder
					.HasOne(userRole => userRole.User)
					.WithMany(role => role.Roles)
					.HasForeignKey(userRole => userRole.UserId);

				modelBuilder
					.HasOne(userRole => userRole.Role)
					.WithMany(role => role.Users)
					.HasForeignKey(userRole => userRole.RoleId);
			});
			builder.Entity<UserLogin>(modelBuilder =>
			{
				modelBuilder.ToTable("UserLogin");

				modelBuilder
					.HasOne(userLogin => userLogin.User)
					.WithMany(user => user.Logins)
					.HasForeignKey(userLogin => userLogin.UserId);
			});
			builder.Entity<RoleClaim>(modelBuilder =>
			{
				modelBuilder.ToTable("RoleClaims");

				modelBuilder.HasOne(roleClaim => roleClaim.Role)
					.WithMany(role => role.Claims)
					.HasForeignKey(roleClaim => roleClaim.RoleId);
			});
			builder.Entity<UserToken>(modelBuilder =>
			{
				modelBuilder.ToTable("UserTokens");

				modelBuilder.HasOne(userToken => userToken.User)
					.WithMany(user => user.Tokens)
					.HasForeignKey(userToken => userToken.UserId);
			});
		}
	}
}
