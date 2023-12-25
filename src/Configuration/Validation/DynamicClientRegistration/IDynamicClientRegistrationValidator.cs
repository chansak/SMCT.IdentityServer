// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Configuration.Models.DynamicClientRegistration;

namespace SMCT.IdentityServer.Configuration.Validation.DynamicClientRegistration;

/// <summary>
/// Validates a dynamic client registration request.
/// </summary>
public interface IDynamicClientRegistrationValidator
{
    /// <summary>
    /// Validates a dynamic client registration request. 
    /// </summary>
    /// <param name="context">Contextual information about the DCR
    /// request.</param>
    /// <returns>A task that returns an <see
    /// cref="IDynamicClientRegistrationValidationResult"/>, which either
    /// indicates success or failure.</returns>
    Task<IDynamicClientRegistrationValidationResult> ValidateAsync(DynamicClientRegistrationContext context);
}
