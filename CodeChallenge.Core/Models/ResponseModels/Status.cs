using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class Status
    {
        [JsonPropertyName("label")]
        public Dictionary<string, string> Label { get; set; }
    }
}
