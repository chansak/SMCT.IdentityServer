﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Common;

class MockResourceValidator : IResourceValidator
{
    public ResourceValidationResult Result { get; set; } = new ResourceValidationResult();

    public Task<IEnumerable<ParsedScopeValue>> ParseRequestedScopesAsync(IEnumerable<string> scopeValues)
    {
        return Task.FromResult(scopeValues.Select(x => new ParsedScopeValue(x)));
    }

    public Task<ResourceValidationResult> ValidateRequestedResourcesAsync(ResourceValidationRequest request)
    {
        return Task.FromResult(Result);
    }
}