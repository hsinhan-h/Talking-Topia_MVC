using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedReviews = table.Column<int>(type: "int", nullable: false),
                    TrialPriceNTD = table.Column<int>(type: "int", nullable: false),
                    TwentyFiveMinPriceNTD = table.Column<int>(type: "int", nullable: false),
                    FiftyMinPriceNTD = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroVideoId = table.Column<int>(type: "int", nullable: false),
                    IntroImages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntroVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroVideo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Description", "FiftyMinPriceNTD", "IntroImages", "IntroVideoId", "MemberID", "ReceivedReviews", "SubTitle", "Title", "TrialPriceNTD", "TwentyFiveMinPriceNTD" },
                values: new object[,]
                {
                    { 1, "💰你是老师吗？ 获得折扣！🇬🇧 常驻利兹（英国） 🇺🇸 15 年以上国际经验 🌎 曾就职于谷歌、环球音乐和国际特赦组织 🤝 传播专家 👩🏻‍🎓\r\n获得学士学位、理学硕士和剑桥资格\r\n🥇找到你想要的工作 🔥 在顶尖大学学习 👑 克服你的恐惧 😎 找到你的声音🚀增强你的信心", 1624, "[\"https://picsum.photos/id/210/350/220\",\"https://picsum.photos/id/250/350/220\"]", 1, 1, 1064, "今天变得冷静和自信", "Feds🥇顶级雅思| 批判性思维 |\r\n面试教练🥇", 469, 1000 },
                    { 2, "期待什麼：\r\n 😉定制課程\r\n 😃免費英語資源\r\n                  🤡80% 學生演講\r\n 😃保證改善\r\n 🌄有趣和友好的環境\r\n                    🌄額外的課外工作表和家庭作業（根據要求）\r\n😀 很多談話😁", 857, "[\"https://picsum.photos/id/210/350/220\",\"https://picsum.photos/id/250/350/220\"]", 2, 2, 328, "25分钟儿童课程", "Todd🤠American Teacher!🏅Kid's English\r\n                          Expert! 🏅 Basic to Advanced😀", 514, 700 }
                });

            migrationBuilder.InsertData(
                table: "IntroVideo",
                columns: new[] { "Id", "Thumbnail", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "~/image/thumb_nails/tutor001_thumbnail", "https://www.youtube.com/embed/3XToqdAcm9g" },
                    { 2, "~/image/thumb_nails/tutor002_thumbnail", "https://www.youtube.com/embed/xXsfl6RBuhQ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "IntroVideo");
        }
    }
}
