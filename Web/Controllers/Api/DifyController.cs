namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DifyController : ControllerBase
    {
        private readonly string _difyUserId;
        private readonly ILogger<DifyController> _logger;
        private readonly DifySearchService _difySearchService;

        public DifyController(IConfiguration configuration,
                          ILogger<DifyController> logger,
                          DifySearchService difySearchService)
        {
            _difyUserId = configuration["DifyUserId"];
            _logger = logger;
            _difySearchService = difySearchService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSearchRecommendation([FromBody] CreateWorkflowRequest request)
        {
            var inputs = new Dictionary<string, object>();
            inputs.Add("input", request.ProductName);
            var runWorkflowRequest = new CreateSearchRecommendationRequest
            {
                Inputs = inputs,
                ResponseMode = "blocking",
                User = _difyUserId
            };
            try
            {
                var response = await _difySearchService.CreateSearch(runWorkflowRequest);
                var apiResponse = new ApiResponse
                {
                    IsSuccess = true,
                    Code = ApiStatusCode.Success,
                    Body = response.Data.Outputs
                };


                string jsonString = apiResponse.Body.ToString();
                string result = _difySearchService.ProcessResponse(jsonString);

                Console.WriteLine(result);

                //呼叫方法傳出去做資料表搜尋

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while creating the workflow.");
                var apiResponse = new ApiResponse
                {
                    IsSuccess = false,
                    Code = ApiStatusCode.Error,
                    Body = "An error occurred while processing your request."
                };
                return Ok(apiResponse);
            }
        }
    }
}
