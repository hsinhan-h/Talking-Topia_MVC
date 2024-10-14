using Microsoft.AspNetCore.SignalR;

namespace Web
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            // 從查詢參數取得 userId，作為 UserIdentifier
            var userId = connection.GetHttpContext()?.Request.Query["userId"].FirstOrDefault();
            return userId;
        }
    }
}
