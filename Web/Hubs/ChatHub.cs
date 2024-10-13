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

        private static List<User> Users = new()
        {
            new User { UserId = "1", UserName = "Alice" },
            new User { UserId = "2", UserName = "Bob" },
            new User { UserId = "3", UserName = "Charlie" }
        };

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;

            if (string.IsNullOrEmpty(userId) || !Users.Any(u => u.UserId == userId))
            {
                await Clients.Caller.SendAsync("Error", "無效的使用者 ID。");
                Context.Abort();
                return;
            }

            Console.WriteLine($"使用者 {userId} 已連線。");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"使用者已斷線：{Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string targetUserId, string message)
        {
            try
            {
                var senderUserId = Context.UserIdentifier;

                if (string.IsNullOrEmpty(senderUserId) || senderUserId == targetUserId)
                {
                    await Clients.Caller.SendAsync("Error", "無法發送訊息給自己或無效的使用者。");
                    return;
                }

                var newMessage = new Message
                {
                    MessageId = ObjectId.GenerateNewId(),
                    ConversationId = CreateConversationId(senderUserId, targetUserId),
                    SenderId = senderUserId,
                    ReceiverId = targetUserId,
                    Content = message,
                    Timestamp = DateTime.UtcNow,
                    MessageType = MessageType.Sent,
                    Visibility = new Visibility { A = true, B = true }
                };
                await _repository.CreateMessageByConversationIdAsync(newMessage.ConversationId, newMessage);

                await Clients.User(targetUserId).SendAsync("ReceiveMessage", senderUserId, message);
                await Clients.User(senderUserId).SendAsync("ReceiveMessage", senderUserId, message);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"發送訊息錯誤：{ex.Message}");
                await Clients.Caller.SendAsync("Error", "伺服器發生錯誤，請稍後再試。");
            }
        }

        private ObjectId CreateConversationId(string user1, string user2)
        {
            var idString = string.Compare(user1, user2) < 0 ? $"{user1}_{user2}" : $"{user2}_{user1}";
            return ObjectId.GenerateNewId();
        }
    }

    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
