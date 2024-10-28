using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Web.Dtos;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Experimental("SKEXP0020")]
    public class VectorSearchController : ControllerBase
    {
        private readonly IVectorSearchService _vectorSearchService;

        public VectorSearchController(IVectorSearchService vectorSearchService)
        {
            _vectorSearchService = vectorSearchService;
        }

        [HttpPost]
        public async Task<IActionResult> SetUpProductSearchVectorDb([FromBody] SetUpCourseSearchVectorDbRequest request)
        {
            await _vectorSearchService.FetchAndSaveProductDocumentsAsync(request.StartIndex, request.Count);
            return Ok();
        }

    }
}
