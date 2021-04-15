using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using SFA.DAS.Provider.Idams.Stub.Custom;
using SFA.DAS.Provider.Idams.Stub.Custom.Resources;
using ClaimTypes = System.Security.Claims.ClaimTypes;

namespace SFA.DAS.Provider.Idams.Stub
{
    public class Users
    {
        public static List<ExtendedUser> Get()
        {
            var trainUGood = TrainingProviders.Get("10005077");
            var likeAPro = TrainingProviders.Get("10000896");

            var result = new List<ExtendedUser>
            {
                new ExtendedUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "employer-user",
                    ProviderId = trainUGood.Ukprn,
                    ProviderName = trainUGood.Name,
                    Description = "Test Employer user",
                    Claims = new List<Claim>
                    {
                        new Claim(Employer.ClaimTypes.DisplayName, "Christopher Foster"),
                        new Claim(Employer.ClaimTypes.Id, "employer-user-id-1"),
                        new Claim(Employer.ClaimTypes.GivenName, "Christopher"),
                        new Claim(Employer.ClaimTypes.FamilyName, "Foster"),
                        new Claim(Employer.ClaimTypes.Email, "chris@email.com")
                    }
                },
                new ExtendedUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "chris",
                    ProviderId = trainUGood.Ukprn,
                    ProviderName = trainUGood.Name,
                    Description = "User with DAA role",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "chrisfoster186@googlemail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(Custom.ClaimTypes.Ukprn, trainUGood.Ukprn),
                        new Claim(Custom.ClaimTypes.Service, "ARA"),
                        new Claim(Custom.ClaimTypes.Service, "DAA"),
                        new Claim(Custom.ClaimTypes.Name, "Chris @ Train-U-Good Corporation"),
                        new Claim(Custom.ClaimTypes.DisplayName, "Chris @ Train-U-Good Corporation"),
                        new Claim("display_name", "Christopher Foster"),
                        new Claim(Custom.ClaimTypes.Upn, trainUGood.Ukprn + "\\" + "chris"),
                        new Claim(Custom.ClaimTypes.Email, "chrisfoster186@googlemail.com")
                    }
                },
                new ExtendedUser
                {
                    SubjectId = "fcea33d2-0bec-4fdd-8c97-5902973746a4",
                    Username = "duff",
                    //Password = "password",
                    ProviderId = trainUGood.Ukprn,
                    ProviderName = trainUGood.Name,
                    Description = "User without DAA role",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "chrisfoster186@googlemail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(Custom.ClaimTypes.Ukprn, trainUGood.Ukprn),
                        //new Claim(Custom.ClaimTypes.Service, "DAA"), //this user does NOT have DAA role
                        new Claim(Custom.ClaimTypes.Name, "Duff @ Train-U-Good Corporation"),
                        new Claim(Custom.ClaimTypes.DisplayName, "Duff @ Train-U-Good Corporation"),
                        new Claim(Custom.ClaimTypes.Upn, trainUGood.Ukprn + "\\" + "duff"),
                        new Claim(Custom.ClaimTypes.Email, "chrisfoster186@googlemail.com")
                    }
                },
                new ExtendedUser
                {
                    SubjectId = "148cd9cb-9189-435d-a5ab-550bb800122d",
                    Username = "user1",
                    //Password = "password",
                    ProviderId = likeAPro.Ukprn,
                    ProviderName = likeAPro.Name,
                    Description = "User with DAA role",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "chrisfoster186@googlemail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(Custom.ClaimTypes.Ukprn, likeAPro.Ukprn),
                        new Claim(Custom.ClaimTypes.Service, "DAA"),
                        new Claim(Custom.ClaimTypes.Name, "user1 @ Like a Pro Education Inc."),
                        new Claim(Custom.ClaimTypes.DisplayName, "user1 @ Like a Pro Education Inc."),
                        new Claim(Custom.ClaimTypes.Upn, likeAPro.Ukprn + "\\" + "user1"),
                        new Claim(Custom.ClaimTypes.Email, "chrisfoster186@googlemail.com")
                    }
                }
            };

            var elliot = new ExtendedUser
            {
                SubjectId = "636c95d8-d55d-47a8-9f6d-4c8ce364ca28",
                Username = "elliot",
                ProviderId = trainUGood.Ukprn,
                ProviderName = trainUGood.Name,
                Description = "User with a large number of claims, useful for causing cookie-chunking",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "chrisfoster186+elliot@googlemail.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(Custom.ClaimTypes.Ukprn, trainUGood.Ukprn),
                    new Claim(Custom.ClaimTypes.Service, "ARA"),
                    new Claim(Custom.ClaimTypes.Service, "DAA"),
                    new Claim(Custom.ClaimTypes.Name, "Elliot @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.DisplayName, "Elliot @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.Upn, trainUGood.Ukprn + "\\" + "elliot"),
                    new Claim(Custom.ClaimTypes.Email, "chrisfoster186+elliot@googlemail.com")
                }
            };

            elliot.Claims.AddManyServiceClaims();
            result.Add(elliot);

            //roatp
            result.Add(new ExtendedUser
            {
                SubjectId = "dd732fd7-ab57-7900-85c6-9e6a80c9b24b", //this is "nameidentifier", aka "sub" I believe
                Username = "roatpuser",
                ProviderId = trainUGood.Ukprn,
                ProviderName = trainUGood.Name,
                Description = "Roatp Apply User",
                Claims = new List<Claim>
                {
                    //new Claim(JwtClaimTypes.Subject, "dd732fd7-ab57-7900-85c6-9e6a80c9b24b"), //not sure what this is then?
                    new Claim(JwtClaimTypes.Email, "chrisfoster186@googlemail.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(Custom.ClaimTypes.Ukprn, trainUGood.Ukprn),
                    new Claim(Custom.ClaimTypes.Name, "Chris @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.DisplayName, "Chris @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.Upn, "dd732fd7-ab57-7900-85c6-9e6a80c9b24b"),
                    new Claim(Custom.ClaimTypes.Email, "chrisfoster186@googlemail.com")
                }
            });

            return result;
        }
    }
}
