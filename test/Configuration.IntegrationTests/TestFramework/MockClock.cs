// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer;

namespace IntegrationTests.TestFramework;

public class MockClock : IClock
{
    public DateTimeOffset UtcNow { get; set; }
}
