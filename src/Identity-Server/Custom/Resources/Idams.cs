using System.Collections.Generic;
using IdentityServer4.Models;

namespace SFA.DAS.Provider.Idams.Stub.Custom.Resources
{
    public class Idams : IdentityResource
    {
        public Idams()
        {
            Name = Scopes.Idams;
            DisplayName = "Provider Idams Claims";
            UserClaims = new List<string>{ ClaimTypes.Ukprn, ClaimTypes.Service, ClaimTypes.DisplayName, ClaimTypes.Name, ClaimTypes.Email, ClaimTypes.Upn };
        }
    }
}
