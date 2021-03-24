using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace AuthServer.Config
{
    public static class MemoryConfig
    {
        const string SCOPE_NAME = "jobsApi.scope";
        const string SCOPE_TITLE = "Jobs API";
        public static IEnumerable<ApiScope> ApiScopes() =>
         new List<ApiScope>
         {
             new ApiScope(SCOPE_NAME, SCOPE_TITLE)
         };
        public static IEnumerable<ApiResource> ApiResources() => 
            new List<ApiResource>
            {
                new ApiResource("jobsApi",SCOPE_TITLE)
                {
                    Scopes={SCOPE_NAME}
                }
            };
        public static IEnumerable<IdentityResource> IdentityResources() => 
            new List<IdentityResource> 
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<Client> Clients() =>
            new List<Client> 
            {
                new Client 
                {
                    ClientId = "first-client",
                    ClientSecrets = new [] { new Secret("sebastianSuperSecret".Sha512())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId, SCOPE_NAME}
                },
                new Client 
                {
                    ClientName = "MvcClient",
                    ClientId = "mvc-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    //The flow redirects the non validated user towards the login
                    RedirectUris = new List<string>{ "http://localhost:5020/signin-oidc"},
                    AllowedScopes= 
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        },
                    ClientSecrets = 
                    {
                        new Secret("mvcClientSecret".Sha512())
                    },
                    RequirePkce = true,
                    RequireConsent = true
                }
            };
        public static List<TestUser> TestUsers() =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "abc1",
                    Username = "Sebas",
                    Password = "SebasPassword123",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "sebas"),
                        new Claim("family_name", "nerbei")
                    }
                },
                new TestUser
                {
                    SubjectId = "abc2",
                    Username = "Kulem",
                    Password = "KulemPassword123",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "fernanda"),
                        new Claim("family_name", "kulem")
                    }
                }
            };
    }
}