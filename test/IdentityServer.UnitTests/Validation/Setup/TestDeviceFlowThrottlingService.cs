// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Services;

namespace UnitTests.Validation.Setup;

public class TestDeviceFlowThrottlingService : IDeviceFlowThrottlingService
{
    private readonly bool shouldSlownDown;

    public TestDeviceFlowThrottlingService(bool shouldSlownDown = false)
    {
        this.shouldSlownDown = shouldSlownDown;
    }

    public Task<bool> ShouldSlowDown(string deviceCode, DeviceCode details) => Task.FromResult(shouldSlownDown);
}