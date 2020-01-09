using Microsoft.AspNetCore.Identity;

namespace Kargosha.Data.Domain.Identity
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public User User { get; set; }
    }
}
