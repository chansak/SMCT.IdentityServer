// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.EntityFramework.DbContexts;
using SMCT.IdentityServer.EntityFramework.Mappers;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Services;
using Microsoft.Extensions.Logging;

namespace SMCT.IdentityServer.Configuration;

/// <summary>
/// Communicates with the client configuration data store using entity
/// framework. 
/// </summary>
public class ClientConfigurationStore : IClientConfigurationStore
{
    /// <summary>
    /// The DbContext.
    /// </summary>
    protected readonly ConfigurationDbContext DbContext;

    /// <summary>
    /// The CancellationToken provider.
    /// </summary>
    protected readonly ICancellationTokenProvider CancellationTokenProvider;

    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<ClientConfigurationStore> Logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConfigurationStore"/>
    /// class.
    /// </summary>
    public ClientConfigurationStore(
        ConfigurationDbContext dbContext,
        ICancellationTokenProvider cancellationTokenProvider,
        ILogger<ClientConfigurationStore> logger)
    {
        DbContext = dbContext;
        CancellationTokenProvider = cancellationTokenProvider;
        Logger = logger;
    }

    /// <inheritdoc />
    public async Task AddAsync(Client client)
    {
        Logger.LogDebug("Adding client {clientId} to configuration store", client.ClientId);
        DbContext.Clients.Add(ClientMappers.ToEntity(client));
        await DbContext.SaveChangesAsync(CancellationTokenProvider.CancellationToken);
    }
}
