using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class BookingApiService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public BookingApiService(IRepository<Member> memberRepository,
                                 IRepository<Course> courseRepository,
                                 IRepository<Booking> bookingRepository,
                                 IRepository<Order> orderRepository,
                                 IRepository<OrderDetail> orderDetailRepository)
        {
            _memberRepository = memberRepository;
            _courseRepository = courseRepository;
            _bookingRepository = bookingRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            // 整張表撈出來
            var bookings = await _bookingRepository.ListAsync();
            var bookingCount = CalculateBookings(bookings);
            var result = new List<BookingDto>();

            foreach (var booking in bookings)
            {
                var course = await _courseRepository.GetByIdAsync(booking.CourseId);
                var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
                var student = await _memberRepository.GetByIdAsync(booking.StudentId);
                // 剩餘堂數邏輯
                var bookingTotal = await _bookingRepository.ListAsync(bt => bt.StudentId == student.MemberId);
                var orders = await _orderRepository.ListAsync(o => o.MemberId == booking.StudentId);
                int surplus = 0;
                foreach (var order in orders)
                {
                    var odTotal = await _orderDetailRepository.ListAsync(od => od.OrderId == order.OrderId && od.CourseId == booking.CourseId);
                    var bookedTotal = bookingTotal.Count;
                    var odQuantity = odTotal.Sum(x => x.Quantity);
                    surplus = odQuantity - bookedTotal;
                    if (surplus < 1) surplus = 0;
                }
                var bResult = new BookingDto
                    {
                        BookingID = booking.BookingId,
                        BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                        BookingTime = booking.BookingTime + ":00",
                        CourseTitle = course.Title,
                        TutorName = tutor.FirstName + " " + tutor.LastName,
                        StudentName = student.FirstName + " " + student.LastName,
                        Surplus = surplus.ToString(),
                        MonthCount = bookingCount["Month"],
                        YearCount = bookingCount["Year"]
                    };
                    result.Add(bResult);
            }
            return result;
        }
        public async Task<int> UpdateBooking(UpdateBookingDto request)
        {
            if (request == null || request.BookingID <= 0 ||
                string.IsNullOrWhiteSpace(request.BookingDate) ||
                string.IsNullOrWhiteSpace(request.BookingTime))
            {
                throw new ArgumentException("Invalid booking update request.");
            }

            var entity = await _bookingRepository.GetByIdAsync(request.BookingID);
            var bookingDate = DateTime.Parse(request.BookingDate.Trim());
            var bookingTime = request.BookingTime.Trim();
            entity.BookingDate = bookingDate;
            entity.BookingTime = Int32.Parse(bookingTime.Replace(":00", ""));
            var result = await _bookingRepository.UpdateAsync(entity);

            if (result != null) return 1;
            else return 0;
        }
        public async Task<int> DeleteBooking(int bookingId)
        {
            try
            {
                var booking = await _bookingRepository.FirstOrDefaultAsync(b => b.BookingId == bookingId);
                await _bookingRepository.DeleteAsync(booking);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public Dictionary<string, int> CalculateBookings(List<Booking> bookings)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            int monthCount = bookings.Count(booking => booking.BookingDate.Year == currentYear && booking.BookingDate.Month == currentMonth);
            int yearCount = bookings.Count(booking => booking.BookingDate.Year == currentYear);

            result.Add("Month", monthCount);
            result.Add("Year", yearCount);

            return result;
        }
    }
}
