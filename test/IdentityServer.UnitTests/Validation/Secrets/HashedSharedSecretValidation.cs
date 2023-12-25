﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Stores;
using SMCT.IdentityServer.Validation;
using FluentAssertions;
using UnitTests.Validation.Setup;
using Microsoft.Extensions.Logging;
using Xunit;

namespace UnitTests.Validation.Secrets;

public class HashedSharedSecretValidation
{
    private const string Category = "Secrets - Hashed Shared Secret Validation";

    private ISecretValidator _validator = new HashedSharedSecretValidator(new Logger<HashedSharedSecretValidator>(new LoggerFactory()));
    private IClientStore _clients = new InMemoryClientStore(ClientValidationTestClients.Get());

    [Fact]
    [Trait("Category", Category)]
    public async Task Valid_Single_Secret()
    {
        var clientId = "single_secret_hashed_no_expiration";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Credential = "secret",
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);

        result.Success.Should().BeTrue();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Invalid_Credential_Type()
    {
        var clientId = "single_secret_hashed_no_expiration";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Credential = "secret",
            Type = "invalid"
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);

        result.Success.Should().BeFalse();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Valid_Multiple_Secrets()
    {
        var clientId = "multiple_secrets_hashed";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Credential = "secret",
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeTrue();

        secret.Credential = "foobar";
        result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeTrue();

        secret.Credential = "quux";
        result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeTrue();

        secret.Credential = "notexpired";
        result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeTrue();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Invalid_Single_Secret()
    {
        var clientId = "single_secret_hashed_no_expiration";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Credential = "invalid",
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);

        result.Success.Should().BeFalse();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Invalid_Multiple_Secrets()
    {
        var clientId = "multiple_secrets_hashed";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Credential = "invalid",
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeFalse();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Client_with_no_Secret_Should_Fail()
    {
        var clientId = "no_secret_client";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeFalse();
    }

    [Fact]
    [Trait("Category", Category)]
    public async Task Client_with_null_Secret_Should_Fail()
    {
        var clientId = "null_secret_client";
        var client = await _clients.FindEnabledClientByIdAsync(clientId);

        var secret = new ParsedSecret
        {
            Id = clientId,
            Type = IdentityServerConstants.ParsedSecretTypes.SharedSecret,
            Credential = "secret"
        };

        var result = await _validator.ValidateAsync(client.ClientSecrets, secret);
        result.Success.Should().BeFalse();
    }
}