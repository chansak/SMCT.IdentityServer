// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using SMCT.IdentityServer.Services;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Stores.Serialization;
using Microsoft.Extensions.Logging;
using SMCT.IdentityServer.Extensions;

namespace SMCT.IdentityServer.Stores;

/// <summary>
/// Default authorization code store.
/// </summary>
public class DefaultAuthorizationCodeStore : DefaultGrantStore<AuthorizationCode>, IAuthorizationCodeStore
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultAuthorizationCodeStore"/> class.
    /// </summary>
    /// <param name="store">The store.</param>
    /// <param name="serializer">The serializer.</param>
    /// <param name="handleGenerationService">The handle generation service.</param>
    /// <param name="logger">The logger.</param>
    public DefaultAuthorizationCodeStore(
        IPersistedGrantStore store,
        IPersistentGrantSerializer serializer,
        IHandleGenerationService handleGenerationService,
        ILogger<DefaultAuthorizationCodeStore> logger)
        : base(IdentityServerConstants.PersistedGrantTypes.AuthorizationCode, store, serializer, handleGenerationService, logger)
    {
    }

    /// <summary>
    /// Stores the authorization code asynchronous.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public Task<string> StoreAuthorizationCodeAsync(AuthorizationCode code)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultAuthorizationCodeStore.StoreAuthorizationCode");
        
        return CreateItemAsync(code, code.ClientId, code.Subject.GetSubjectId(), code.SessionId, code.Description, code.CreationTime, code.Lifetime);
    }

    /// <summary>
    /// Gets the authorization code asynchronous.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public Task<AuthorizationCode> GetAuthorizationCodeAsync(string code)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultAuthorizationCodeStore.GetAuthorizationCode");
        
        return GetItemAsync(code);
    }

    /// <summary>
    /// Removes the authorization code asynchronous.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public Task RemoveAuthorizationCodeAsync(string code)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultAuthorizationCodeStore.RemoveAuthorizationCode");
        
        return RemoveItemAsync(code);
    }
}