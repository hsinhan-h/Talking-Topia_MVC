using Microsoft.AspNetCore.SignalR;

namespace Web
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            var userId = connection.GetHttpContext()?.Request.Query["userId"].FirstOrDefault();
            return userId;
        }
    }
}
