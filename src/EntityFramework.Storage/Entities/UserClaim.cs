﻿// Copyright (c) SMCT Software. All rights reserved.
// See LICENSE in the project root for license information.


#pragma warning disable 1591

namespace SMCT.IdentityServer.EntityFramework.Entities;

public abstract class UserClaim
{
    public int Id { get; set; }
    public string Type { get; set; }
}