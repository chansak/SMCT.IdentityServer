// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#nullable enable

using SMCT.IdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMCT.IdentityServer.Stores;

/// <summary>
/// Interface to model storage of identity providers.
/// </summary>
public interface IIdentityProviderStore
{
    /// <summary>
    /// Gets all identity providers name.
    /// </summary>
    Task<IEnumerable<IdentityProviderName>> GetAllSchemeNamesAsync();
        
    /// <summary>
    /// Gets the identity provider by scheme name.
    /// </summary>
    /// <param name="scheme"></param>
    /// <returns></returns>
    Task<IdentityProvider?> GetBySchemeAsync(string scheme);
}
