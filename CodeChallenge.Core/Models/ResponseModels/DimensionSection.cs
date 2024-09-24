using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class DimensionSection
    {
        [JsonPropertyName("FREQ")]
        public Dimension Freq { get; set; }

        [JsonPropertyName("UNIT")]
        public Dimension Unit { get; set; }

        [JsonPropertyName("AGE")]
        public Dimension Age { get; set; }

        [JsonPropertyName("SEX")]
        public Dimension Sex { get; set; }

        [JsonPropertyName("REGIS_ES")]
        public Dimension RegisEs { get; set; }

        [JsonPropertyName("LMP_TYPE")]
        public Dimension LmpType { get; set; }

        [JsonPropertyName("GEO")]
        public Dimension Geo { get; set; }

        [JsonPropertyName("TIME_PERIOD")]
        public Dimension TimePeriod { get; set; }
    }
}
