// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


using SMCT.IdentityServer.Configuration;
using SMCT.IdentityServer.Validation;

namespace SMCT.IdentityServer.Endpoints.Results;

/// <summary>
/// Result for consent page
/// </summary>
public class ConsentPageResult : AuthorizeInteractionPageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConsentPageResult"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="options"></param>
    /// <exception cref="System.ArgumentNullException">request</exception>
    public ConsentPageResult(ValidatedAuthorizeRequest request, IdentityServerOptions options)
        : base(request, options.UserInteraction.ConsentUrl, options.UserInteraction.ConsentReturnUrlParameter)
    {
    }
}