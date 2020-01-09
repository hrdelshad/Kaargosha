using Kargosha.Data.Domain.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kargosha.Data.Services.Identity.Managers
{
    public class AppSigninManager : SignInManager<User>
    {
        public AppSigninManager(
            UserManager<User> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<User> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<User>> logger, 
            IAuthenticationSchemeProvider schemes, 
            IUserConfirmation<User> confirmation
        ) : base(userManager,
                 contextAccessor,
                 claimsFactory,
                 optionsAccessor,
                 logger,
                 schemes,
                 confirmation)
        {
        }

        //override
    }
}
