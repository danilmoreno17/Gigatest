﻿using Kameyo.Core.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Common
{
    public static class IdentityResultExtensions
    {
        public static ResultIdentity ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? ResultIdentity.Success()
                : ResultIdentity.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
