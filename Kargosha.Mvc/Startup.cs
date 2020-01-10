using Kargosha.Data.Services.Identity;
using Kargosha.Data.Context;
using Kargosha.Data.Domain.Identity;
using Kargosha.Data.Services.Identity.Managers;
using Kargosha.Data.Services.Identity.Stores;
using Kargosha.Data.Services.Identity.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kargosha.Mvc
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<KargoshaDbContext>(options =>
			{
				options.UseSqlServer(
					connectionString: Configuration.GetConnectionString("KargoshaConnection")
					);
			});

			services.AddIdentity<User, Role>(option =>
			{
				option.User.RequireUniqueEmail = true;

				option.Password.RequireDigit = false;
				option.Password.RequireLowercase = false;
				option.Password.RequireUppercase = false;
				option.Password.RequireNonAlphanumeric = false;

				option.SignIn.RequireConfirmedAccount = false;
				option.SignIn.RequireConfirmedEmail = false;
				option.SignIn.RequireConfirmedPhoneNumber = false;
				// رمزنگاری اطلاعات کاربر در دیتابیس
				//option.Stores.ProtectPersonalData = false;
				// ایجاد توکن برای تغییر رمز، ارسال ایمیل،‌ارسال پیمک و ...
				// ما از AddDefaultTokenProviders استفاده کرده ایم
				//option.Tokens.

			})
				//.AddEntityFrameworkStores<KargoshaDbContext>()
				// به جای استفاده از استور پیش فرض از استورهایی که خودمان ساخته ایم استفاده میکنیم
				.AddRoleStore<AppRoleStore>()
				.AddUserStore<AppUserStore>()
				// جهت استفاده از ولیدیتورهای خودمون
				.AddUserValidator<AppUserValidator>()
				.AddRoleValidator<AppRoleValidator>()
				// استفاده از منجرهای خودمان
				.AddUserManager<AppUserManager>()
				.AddRoleManager<AppRoleManager>()
				.AddSignInManager<AppSigninManager>()
				// پیامهای فارسی
				.AddErrorDescriber<AppErrorDescriber>()
				//
				.AddClaimsPrincipalFactory<AppUserClaimsPrincipalFactory>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				// تغییر نام کوکی
				options.Cookie.Name = "Kargosha.Cooki";
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapAreaControllerRoute(
					name: "MemberPanel", 
					areaName: "member", 
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapAreaControllerRoute(
					name: "AdminPanel",
					areaName: "admin",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}