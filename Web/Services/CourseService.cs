using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Web.Entities;
using Web.Repository;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Web.Services
{
    public class CourseService
    {
        private readonly IRepository _repository;

        public CourseService(IRepository repository)
        {
            _repository = repository;
        }


        //public async Task<CourseInfoListViewModel> GetCourseCardsListRepo()
        //{

        //    IQueryable<CourseInfoViewModel> courses =
        //        from course in _repository.GetAll<Course>().AsNoTracking()
        //        join member in _repository.GetAll<Member>().AsNoTracking()
        //        on course.TutorId equals member.MemberId

        //        join nation in _repository.GetAll<Nation>()
        //        on member.NationId equals nation.NationId

        //        join review in _repository.GetAll<Review>()
        //        on course.CourseId equals review.CourseId into reviewGroup
        //        from review in reviewGroup.DefaultIfEmpty() //left join review

        //        join booking in _repository.GetAll<Booking>()
        //        on course.CourseId equals booking.CourseId into bookingGroup
        //        from booking in bookingGroup.DefaultIfEmpty() //left join booking

        //        join tutorTimeSlot in _repository.GetAll<TutorTimeSlot>()
        //        on member.MemberId equals tutorTimeSlot.TutorId into tutorTimeSlotGroup
        //        from tutorTimeSlot in tutorTimeSlotGroup.DefaultIfEmpty() //left join tutortimeslot

        //        join courseImage in _repository.GetAll<CourseImage>()
        //        on course.CourseId equals courseImage.CourseId into courseImageGroup
        //        from courseImage in courseImageGroup.DefaultIfEmpty()

        //        group new { course, member, nation, review, booking, tutorTimeSlot, courseImage } by course.CourseId into groupedCourse
        //        select new CourseInfoViewModel
        //        {
        //            CourseId = groupedCourse.Key,
        //            TutorHeadShotImage = groupedCourse
        //                                 .FirstOrDefault().member.HeadShotImage,
        //            TutorFlagImage = groupedCourse
        //                                  .FirstOrDefault().nation.FlagImage,
        //            IsVerifiedTutor = (bool)groupedCourse
        //                                  .FirstOrDefault().member.IsVerifiedTutor,
        //            CourseTitle = groupedCourse
        //                                  .FirstOrDefault().course.Title,
        //            CourseSubTitle = groupedCourse
        //                                  .FirstOrDefault().course.SubTitle,
        //            TutorIntro = groupedCourse
        //                                  .FirstOrDefault().member.TutorIntro,
        //            TwentyFiveMinUnitPrice = groupedCourse
        //                                  .FirstOrDefault().course.TwentyFiveMinUnitPrice,
        //            FiftyMinUnitPrice = groupedCourse
        //                                  .FirstOrDefault().course.FiftyMinUnitPrice,
        //            CourseVideo = groupedCourse
        //                                  .FirstOrDefault().course.VideoUrl,
        //            CourseVideoThumbnail = groupedCourse
        //                                  .FirstOrDefault().course.ThumbnailUrl,
        //            CourseImages = groupedCourse
        //                                  .Where(g => g.courseImage != null)
        //                                  .Select(g => new CourseImageViewModel
        //                                  {
        //                                      ImageUrl = g.courseImage.ImageUrl
        //                                  })
        //                                  .ToList(),
        //            CourseRatings = Math.Round(groupedCourse
        //                                  .Where(g => g.review != null).Any() ?
        //                                  groupedCourse.Where(g => g.review != null)
        //                                  .Average(g => g.review.Rating) : 0, 2),
        //            CourseReviews = groupedCourse.Where(g => g.review != null)
        //                                  .GroupBy(g => g.review.ReviewId)
        //                                  .Count(),
        //            BookedTimeSlots = groupedCourse
        //                                  .Where(g => g.booking != null)
        //                                  .Select(g => new TimeSlotViewModel
        //                                  {
        //                                      Date = g.booking.BookingDate,
        //                                      StartHour = g.booking.BookingTime - 1 //因資料表時間Id從1開始對應0:00起始時間
        //                                  })
        //                                  .ToList(),
        //            AvailableTimeSlots = groupedCourse
        //                                  .Where(g => g.tutorTimeSlot != null)
        //                                  .Select(g => new TimeSlotViewModel
        //                                  {
        //                                      Weekday = g.tutorTimeSlot.Weekday,
        //                                      StartHour = g.tutorTimeSlot.CourseHourId - 1 //因資料表時間Id從1開始對應0:00起始時間
        //                                  })
        //                                  .ToList()
        //        };

        //    return new CourseInfoListViewModel
        //    {
        //        CourseInfoList = await courses.ToListAsync()
        //    };
        //}

        public async Task<CourseInfoListViewModel> GetCourseCardsListAsync(int page, int pageSize)
        {
            //主查詢
            var courseMainInfo = await (
            from course in _repository.GetAll<Course>().AsNoTracking()
            join member in _repository.GetAll<Member>().AsNoTracking()
            on course.TutorId equals member.MemberId
            join nation in _repository.GetAll<Nation>().AsNoTracking()
            on member.NationId equals nation.NationId
            select new CourseInfoViewModel
            {
                MemberId = member.MemberId,
                CourseId = course.CourseId,
                TutorHeadShotImage = member.HeadShotImage,
                TutorFlagImage = nation.FlagImage,
                IsVerifiedTutor = member.IsVerifiedTutor,
                CourseTitle = course.Title,
                CourseSubTitle = course.SubTitle,
                TutorIntro = member.TutorIntro,
                TwentyFiveMinUnitPrice = course.TwentyFiveMinUnitPrice,
                FiftyMinUnitPrice = course.FiftyMinUnitPrice,
                CourseVideo = course.VideoUrl,
                CourseVideoThumbnail = course.ThumbnailUrl
            })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            // 圖片查詢
            var courseImagesInfo = await (
                from course in _repository.GetAll<Course>().AsNoTracking()
                join courseImage in _repository.GetAll<CourseImage>().AsNoTracking()
                on course.CourseId equals courseImage.CourseId
                group courseImage by course.CourseId into gpImage
                select new CourseInfoViewModel
                {
                    CourseId = gpImage.Key,
                    CourseImages = gpImage.Select(ci => new CourseImageViewModel
                    {
                        ImageUrl = ci.ImageUrl
                    }).ToList()
                }).ToListAsync();

            // 評價及評論數查詢
            var courseRatingsAndReviewsInfo = await (
                from course in _repository.GetAll<Course>().AsNoTracking()
                join review in _repository.GetAll<Review>().AsNoTracking()
                on course.CourseId equals review.CourseId
                group review by course.CourseId into gpReview
                select new CourseInfoViewModel
                {
                    CourseId = gpReview.Key,
                    CourseRatings = gpReview.Any() ?
                                    Math.Round(gpReview.Average(cr => cr.Rating), 2) : 0,
                    CourseReviews = gpReview.Count()
                }).ToListAsync();

            // 已被預約時間查詢
            var bookedTimeSlotsInfo = await (
                from course in _repository.GetAll<Course>().AsNoTracking()
                join booking in _repository.GetAll<Booking>().AsNoTracking()
                on course.CourseId equals booking.CourseId
                group booking by course.CourseId into gpBooking
                select new CourseInfoViewModel
                {
                    CourseId = gpBooking.Key,
                    BookedTimeSlots = gpBooking.Select(cb => new TimeSlotViewModel
                    {
                        Date = cb.BookingDate,
                        StartHour = cb.BookingTime - 1 // id - 1 對應實際起始時間
                    }).ToList()
                }).ToListAsync();

            // 教師可預約時間查詢
            var availableTimeSlotsInfo = await (
                from member in _repository.GetAll<Member>().AsNoTracking()
                join tutorTimeSlot in _repository.GetAll<TutorTimeSlot>().AsNoTracking()
                on member.MemberId equals tutorTimeSlot.TutorId
                group tutorTimeSlot by member.MemberId into gpMember
                select new CourseInfoViewModel
                {
                    MemberId = gpMember.Key,
                    AvailableTimeSlots = gpMember.Select(mt => new TimeSlotViewModel
                    {
                        Weekday = mt.Weekday,
                        StartHour = mt.CourseHourId - 1,
                    }).ToList()
                }).ToListAsync();

            // 合併查詢
            var completeCoursesInfo = (
                from courseMain in courseMainInfo
                join imgInfo in courseImagesInfo on courseMain.CourseId equals imgInfo.CourseId into imgInfoGroup
                from imgInfo in imgInfoGroup.DefaultIfEmpty()
                join revInfo in courseRatingsAndReviewsInfo on courseMain.CourseId equals revInfo.CourseId into revInfoGroup
                from revInfo in revInfoGroup.DefaultIfEmpty()
                join bookInfo in bookedTimeSlotsInfo on courseMain.CourseId equals bookInfo.CourseId into bookInfoGroup
                from bookInfo in bookInfoGroup.DefaultIfEmpty()
                join tTimeInfo in availableTimeSlotsInfo on courseMain.MemberId equals tTimeInfo.MemberId into tTimeInfoGroup
                from tTimeInfo in tTimeInfoGroup.DefaultIfEmpty()
                select new CourseInfoViewModel
                {
                    CourseId = courseMain.CourseId,
                    TutorHeadShotImage = courseMain.TutorHeadShotImage,
                    TutorFlagImage = courseMain.TutorFlagImage,
                    IsVerifiedTutor = courseMain.IsVerifiedTutor,
                    CourseTitle = courseMain.CourseTitle,
                    CourseSubTitle = courseMain.CourseSubTitle,
                    TutorIntro = courseMain.TutorIntro,
                    TwentyFiveMinUnitPrice = courseMain.TwentyFiveMinUnitPrice,
                    FiftyMinUnitPrice = courseMain.FiftyMinUnitPrice,
                    CourseVideo = courseMain.CourseVideo,
                    CourseVideoThumbnail = courseMain.CourseVideoThumbnail,
                    CourseImages = imgInfo?.CourseImages ?? new List<CourseImageViewModel>(),
                    CourseRatings = revInfo?.CourseRatings ?? 0,
                    CourseReviews = revInfo?.CourseReviews ?? 0,
                    BookedTimeSlots = bookInfo?.BookedTimeSlots ?? new List<TimeSlotViewModel>(),
                    AvailableTimeSlots = tTimeInfo?.AvailableTimeSlots ?? new List<TimeSlotViewModel>()
                }).ToList();

            return new CourseInfoListViewModel
            {
                CourseInfoList = completeCoursesInfo
            };
        }

        public async Task<int> GetTotalCourseQty()
        {
            return  _repository.GetAll<Course>().Count();
        }


        public async Task<CourseMainPageViewModel> GetCourseMainPage(int courseId)
        {
            // 查詢課程、會員和國籍資料
            var courseMainInfo = await (
                from course in _repository.GetAll<Course>().AsNoTracking()
                join member in _repository.GetAll<Member>().AsNoTracking()
                on course.TutorId equals member.MemberId
                join nation in _repository.GetAll<Nation>().AsNoTracking()
                on member.NationId equals nation.NationId
                where course.CourseId == courseId
                select new CourseMainPageViewModel
                {
                    MemberId = member.MemberId,
                    CourseId = course.CourseId,
                    SpokenLanguage = member.SpokenLanguage,
                    TutorHeadShotImage = member.HeadShotImage,
                    TutorFlagImage = nation.FlagImage,
                    IsVerifiedTutor = member.IsVerifiedTutor,
                    CourseTitle = course.Title,
                    CourseSubTitle = course.SubTitle,
                    TutorIntro = member.TutorIntro,
                    TwentyFiveMinPrice = course.TwentyFiveMinUnitPrice,
                    FiftyMinPrice = course.FiftyMinUnitPrice,
                    CourseVideo = course.VideoUrl,
                    CourseVideoThumbnail = course.ThumbnailUrl
                })
                .FirstOrDefaultAsync();

            if (courseMainInfo == null)
                return null; // 如果找不到對應的課程資料，返回 null



            // 查詢該課程的評論
            var reviews = await _repository.GetAll<Review>()
                .Where(r => r.CourseId == courseId)
                .AsNoTracking()
                .ToListAsync();

            // 若評論為空或 null，添加預設評論
            var reviewCardList = reviews.Any()
                ? reviews.Select(r => new ReviewViewModel
                {
                    ReviewerId = r.StudentId,
                    ReviewDate = r.Cdate.ToString("yyyy/MM/dd"),
                    ReviewContent = r.CommentText
                }).ToList()
                : new List<ReviewViewModel>
                    {
                        new ReviewViewModel
                        {
                            ReviewerId = 0, // 可以選擇合適的預設 ID 或者用戶名
                            ReviewDate = DateTime.Now.ToString("yyyy/MM/dd"),
                            ReviewContent = "目前並無評論"
                        }
                    }.ToList();


            // 查詢教師的工作經驗
            var tutorExperiences = await _repository.GetAll<WorkExperience>()
                .Where(w => w.MemberId == courseMainInfo.MemberId)
                .AsNoTracking()
                .ToListAsync();

            // 計算課程評分
            var averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

            // 準備 CourseMainPageViewModel
            var courseMainPageViewModel = new CourseMainPageViewModel
            {
                CourseId = courseMainInfo.CourseId,
                MemberId = courseMainInfo.MemberId,
                TutorHeadShotImage = courseMainInfo.TutorHeadShotImage,
                TutorFlagImage = courseMainInfo.TutorFlagImage,
                IsVerifiedTutor = courseMainInfo.IsVerifiedTutor,
                CourseTitle = courseMainInfo.CourseTitle,
                CourseSubTitle = courseMainInfo.CourseSubTitle,
                TutorIntro = courseMainInfo.TutorIntro,
                TwentyFiveMinPrice = courseMainInfo.TwentyFiveMinPrice,
                FiftyMinPrice = courseMainInfo.FiftyMinPrice,
                CourseVideo = courseMainInfo.CourseVideo,
                CourseVideoThumbnail = courseMainInfo.CourseVideoThumbnail,
                CourseRatings = averageRating,
                CourseReviews = reviews.Count,
                FinishedCoursesTotal = 3056, // 假設值，需從其他表查詢
                ReviewCardList = reviews.Select(r => new ReviewViewModel
                {
                    ReviewerId = r.StudentId,
                    ReviewDate = r.Cdate.ToString("yyyy/MM/dd"),
                    ReviewContent = r.CommentText
                }).ToList(),
                ExperienceList = tutorExperiences.Select(e => new TutorExperience
                {
                    StartYear = e.WorkStartDate.Year,
                    EndYear = e.WorkEndDate.Year,
                    WorkTitle = e.WorkName
                }).ToList(),
                CourseImages = new List<CourseImageViewModel>(), // 根據需求查詢並填充
                FollowingStatus = false // 假設未關注
            };

            // 處理折扣價錢
            var courseCountDiscountList = new List<CourseCountDiscount>
    {
        new CourseCountDiscount { CourseCount = 1, Discount = 0 },
        new CourseCountDiscount { CourseCount = 5, Discount = 5 },
        new CourseCountDiscount { CourseCount = 10, Discount = 10 },
        new CourseCountDiscount { CourseCount = 20, Discount = 15 }
    };

            courseMainPageViewModel.TwentyFiveDiscountedPrice = GettCoursePriceList(courseCountDiscountList, 25, courseMainPageViewModel.TwentyFiveMinPrice);
            courseMainPageViewModel.FiftyDiscountedPrice = GettCoursePriceList(courseCountDiscountList, 50, courseMainPageViewModel.FiftyMinPrice);

            return courseMainPageViewModel;
        }

        /// <summary>
        /// 25/50分鐘課程、價錢、折扣的方法
        /// </summary>
        private List<BaseDiscountPice> GettCoursePriceList(List<CourseCountDiscount> courseCounts, int time, decimal price)
        {
            return courseCounts.Select(x => new BaseDiscountPice
            {
                CourseCount = x.CourseCount,
                CourseDurance = time,
                Discount = (int)x.Discount,
                DiscountPrice = x.Discount == 0 ? price.ToString() : (price * (1 - (x.Discount / 100))).ToString("0"),
            }).ToList();
        }




        /// <summary>
        /// 首頁隨機顯示課程
        /// </summary>
        /// <returns></returns>
        public async Task<CourseInfoListViewModel> GetCourseList()
        {
            var courseList = new List<CourseInfoViewModel>
            {
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="法文",
                    TwentyFiveMinUnitPrice=100,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=France"
                },
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="國文",
                    TwentyFiveMinUnitPrice=150,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=Chinese"
                },
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="日文",
                    TwentyFiveMinUnitPrice=200,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=Japen"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="台語",
                    TwentyFiveMinUnitPrice=250,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=Taiwaness"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="韓文",
                    TwentyFiveMinUnitPrice=300,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=Karen"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="英文",
                    TwentyFiveMinUnitPrice=350,
                    HeadShotImage="https://fakeimg.pl/300x300/?text=English"
                }
            };

            return new CourseInfoListViewModel()
            {
                CourseInfoList = courseList
            };
        }


        public double GetCourseRating(int courseId)
        {
            var courseRatings = _repository.GetAll<Review>()
                .Where(review => review.CourseId == courseId)
                .Select(review => (double)review.Rating);
            return courseRatings.Any() ? courseRatings.Average() : 0;
        }
    }
}




