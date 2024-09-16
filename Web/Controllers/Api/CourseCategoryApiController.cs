using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseCategoryApiController : ControllerBase
    {
        private readonly CourseCategoryService _courseCategoryService;
        public CourseCategoryApiController(CourseCategoryService courseCategoryService)
        {
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseCategories()
        {
            var categoryAndSubjectnNames = await _courseCategoryService.GetCourseCategoriesWithSubjectsAsync();

            if (categoryAndSubjectnNames == null || categoryAndSubjectnNames.Count == 0)
            {
                return NotFound();
            }
            return Ok(categoryAndSubjectnNames);
        }
    }
}
