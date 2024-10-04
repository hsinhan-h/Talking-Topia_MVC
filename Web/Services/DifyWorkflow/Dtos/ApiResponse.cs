namespace Web.Services.DifyWorkflow.Dtos
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public ApiStatusCode Code { get; set; }
        public object Body { get; set; }
    }

    public enum ApiStatusCode
    {
        Success = 200,
        Error = 500
    }
}
