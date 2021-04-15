using System.Collections.Generic;
using System.Security.Claims;

namespace SFA.DAS.Provider.Idams.Stub
{
    public static class ClaimsHelper
    {
        public static void AddManyServiceClaims(this ICollection<Claim> claims)
        {
            for (var i = 0; i < 50; i++)
            {
                claims.Add(new Claim(SFA.DAS.Provider.Idams.Stub.Custom.ClaimTypes.Service, $"foo{i}"));
            }

        }
    }
}