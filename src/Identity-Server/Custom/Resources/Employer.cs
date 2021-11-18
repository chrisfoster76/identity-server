using System.Collections.Generic;
using IdentityServer4.Models;

namespace SFA.DAS.Provider.Idams.Stub.Custom.Resources
{
    public class Employer : IdentityResource
    {
        public Employer()
        {
            Name = Scopes.Employer;
            DisplayName = "Employer Claims";
            UserClaims = new List<string>
            {
                Employer.ClaimTypes.Id,
                Employer.ClaimTypes.GivenName,
                Employer.ClaimTypes.FamilyName,
                Employer.ClaimTypes.Email,
                Employer.ClaimTypes.EmailAddress,
                Employer.ClaimTypes.DisplayName,
            };
        }

        public class ClaimTypes
        {
            public const string Id = "http://das/employer/identity/claims/id";
            public const string GivenName = "http://das/employer/identity/claims/given_name";
            public const string FamilyName = "http://das/employer/identity/claims/family_name";
            public const string Email = "http://das/employer/identity/claims/email";
            public const string EmailAddress = "http://das/employer/identity/claims/email_address";
            public const string DisplayName = "http://das/employer/identity/claims/display_name";
        }
    }
}
