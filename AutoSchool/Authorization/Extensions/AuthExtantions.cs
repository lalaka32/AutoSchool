using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoSchool.Authorization.Extensions
{
    public static class AuthExtantions
    {
        public static int Id(this ClaimsPrincipal user)
        {
            var userIdString = user.Claims.FirstOrDefault(x => x.Type.Equals(JwtRegisteredClaimNames.Jti, StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (userIdString == null)
            {
                throw new MissingFieldException("Id is null");
            }
            return int.Parse(userIdString);
        }
    }
}
