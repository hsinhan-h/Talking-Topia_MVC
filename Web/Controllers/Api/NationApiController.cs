using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationApiController : ControllerBase
    {
        private readonly NationService _nationService;
        public NationApiController(NationService nationService)
        {
            _nationService = nationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNationNames()
        {
            var nationNames = await _nationService.GetNationNamesAsync();
            return Ok(nationNames);
        }
            

    }
}
