using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer.Extensions;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   new Client
                   {
                       ClientId             = "movies_mvc_client",
                       ClientName           = "Movies MVC Web App",
                       AllowedGrantTypes    = GrantTypes.Hybrid,
                       RequirePkce          = false,
                       AllowRememberConsent = false,
                       RedirectUris         = new List<string>()
                       {
                           "https://localhost:5002/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.Address,
                           IdentityServerConstants.StandardScopes.Email,
                           "movieAPI",
                           IdentityServerConstantsExtensions.StandardScopesExtensions.Roles
                       }
                   }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("movieAPI", "Movie API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {

          };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResourcesExtensions.Roles()
          };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username  = "murat",
                    Password  = "murat",
                    Claims    = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName , "murat"),
                        new Claim(JwtClaimTypes.FamilyName, "boz")
                    }
                }
            };
    }
}
