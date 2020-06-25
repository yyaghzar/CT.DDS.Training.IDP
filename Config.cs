﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CT.DDS.Training.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("role",new List<string>{ "role"})
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("employeeapi","CT.DDS.Training.Blazor.EmployeeApi",new List<string>{ "role"}){

                Scopes = {
                        new Scope("employeeapi.read","employeeapi.read")
                    }

                } };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {

                new Client{
                    ClientName = "CT.DDS.Training.DevExpressBlazor",
                    ClientId = "CT.DDS.Training.DevExpressBlazor",
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = new string[] {"https://localhost:44346" },
                    RedirectUris = { "https://localhost:44346/authentication/login-callback"},
                    PostLogoutRedirectUris = { "https://localhost:44346/authentication/logout-callback" },
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.Email, "role","employeeapi.read"}
                }
            };

    }
}