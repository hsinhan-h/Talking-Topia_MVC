using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingApiService _bookingApiService;

        public BookingController(BookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        /// <summary>
        /// 撈取Booking
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingApiService.GetAllBookings();

            return Ok(new BaseApiResponse(result));
        }

        /// <summary>
        /// 更新Booking
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto request)
        {
            var result = await _bookingApiService.UpdateBooking(request);

            if (result == 1) return Ok(200);
            else return BadRequest("更新失敗");
        }

        [HttpPut]
        public async Task<IActionResult> DeleteBooking(DeleteBookingDto request)
        {
            var result = await _bookingApiService.DeleteBooking(request.BookingID);

            if (result == 1) return Ok(200);
            else return BadRequest("刪除失敗");
        }
    }
}
