﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SMCT.IdentityServer.Services;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Common;

class MockClaimsService : IClaimsService
{
    public List<Claim> IdentityTokenClaims { get; set; } = new List<Claim>();
    public List<Claim> AccessTokenClaims { get; set; } = new List<Claim>();

    public Task<IEnumerable<Claim>> GetIdentityTokenClaimsAsync(ClaimsPrincipal subject, ResourceValidationResult resources, bool includeAllIdentityClaims, ValidatedRequest request)
    {
        return Task.FromResult(IdentityTokenClaims.AsEnumerable());
    }

    public Task<IEnumerable<Claim>> GetAccessTokenClaimsAsync(ClaimsPrincipal subject, ResourceValidationResult resources, ValidatedRequest request)
    {
        return Task.FromResult(AccessTokenClaims.AsEnumerable());
    }
}