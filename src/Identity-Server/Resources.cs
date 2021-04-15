using System.Collections.Generic;
using IdentityServer4.Models;

namespace SFA.DAS.Provider.Idams.Stub
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new Custom.Resources.Idams(),
                new Custom.Resources.RoatpApply(),
                new Custom.Resources.Employer() //todo: get this from a collection in Custom.Resources class
            };
        }
    }
}
