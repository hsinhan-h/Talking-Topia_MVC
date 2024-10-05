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

        public BookingApiService(IRepository<Member> memberRepository,
                                 IRepository<Course> courseRepository,
                                 IRepository<Booking> bookingRepository)
        {
            _memberRepository = memberRepository;
            _courseRepository = courseRepository;
            _bookingRepository = bookingRepository;
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
                var student = await _memberRepository.GetByIdAsync(booking.StudentId);
                var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
                var bResult = new BookingDto
                {
                    BookingID = booking.BookingId,
                    BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                    BookingTime = booking.BookingTime + ":00",
                    CourseTitle = course.Title,
                    TutorName = tutor.FirstName + " " + tutor.LastName,
                    StudentName = student.FirstName + " " + student.LastName,
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
    }
}
