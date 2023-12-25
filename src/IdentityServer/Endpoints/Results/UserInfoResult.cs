// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Threading.Tasks;
using SMCT.IdentityServer.Hosting;
using SMCT.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace SMCT.IdentityServer.Endpoints.Results;

/// <summary>
/// The result of userinfo 
/// </summary>
public class UserInfoResult : EndpointResult<UserInfoResult>
{
    /// <summary>
    /// The claims
    /// </summary>
    public Dictionary<string, object> Claims { get; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="claims"></param>
    public UserInfoResult(Dictionary<string, object> claims)
    {
        Claims = claims ?? throw new ArgumentNullException(nameof(claims));
    }
}

internal class UserInfoHttpWriter : IHttpResponseWriter<UserInfoResult>
{
    public async Task WriteHttpResponse(UserInfoResult result, HttpContext context)
    {
        context.Response.SetNoCache();
        await context.Response.WriteJsonAsync(result.Claims);
    }
}