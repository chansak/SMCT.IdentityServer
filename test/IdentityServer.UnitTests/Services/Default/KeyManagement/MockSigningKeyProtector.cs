// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Services.KeyManagement;
using System;

namespace UnitTests.Services.Default.KeyManagement;

class MockSigningKeyProtector : ISigningKeyProtector
{
    public bool ProtectWasCalled { get; set; }

    public SerializedKey Protect(KeyContainer key)
    {
        ProtectWasCalled = true;
        return new SerializedKey
        {
            Id = key.Id,
            Algorithm = key.Algorithm,
            IsX509Certificate = key.HasX509Certificate,
            Created = DateTime.UtcNow,
            Data = KeySerializer.Serialize(key),
        };
    }

    public KeyContainer Unprotect(SerializedKey key)
    {
        return KeySerializer.Deserialize<RsaKeyContainer>(key.Data);
    }
}
