// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SMCT.IdentityServer.Extensions;
using System;
using SMCT.IdentityServer.Configuration;
using SMCT.IdentityServer.Hosting;
using SMCT.IdentityServer.Models;
using SMCT.IdentityServer.Stores;
using SMCT.IdentityServer.Validation;
using SMCT.IdentityServer.Services;

namespace SMCT.IdentityServer.Endpoints.Results;

/// <summary>
/// Result for endsession
/// </summary>
/// <seealso cref="IEndpointResult" />
public class EndSessionResult : EndpointResult<EndSessionResult>
{
    /// <summary>
    /// The result
    /// </summary>
    public EndSessionValidationResult Result { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EndSessionResult"/> class.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <exception cref="System.ArgumentNullException">result</exception>
    public EndSessionResult(EndSessionValidationResult result)
    {
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }
}


class EndSessionHttpWriter : IHttpResponseWriter<EndSessionResult>
{
    public EndSessionHttpWriter(
        IdentityServerOptions options,
        IClock clock,
        IServerUrls urls,
        IMessageStore<LogoutMessage> logoutMessageStore)
    {
        _options = options;
        _clock = clock;
        _urls = urls;
        _logoutMessageStore = logoutMessageStore;
    }

    private IdentityServerOptions _options;
    private IClock _clock;
    private IServerUrls _urls;
    private IMessageStore<LogoutMessage> _logoutMessageStore;

    public async Task WriteHttpResponse(EndSessionResult result, HttpContext context)
    {
        var validatedRequest = result.Result.IsError ? null : result.Result.ValidatedRequest;

        string id = null;

        if (validatedRequest != null)
        {
            var logoutMessage = new LogoutMessage(validatedRequest);
            if (logoutMessage.ContainsPayload)
            {
                var msg = new Message<LogoutMessage>(logoutMessage, _clock.UtcNow.UtcDateTime);
                id = await _logoutMessageStore.WriteAsync(msg);
            }
        }

        var redirect = _options.UserInteraction.LogoutUrl;

        if (redirect.IsLocalUrl())
        {
            redirect = _urls.GetIdentityServerRelativeUrl(redirect);
        }

        if (id != null)
        {
            redirect = redirect.AddQueryString(_options.UserInteraction.LogoutIdParameter, id);
        }

        context.Response.Redirect(redirect);
    }
}
