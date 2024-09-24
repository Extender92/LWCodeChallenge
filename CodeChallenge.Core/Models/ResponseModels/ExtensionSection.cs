using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class ExtensionSection
    {
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("agencyId")]
        public string AgencyId { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("datastructure")]
        public DataStructure DataStructure { get; set; }

        [JsonPropertyName("annotation")]
        public List<Annotation> Annotation { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("positions-with-no-data")]
        public PositionsWithNoData PositionsWithNoData { get; set; }
    }
}
