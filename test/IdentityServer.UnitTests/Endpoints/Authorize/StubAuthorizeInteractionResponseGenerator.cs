// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.ResponseHandling;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Endpoints.Authorize;

internal class StubAuthorizeInteractionResponseGenerator : IAuthorizeInteractionResponseGenerator
{
    internal InteractionResponse Response { get; set; } = new InteractionResponse();

    public Task<InteractionResponse> ProcessInteractionAsync(ValidatedAuthorizeRequest request, ConsentResponse consent = null)
    {
        return Task.FromResult(Response);
    }
}