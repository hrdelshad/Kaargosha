using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kargosha.Data.Services.Identity.Validators
{
    public class AppUserValidator : UserValidator<User>
    {
        public AppUserValidator(IdentityErrorDescriber errors) : base(errors)
        {

        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            var result = await base.ValidateAsync(manager, user);
            this.ValidateEmail(user, result.Errors.ToList());

            return result;
        }

        private void ValidateEmail(User user, List<IdentityError> errors)
        {
            if (user.UserName.Contains("Admin"))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidUser",
                    Description = "نام کاربری معتبر نیست"
                });
            }
        }
    }
}
