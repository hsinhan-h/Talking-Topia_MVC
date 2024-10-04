using Api.Dtos;
using Api.Services;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderApiService _orderApiService;

        public OrderController(OrderApiService orderApiService)
        {
            _orderApiService = orderApiService;
        }

        /// <summary>
        /// 撈取Order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderApiService.GetAllOrders();

            return Ok(new BaseApiResponse(result));
        }

        /// <summary>
        /// 更新Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto request)
        {
            var result =  await _orderApiService.UpdateOrder(request);

            if (result == 1 ) return Ok(200);
            else return BadRequest("更新失敗");
        }
    }
}
