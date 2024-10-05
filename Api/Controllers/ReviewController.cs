using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewApiService _reviewApiService;

        public ReviewController(ReviewApiService reviewApiService)
        {
            _reviewApiService = reviewApiService;
        }

        /// <summary>
        /// 撈取評論
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await _reviewApiService.GetAllReviews();

            return Ok(new BaseApiResponse(result));
        }

        /// <summary>
        /// 刪除評論
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteReview()
        {


            return Ok();
        }
    }
}
