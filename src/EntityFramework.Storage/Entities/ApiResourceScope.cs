// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#pragma warning disable 1591

namespace SMCT.IdentityServer.EntityFramework.Entities;

public class ApiResourceScope
{
    public int Id { get; set; }
    public string Scope { get; set; }

    public int ApiResourceId { get; set; }
    public ApiResource ApiResource { get; set; }
}
