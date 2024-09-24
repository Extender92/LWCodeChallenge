using CodeChallange.Core.Models.ResponseModels;

namespace CodeChallange.Core.Configuration
{
    public static class UnemploymentDataConfig
    {
        public static int Years { get; private set; }
        public static int Countries { get; private set; }
        public static int Policies { get; private set; }
        public static int Registrations { get; private set; }
        public static int Sexes { get; private set; }
        public static int Ages { get; private set; }

        public static void Initialize(UnemployedDataResponse data)
        {
            Years = data.Dimension.TimePeriod.Category.Index.Count;
            Countries = data.Dimension.Geo.Category.Index.Count;
            Policies = data.Dimension.LmpType.Category.Index.Count;
            Registrations = data.Dimension.RegisEs.Category.Index.Count;
            Sexes = data.Dimension.Sex.Category.Index.Count;
            Ages = data.Dimension.Age.Category.Index.Count;
        }
    }
}
