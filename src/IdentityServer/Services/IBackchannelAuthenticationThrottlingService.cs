// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#nullable enable

using System.Threading.Tasks;
using SMCT.IdentityServer.Models;

namespace SMCT.IdentityServer.Services;

/// <summary>
/// The backchannel authentication throttling service.
/// </summary>
public interface IBackchannelAuthenticationThrottlingService
{
    /// <summary>
    /// Decides if the requesting client and request needs to slow down.
    /// </summary>
    Task<bool> ShouldSlowDown(string requestId, BackChannelAuthenticationRequest details);
}
