using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kargosha.Data.Services.Identity.Validators
{
    public class AppRoleValidator : RoleValidator<Role>
    {
        public AppRoleValidator(IdentityErrorDescriber errors) : base(errors)
        {

        }

        public override async Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
        {
            var result = await base.ValidateAsync(manager, role);
            this.ValidateRoleName(role, result.Errors.ToList());

            return result;
        }

        private void ValidateRoleName(Role role, List<IdentityError> errors)
        {
            if (role.Name.Contains("Admin"))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidRoleName",
                    Description = "این نام برای نقش معتبر نیست"
                });
            }
        }
    }
}
