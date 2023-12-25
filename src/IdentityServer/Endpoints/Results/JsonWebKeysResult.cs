// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMCT.IdentityServer.Hosting;
using SMCT.IdentityServer.Models;

namespace SMCT.IdentityServer.Endpoints.Results;

/// <summary>
/// Result for the jwks document
/// </summary>
/// <seealso cref="IEndpointResult" />
public class JsonWebKeysResult : EndpointResult<JsonWebKeysResult>
{
    /// <summary>
    /// Gets the web keys.
    /// </summary>
    /// <value>
    /// The web keys.
    /// </value>
    public IEnumerable<JsonWebKey> WebKeys { get; }

    /// <summary>
    /// Gets the maximum age.
    /// </summary>
    /// <value>
    /// The maximum age.
    /// </value>
    public int? MaxAge { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonWebKeysResult" /> class.
    /// </summary>
    /// <param name="webKeys">The web keys.</param>
    /// <param name="maxAge">The maximum age.</param>
    public JsonWebKeysResult(IEnumerable<JsonWebKey> webKeys, int? maxAge)
    {
        WebKeys = webKeys ?? throw new ArgumentNullException(nameof(webKeys));
        MaxAge = maxAge;
    }
}

class JsonWebKeysHttpWriter : IHttpResponseWriter<JsonWebKeysResult>
{
    public Task WriteHttpResponse(JsonWebKeysResult result, HttpContext context)
    {
        if (result.MaxAge.HasValue && result.MaxAge.Value >= 0)
        {
            context.Response.SetCache(result.MaxAge.Value, "Origin");
        }

        return context.Response.WriteJsonAsync(new { keys = result.WebKeys }, "application/json; charset=UTF-8");
    }
}