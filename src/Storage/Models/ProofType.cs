// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


namespace SMCT.IdentityServer.Models;

/// <summary>
/// Models the type of proof of possession
/// </summary>
public enum ProofType
{
    /// <summary>
    /// None
    /// </summary>
    None,
    /// <summary>
    /// Client certificate
    /// </summary>
    ClientCertificate,
    /// <summary>
    /// DPoP
    /// </summary>
    DPoP
}
