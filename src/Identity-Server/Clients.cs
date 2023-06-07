using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SFA.DAS.Provider.Idams.Stub
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    AllowAccessTokensViaBrowser = true,
                    ClientId = "openIdConnectClient",
                    ClientName = "Idams Stub Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Custom.Scopes.Idams
                    },
                    RedirectUris = new List<string> {"https://localhost:5001/signin-oidc", "https://127.0.0.1:44347/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5001" }
                },
                new Client {
                    AllowAccessTokensViaBrowser = true,
                    ClientId = "openIdConnectRoATPClient",
                    ClientName = "RoATP Apply",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Custom.Scopes.RoatpApply
                    },
                    RedirectUris = new List<string> {"https://localhost:6016/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> { "https://localhost:6016" }
                },
                new Client {
                    AllowAccessTokensViaBrowser = true,
                    ClientId = "employerOpenIdConnect",
                    ClientName = "Employer Stub Client",
                    AllowedGrantTypes = new List<string>{ GrantType.Implicit } ,
                    ClientSecrets = new List<Secret>{ new Secret("secret")},
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RequireConsent = false,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Custom.Scopes.Employer
                    },
                    RedirectUris = new List<string> {"https://localhost:5001/signin-oidc", "https://localhost:44376/signin-oidc", "https://localhost:44331/signin-oidc", "https://localhost:44373/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5001" }
                },
            };
        }
    }
}
