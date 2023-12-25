// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#nullable enable

using SMCT.IdentityServer.Validation;

namespace SMCT.IdentityServer.Models;

/// <summary>
/// Represents contextual information about a device flow authorization request.
/// </summary>
public class DeviceFlowAuthorizationRequest
{
    /// <summary>
    /// Gets or sets the client.
    /// </summary>
    /// <value>
    /// The client.
    /// </value>
    public Client Client { get; set; } = default!;

    /// <summary>
    /// Gets or sets the validated resources.
    /// </summary>
    /// <value>
    /// The scopes requested.
    /// </value>
    public ResourceValidationResult ValidatedResources { get; set; } = default!;
}
