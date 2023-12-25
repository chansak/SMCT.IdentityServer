// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#pragma warning disable 1591

namespace SMCT.IdentityServer.Stores.Serialization;

public class ClaimsPrincipalLite
{
    public string AuthenticationType { get; set; }
    public ClaimLite[] Claims { get; set; }
}
