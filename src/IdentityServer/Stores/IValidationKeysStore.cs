// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Threading.Tasks;
using SMCT.IdentityServer.Models;

namespace SMCT.IdentityServer.Stores;

/// <summary>
/// Interface for the validation key store
/// </summary>
public interface IValidationKeysStore
{
    /// <summary>
    /// Gets all validation keys.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SecurityKeyInfo>> GetValidationKeysAsync();
}