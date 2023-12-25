// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System;

namespace SMCT.IdentityServer;

/// <summary>
/// Abstraction for the date/time.
/// </summary>
public interface IClock
{
    /// <summary>
    /// The current UTC date/time.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}
