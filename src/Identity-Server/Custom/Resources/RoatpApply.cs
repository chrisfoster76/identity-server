using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;

namespace SFA.DAS.Provider.Idams.Stub.Custom.Resources
{
    public class RoatpApply : IdentityResource
    {
        public RoatpApply()
        {
            Name = Scopes.RoatpApply;
            DisplayName = "Roatp Apply Claims";
            UserClaims = new List<string> { ClaimTypes.Ukprn, ClaimTypes.Service, ClaimTypes.DisplayName, ClaimTypes.Name, ClaimTypes.Email, ClaimTypes.Upn };
        }
    }
}
