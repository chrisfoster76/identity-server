using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Provider.Idams.Stub.Custom
{
    public static class TrainingProviders
    {
        public static List<TrainingProvider> Get()
        {
            return new List<TrainingProvider>
            {
                new TrainingProvider{ Ukprn = "10005077", Name = "Train-U-Good Corporation"},
                new TrainingProvider{ Ukprn = "10000896", Name = "Like a Pro Education Inc."}
            };
        }

        public static TrainingProvider Get(string ukprn)
        {
            return Get().Single(t => t.Ukprn == ukprn);
        }
    }

    public class TrainingProvider
    {
        public string Ukprn { get; set; }
        public string Name { get; set; }
    }
}
