// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Services;

namespace UnitTests.Common;

public class MockJwtRequestUriHttpClient : IJwtRequestUriHttpClient
{
    public string Jwt { get; set; }

    public Task<string> GetJwtAsync(string url, Client client)
    {
        return Task.FromResult(Jwt);
    }
}