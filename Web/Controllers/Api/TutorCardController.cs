using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TutorCardController : ControllerBase
    {
        private readonly CourseService _courseService;
        private readonly MemberDataService _memberdataService;


        public TutorCardController(CourseService courseService, MemberDataService memberdataService)
        {
            _courseService = courseService;
            _memberdataService = memberdataService;
        }

        [HttpGet]
        public IActionResult GetRecommandTutorCard([FromQuery]int categoryId)
        {
            var getCardData = _courseService.GetTutorRecommendCard(categoryId);
            var result = JsonConvert.SerializeObject(getCardData);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetWatchListCard()
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            int memberId = int.Parse(memberIdClaim.Value);

            var getCardData = _memberdataService.GetWatchList(memberId);
            var result = JsonConvert.SerializeObject(getCardData);
            return Ok(result);
        }
    }
}
