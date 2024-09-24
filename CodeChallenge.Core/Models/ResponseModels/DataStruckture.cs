using System.Text.Json.Serialization;

namespace CodeChallange.Core.Models.ResponseModels
{
    public class DataStructure
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("agencyId")]
        public string AgencyId { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
