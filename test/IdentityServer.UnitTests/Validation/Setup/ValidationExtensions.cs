// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Validation;

namespace UnitTests.Validation.Setup;

public static class ValidationExtensions
{
    public static ClientSecretValidationResult ToValidationResult(this Client client, ParsedSecret secret = null)
    {
        return new ClientSecretValidationResult
        {
            Client = client,
            Secret = secret
        };
    }
}