using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class PositionsWithNoData
    {
        [JsonPropertyName("FREQ")]
        public List<int> Freq { get; set; }

        [JsonPropertyName("UNIT")]
        public List<int> Unit { get; set; }

        [JsonPropertyName("AGE")]
        public List<int> Age { get; set; }

        [JsonPropertyName("SEX")]
        public List<int> Sex { get; set; }

        [JsonPropertyName("REGIS_ES")]
        public List<int> RegisEs { get; set; }

        [JsonPropertyName("LMP_TYPE")]
        public List<int> LmpType { get; set; }

        [JsonPropertyName("GEO")]
        public List<int> Geo { get; set; }  // Corrected to List<int>

        [JsonPropertyName("TIME_PERIOD")]
        public List<int> TimePeriod { get; set; }
    }
}
