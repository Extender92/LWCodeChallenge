using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class UnemployedDataResponse
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("value")]
        public Dictionary<int, double> Value { get; set; }

        [JsonPropertyName("status")]
        public Dictionary<int, string> Status { get; set; }

        [JsonPropertyName("id")]
        public List<string> Id { get; set; }

        [JsonPropertyName("size")]
        public List<int> Size { get; set; }

        [JsonPropertyName("dimension")]
        public DimensionSection Dimension { get; set; }

        [JsonPropertyName("extension")]
        public ExtensionSection Extension { get; set; }

    }
}
