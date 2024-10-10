namespace Api
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {

        }
        public BaseApiResponse(object key)
        {
            IsSuccess = true;
            Body = key;
            ErrMsg = "";
        }

        public bool IsSuccess { get; set; }
        public object Body { get; set; }
        public string ErrMsg { get; set; }
    }
}
