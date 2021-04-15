using System.Collections.Generic;
using IdentityServer4.Test;

namespace SFA.DAS.Provider.Idams.Stub.Custom
{
    public static class Extensions
    {
        public static List<TestUser> AsTestUsers(this List<ExtendedUser> fakeUsers)
        {
            var result = new List<TestUser>();

            foreach (var fakeUser in fakeUsers)
            {
                result.Add(fakeUser);
            }

            return result;
        }
    }
}
