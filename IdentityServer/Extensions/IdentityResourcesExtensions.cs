using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Extensions
{
    public class IdentityResourcesExtensions
    {
        /// <summary>
        /// Models the standard roles scope
        /// </summary>
        /// <seealso cref="IdentityResourcesExtensions" />
        public class Roles : IdentityResource
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="OpenId"/> class.
            /// </summary>
            public Roles()
            {
                Name        = IdentityServerConstantsExtensions.StandardScopesExtensions.Roles;
                DisplayName = "Your role(s)";
                Required    = true;
                UserClaims  = new List<string> { "role" };
            }
        }
    }
}
