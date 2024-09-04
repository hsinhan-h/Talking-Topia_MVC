using Web.Entities;
using Web.Repository;
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


        public async Task<CourseInfoListViewModel> GetCourseCardsListRepo()
        {
            //real data from database
            var courses = from course in _repository.GetAll<Course>()
                          join member in _repository.GetAll<Member>()
                          on course.TutorId equals member.MemberId

                          join nation in _repository.GetAll<Nation>()
                          on member.NationId equals nation.NationId

                          join review in _repository.GetAll<Review>()
                          on course.CourseId equals review.CourseId into reviewGroup
                          from review in reviewGroup.DefaultIfEmpty() //left join review

                          join booking in _repository.GetAll<Booking>()
                          on course.CourseId equals booking.CourseId into bookingGroup
                          from booking in bookingGroup.DefaultIfEmpty() //left join booking

                          join tutorTimeSlot in _repository.GetAll<TutorTimeSlot>()
                          on member.MemberId equals tutorTimeSlot.TutorId into tutorTimeSlotGroup
                          from tutorTimeSlot in tutorTimeSlotGroup.DefaultIfEmpty() //left join tutortimeslot

                          join courseImage in _repository.GetAll<CourseImage>()
                          on course.CourseId equals courseImage.CourseId into courseImageGroup
                          from courseImage in courseImageGroup.DefaultIfEmpty()

                          group new { course, member, nation, review, booking, tutorTimeSlot, courseImage } by course.CourseId into groupedCourse
                          select new CourseInfoViewModel
                          {
                              CourseId = groupedCourse.Key,
                              TutorHeadShotImage = groupedCourse
                                                   .FirstOrDefault().member.HeadShotImage,
                              TutorFlagImage = groupedCourse
                                                    .FirstOrDefault().nation.FlagImage,
                              IsVerifiedTutor = (bool)groupedCourse
                                                    .FirstOrDefault().member.IsVerifiedTutor,
                              CourseTitle = groupedCourse
                                                    .FirstOrDefault().course.Title,
                              CourseSubTitle = groupedCourse
                                                    .FirstOrDefault().course.SubTitle,
                              TutorIntro = groupedCourse
                                                    .FirstOrDefault().member.TutorIntro,
                              TwentyFiveMinUnitPrice = groupedCourse
                                                    .FirstOrDefault().course.TwentyFiveMinUnitPrice,
                              FiftyMinUnitPrice = groupedCourse
                                                    .FirstOrDefault().course.FiftyMinUnitPrice,
                              CourseVideo = groupedCourse
                                                    .FirstOrDefault().course.VideoUrl,
                              CourseVideoThumbnail = groupedCourse
                                                    .FirstOrDefault().course.ThumbnailUrl,
                              CourseImages = groupedCourse
                                                    .Where(g => g.courseImage != null)
                                                    .Select(g => new CourseImageViewModel
                                                    {
                                                        ImageUrl = g.courseImage.ImageUrl
                                                    })
                                                    .ToList(),
                              CourseRatings = Math.Round(groupedCourse
                                                    .Where(g => g.review != null).Any() ? 
                                                    groupedCourse.Where(g => g.review != null)
                                                    .Average(g => g.review.Rating): 0, 2),
                              CourseReviews = groupedCourse.Where(g => g.review != null)
                                                    .GroupBy(g => g.review.ReviewId)
                                                    .Count(),
                              BookedTimeSlots = groupedCourse
                                                    .Where(g => g.booking != null)
                                                    .Select(g => new TimeSlotViewModel
                                                    {
                                                        Date = g.booking.BookingDate,
                                                        StartHour = g.booking.BookingTime - 1 //因資料表時間Id從1開始對應0:00起始時間
                                                    })
                                                    .ToList(),
                              AvailableTimeSlots = groupedCourse
                                                    .Where (g => g.tutorTimeSlot != null)
                                                    .Select(g => new TimeSlotViewModel
                                                    {
                                                        Weekday = g.tutorTimeSlot.Weekday,
                                                        StartHour = g.tutorTimeSlot.CourseHourId - 1 //因資料表時間Id從1開始對應0:00起始時間
                                                    })
                                                    .ToList()
                          };

            return new CourseInfoListViewModel
            {
                CourseInfoList = await courses.ToListAsync()
            };
        }

        //fake data
        public async Task<CourseInfoListViewModel> GetCourseCardsList()
        {
            var courseList = new List<CourseInfoViewModel>
            {
                new CourseInfoViewModel
                {
                    CourseId = 1,
                    TutorHeadShotImage = "~/image/tutor_headshot_imgs/tutor_demo_jp_001.webp",
                    TutorFlagImage = "~/image/flag_imgs/japan_flag.png",
                    IsVerifiedTutor = true,
                    CourseTitle = "Akimo老師 🔥精通日語：掌握這門全球流行語言的鑰匙！",
                    CourseSubTitle = "💡 從基礎到高階語法—全面提升你的日語能力！",
                    TutorIntro = "こんにちは！👋 私は Akimoです。生まれも育ちも日本で、日本語を教えることに情熱を持っています。🇯🇵 私は大学で日本語教育を専攻し、修士課程を修了後、さまざまな学校や語学機関で7年間教鞭を執ってきました。📚 これまでに、世界中の多くの学生たちに日本語の魅力を伝え、彼らが日本語能力試験に合格し、仕事や日常生活で日本語を自由に使えるようにサポートしてきました。🎓\r\n\r\n私は、生徒一人ひとりの個性を大切にし、それぞれの目標に応じた最適な学習プランを提供します。🎯 私の授業では、単なる文法や単語の暗記だけでなく、実際に使える日本語を身につけることに重点を置いています。具体的な場面を想定した会話練習や、文化についてのディスカッションを通じて、言葉の背景にある日本の文化や価値観も理解していただけるよう努めています。🎌\r\n\r\n私の目標は、皆さんが日本語を学ぶ楽しさを実感し、自信を持って日本語を使えるようになることです。💪 一緒に日本語の世界を探求し、新しい可能性を広げていきましょう！🚀 お会いできるのを楽しみにしています。😊",
                    TwentyFiveMinUnitPrice = 560,
                    FiftyMinUnitPrice = 1088,
                    CourseVideo = "https://www.youtube.com/embed/MAhD37a7AlE",
                    CourseVideoThumbnail = "~/image/thumb_nails/thumbnail_demo_jp_001.webp",
                    CourseImages = new List<CourseImageViewModel>
                    {
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/300/200?grayscale"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/237/450/300"}
                    },
                    CourseRatings = GetCourseRating(1),
                    CourseReviews = 1013,
                    BookedTimeSlots = new List<TimeSlotViewModel>
                    {
                        new TimeSlotViewModel { Date = new DateTime(2024, 8, 27, 12, 0, 0).Date, StartHour = new DateTime(2024, 8, 27, 12, 0, 0).Hour },
                        new TimeSlotViewModel { Date = new DateTime(2024, 9, 3, 14, 0, 0).Date, StartHour = new DateTime(2024, 9, 3, 14, 0, 0).Hour },
                        new TimeSlotViewModel { Date = new DateTime(2024, 9, 7, 17, 0, 0).Date, StartHour = new DateTime(2024, 9, 7, 17, 0, 0).Hour }
                    },
                    AvailableTimeSlots = new List<TimeSlotViewModel>
                    {
                        new TimeSlotViewModel { Weekday = 2, StartHour = 12 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 13 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 14 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 15 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 16 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 17 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 8 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 9 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 10 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 11 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 12 },
                        new TimeSlotViewModel { Weekday = 5, StartHour = 17 },
                        new TimeSlotViewModel { Weekday = 5, StartHour = 18 },
                        new TimeSlotViewModel { Weekday = 5, StartHour = 19 },
                        new TimeSlotViewModel { Weekday = 6, StartHour = 17 }
                    }
                },
                new CourseInfoViewModel
                {
                    CourseId = 2,
                    TutorHeadShotImage = "~/image/tutor_headshot_imgs/tutor_head_002.png",
                    TutorFlagImage = "~/image/flag_imgs/us_flag.png",
                    IsVerifiedTutor = false,
                    CourseTitle = "Todd🤠American Teacher!🏅Kid's English🔥精通英文：掌握這門全球流行語言的鑰匙！",
                    CourseSubTitle = "Expert! 🏅 Basic to Advanced😀",
                    TutorIntro = "嗨！我是 👩‍🏫 Todd，擁有 10 年的教學經驗！📚\r\n\r\n🎓 我持有 英文教師證 的證書，並且擁有多次國際英語教學的實戰經驗。對於不同年齡層的學生，我都有教學的方法與技巧，尤其擅長讓學習變得有趣且富有成效。🌈\r\n\r\n在這堂課中，我會根據學生的需求和程度量身定製教學計畫，讓每一位學生都能在輕鬆的氛圍中學習。課程的設計旨在建立自信心，讓你能夠在日常生活中自如地使用英語，無論是與朋友交談、旅遊還是商務會議中，都能夠流利溝通。🚀",
                    TwentyFiveMinUnitPrice = 700,
                    FiftyMinUnitPrice = 1100,
                    CourseVideo = "https://www.youtube.com/embed/xXsfl6RBuhQ",
                    CourseVideoThumbnail = "~/image/thumb_nails/tutor002_thumbnail.jpg",
                    CourseImages = new List<CourseImageViewModel>
                    {
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/100/450/300"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/200/450/300"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/300/450/300"}
                    },
                    CourseRatings = GetCourseRating(2),
                    CourseReviews = 512,
                    BookedTimeSlots = new List<TimeSlotViewModel>
                    {
                        new TimeSlotViewModel { Date = new DateTime(2024, 8, 28, 15, 0, 0).Date, StartHour = new DateTime(2024, 8, 27, 13, 0, 0).Hour },
                        new TimeSlotViewModel { Date = new DateTime(2024, 9, 6, 12, 0, 0).Date, StartHour = new DateTime(2024, 8, 28, 12, 0, 0).Hour }
                    },
                    AvailableTimeSlots = new List<TimeSlotViewModel>
                    {
                        new TimeSlotViewModel { Weekday = 2, StartHour = 13 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 14 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 15 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 16 },
                        new TimeSlotViewModel { Weekday = 2, StartHour = 17 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 11 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 12 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 13 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 14 },
                        new TimeSlotViewModel { Weekday = 3, StartHour = 15 },
                        new TimeSlotViewModel { Weekday = 5, StartHour = 12 },
                        new TimeSlotViewModel { Weekday = 5, StartHour = 13 },
                        new TimeSlotViewModel { Weekday = 6, StartHour = 17 },
                        new TimeSlotViewModel { Weekday = 6, StartHour = 18 }
                    }
                }
            };

            return new CourseInfoListViewModel()
            {
                CourseInfoList = courseList
            };


        }

        public async Task<CourseMainPageViewModel> GetCourseMainPage(int id)
        {

            var spokenLanguage = "中文,英文";
            var courseCountDiscountList = new List<CourseCountDiscount>
            {
                new CourseCountDiscount
                {
                    CourseCount = 1,
                    Discount = 0,
                },
                new CourseCountDiscount
                {
                    CourseCount = 5,
                    Discount = 5,
                },
                new CourseCountDiscount
                {
                    CourseCount = 10,
                    Discount = 10,
                },
                new CourseCountDiscount
                {
                    CourseCount = 20,
                    Discount =15,
                }
            };
            var courseInfo = new CourseMainPageViewModel()
            {
                CourseId = id,
                MemberId = 312,
                TutorHeadShotImage = "~/image/tutor_headshot_imgs/tutor_demo_jp_001.webp",
                TutorFlagImage = "~/image/flag_imgs/japan_flag.png",
                IsVerifiedTutor = true,
                CourseTitle = "Akimo老師 🔥精通日語：掌握這門全球流行語言的鑰匙！",
                CourseSubTitle = "💡 從基礎到高階語法—全面提升你的日語能力！",
                TutorIntro = "こんにちは！👋 私は Akimoです。生まれも育ちも日本で、日本語を教えることに情熱を持っています。🇯🇵 私は大学で日本語教育を専攻し、修士課程を修了後、さまざまな学校や語学機関で7年間教鞭を執ってきました。📚 これまでに、世界中の多くの学生たちに日本語の魅力を伝え、彼らが日本語能力試験に合格し、仕事や日常生活で日本語を自由に使えるようにサポートしてきました。🎓\r\n\r\n私は、生徒一人ひとりの個性を大切にし、それぞれの目標に応じた最適な学習プランを提供します。🎯 私の授業では、単なる文法や単語の暗記だけでなく、実際に使える日本語を身につけることに重点を置いています。具体的な場面を想定した会話練習や、文化についてのディスカッションを通じて、言葉の背景にある日本の文化や価値観も理解していただけるよう努めています。🎌\r\n\r\n私の目標は、皆さんが日本語を学ぶ楽しさを実感し、自信を持って日本語を使えるようになることです。💪 一緒に日本語の世界を探求し、新しい可能性を広げていきましょう！🚀 お会いできるのを楽しみにしています。😊",
                TwentyFiveMinPriceNTD = 480,
                TwentyFiveDiscountedPrice = GettCoursePriceList(courseCountDiscountList, 25, 480),
                FiftyMinPriceNTD = 888,
                SpokenLanguage = spokenLanguage.Split(",").ToList(),
                FiftyDiscountedPrice = GettCoursePriceList(courseCountDiscountList, 50, 888),
                CourseVideo = "https://www.youtube.com/embed/MAhD37a7AlE",
                CourseVideoThumbnail = "~/image/thumb_nails/thumbnail_demo_jp_001.webp",
                CourseRatings = 4.96,
                CourseReviews = 1013,
                FinishedCoursesTotal = 3056,
                ReviewCardList = new List<ReviewViewModel>
                {
                    new ReviewViewModel
                    {
                        ReviewerId = 1023,
                        ReviewDate = DateTime.Now.ToString("yyyy/MM/dd"),
                        ReviewContent = "Akimo老師的日語課程真是太棒了！老師講解得非常詳細，從基礎到進階都涵蓋到了。現在我不僅能讀懂日文，還能進行簡單的對話，真的感謝這門課！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 2045,
                        ReviewDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"),
                        ReviewContent = "這門課程讓我對日語有了全新的理解。Akimo老師的教學方式非常獨特，讓我在學習中不斷進步。課程內容豐富且實用，是想學日語的朋友們必修的好課！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 3091,
                        ReviewDate = DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd"),
                        ReviewContent = "學習這門課程後，我的日語能力提升得很快。Akimo老師教得非常細心，每個難點都能清楚解釋。現在我更有信心用日語溝通了，真的非常推薦這門課！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 4587,
                        ReviewDate = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd"),
                        ReviewContent = "老師的課程設計非常合理，涵蓋了日語學習的各個方面，讓我在短時間內有了很大的進步，非常感謝！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 5176,
                        ReviewDate = DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd"),
                        ReviewContent = "學習這門課程後，我對日語的發音和語法有了更深的理解，老師的講解簡單易懂，十分推薦！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 6238,
                        ReviewDate = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd"),
                        ReviewContent = "老師的教學風格很獨特，課程內容豐富多樣，尤其是口語練習部分，讓我更自信地說日語。"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 7324,
                        ReviewDate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd"),
                        ReviewContent = "非常滿意這門課程，老師的講解深入淺出，讓我能夠輕鬆掌握日語的基礎知識，學習變得有趣！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 8457,
                        ReviewDate = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd"),
                        ReviewContent = "老師非常有耐心，逐步講解了日語語法的難點和重點，讓我不再害怕學習這門語言，非常感謝！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 9546,
                        ReviewDate = DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd"),
                        ReviewContent = "這門課幫助我從零開始學習日語，現在已經能夠進行簡單對話，老師的教學方法真的很有效！"
                    },
                    new ReviewViewModel
                    {
                        ReviewerId = 1078,
                        ReviewDate = DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd"),
                        ReviewContent = "感謝老師詳細的講解和課堂上的實踐練習，讓我在短時間內掌握了日語的基礎用法，非常受益！"
                    }
                },
                ExperienceList = new List<TutorExperience>
                {
                    new TutorExperience
                    {
                        StartYear = 2015,
                        EndYear = 2018,
                        WorkTitle = "語言學校日語講師"
                    },
                    new TutorExperience
                    {
                        StartYear = 2019,
                        EndYear = 2021,
                        WorkTitle = "國際日語學院資深教師"
                    },
                    new TutorExperience
                    {
                        StartYear = 2022,
                        EndYear = 2024,
                        WorkTitle = "線上日語課程導師"
                    },
                    new TutorExperience
                    {
                        StartYear = 2017,
                        EndYear = 2020,
                        WorkTitle = "日本語學校教學主任"
                    },
                    new TutorExperience
                    {
                        StartYear = 2020,
                        EndYear = 2023,
                        WorkTitle = "語言中心教學協調員"
                    }
                }
            };            
            return courseInfo;
        }
        /// <summary>
        /// 25/50分鐘課程、價錢、折扣的方法
        /// </summary>
        private List<BaseDiscountPice> GettCoursePriceList(List<CourseCountDiscount> courseCounts, int time, decimal price)
        {

            var result = courseCounts.Select(x =>
            new BaseDiscountPice
            {
                CourseCount = x.CourseCount,
                CourseDurance = time,
                Discount = (int)x.Discount,
                DiscountPrice = x.Discount == 0 ? price.ToString() : (price * (1 - (x.Discount / 100))).ToString("0"),

            }).ToList();
            return result;
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




