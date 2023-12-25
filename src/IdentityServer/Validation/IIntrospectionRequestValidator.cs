// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;

namespace SMCT.IdentityServer.Validation;

/// <summary>
/// Interface for the introspection request validator
/// </summary>
public interface IIntrospectionRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    Task<IntrospectionRequestValidationResult> ValidateAsync(IntrospectionRequestValidationContext context);
}

