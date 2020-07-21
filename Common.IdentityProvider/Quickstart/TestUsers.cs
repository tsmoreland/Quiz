// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "82A84132-9C76-48AA-B4C0-1114A33EAE5B",
                        Username = "tsmoreland",
                        Password = "password",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Terry Moreland"),
                            new Claim(JwtClaimTypes.GivenName, "Terry"),
                            new Claim(JwtClaimTypes.FamilyName, "Moreland"),
                            new Claim(JwtClaimTypes.Email, "terry.s.moreland@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://github.com/tsmoreland"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "82A84132-9C76-48AA-B4C0-1114A33EAE5B",
                        Username = "batman",
                        Password = "password",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bruce Wayne"),
                            new Claim(JwtClaimTypes.GivenName, "Bruce"),
                            new Claim(JwtClaimTypes.FamilyName, "Wayne"),
                            new Claim(JwtClaimTypes.Email, "bruce.wayne@wayneenterprises.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://127.0.0.1"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}