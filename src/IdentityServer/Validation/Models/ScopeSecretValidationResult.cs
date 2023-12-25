// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Models;

namespace SMCT.IdentityServer.Validation;

/// <summary>
/// Validation result for API validation
/// </summary>
public class ApiSecretValidationResult : ValidationResult
{
    /// <summary>
    /// Gets or sets the resource.
    /// </summary>
    /// <value>
    /// The resource.
    /// </value>
    public ApiResource Resource { get; set; }
}