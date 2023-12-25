// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#nullable enable

namespace SMCT.IdentityServer.Stores;

/// <summary>
/// Marker interface to indicate if server side sessions enabled in DI.
/// </summary>
public interface IServerSideSessionsMarker { }

/// <summary>
/// Nop implementation for IServerSideSessionsMarker.
/// </summary>
public class NopIServerSideSessionsMarker : IServerSideSessionsMarker { }
