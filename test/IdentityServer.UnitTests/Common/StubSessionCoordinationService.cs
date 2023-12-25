// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Services;

namespace UnitTests.Common;

internal class StubSessionCoordinationService : ISessionCoordinationService
{
    public Task ProcessExpirationAsync(UserSession session)
    {
        return Task.CompletedTask;
    }

    public Task ProcessLogoutAsync(UserSession session)
    {
        return Task.CompletedTask;
    }

    public Task<bool> ValidateSessionAsync(SessionValidationRequest request)
    {
        return Task.FromResult(true);
    }
}