using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmartReservation.Interface;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartReservation.Areas.Identity
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ExternalUser>
    {
        private readonly IRole _roleService;
        private readonly IExternalUser _externalUser;
        private readonly IExternalUserRole _externalUserRole;

        public UserClaimsPrincipalFactory(UserManager<ExternalUser> userManager, IOptions<IdentityOptions> optionsAccessor, IRole role, IExternalUser externalUser,
            IExternalUserRole externalUserRole) : base(userManager, optionsAccessor)
        {
            _roleService = role;
            _externalUser = externalUser;
            _externalUserRole = externalUserRole;
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ExternalUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var UserID = await _externalUser.FindByNameAsync(user.Email);
            int userID = UserID.ExternalUserID;
            identity.AddClaim(new Claim("ExternalUserID", $"{userID}"));
            identity.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            var roleList = await _externalUserRole.GetRolesByUserId(userID, "Recipe");
            foreach (var item in roleList)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, item.Role));
            }
            return identity;
        }
    }
}
