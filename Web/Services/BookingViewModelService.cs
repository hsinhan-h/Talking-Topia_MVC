using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Entities;


namespace Web.Services
{
    public class BookingViewModelService
    {
        private readonly IRepository<ApplicationCore.Entities.Course> _courseRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseCategory> _courseCategoryRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseSubject> _courseSubjectRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseImage> _courseImagerepository;
        private readonly IRepository<ApplicationCore.Entities.Member> _memberRepository;
        private readonly IRepository<ApplicationCore.Entities.Booking> _bookingRepository;
        public BookingViewModelService(
            IRepository<ApplicationCore.Entities.Course> courseRepository,
            IRepository<ApplicationCore.Entities.CourseCategory> courseCategoryRepository,
            IRepository<ApplicationCore.Entities.CourseSubject> courseSubjectRepository,
            IRepository<ApplicationCore.Entities.CourseImage> courseImageRepository,
            IRepository<ApplicationCore.Entities.Member> memberRepository,
            IRepository<ApplicationCore.Entities.Booking> bookingRepository)
        {
            _courseRepository = courseRepository;
            _courseCategoryRepository = courseCategoryRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _courseImagerepository = courseImageRepository;
            _memberRepository = memberRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingListViewModel> GetPublishCourseList(int MemberId)
        {
            var courses = await _courseRepository.ListAsync(c => c.TutorId == MemberId);
            if (courses == null || courses.Count == 0)
            {

            }

            var courseCategory = await _courseCategoryRepository.ListAsync(x => x.Courses.Select(c => c.CourseId).Distinct().Contains(x.CourseCategoryId));

            //var courseSubject = 

            //var courseImage = 

            var member = await _memberRepository.GetByIdAsync(MemberId);

            //var booking =await _bookingRepository.GetByIdAsync()


            return new BookingListViewModel()
            {

            };
        }
    }
}
