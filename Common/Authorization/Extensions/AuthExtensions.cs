using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Common.Authorization.Extensions
{
    public static class AuthExtensions
    {
        public static int Id(this ClaimsPrincipal user)
        {
            var userIdString = user.Claims.FirstOrDefault(x =>
                x.Type.Equals(JwtRegisteredClaimNames.Jti, StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (userIdString == null)
            {
                throw new MissingFieldException("Id is null");
            }

            return int.Parse(userIdString);
        }
    }
}