using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Web.Data;

namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/CourseSortingApi")]
    public class CourseSortingApiController : ControllerBase
    {
        private readonly CourseService _courseService;
        public CourseSortingApiController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses([FromQuery] int page)
        {
            var courses = await _courseService.GetCourseCardsListAsync(page, 6);
            return Ok(courses);
        }

        

        //[HttpGet]
        //public async Task<IActionResult> GetSortedCourses(string sortBy, 
        //    [FromQuery, DefaultValue(1)] int page, int pageSize = 6)
        //{
        //    var courses = await _courseService.GetCourseCardsListAsync(page, pageSize);

        //    switch (sortBy.ToLower())
        //    {
        //        case "price":
        //            courses = courses.OrderBy(c => c.TwentyFiveMinUnitPrice).ToList();
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetAllNations()
        //{


        //}
    }
}
