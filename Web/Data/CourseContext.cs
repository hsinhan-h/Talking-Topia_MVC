namespace Web.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                    new Course
                    {
                        Id = 1,
                        MemberID = 1,
                        Title = "Feds\U0001f947顶级雅思| 批判性思维 |\r\n面试教练\U0001f947",
                        SubTitle = "今天变得冷静和自信",
                        ReceivedReviews = 1064,
                        TrialPriceNTD = 469,
                        TwentyFiveMinPriceNTD = 1000,
                        FiftyMinPriceNTD = 1624,
                        Description = "💰你是老师吗？ 获得折扣！🇬🇧 常驻利兹（英国） 🇺🇸 15 年以上国际经验 🌎 曾就职于谷歌、环球音乐和国际特赦组织 \U0001f91d 传播专家 👩🏻‍🎓\r\n获得学士学位、理学硕士和剑桥资格\r\n\U0001f947找到你想要的工作 🔥 在顶尖大学学习 👑 克服你的恐惧 😎 找到你的声音🚀增强你的信心",
                        IntroVideo = new Tuple<string, string>("~/image/thumb_nails/tutor001_thumbnail", "https://www.youtube.com/embed/3XToqdAcm9g"),
                        IntroImages = new List<string> { "https://picsum.photos/id/210/350/220", "https://picsum.photos/id/250/350/220" }
                    },
                    new Course
                    {
                        Id = 2,
                        MemberID = 2,
                        Title = "Todd\U0001f920American Teacher!🏅Kid's English\r\n                          Expert! 🏅 Basic to Advanced😀",
                        SubTitle = "25分钟儿童课程",
                        ReceivedReviews = 328,
                        TrialPriceNTD = 514,
                        TwentyFiveMinPriceNTD = 700,
                        FiftyMinPriceNTD = 857,
                        Description = "期待什麼：\r\n 😉定制課程\r\n 😃免費英語資源\r\n                  \U0001f92180% 學生演講\r\n 😃保證改善\r\n 🌄有趣和友好的環境\r\n                    🌄額外的課外工作表和家庭作業（根據要求）\r\n😀 很多談話😁",
                        IntroVideo = new Tuple<string, string>("~/image/thumb_nails/tutor002_thumbnail", "https://www.youtube.com/embed/xXsfl6RBuhQ"),
                        IntroImages = new List<string> { "https://picsum.photos/id/210/350/220", "https://picsum.photos/id/250/350/220" }
                    }

                );
        }

        public DbSet<Member> Members { get; set; }


    }
}
