using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Web.Models.MongoDB;

namespace Web.Controllers.Api
{
    public class ChatController : Controller
    {
        private readonly MongoRepository _repository;

        public ChatController(MongoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/chat/history")]
        public async Task<IActionResult> GetChatHistory(string user1, string user2)
        {
            var conversationId = CreateConversationId(user1, user2);
            var messages = await _repository.GetMessagesByConversationIdAsync(conversationId);
            return Ok(messages);
        }

        private ObjectId CreateConversationId(string user1, string user2)
        {
            var idString = string.Compare(user1, user2) < 0 ? $"{user1}_{user2}" : $"{user2}_{user1}";
            return ObjectId.GenerateNewId();
        }
    }
}
