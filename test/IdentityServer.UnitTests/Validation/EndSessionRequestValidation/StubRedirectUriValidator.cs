// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Validation.EndSessionRequestValidation;

public class StubRedirectUriValidator : IRedirectUriValidator
{
    public bool IsRedirectUriValid { get; set; }
    public bool IsPostLogoutRedirectUriValid { get; set; }

    public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
    {
        return Task.FromResult(IsPostLogoutRedirectUriValid);
    }

    public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
    {
        return Task.FromResult(IsRedirectUriValid);
    }
}