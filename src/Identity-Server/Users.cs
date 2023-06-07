using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
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

            var associatedAccounts1 = new Dictionary<string, EmployerUserAccountItem>();
            associatedAccounts1.Add("VN48RP", new EmployerUserAccountItem
            {
                AccountId = "VN48RP",
                EmployerName = "Mega Corp",
                Role = "Owner"
            });
            associatedAccounts1.Add("VNR6P9", new EmployerUserAccountItem
            {
                AccountId = "VNR6P9",
                EmployerName = "Rapid Logistics Co Ltd",
                Role = "Owner"
            });


            var result = new List<ExtendedUser>
            {
                new ExtendedUser
                {
                    ClientId = ClientIds.Employer,
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "employer-user",
                    Description = "Mega Corp User",
                    Claims = new List<Claim>
                    {
                        new Claim(Employer.ClaimTypes.DisplayName, "Mega Corp User"),
                        new Claim(Employer.ClaimTypes.Id, "37e9761e-1dc9-42b7-9054-787794ad6442"),
                        new Claim(Employer.ClaimTypes.GivenName, "Christopher"),
                        new Claim(Employer.ClaimTypes.FamilyName, "Foster"),
                        new Claim(Employer.ClaimTypes.Email, "chris@email.com"),
                        new Claim(Employer.ClaimTypes.EmailAddress, "chris@email.com"),
                        new Claim(Employer.ClaimTypes.AccountOwner, "8194"),
                        new Claim(Employer.ClaimTypes.AssociatedAccounts, JsonConvert.SerializeObject(associatedAccounts1))
                    }
                },
                new ExtendedUser
                {
                    ClientId = ClientIds.Employer,
                    SubjectId = "77826be4-bd8f-4495-8f5c-ee950d18751c",
                    Username = "employer-user-viewer",
                    Description = "Mega Corp Viewer",
                    Claims = new List<Claim>
                    {
                        new Claim(Employer.ClaimTypes.DisplayName, "Mega Corp Viewer"),
                        new Claim(Employer.ClaimTypes.Id, "77826be4-bd8f-4495-8f5c-ee950d18751c"),
                        new Claim(Employer.ClaimTypes.GivenName, "John"),
                        new Claim(Employer.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Employer.ClaimTypes.Email, "chris@email.com"),
                        new Claim(Employer.ClaimTypes.EmailAddress, "chris@email.com")
                    }
                },
                new ExtendedUser
                {
                    ClientId = ClientIds.Employer,
                    SubjectId = "b82f7646-4d31-4541-b640-0f0dbc189e44",
                    Username = "employer-nonlevy-user",
                    Description = "Rapid Logistics User",
                    Claims = new List<Claim>
                    {
                        new Claim(Employer.ClaimTypes.DisplayName, "Rapid Logistics User"),
                        new Claim(Employer.ClaimTypes.Id, "b82f7646-4d31-4541-b640-0f0dbc189e44"),
                        new Claim(Employer.ClaimTypes.GivenName, "Christopher"),
                        new Claim(Employer.ClaimTypes.FamilyName, "Foster"),
                        new Claim(Employer.ClaimTypes.Email, "chris@email.com"),
                        new Claim(Employer.ClaimTypes.EmailAddress, "chris@email.com")
                    }
                },
                new ExtendedUser
                {
                    ClientId = ClientIds.Employer,
                    SubjectId = "22ba2d68-db01-4f90-bfe7-01bd59f39b42",
                    Username = "positivity-user",
                    Description = "Positivity User",
                    Claims = new List<Claim>
                    {
                        new Claim(Employer.ClaimTypes.DisplayName, "Positivity User"),
                        new Claim(Employer.ClaimTypes.Id, "22ba2d68-db01-4f90-bfe7-01bd59f39b42"),
                        new Claim(Employer.ClaimTypes.GivenName, "Christopher"),
                        new Claim(Employer.ClaimTypes.FamilyName, "Foster"),
                        new Claim(Employer.ClaimTypes.Email, "chris@email.com"),
                        new Claim(Employer.ClaimTypes.EmailAddress, "chris@email.com")
                    }
                },
                new ExtendedUser
                {
                    ClientId = ClientIds.Idams,
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "chris",
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
                    ClientId = ClientIds.Idams,
                    SubjectId = "fcea33d2-0bec-4fdd-8c97-5902973746a4",
                    Username = "duff",
                    //Password = "password",
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
                    ClientId = ClientIds.Idams,
                    SubjectId = "148cd9cb-9189-435d-a5ab-550bb800122d",
                    Username = "user1",
                    //Password = "password",
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
                ClientId = ClientIds.Idams,
                SubjectId = "636c95d8-d55d-47a8-9f6d-4c8ce364ca28",
                Username = "elliot",
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
                ClientId = ClientIds.Roatp,
                SubjectId = "dd732fd7-ab57-7900-85c6-9e6a80c9b24b", //this is "nameidentifier", aka "sub" I believe
                Username = "roatpuser",
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
                    new Claim(Custom.ClaimTypes.Email, "chrisfoster186@googlemail.com"),
                }
            });
            result.Add(new ExtendedUser
            {
                ClientId = ClientIds.Roatp,
                SubjectId = "B53B9317-3551-4B86-B435-FD14F2E6930E", //this is "nameidentifier", aka "sub" I believe
                Username = "roatpuser2",
                Description = "Another Roatp Apply User",
                Claims = new List<Claim>
                {
                    //new Claim(JwtClaimTypes.Subject, "dd732fd7-ab57-7900-85c6-9e6a80c9b24b"), //not sure what this is then?
                    new Claim(JwtClaimTypes.Email, "chrisfoster186+test2@googlemail.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(Custom.ClaimTypes.Ukprn, trainUGood.Ukprn),
                    new Claim(Custom.ClaimTypes.Name, "Chris @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.DisplayName, "Chris @ Train-U-Good Corporation"),
                    new Claim(Custom.ClaimTypes.Upn, "B53B9317-3551-4B86-B435-FD14F2E6930E"),
                    new Claim(Custom.ClaimTypes.Email, "chrisfoster186+test2@googlemail.com"),
                }
            });

            return result;
        }

        public class EmployerUserAccountItem
        {
            public string AccountId { get; set; }
            public string EmployerName { get; set; }
            public string Role { get; set; }
        }
    }
}
