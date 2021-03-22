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
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId}
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