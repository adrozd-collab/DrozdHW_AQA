using System.Text.Json.Serialization;

namespace TestAQA1
{
    public class UpdateUserResponseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
