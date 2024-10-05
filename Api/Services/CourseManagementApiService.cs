using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class CourseManagementApiService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseCategory> _courseCategoryRepository;
        private readonly IRepository<CourseSubject> _courseSubjectRepository;
        private readonly IRepository<CourseImage> _courseImageRepository;
        private readonly IRepository<Member> _memberRepository;

        public CourseManagementApiService(IRepository<Course> courseRepository, 
            IRepository<CourseCategory> courseCategoryRepository, 
            IRepository<CourseSubject> courseSubjectRepository, 
            IRepository<CourseImage> courseImageRepository,
            IRepository<Member> memberRepository)
        {
            _courseRepository = courseRepository;
            _courseCategoryRepository = courseCategoryRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _courseImageRepository = courseImageRepository;
            _memberRepository = memberRepository;
        }

        //public async Task<List<CourseManagementDto>> GetCourseInfo()
        //{
        //    var courses = _courseRepository.ListAsync();

        //}

        public async Task<List<CourseApprovalDto>> GetCourseApprovalList()
        {
            var unApprovedCourses = (await _courseRepository.ListAsync())
                .Where(c => c.CoursesStatus == 0)
                .ToList();

            //提取篩選過後課程的Id
            var courseIds = unApprovedCourses.Select(c => c.CourseId).ToList();
            var categoryIds = unApprovedCourses.Select(c => c.CategoryId).ToList();
            var subjectIds = unApprovedCourses.Select(c => c.SubjectId).ToList();
            var memberIds = unApprovedCourses.Select(c => c.TutorId).ToList();

            //只抓unApprovedCourses的images, category, subject
            var images = await _courseImageRepository.ListAsync(i => courseIds.Contains(i.CourseId));
            var images1 = await _courseImageRepository.ListAsync();
            var categories = await _courseCategoryRepository.ListAsync(c => categoryIds.Contains(c.CourseCategoryId));
            var subjects = await _courseSubjectRepository.ListAsync(s => subjectIds.Contains(s.SubjectId));
            var tutors = await _memberRepository.ListAsync(m => memberIds.Contains(m.MemberId));

            var courseApprovalList =
                from c in unApprovedCourses
                join img in images on c.CourseId equals img.CourseId into courseImages
                from courseImage in courseImages.DefaultIfEmpty()
                join ct in categories on c.CategoryId equals ct.CourseCategoryId into courseCategories
                from courseCategory in courseCategories.DefaultIfEmpty()
                join s in subjects on c.SubjectId equals s.SubjectId into courseSubjects
                from courseSubject in courseSubjects.DefaultIfEmpty()
                join t in tutors on c.TutorId equals t.MemberId into courseTutors
                from courseTutor in courseTutors.DefaultIfEmpty()
                select new CourseApprovalDto
                {
                    CourseId = c.CourseId,
                    TutorName = courseTutor.FirstName + " " + courseTutor.LastName,
                    ApplyDate = c.Cdate,
                    CourseCategory = courseCategory.CategorytName,
                    CourseSubject = courseSubject.SubjectName,
                    CourseTitle = c.Title,
                    TwentyFiveMinUnitPrice = c.TwentyFiveMinUnitPrice,
                    FiftyMinUnitPrice = c.FiftyMinUnitPrice,
                    Description = c.Description,
                    CourseImages = courseImages.Select(i => i.ImageUrl).ToList(),
                    ThumbnailUrl = c.ThumbnailUrl,
                    VideoUrl = c.VideoUrl
                };

            return courseApprovalList
                .GroupBy(c => c.CourseId)
                .Select(gp => gp.First())
                .ToList();
        }
    }
}
