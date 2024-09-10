using Web.Entities;
using Web.Repository;
using Web.ViewModels;

namespace Web.Services
{
    public class BookingService
    {
        private readonly IRepository _repository;
        public BookingService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingListViewModel> GetPublishCourseList(int MemberId)
        {
            //var booking = new List<BookingViewModel>
            //{
            //   new BookingViewModel
            //   {
            //       UpdateDatetime = DateTime.Now.AddDays(-5),
            //       CourseTitle = "基礎Python編程",
            //       Category = "程式設計",
            //       CourseSubject = "Python入門",
            //       Thumbnail = "https://example.com/images/python_thumbnail.jpg",
            //       VideoUrl = "https://example.com/videos/python_intro.mp4",
            //       CourseImageId = "img_12345",
            //       CourseId = 101,
            //       Title = "Python入門課程",
            //       SubTitle = "適合初學者的Python基礎教學",
            //       TutorIntro = "王小明，擁有超過15年的軟體開發經驗，專注於Python及數據分析領域。"
            //                    + "他曾在多家國際知名企業擔任軟體工程師及技術顧問，參與過多個大型項目的開發，"
            //                    + "包括金融數據分析、機器學習應用及自動化測試等。王小明也是一位熱衷分享的技術部落客，"
            //                    + "他的文章深受讀者歡迎，累計閱讀量已超過百萬次。他相信程式設計不僅僅是一種技術，更是一種思維方式，"
            //                    + "透過系統化的學習，任何人都能掌握Python的力量。除此之外，他也是數據科學愛好者，常常利用Python進行數據分析，"
            //                    + "幫助企業挖掘隱藏在數據中的價值。他的教學風格深入淺出，強調實踐與理論並重，"
            //                    + "學生們都稱讚他能將複雜的概念簡單化，讓學習過程變得輕鬆愉快。王小明希望透過這門課程，"
            //                    + "能幫助更多的人進入程式設計的世界，成為合格的Python開發者。",
            //       Description = "這門Python入門課程專為零基礎的學員設計，旨在幫助學員快速掌握Python的核心概念及基本語法。"
            //                    + "課程從安裝Python開發環境開始，逐步帶領學員了解變量、數據類型、條件語句、迴圈、函數等基礎知識。"
            //                    + "在學習過程中，我們將透過實際案例與習題，加深學員對於這些知識的理解。"
            //                    + "此外，課程還會介紹Python在數據分析、網頁爬蟲及自動化測試等領域的應用，"
            //                    + "讓學員能夠在實際場景中靈活運用所學。完成課程後，學員將能夠獨立撰寫Python程式，"
            //                    + "解決日常生活中或工作中的簡單問題，並為進一步學習進階Python知識奠定堅實基礎。"
            //                    + "無論你是希望進入程式設計領域的初學者，還是想為職業發展增加新技能的專業人士，"
            //                    + "這門課程都將是你不可錯過的絕佳選擇。學員在學習過程中若有任何疑問，"
            //                    + "也可以隨時在課程討論區發問，我們的講師及助教會隨時提供幫助，"
            //                    + "確保每位學員都能順利完成學習目標。",
            //       TrialPriceNTD = 399,
            //       TwentyFiveMinPriceNTD = 450,
            //       FiftyMinPriceNTD = 800,
            //       BookingId = 1,
            //       BookingDate = DateTime.Now.AddDays(-1),
            //       CourseLength = "25分鐘",
            //       MemberName = "TestMemberName",
            //   },
            //   new BookingViewModel
            //   {
            //       UpdateDatetime = DateTime.Now.AddDays(-10),
            //       CourseTitle = "高效時間管理術",
            //       Category = "個人發展",
            //       CourseSubject = "時間管理",
            //       Thumbnail = "https://example.com/images/time_management_thumbnail.jpg",
            //       VideoUrl = "https://example.com/videos/time_management.mp4",
            //       CourseImageId = "img_67890",
            //       CourseId = 102,
            //       Title = "掌握時間的藝術",
            //       SubTitle = "提高工作效率的時間管理技巧",
            //       TutorIntro = "李大華是一位資深的時間管理顧問，擁有超過20年的時間管理與生產力提升經驗。"
            //                   + "他曾為多家世界500強企業提供顧問服務，專門設計並實施高效的時間管理系統。"
            //                   + "李大華在個人效率提升方面的研究頗有建樹，他的專著《時間的藝術》被譽為時間管理領域的經典之作，"
            //                   + "並被翻譯成多國語言在全球範圍內廣泛傳播。他擁有心理學背景，擅長將心理學理論與實踐相結合，"
            //                   + "幫助個人和團隊發掘潛在的效率瓶頸，並通過系統化的方法來改善這些問題。"
            //                   + "他熱衷於推廣以人為本的時間管理理念，強調個人的幸福感與工作效率的平衡，"
            //                   + "並認為真正的高效能並不在於更快地完成更多工作，而是在於更有智慧地分配時間與精力。"
            //                   + "他的課程融合了理論與實踐，並提供了一系列工具和技術，"
            //                   + "幫助學員在快節奏的生活中實現更高效的時間管理。他相信，"
            //                   + "每個人都可以通過科學的時間管理來提升生活品質，"
            //                   + "而他的使命就是幫助更多人實現這一目標。",
            //       Description = "本課程專為那些希望提升工作效率、改善生活質量的人士設計。"
            //                   + "通過學習這門課程，你將掌握一系列實用的時間管理技巧，"
            //                   + "包括優先級設定、任務分解、時間阻隔法以及有效的目標設定方法。"
            //                   + "課程中還將深入探討時間管理的心理學原理，幫助你了解自己的時間使用習慣，"
            //                   + "識別並消除浪費時間的因素。通過課堂上的案例分析與實踐練習，"
            //                   + "你將學會如何制定每日、每週、每月的計劃，並確保這些計劃能夠被有效執行。"
            //                   + "此外，我們還會介紹如何應對時間壓力，保持工作與生活的平衡。"
            //                   + "本課程的特色在於不僅僅是理論講解，更是著重於實踐應用，"
            //                   + "讓你能夠將所學的時間管理技巧立即運用到生活和工作中去。"
            //                   + "無論你是學生、上班族、還是自由職業者，這門課程都將幫助你"
            //                   + "更好地管理自己的時間，提升效率，從而實現更快的成長與進步。"
            //                   + "完成課程後，你將不再被時間壓力所困擾，而是能夠從容應對各種挑戰，"
            //                   + "為自己的目標與夢想留出更多的時間與空間。",
            //        TrialPriceNTD = 399,
            //       TwentyFiveMinPriceNTD = 450,
            //       FiftyMinPriceNTD = 800,
            //       BookingId = 2,
            //       BookingDate = DateTime.Now.AddDays(-2),
            //       CourseLength = "50分鐘",
            //       MemberName = "TestMemberName2",
            //   },
            //};

            var bookingValue = from course in _repository.GetAll<Course>()
                           join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                           join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                           join image in _repository.GetAll<CourseImage>() on course.CourseId equals image.CourseId
                           join member in _repository.GetAll<Member>() on course.TutorId equals member.MemberId
                           join booking in _repository.GetAll<Booking>() on course.CourseId equals booking.CourseId
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
