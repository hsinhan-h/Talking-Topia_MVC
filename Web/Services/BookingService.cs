using ApplicationCore.Interfaces;
using System.ComponentModel;
using Web.Entities;
using Web.Repository;
using Web.ViewModels;

namespace Web.Services
{
    public class BookingService
    {
        private readonly IRepository _repository;
        private readonly IRepository<ApplicationCore.Entities.CourseCategory> _courseCategoryRepository;
        public BookingService(IRepository repository
            , IRepository<ApplicationCore.Entities.CourseCategory> courseCategoryRepository
            )
        {
            _repository = repository;
            //_courseCategoryRepository = courseCategoryRepository;
        }
        /// <summary>
        /// 課程明細
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public async Task<BookingListViewModel> GetPublishCourseList(int MemberId)
        {
            var bookingValue = from course in _repository.GetAll<Course>()
                               join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                               join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                               join image in _repository.GetAll<CourseImage>() on course.CourseId equals image.CourseId
                               join member in _repository.GetAll<Member>() on course.TutorId equals member.MemberId
                               join booking in _repository.GetAll<Booking>() on course.CourseId equals booking.CourseId
                               where member.MemberId == MemberId
                               select new BookingViewModel
                               {
                                   UpdateDatetime = DateTime.Now,
                                   CourseTitle = course.Title,  //這不確定是哪個欄位
                                   Category = category.CategorytName,
                                   CourseSubject = subject.SubjectName,
                                   Thumbnail = course.ThumbnailUrl,
                                   VideoUrl = course.VideoUrl,
                                   CourseImageId = image.CourseImageId.ToString(),
                                   CourseId = course.CourseId,
                                   Title = course.Title,
                                   SubTitle = course.SubTitle,
                                   TutorIntro = member.TutorIntro,
                                   Description = course.Description,
                                   TrialPriceNTD = 0,
                                   TwentyFiveMinPriceNTD = course.TwentyFiveMinUnitPrice,
                                   FiftyMinPriceNTD = course.FiftyMinUnitPrice,
                                   //BookingId = booking.BookingId,
                                   //BookingDate = booking.BookingDate,
                                   CourseLength = "", //這不確定是哪個欄位
                                   MemberName = $"{member.FirstName}, {member.LastName}"
                               };

            return new BookingListViewModel()
            {
                BookingList = await bookingValue.ToListAsync(),
            };
        }
        /// <summary>
        /// 歷史課程
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public async Task<BookingListViewModel> GetPublishCourseHistoryList(int MemberId)
        {
            var bookingValue = from course in _repository.GetAll<Course>()
                               join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                               join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                               join image in _repository.GetAll<CourseImage>() on course.CourseId equals image.CourseId
                               join member in _repository.GetAll<Member>() on course.TutorId equals member.MemberId
                               join booking in _repository.GetAll<Booking>() on course.CourseId equals booking.CourseId
                               where member.MemberId == MemberId 
                               && booking.BookingDate < DateTime.Now.AddDays(1)
                               select new BookingViewModel
                               {
                                   UpdateDatetime = DateTime.Now,
                                   CourseTitle = course.Title,  //這不確定是哪個欄位
                                   Category = category.CategorytName,
                                   CourseSubject = subject.SubjectName,
                                   Thumbnail = course.ThumbnailUrl,
                                   VideoUrl = course.VideoUrl,
                                   CourseImageId = image.CourseImageId.ToString(),
                                   CourseId = course.CourseId,
                                   Title = course.Title,
                                   SubTitle = course.SubTitle,
                                   TutorIntro = member.TutorIntro,
                                   Description = course.Description,
                                   TrialPriceNTD = 0,
                                   TwentyFiveMinPriceNTD = course.TwentyFiveMinUnitPrice,
                                   FiftyMinPriceNTD = course.FiftyMinUnitPrice,
                                   BookingId = booking.BookingId,
                                   BookingDate = booking.BookingDate,
                                   CourseLength = "", //這不確定是哪個欄位
                                   MemberName = $"{member.FirstName}, {member.LastName}"
                               };

            return new BookingListViewModel()
            {
                BookingList = await bookingValue.ToListAsync(),
            };
        }

        public async Task<int> GetRemainCourseQtyAsync(int memberId, int courseId)
        {
            //已購買課程數
            int purchasedQty = (
                from order in _repository.GetAll<Order>()
                join orderDetail in _repository.GetAll<OrderDetail>()
                on order.OrderId equals orderDetail.OrderId
                where order.MemberId == memberId && orderDetail.CourseId == courseId
                select (int)orderDetail.Quantity
                ).Sum();

            //已預約(使用)課程數
            int bookedQty = _repository.GetAll<Booking>()
                .Where(bk => bk.CourseId == courseId && bk.StudentId == memberId)
                .Count();

            return purchasedQty - bookedQty;
        }

        public void CreateBookingData(int courseId, DateTime bookingDate, short bookingTime, int studentId)
        {
            var booking = new Booking
            {
                CourseId = courseId,
                BookingDate = bookingDate,
                BookingTime = bookingTime,
                StudentId = studentId,
                Cdate = DateTime.Now,
                Udate = DateTime.Now
            };
            _repository.Create(booking);
            _repository.SaveChanges();
        }
    }
}
