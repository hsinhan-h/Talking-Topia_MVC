using Web.Entities;
using static System.Net.WebRequestMethods;

namespace Web.Services
{
    public class CourseService
    {
        public async Task<CourseInfoListViewModel> GetCourseCardsList()
        {
            var courseList = new List<CourseInfoViewModel>
            {
                new CourseInfoViewModel
                {
                    TutorHeadShotImage = "~/image/tutor_headshot_imgs/tutor_demo_jp_001.webp",
                    TutorFlagImage = "~/image/flag_imgs/japan_flag.png",
                    IsVerifiedTutor = true,
                    CourseTitle = "Akimo老師 🔥精通日語：掌握這門全球流行語言的鑰匙！",
                    CourseSubTitle = "💡 從基礎到高階語法—全面提升你的日語能力！",
                    TutorIntro = "こんにちは！👋 私は Akimoです。生まれも育ちも日本で、日本語を教えることに情熱を持っています。🇯🇵 私は大学で日本語教育を専攻し、修士課程を修了後、さまざまな学校や語学機関で7年間教鞭を執ってきました。📚 これまでに、世界中の多くの学生たちに日本語の魅力を伝え、彼らが日本語能力試験に合格し、仕事や日常生活で日本語を自由に使えるようにサポートしてきました。🎓\r\n\r\n私は、生徒一人ひとりの個性を大切にし、それぞれの目標に応じた最適な学習プランを提供します。🎯 私の授業では、単なる文法や単語の暗記だけでなく、実際に使える日本語を身につけることに重点を置いています。具体的な場面を想定した会話練習や、文化についてのディスカッションを通じて、言葉の背景にある日本の文化や価値観も理解していただけるよう努めています。🎌\r\n\r\n私の目標は、皆さんが日本語を学ぶ楽しさを実感し、自信を持って日本語を使えるようになることです。💪 一緒に日本語の世界を探求し、新しい可能性を広げていきましょう！🚀 お会いできるのを楽しみにしています。😊",
                    TrialPriceNTD = 256,
                    FiftyMinPriceNTD = 888,
                    CourseVideo = "https://www.youtube.com/embed/v22JJP1GBAI",
                    CourseVideoThumbnail = "~/image/thumb_nails/thumbnail_demo_jp_001.webp",
                    CourseImages = new List<CourseImageViewModel>
                    {
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/300/200?grayscale"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/237/450/300"}
                    },
                    CourseRatings = 4.96,
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
                    TutorHeadShotImage = "~/image/tutor_headshot_imgs/tutor_head_002.png",
                    TutorFlagImage = "~/image/flag_imgs/us_flag.png", 
                    IsVerifiedTutor = false,
                    CourseTitle = "Todd🤠American Teacher!🏅Kid's English🔥精通英文：掌握這門全球流行語言的鑰匙！",
                    CourseSubTitle = "Expert! 🏅 Basic to Advanced😀",
                    TutorIntro = "嗨！我是 👩‍🏫 李老師，擁有 10 年的教學經驗！📚\r\n\r\n🎓 我持有 英文教師證 的證書，並且擁有多次國際英語教學的實戰經驗。對於不同年齡層的學生，我都有教學的方法與技巧，尤其擅長讓學習變得有趣且富有成效。🌈\r\n\r\n在這堂課中，我會根據學生的需求和程度量身定製教學計畫，讓每一位學生都能在輕鬆的氛圍中學習。課程的設計旨在建立自信心，讓你能夠在日常生活中自如地使用英語，無論是與朋友交談、旅遊還是商務會議中，都能夠流利溝通。🚀",
                    TrialPriceNTD = 555,
                    FiftyMinPriceNTD = 1100,
                    CourseVideo = "https://www.youtube.com/embed/xXsfl6RBuhQ",
                    CourseVideoThumbnail = "~/image/thumb_nails/tutor002_thumbnail.jpg",
                    CourseImages = new List<CourseImageViewModel>
                    {
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/100/450/300"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/200/450/300"},
                        new CourseImageViewModel {ImageUrl = "https://picsum.photos/id/300/450/300"}
                    },
                    CourseRatings = 4.2,
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
    }
}
