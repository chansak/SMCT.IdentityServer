// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Configuration;
using SMCT.IdentityServer.Validation;

namespace SMCT.IdentityServer.Endpoints.Results;

/// <summary>
/// Result for a custom redirect
/// </summary>
public class CustomRedirectResult : AuthorizeInteractionPageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomRedirectResult"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="url">The URL.</param>
    /// <param name="options"></param>
    /// <exception cref="System.ArgumentNullException">
    /// request
    /// or
    /// url
    /// </exception>
    public CustomRedirectResult(ValidatedAuthorizeRequest request, string url, IdentityServerOptions options)
        : base(request, url, options.UserInteraction.CustomRedirectReturnUrlParameter)
    {
    }
}