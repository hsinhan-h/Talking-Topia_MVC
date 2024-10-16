using Web.Models.MongoDB;
using Web.Models.MongoDB.Entities;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;

namespace Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly MongoRepository _repository;

        public ChatHub(MongoRepository repository)
        {
            _repository = repository;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var senderId = httpContext.Request.Query["senderId"];
            var receiverId = httpContext.Request.Query["receiverId"];


            if (string.IsNullOrEmpty(senderId) || string.IsNullOrEmpty(receiverId))
            {
                await Clients.Caller.SendAsync("Error", "無效的使用者 ID。");
                Context.Abort();
                return;
            }

            Console.WriteLine($"使用者 {senderId} 已連線。");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"使用者已斷線：{Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string receiverId, string message)
        {
            try
            {
                var httpContext = Context.GetHttpContext();
                var senderId = httpContext.Request.Query["senderId"];

                if (string.IsNullOrEmpty(senderId) || string.IsNullOrEmpty(receiverId))
                {
                    await Clients.Caller.SendAsync("Error", "無效的使用者 ID。");
                    return;
                }

                var newMessage = new Message
                {
                    MessageId = ObjectId.GenerateNewId(),
                    ConversationId = CreateConversationId(senderId, receiverId),
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    Content = message,
                    Timestamp = DateTime.UtcNow,
                    MessageType = MessageType.Sent,
                    Visibility = new Visibility { Sender = true, Receiver = true }
                };
                await _repository.CreateMessageByConversationIdAsync(newMessage.ConversationId, newMessage);

                await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
                await Clients.User(senderId).SendAsync("ReceiveMessage", senderId, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發送訊息錯誤：{ex.Message}");
                await Clients.Caller.SendAsync("Error", "伺服器發生錯誤，請稍後再試。");
            }
        }

        private ObjectId CreateConversationId(string user1, string user2)
        {
            var sortedUsers = string.Compare(user1, user2) < 0 ? $"{user1}_{user2}" : $"{user2}_{user1}";
            return new ObjectId(HashStringToObjectId(sortedUsers));
        }

        private string HashStringToObjectId(string input)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hash).Replace("-", "").Substring(0, 24);
            }
        }
    }
}
