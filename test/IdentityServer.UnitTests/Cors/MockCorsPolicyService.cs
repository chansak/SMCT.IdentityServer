﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Services;

namespace UnitTests.Cors;

public class MockCorsPolicyService : ICorsPolicyService
{
    public bool WasCalled { get; set; }
    public bool Response { get; set; }

    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        WasCalled = true;
        return Task.FromResult(Response);
    }
}