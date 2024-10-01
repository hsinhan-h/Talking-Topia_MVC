using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Web.Services.DifyWorkflow.Dtos;

namespace Web.Services.DifyWorkflow
{
    public class DifySearchService
    {
        private readonly string _difyApiUrl;
        private readonly string _difyTravelRecommendationApiKey;
        private readonly IHttpClientFactory _httpClientFactory;

        public DifySearchService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _difyApiUrl = configuration["DifyWorkFlowApiEndpoint"];
            _difyTravelRecommendationApiKey = configuration["DifyTravelRecommendationApiKey"];
            _httpClientFactory = httpClientFactory;
        }
        public async Task<DifyWorkflowResponse> CreateSearch(CreateSearchRecommendationRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _difyTravelRecommendationApiKey);

            var endpoint = $"{_difyApiUrl}/workflows/run";
            var jsonContent = JsonSerializer.Serialize(request);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var runWorkflowResponse = JsonSerializer.Deserialize<DifyWorkflowResponse>(result);
                return runWorkflowResponse;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error running workflow: {errorResponse}");
            }
        }

        public string ProcessResponse(string jsonOutput)
        {
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonOutput);

            if (dictionary != null && dictionary.ContainsKey("category_name"))
            {
                string categoryName = dictionary["category_name"];
                categoryName = System.Text.RegularExpressions.Regex.Unescape(categoryName);
                Console.WriteLine($"Category Name: {categoryName}");
                return categoryName;
            }
            else
            {
                return "處理失敗，找不到這個臭玩意兒";
            }
        }

    }
}
