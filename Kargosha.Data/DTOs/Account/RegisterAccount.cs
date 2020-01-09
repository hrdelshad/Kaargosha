using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kargosha.Data.DTOs.Account
{
	public class RegisterAccount
	{
		public RegisterAccount()
		{
			DateTime now = DateTime.Now;
			RegisteredOn = now;
		}
		[Required]
		[Remote("ValidateUserName", ErrorMessage ="نام کاربری قبلن ثبت شده است.")]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		[Remote("ValidateEmail", ErrorMessage ="ایمیل قبلن ثبت شده است.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage ="رمز عبور و تکرار آن یکسان نیستند.")]
		public string ConfirmPassword { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public DateTime RegisteredOn { get; set; }
	}
}
