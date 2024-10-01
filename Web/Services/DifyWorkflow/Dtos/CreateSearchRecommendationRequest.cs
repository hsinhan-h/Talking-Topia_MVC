using System.Text.Json.Serialization;

namespace Web.Services.DifyWorkflow.Dtos
{
    public class CreateSearchRecommendationRequest
    {
        [JsonPropertyName("inputs")]
        public Dictionary<string, object> Inputs { get; set; } = new Dictionary<string, object>();

        [JsonPropertyName("response_mode")]
        [Required]
        public string ResponseMode { get; set; }

        [JsonPropertyName("user")]
        [Required]
        public string User { get; set; }
    }
}
