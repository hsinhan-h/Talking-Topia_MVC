using System.Linq;

namespace Web.Services
{
    public class CourseService
    {
        private readonly IRepository _repository;

        public CourseService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CourseInfoListViewModel> GetCourseCardsListAsync(int page, int pageSize, string selectedSubject = null, string selectedNation = null, string selectedBudget = null)
        {
            //課程主資訊查詢&套用篩選
            IQueryable<CourseInfoViewModel> courseMainInfoQuery = GetCourseMainInfoQuery();
            courseMainInfoQuery = ApplyCourseMainInfoQueryFilters(courseMainInfoQuery, selectedSubject, selectedNation, selectedBudget);
            

            List<CourseInfoViewModel> courseMainInfo = await courseMainInfoQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<int> courseIds = courseMainInfo.Select(c => c.CourseId).ToList();
            List<int> memberIds = courseMainInfo.Select(c => c.MemberId).ToList();

            var courseImagesInfo = await GetCourseImagesAsync(courseIds);
            var courseRatingsAndReviewsInfo = await GetCourseRatingsAndReviewsAsync(courseIds);
            var bookedTimeSlotsInfo = await GetBookedTimeSlotsAsync(courseIds);
            var availableTimeSlotsInfo = await GetAvailableTimeSlotsAsync(memberIds);

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
                    NationName = courseMain.NationName,
                    IsVerifiedTutor = courseMain.IsVerifiedTutor,
                    CourseTitle = courseMain.CourseTitle,
                    CourseSubTitle = courseMain.CourseSubTitle,
                    TutorIntro = courseMain.TutorIntro,
                    TwentyFiveMinUnitPrice = courseMain.TwentyFiveMinUnitPrice,
                    FiftyMinUnitPrice = courseMain.FiftyMinUnitPrice,
                    CourseVideo = courseMain.CourseVideo,
                    CourseVideoThumbnail = courseMain.CourseVideoThumbnail,
                    SubjectName =courseMain.SubjectName,
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

        //處理篩選
        private IQueryable<CourseInfoViewModel> ApplyCourseMainInfoQueryFilters(
            IQueryable<CourseInfoViewModel> courseMainInfoQuery, 
            string selectedSubject, 
            string selectedNation, 
            string selectedBudget)
        {
            if (!string.IsNullOrEmpty(selectedSubject))
            {
                courseMainInfoQuery = courseMainInfoQuery.Where(c => c.SubjectName == selectedSubject);
            }

            if (!string.IsNullOrEmpty(selectedNation))
            {
                courseMainInfoQuery = courseMainInfoQuery.Where(c => c.NationName == selectedNation);
            }

            if (!string.IsNullOrEmpty(selectedBudget))
            {
                switch (selectedBudget)
                {
                    case "349以下":
                        courseMainInfoQuery = courseMainInfoQuery.Where(c => c.TwentyFiveMinUnitPrice <= 349);
                        break;
                    case "350-499":
                        courseMainInfoQuery = courseMainInfoQuery.Where(c => c.TwentyFiveMinUnitPrice <= 499 && c.TwentyFiveMinUnitPrice >= 350);
                        break;
                    case "500-799":
                        courseMainInfoQuery = courseMainInfoQuery.Where(c => c.TwentyFiveMinUnitPrice <= 799 && c.TwentyFiveMinUnitPrice >= 500);
                        break;
                    case "800-999":
                        courseMainInfoQuery = courseMainInfoQuery.Where(c => c.TwentyFiveMinUnitPrice <= 999 && c.TwentyFiveMinUnitPrice >= 800);
                        break;
                    case "1000以上":
                        courseMainInfoQuery = courseMainInfoQuery.Where(c => c.TwentyFiveMinUnitPrice >= 1000);
                        break;
                    default:
                        break;
                }
            }
            return courseMainInfoQuery;
        }

        //主查詢
        private IQueryable<CourseInfoViewModel> GetCourseMainInfoQuery()
        {
            return (
                from course in _repository.GetAll<Course>().AsNoTracking()
                join member in _repository.GetAll<Member>().AsNoTracking()
                on course.TutorId equals member.MemberId
                join subject in _repository.GetAll<CourseSubject>().AsNoTracking()
                on course.SubjectId equals subject.SubjectId
                join nation in _repository.GetAll<Nation>().AsNoTracking()
                on member.NationId equals nation.NationId

                select new CourseInfoViewModel
                {
                    MemberId = member.MemberId,
                    CourseId = course.CourseId,
                    TutorHeadShotImage = member.HeadShotImage,
                    NationName = nation.NationName,
                    TutorFlagImage = nation.FlagImage,
                    IsVerifiedTutor = member.IsVerifiedTutor,
                    CourseTitle = course.Title,
                    CourseSubTitle = course.SubTitle,
                    TutorIntro = member.TutorIntro,
                    TwentyFiveMinUnitPrice = course.TwentyFiveMinUnitPrice,
                    FiftyMinUnitPrice = course.FiftyMinUnitPrice,
                    CourseVideo = course.VideoUrl,
                    CourseVideoThumbnail = course.ThumbnailUrl,
                    SubjectName = subject.SubjectName
                });
        }


        // 課程圖片查詢 (by courseIds)
        private async Task<List<CourseInfoViewModel>> GetCourseImagesAsync(List<int> courseIds)
        {
            return await (
                from courseImage in _repository.GetAll<CourseImage>().AsNoTracking()
                where courseIds.Contains(courseImage.CourseId)
                group courseImage by courseImage.CourseId into gpImage
                select new CourseInfoViewModel
                {
                    CourseId = gpImage.Key,
                    CourseImages = gpImage.Select(ci => new CourseImageViewModel
                    {
                        ImageUrl = ci.ImageUrl
                    }).ToList()
                }).ToListAsync();
        }

        // 評價及評論數查詢 (by courseIds)
        private async Task<List<CourseInfoViewModel>> GetCourseRatingsAndReviewsAsync(List<int> courseIds)
        {
            return await (
                from review in _repository.GetAll<Review>().AsNoTracking()
                where courseIds.Contains(review.CourseId)
                group review by review.CourseId into gpReview
                select new CourseInfoViewModel
                {
                    CourseId = gpReview.Key,
                    CourseRatings = gpReview.Any() ?
                                    Math.Round(gpReview.Average(cr => cr.Rating), 2) : 0,
                    CourseReviews = gpReview.Count()
                }).ToListAsync();
        }

        //已被預約時間查詢 (by courseIds)
        private async Task<List<CourseInfoViewModel>> GetBookedTimeSlotsAsync(List<int> courseIds)
        {
            return await (
                from booking in _repository.GetAll<Booking>().AsNoTracking()
                where courseIds.Contains(booking.CourseId)
                group booking by booking.CourseId into gpBooking
                select new CourseInfoViewModel
                {
                    CourseId = gpBooking.Key,
                    BookedTimeSlots = gpBooking.Select(cb => new TimeSlotViewModel
                    {
                        Date = cb.BookingDate,
                        StartHour = cb.BookingTime - 1 // id - 1 對應實際起始時間
                    }).ToList()
                }).ToListAsync();
        }

        // 教師可預約時間查詢 (by memberIds)
        private async Task<List<CourseInfoViewModel>> GetAvailableTimeSlotsAsync(List<int> memberIds)
        {
            return await(
                from tutorTimeSlot in _repository.GetAll<TutorTimeSlot>().AsNoTracking()
                where memberIds.Contains(tutorTimeSlot.TutorId)
                group tutorTimeSlot by tutorTimeSlot.TutorId into gpMember
                select new CourseInfoViewModel
                {
                    MemberId = gpMember.Key,
                    AvailableTimeSlots = gpMember.Select(mt => new TimeSlotViewModel
                    {
                        Weekday = mt.Weekday,
                        StartHour = mt.CourseHourId - 1,
                    }).ToList()
                }).ToListAsync();

        }


        public async Task<int> GetTotalCourseQtyAsync(string subject = null, string nation=null, string budget=null)
        {
            IQueryable<CourseInfoViewModel> courseQuery = GetCourseMainInfoQuery();
            courseQuery = ApplyCourseMainInfoQueryFilters(courseQuery, subject, nation, budget);

            return await courseQuery.CountAsync();
        }

        public async Task<CourseInfoViewModel> GetBookingTableAsync(int courseId)
        {
            var courseInfo = await _repository
                .GetAll<Course>()
                .AsNoTracking()
                .Where(course => course.CourseId == courseId)
                .Select(course => new CourseInfoViewModel
                {
                    CourseId = course.CourseId,
                    MemberId = course.TutorId,
                    TutorHeadShotImage = _repository
                        .GetAll<Member>()
                        .AsNoTracking()
                        .Where(m => m.MemberId == course.TutorId)
                        .Select(m => m.HeadShotImage)
                        .FirstOrDefault(),
                    CourseTitle = course.Title,
                    AvailableTimeSlots = _repository
                        .GetAll<TutorTimeSlot>()
                        .AsNoTracking()
                        .Where(ts => ts.TutorId == course.TutorId)
                        .Select(ts => new TimeSlotViewModel
                        {
                            Weekday = ts.Weekday,
                            StartHour = ts.CourseHourId
                        }).ToList(),
                    BookedTimeSlots = _repository
                        .GetAll<Booking>()
                        .AsNoTracking()
                        .Where(bk => bk.CourseId == course.CourseId)
                        .Select(bk => new TimeSlotViewModel
                        {
                            Date = bk.BookingDate,
                            StartHour = bk.BookingTime
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return courseInfo;
        }

        public decimal GetCourse25MinUnitPrice(int courseId)
        {
            return _repository.GetAll<Course>().AsNoTracking()
                .Where(c => c.CourseId == courseId)
                .Select(c => c.TwentyFiveMinUnitPrice)
                .FirstOrDefault();
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
                    TutorId = member.MemberId,
                    CourseId = course.CourseId,
                    CategoryId = course.CategoryId,
                    EducationId= (int)member.EducationId,
                    SpokenLanguage = member.SpokenLanguage,
                    TutorHeadShotImage = member.HeadShotImage,
                    TutorFlagImage = nation.FlagImage,
                    IsVerifiedTutor = member.IsVerifiedTutor,
                    CourseTitle = course.Title,
                    CourseSubTitle = course.SubTitle, 
                    TutorIntro = member.TutorIntro,
                    TwentyFiveMinPrice = (int)course.TwentyFiveMinUnitPrice,
                    FiftyMinPrice = (int)course.FiftyMinUnitPrice,
                    CourseVideo = course.VideoUrl,
                    CourseVideoThumbnail = course.ThumbnailUrl
                })
                .FirstOrDefaultAsync();          
                   
          
            if (courseMainInfo == null)
                return null; // 如果找不到對應的課程資料，返回 null

           //最高學歷的查詢
            var education = await _repository.GetAll<Education>()
                                .Where(w => w.EducationId == courseMainInfo.EducationId)
                                .AsNoTracking().ToListAsync();
            //專業證照的查詢
            var professional = await _repository.GetAll<ProfessionalLicense>()
                                .Where(p=>p.MemberId == courseMainInfo.TutorId)
                                .AsNoTracking().ToListAsync();
            var professionallist = professional.Any() ?
                                    professional.Select(p =>                                    
                                        new TutorProfessionList
                                        {
                                            ProfessionName = p.ProfessionalLicenseName
                                        }).ToList()
                                    : new List<TutorProfessionList>
                                    {
                                        new TutorProfessionList
                                        {
                                            ProfessionName = "目前無專業證照"
                                        }
                                    }.ToList();

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
                                .Where(w => w.MemberId == courseMainInfo.TutorId)
                                .AsNoTracking()
                                .ToListAsync();

            var recomCard = GetTutorRecommendCard(courseMainInfo.CategoryId);

            // 計算課程評分
            var averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

            // 準備 CourseMainPageViewModel
            var courseMainPageViewModel = new CourseMainPageViewModel
            {
                CourseId = courseMainInfo.CourseId,
                TutorId = courseMainInfo.TutorId,
                MemberId = 1,
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
                EducationDegree = education.Select(w => new TutorEducationList
                {
                    StudyStartYear = w.StudyStartYear,
                    StudyEndYear = w.StudyEndYear,
                    SchoolAndDepartment = w.SchoolName + " " + w.DepartmentName,
                }).ToList(),
                CourseImages = new List<CourseImageViewModel>(), // 根據需求查詢並填充
                ProfessionList = professional.Select(p => new TutorProfessionList
                {
                    ProfessionName = p.ProfessionalLicenseName
                }).ToList(),
                FollowingStatus = false ,// 假設未關注
                TutorReconmmendCard = recomCard
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
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=France"
                },
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="國文",
                    TwentyFiveMinUnitPrice=150,
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=Chinese"
                },
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="日文",
                    TwentyFiveMinUnitPrice=200,
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=Japen"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="台語",
                    TwentyFiveMinUnitPrice=250,
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=Taiwaness"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="韓文",
                    TwentyFiveMinUnitPrice=300,
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=Karen"
                }
                ,
                new CourseInfoViewModel
                {
                    CourseId=1,
                    SubjectId=1,
                    SubjectName="英文",
                    TwentyFiveMinUnitPrice=350,
                    TutorHeadShotImage="https://fakeimg.pl/300x300/?text=English"
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

        public List<TutorRecomCardList> GetTutorRecommendCard(int categoryId)
        {            
            var recomCardList = (from course in _repository.GetAll<Course>().AsNoTracking()
                                join member in _repository.GetAll<Member>().AsNoTracking()
                                on course.TutorId equals member.MemberId
                                join nation in _repository.GetAll<Nation>().AsNoTracking()
                                on member.NationId equals nation.NationId
                                where course.CategoryId == categoryId
                                select new TutorRecomCardList
                                {
                                    CourseId = course.CourseId,
                                    TutorHeadShot = member.HeadShotImage,
                                    NationFlagImg = nation.FlagImage,
                                    CourseTitle = course.Title,
                                    CourseSubTitle = course.SubTitle,
                                    TwentyFiveMinPrice = (int)course.TwentyFiveMinUnitPrice,
                                    FiftyminPrice = (int)course.FiftyMinUnitPrice,
                                    Description = course.Description,
                                }).ToList();


            var recomCardReview =  (
               from course in _repository.GetAll<Course>().AsNoTracking()
               join review in _repository.GetAll<Review>().AsNoTracking()
               on course.CourseId equals review.CourseId
               group review by course.CourseId into Review
               select new TutorRecomCardList
               {
                   CourseId = Review.Key,
                   Rating = Review.Any() ? Math.Round(Review.Average(cr => cr.Rating), 2) : 0,               
               }).ToList();

            foreach (var card in recomCardList)
            {
                var review = recomCardReview.FirstOrDefault(r => r.CourseId == card.CourseId);

                card.Rating = review?.Rating ?? 0;
            }
            
            return recomCardList;
        }
    }
}




