﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.

using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Validation;

namespace IdentityServerHost.Extensions;

public class NoSubjectExtensionGrantValidator : IExtensionGrantValidator
{
    public Task ValidateAsync(ExtensionGrantValidationContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        var credential = context.Request.Raw.Get("custom_credential");

        if (credential != null)
        {
            context.Result = new GrantValidationResult();
        }
        else
        {
            // custom error message
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
        }

        return Task.CompletedTask;
    }

    public string GrantType
    {
        get { return "custom.nosubject"; }
    }
}