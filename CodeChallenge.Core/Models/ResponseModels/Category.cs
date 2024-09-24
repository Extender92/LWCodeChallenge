using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class Category
    {
        [JsonPropertyName("index")]
        public Dictionary<string, int> Index { get; set; }

        [JsonPropertyName("label")]
        public Dictionary<string, string> Label { get; set; }
    }
}
