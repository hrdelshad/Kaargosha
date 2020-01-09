using Microsoft.AspNetCore.Identity;

namespace Kargosha.Data.Services.Identity
{
	public class AppErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError DefaultError()
		{
			return new IdentityError
			{
				Code=nameof(DefaultError),
				Description="خطایی رخ داده است."
			};
		}

		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Code=nameof(DuplicateEmail),
				Description = "ایمیل تکراری است."
			};
		}

		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError
			{
				Code = nameof(DuplicateUserName),
				Description = "نام کاربری تکراری است."
			};
		}

		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError
			{
				Code= nameof(InvalidUserName),
				Description = "نام کاربری معتبر نیست."
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code=nameof(PasswordRequiresDigit),
				Description="رمز عبور باید شامل عدد باشد."
			};
		}
	}
}
