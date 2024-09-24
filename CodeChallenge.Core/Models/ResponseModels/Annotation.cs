using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class Annotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }
    }
}
