// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#nullable enable

using System.Threading.Tasks;

namespace SMCT.IdentityServer.Validation;

/// <summary>
/// Validator for handling DPoP proofs.
/// </summary>
public interface IDPoPProofValidator
{
    /// <summary>
    /// Validates the DPoP proof.
    /// </summary>
    Task<DPoPProofValidatonResult> ValidateAsync(DPoPProofValidatonContext context);
}
