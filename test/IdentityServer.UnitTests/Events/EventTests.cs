// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SMCT.IdentityServer.Configuration;
using SMCT.IdentityServer.Endpoints.Results;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.ResponseHandling;
using SMCT.IdentityServer.Validation;
using FluentAssertions;
using IdentityModel;
using UnitTests.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Xunit;
using SMCT.IdentityServer.Services;
using SMCT.IdentityServer;
using SMCT.IdentityServer.Events;

namespace UnitTests.Endpoints.Results;

public class EventTests
{

    [Fact]
    public void UnhandledExceptionEventCanCallToString()
    {
        try
        {
            throw new InvalidOperationException("Boom");
        }
        catch (Exception ex)
        {
            var unhandledExceptionEvent = new UnhandledExceptionEvent(ex);

            var s = unhandledExceptionEvent.ToString();

            s.Should().NotBeNullOrEmpty();
        }
    }
}