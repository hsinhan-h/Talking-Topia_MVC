using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Security.Claims;
using Web.Models.MongoDB;

namespace Web.Controllers.Api
{
    public class ChatController : Controller
    {
        private readonly MongoRepository _repository;
        private readonly IMemberService _memberService;
        //private readonly ChatIndexViewModelService _chatIndexViewModelService;

        public ChatController(MongoRepository repository, IMemberService memberService)
        {
            _repository = repository;
            _memberService = memberService;
            //_chatIndexViewModelService = chatIndexViewModelService;
        }

        public async Task<IActionResult> Index(int courseId)
        {
            // 抓SenderID
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }

            // 抓ReceiverId
            var tutor = await _memberService.GetTutor(courseId);
            string member = await _memberService.GetMemberName(memberId);


            ViewBag.CourseId = courseId;
            ViewBag.SenderId = memberId;
            ViewBag.SenderName = member;
            ViewBag.ReceiverId = tutor.MemberId;
            ViewBag.ReceiverName = tutor.MemberName;
            ViewBag.HeadShotImage = tutor.HeadShotImage;
            ViewBag.CourseTitle = tutor.CourseTitle;
            ViewBag.CourseSubTitle = tutor.CourseSubTitle;

            //var chat = await _repository.GetMessagesBySenderIdAsync(memberId.ToString());
            //var chatVM = await _chatIndexViewModelService.GetChatListAsync(chat);

            //return View(chatVM);
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
            return new ObjectId(HashStringToObjectId(idString));
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
