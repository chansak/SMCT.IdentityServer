// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.ResponseHandling;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Common;

internal class StubAuthorizeResponseGenerator : IAuthorizeResponseGenerator
{
    public AuthorizeResponse Response { get; set; } = new AuthorizeResponse();

    public Task<AuthorizeResponse> CreateResponseAsync(ValidatedAuthorizeRequest request)
    {
        return Task.FromResult(Response);
    }
}