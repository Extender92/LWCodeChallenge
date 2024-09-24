using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class Dimension
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
