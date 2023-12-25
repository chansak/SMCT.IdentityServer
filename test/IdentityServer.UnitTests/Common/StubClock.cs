// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer;
using System;

namespace UnitTests.Common;

internal class StubClock : IClock
{
    public Func<DateTime> UtcNowFunc { get; set; } = () => DateTime.UtcNow;
    public DateTimeOffset UtcNow => new DateTimeOffset(UtcNowFunc());
}