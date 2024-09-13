using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false, comment: "優惠折扣Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false, comment: "優惠折扣名稱"),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "折扣代碼"),
                    DiscountType = table.Column<int>(type: "int", nullable: false, comment: "折扣方式"),
                    Discount = table.Column<int>(type: "int", nullable: true, comment: "折扣"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "折扣到期日"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "是否有效"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coupons__384AF1BAE1D06BB9", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false, comment: "課程類別Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorytName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "課程類別名稱"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseCa__4D67EBB68E28BA31", x => x.CourseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CourseHours",
                columns: table => new
                {
                    CourseHourId = table.Column<int>(type: "int", nullable: false, comment: "課程時間Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "小時時段"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseHo__AE73575BBC30FF2E", x => x.CourseHourId);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false, comment: "學歷Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "學校名稱"),
                    StudyStartYear = table.Column<int>(type: "int", nullable: false, comment: "在學期間起"),
                    StudyEndYear = table.Column<int>(type: "int", nullable: false, comment: "在學期間迄"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "科系名稱"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Educatio__4BBE38058A56247B", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NationId = table.Column<int>(type: "int", nullable: false, comment: "國籍Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "國籍名稱"),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "國籍圖片路徑")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nations__211B9BBEE3B01F5C", x => x.NationId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "課程類別Id"),
                    SubjectId = table.Column<int>(type: "int", nullable: false, comment: "科目Id"),
                    TutorId = table.Column<int>(type: "int", nullable: false, comment: "學生Id"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "課程標題"),
                    SubTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "課程副標題"),
                    TwentyFiveMinUnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "25分鐘價"),
                    FiftyMinUnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "50分鐘價"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "課程詳細描述"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "是否顯示"),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "影片封面"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "影片路徑"),
                    CoursesStatus = table.Column<short>(type: "smallint", nullable: false, comment: "課程審核狀態"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D71A7F51F70E3", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories",
                        column: x => x.CategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "CourseCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "CourseSubjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false, comment: "課程科目Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "課程科目名稱"),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false, comment: "課程類別Id"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseSu__AC1BA3A8B5819935", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK__CourseSub__Cours__59063A47",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "CourseCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadShotImage = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "會員頭像"),
                    NationId = table.Column<int>(type: "int", nullable: true, comment: "國籍Id"),
                    IsVerifiedTutor = table.Column<bool>(type: "bit", nullable: false, comment: "優質會員"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "名字"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "姓氏"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "密碼"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "電子郵件信箱"),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "綽號"),
                    Phone = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false, comment: "電話"),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true, comment: "生日"),
                    Gender = table.Column<short>(type: "smallint", nullable: false, comment: "性別"),
                    NativeLanguage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "母語"),
                    SpokenLanguage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "會的語言"),
                    BankCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "銀行代碼"),
                    BankAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "帳戶名稱"),
                    EducationId = table.Column<int>(type: "int", nullable: true, comment: "最高學歷Id"),
                    TutorIntro = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "教師自介"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "帳號"),
                    AccountType = table.Column<int>(type: "int", nullable: false, comment: "帳號類型"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間"),
                    IsTutor = table.Column<bool>(type: "bit", nullable: false, comment: "是否為教師")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Members__0CF04B1808627D7C", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK__Members__Educati__49C3F6B7",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "EducationId");
                    table.ForeignKey(
                        name: "FK__Members__NationI__48CFD27E",
                        column: x => x.NationId,
                        principalTable: "Nations",
                        principalColumn: "NationId");
                });

            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    CourseImageId = table.Column<int>(type: "int", nullable: false, comment: "課程照片Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "圖片路徑"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseIm__349B6FE480594337", x => x.CourseImageId);
                    table.ForeignKey(
                        name: "FK__CourseIma__Cours__52593CB8",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "ApplyLists",
                columns: table => new
                {
                    ApplyID = table.Column<int>(type: "int", nullable: false, comment: "申請Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    ApplyStatus = table.Column<bool>(type: "bit", nullable: false, comment: "申請狀態"),
                    ApplyDateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "申請日期"),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "審核通過時間"),
                    UpdateStatusDateTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新審核通過時間"),
                    RejectReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "拒絕原因")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ApplyLis__F0687F91F95B14E5", x => x.ApplyID);
                    table.ForeignKey(
                        name: "FK__ApplyList__Membe__59FA5E80",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false, comment: "預約Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "預約上課日期"),
                    BookingTime = table.Column<short>(type: "smallint", nullable: false, comment: "預約上課時間"),
                    StudentId = table.Column<int>(type: "int", nullable: false, comment: "預約學生Id"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__73951AEDF4836C80", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK__Bookings__Course__5441852A",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK__Bookings__Member__534D60F1",
                        column: x => x.StudentId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "MemberCoupons",
                columns: table => new
                {
                    MemberCouponId = table.Column<int>(type: "int", nullable: false, comment: "會員優惠Id"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, comment: "是否使用"),
                    CouponId = table.Column<int>(type: "int", nullable: false, comment: "優惠折扣Id"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MemberCoupons_Coupons",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "CouponId");
                    table.ForeignKey(
                        name: "FK_MemberCoupons_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "MemberPreferences",
                columns: table => new
                {
                    MemberPreferenceId = table.Column<int>(type: "int", nullable: false, comment: "會員偏好Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    SubjecId = table.Column<int>(type: "int", nullable: false, comment: "主題Id"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MemberPr__5B2A2D7058311916", x => x.MemberPreferenceId);
                    table.ForeignKey(
                        name: "FK__MemberPre__Membe__5AEE82B9",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK__MemberPre__Subje__52593CB8",
                        column: x => x.SubjecId,
                        principalTable: "CourseSubjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "訂單Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "付款方式"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false, comment: "總金額"),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "交易日期"),
                    CouponPrice = table.Column<decimal>(type: "money", nullable: true, comment: "優惠金額"),
                    TaxIdNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "統一編號"),
                    InvoiceType = table.Column<short>(type: "smallint", nullable: false, comment: "發票類型"),
                    VATNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "發票號碼"),
                    SentVATEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "寄送Mail"),
                    OrderStatusId = table.Column<short>(type: "smallint", nullable: false, comment: "訂單狀態"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BCFBCC07793", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Orders__MemberId__4BAC3F29",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalLicenses",
                columns: table => new
                {
                    ProfessionalLicenseId = table.Column<int>(type: "int", nullable: false, comment: "證照Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalLicenseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "證照名稱"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    ProfessionalLicenseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "證照路徑"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professi__E1630CEE26905146", x => x.ProfessionalLicenseId);
                    table.ForeignKey(
                        name: "FK__Professio__Membe__5165187F",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false, comment: "課程評論Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false, comment: "學生Id"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false, comment: "評分"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "評論內容"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "評論日期"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__74BC79CE821ED086", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK__Reviews__CourseI__5070F446",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK__Reviews__MemberI__4F7CD00D",
                        column: x => x.StudentId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "購物車Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "課程單價"),
                    Quantity = table.Column<short>(type: "smallint", nullable: false, comment: "購買堂數"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false, comment: "單筆總價"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    CourseType = table.Column<short>(type: "smallint", nullable: false, comment: "課程類型"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間"),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "預約日期"),
                    BookingTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "預約時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TempOrde__38D216B780E2926D", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Courses",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "TutorTimeSlots",
                columns: table => new
                {
                    TutorTimeSlotId = table.Column<int>(type: "int", nullable: false, comment: "教師可預約Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorID = table.Column<int>(type: "int", nullable: false, comment: "老師Id"),
                    Weekday = table.Column<int>(type: "int", nullable: false, comment: "開課星期"),
                    CourseHourId = table.Column<int>(type: "int", nullable: false, comment: "開課時間"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TutorTim__E709EE17B13CB862", x => x.TutorTimeSlotId);
                    table.ForeignKey(
                        name: "FK__TutorTime__Cours__5EBF139D",
                        column: x => x.CourseHourId,
                        principalTable: "CourseHours",
                        principalColumn: "CourseHourId");
                    table.ForeignKey(
                        name: "FK__TutorTime__Membe__5535A963",
                        column: x => x.TutorID,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "WatchLists",
                columns: table => new
                {
                    WatchListId = table.Column<int>(type: "int", nullable: false, comment: "關注Id"),
                    FollowerId = table.Column<int>(type: "int", nullable: true, comment: "送出關注的人"),
                    CourseId = table.Column<int>(type: "int", nullable: true, comment: "關注的課程")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLists", x => x.WatchListId);
                    table.ForeignKey(
                        name: "FK_WatchLists_Courses",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_WatchLists_WatchLists",
                        column: x => x.WatchListId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(type: "int", nullable: false, comment: "工作經驗Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkExperienceFile = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "工作經驗檔案路徑"),
                    WorkStartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "工作起始日"),
                    WorkEndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "工作結束日"),
                    WorkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "工作經驗名稱"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WorkExpe__55A2B889201583D4", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK__WorkExper__Membe__4AB81AF0",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false, comment: "訂單明細Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "訂單Id"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "課程單價"),
                    Quantity = table.Column<short>(type: "smallint", nullable: false, comment: "購買堂數"),
                    DiscountPrice = table.Column<decimal>(type: "money", nullable: true, comment: "折扣金額"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false, comment: "總價"),
                    CourseType = table.Column<short>(type: "smallint", nullable: false, comment: "課程類別"),
                    CourseTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "課程名稱"),
                    CourseCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "課程類別"),
                    CourseSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "課程主題")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3F80D6D0305DA525", x => new { x.OrderDetailId, x.OrderId });
                    table.ForeignKey(
                        name: "FK__OrderDeta__Cours__4E88ABD4",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__4D94879B",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false, comment: "課程預定Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true, comment: "課程Id"),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "預約日期"),
                    BookingTime = table.Column<short>(type: "smallint", nullable: true, comment: "預約時間"),
                    MemberId = table.Column<int>(type: "int", nullable: true, comment: "會員Id"),
                    TempShoppingCartId = table.Column<int>(type: "int", nullable: true),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__73951AED7A624397", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK__TempShopp__TempS__60A75C0F",
                        column: x => x.TempShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId");
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CDate", "CouponCode", "CouponName", "Discount", "DiscountType", "ExpirationDate", "IsActive", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1258), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1256), true, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1259) },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1261), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1261), true, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1262) },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1264), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1263), false, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1264) },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1272), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1268), true, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1272) },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1274), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1274), false, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1275) },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1277), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1276), true, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1277) },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1283), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1279), false, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1283) },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1285), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1285), true, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1286) },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1288), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1287), false, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1288) },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1291), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1290), true, new DateTime(2024, 9, 24, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1291) },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1293), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1293), true, new DateTime(2024, 9, 25, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1294) },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1296), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1295), true, new DateTime(2024, 9, 26, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1296) },
                    { 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1299), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1298), false, new DateTime(2024, 9, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1299) },
                    { 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1301), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1300), true, new DateTime(2024, 9, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1301) },
                    { 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1304), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1303), true, new DateTime(2024, 9, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1304) },
                    { 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1309), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1308), true, new DateTime(2024, 9, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1310) },
                    { 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1312), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1311), true, new DateTime(2024, 10, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1312) },
                    { 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1314), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1313), true, new DateTime(2024, 10, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1314) },
                    { 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1316), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1316), true, new DateTime(2024, 10, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1317) },
                    { 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1319), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1318), true, new DateTime(2024, 10, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1319) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(824), null },
                    { 2, "程式設計", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(825), null },
                    { 3, "升學科目", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(826), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2708), "00:00", null },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2710), "01:00", null },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2711), "02:00", null },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2712), "03:00", null },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2715), "04:00", null },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2716), "05:00", null },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2717), "06:00", null },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2718), "07:00", null },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2719), "08:00", null },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2720), "09:00", null },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2720), "10:00", null },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2721), "11:00", null },
                    { 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2722), "12:00", null },
                    { 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2723), "13:00", null },
                    { 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2724), "14:00", null },
                    { 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2725), "15:00", null },
                    { 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2726), "16:00", null },
                    { 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2727), "17:00", null },
                    { 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2728), "18:00", null },
                    { 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2729), "19:00", null },
                    { 21, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2729), "20:00", null },
                    { 22, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2730), "21:00", null },
                    { 23, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2731), "22:00", null },
                    { 24, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2732), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(225), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(250), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(251), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(252), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(253), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(255), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(256), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(257), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(258), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(260), "Biology", "University of Toronto", 2016, 2012, null }
                });

            migrationBuilder.InsertData(
                table: "Nations",
                columns: new[] { "NationId", "FlagImage", "NationName" },
                values: new object[,]
                {
                    { 1, "~/image/flag_imgs/taiwan_flag.jpg", "臺灣" },
                    { 2, "~/image/flag_imgs/japan_flag.png", "日本" },
                    { 3, "~/image/flag_imgs/uk_flag.png", "英國" },
                    { 4, "~/image/flag_imgs/us_flag.png", "美國" },
                    { 5, "~/image/flag_imgs/france_flag.png", "法國" },
                    { 6, "~/image/flag_imgs/germany_flag.webp", "德國" },
                    { 7, "~/image/flag_imgs/spain_flag.png", "西班牙" },
                    { 8, "~/image/flag_imgs/india_flag.png", "印度" },
                    { 9, "~/image/flag_imgs/mexico_flag.webp", "墨西哥" },
                    { 10, "~/image/flag_imgs/other_flag.png", "其他" }
                });

            migrationBuilder.InsertData(
                table: "CourseSubjects",
                columns: new[] { "SubjectId", "CDate", "CourseCategoryId", "SubjectName", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(872), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(906), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(907), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(909), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(910), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(911), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(913), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(915), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(916), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(917), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(918), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(919), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(920), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(921), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(922), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(923), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(923), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(924), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(594), (short)1, "適合初學者的英文課程", 595m, true, "從零開始學英文", 1, "https://example.com/courses/english.jpg", "基礎英文", 1, 350m, null, "https://example.com/courses/english_intro.mp4" },
                    { 2, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(597), (short)1, "基礎日語語法和詞彙", 680m, true, "日語學習的基礎", 2, "https://example.com/courses/japanese.jpg", "日語入門", 2, 400m, null, "https://example.com/courses/japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(600), (short)1, "全面學習中文語法", 875m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 500m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(646), (short)1, "提高德語口語能力", 935m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 550m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(648), (short)1, "提升法語閱讀能力", 510m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 300m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(651), (short)1, "提高西班牙語寫作能力", 1440m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 800m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(654), (short)1, "從頭開始學習HTML和CSS", 765m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 450m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(656), (short)1, "學習JavaScript語法和應用", 1050m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 600m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(659), (short)1, "深入學習C#編程", 1620m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 900m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(664), (short)1, "從零開始學習SQL", 595m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 350m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(667), (short)1, "從頭開始學習Python編程", 935m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 550m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(669), (short)1, "從零開始學習Java語言", 1080m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 600m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(672), (short)1, "提升數學基礎知識", 540m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 300m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(674), (short)1, "物理學基礎知識", 630m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 350m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(677), (short)1, "全面了解化學基礎知識", 680m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 400m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(679), (short)1, "歷史事件和背景的深入分析", 1050m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 600m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(682), (short)1, "全面了解地理學的基礎", 875m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 500m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(684), (short)1, "深入學習生物學的基本概念", 1350m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 750m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(686), (short)1, "深入練習英語會話和詞彙", 1135m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 650m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(692), (short)1, "提升日語會話和語法能力", 1225m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 700m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(694), (short)1, "深入學習中文語法和詞彙", 1480m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 850m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(697), (short)1, "德語會話和詞彙的深入練習", 990m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 550m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(699), (short)1, "法語閱讀和寫作的深入研究", 1365m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 780m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(702), (short)1, "西班牙語寫作和語法的深入練習", 1620m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 900m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(704), (short)1, "高級網頁設計和開發技術", 925m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 500m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(747), (short)1, "JavaScript編程的高級應用和技巧", 1530m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 850m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(750), (short)1, "深入掌握C#編程的高級技術", 1225m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 700m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(755), (short)1, "SQL資料庫管理和優化的高級技術", 1080m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 600m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(757), (short)1, "Python編程的高級應用和數據處理", 1620m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 900m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(760), (short)1, "Java編程的高級技術和應用", 1350m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 750m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(762), (short)1, "高等數學理論和應用", 890m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 500m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(765), (short)1, "物理學的高級理論和應用", 1350m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 750m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(767), (short)1, "化學的高級理論和應用", 900m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 500m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(769), (short)1, "歷史研究的高級技術和方法", 1050m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 600m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(772), (short)1, "地理學的高級理論和應用", 1080m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 600m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(777), (short)1, "生物學的高級理論和應用", 1620m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 900m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(779), (short)1, "專業英文寫作的高級技巧", 935m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 550m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(782), (short)1, "專業日語寫作的高級技巧", 720m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 400m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(784), (short)1, "專業中文寫作的高級技巧", 1260m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 700m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(786), (short)1, "專業德語寫作的高級技巧", 1170m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 650m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(302), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(323), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(324) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(327), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(328), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(329) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(332), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(338), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(338) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(341), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(346), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(346) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(349), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(350), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(351) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(354), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(356), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(356) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(392), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(394), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(394) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(397), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(399), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(399) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(401), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(406), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(407) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(409), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(411), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(412) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(414), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(416), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(416) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(419), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(420), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(421) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(423), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(425), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(425) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(431), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(434), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(434) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(436), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(438), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(438) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(441), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(443), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(443) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(445), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(447), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(447) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(450), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(452), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(452) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(457), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(459), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(460) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(462), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(464), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(464) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(488), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(490), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(491) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(493), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(495), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(495) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(503), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(504), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(505) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(507), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(509), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(509) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(512), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(514), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(514) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(516), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(518), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(519) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(521), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(523), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(523) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(526), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(530), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(531) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(533), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(535), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(535) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(538), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(539), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(540) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1460), true, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1460), 1, null, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1461) },
                    { 2, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1463), false, null, 2, "Incomplete application", new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1464) },
                    { 3, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1465), true, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1465), 3, null, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1466) },
                    { 4, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1467), false, null, 4, "Failed verification", new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1468) },
                    { 5, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1469), true, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1470), 5, null, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1471) },
                    { 6, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1475), true, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1476), 6, null, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1476) },
                    { 7, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1478), false, null, 7, "Incorrect details", new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1478) },
                    { 8, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1480), true, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1480), 8, null, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1481) },
                    { 9, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1482), true, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1483), 9, null, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1483) },
                    { 10, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1484), false, null, 10, "Missing documents", new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1485) },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1486), true, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1487), 11, null, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1487) },
                    { 12, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1489), false, null, 12, "Not eligible", new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1489) },
                    { 13, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1491), true, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1491), 13, null, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1492) },
                    { 14, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1493), true, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1497), 14, null, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1497) },
                    { 15, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1498), false, null, 15, "Failed interview", new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1499) },
                    { 16, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1500), true, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1501), 16, null, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1501) },
                    { 17, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1503), true, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1503), 17, null, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1504) },
                    { 18, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1505), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1506) },
                    { 19, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1507), true, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1507), 19, null, new DateTime(2024, 9, 24, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1508) },
                    { 20, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1509), false, null, 20, "Unverified information", new DateTime(2024, 9, 25, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1510) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1533), (short)14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1534), 3, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1534) },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1538), (short)15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1538), 4, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1539) },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1540), (short)16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1541), 5, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1541) },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1542), (short)17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1543), 6, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1543) },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1544), (short)18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1545), 7, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1545) },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1546), (short)19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1547), 8, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1548) },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1548), (short)20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1549), 9, 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1550) },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1550), (short)12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1551), 10, 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1552) },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1552), (short)13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1553), 11, 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1553) },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1554), (short)14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1555), 12, 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1555) },
                    { 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1556), (short)15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1557), 13, 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1557) },
                    { 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1558), (short)16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1559), 14, 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1559) },
                    { 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1560), (short)17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1561), 15, 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1561) },
                    { 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1562), (short)18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1563), 16, 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1563) },
                    { 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1567), (short)19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1568), 17, 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1569) },
                    { 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1569), (short)20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1570), 18, 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1570) },
                    { 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1571), (short)12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1572), 19, 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1572) },
                    { 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1573), (short)13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1574), 20, 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1574) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(954), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(955), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(956), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(957), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(958), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(959), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(960), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(961), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(962), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(966), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(967), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(967), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1349), 1, 1, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1351) },
                    { 2, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1353), 2, 2, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1354) },
                    { 3, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1355), 3, 3, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1356) },
                    { 4, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1357), 4, 4, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1357) },
                    { 5, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1359), 5, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1359) },
                    { 6, new DateTime(2024, 3, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1360), 6, 6, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1361) },
                    { 7, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1362), 7, 7, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1363) },
                    { 8, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1364), 8, 8, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1365) },
                    { 9, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1366), 9, 9, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1367) },
                    { 10, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1368), 10, 10, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1368) },
                    { 11, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1370), 11, 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1370) },
                    { 12, new DateTime(2024, 3, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1371), 12, 12, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1372) },
                    { 13, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1373), 13, 13, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1373) },
                    { 14, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1375), 14, 14, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1375) },
                    { 15, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1376), 15, 15, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1377) },
                    { 16, new DateTime(2024, 7, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1378), 16, 16, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1381) },
                    { 17, new DateTime(2024, 8, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1383), 17, 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1383) },
                    { 18, new DateTime(2024, 3, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1384), 18, 18, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1385) },
                    { 19, new DateTime(2024, 4, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1386), 19, 1, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1386) },
                    { 20, new DateTime(2024, 5, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1420), 20, 2, new DateTime(2024, 6, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1421) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1013), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1000), new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1014), "12345678" },
                    { 2, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1017), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1015), new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1017), "22345678" },
                    { 3, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1021), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1019), new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1021), "32345678" },
                    { 4, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1024), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1023), new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1025), "42345678" },
                    { 5, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1030), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1029), new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1031), "52345678" },
                    { 6, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1034), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1032), new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1034), "62345678" },
                    { 7, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1037), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1036), new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1038), "72345678" },
                    { 8, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1041), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1039), new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1041), "82345678" },
                    { 9, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1044), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1043), new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1045), "92345678" },
                    { 10, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1049), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1048), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1050), "01234567" },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1053), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1051), new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1053), "12345679" },
                    { 12, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1056), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1055), new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1057), "22345679" },
                    { 13, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1059), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1058), new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1060), "32345679" },
                    { 14, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1063), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1061), new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1063), "42345679" },
                    { 15, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1069), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1068), new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1070), "52345679" },
                    { 16, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1072), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1071), new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1073), "62345679" },
                    { 17, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1076), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1074), new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1076), "72345679" },
                    { 18, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1079), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1077), new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1079), "82345679" },
                    { 19, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1111), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1110), new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1111), "92345679" },
                    { 20, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1114), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1113), new DateTime(2024, 9, 24, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1114), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1604), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1607) },
                    { 2, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1608), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1609) },
                    { 3, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1610), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1610) },
                    { 4, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1612), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1612) },
                    { 5, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1613), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1614) },
                    { 6, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1615), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1616) },
                    { 7, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1617), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1617) },
                    { 8, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1620), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1620) },
                    { 9, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1621), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1622) },
                    { 10, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1623), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1623) },
                    { 11, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1625), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1625) },
                    { 12, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1626), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1627) },
                    { 13, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1628), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1629) },
                    { 14, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1630), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1630) },
                    { 15, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1632), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1632) },
                    { 16, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1633), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1634) },
                    { 17, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1635), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1636) },
                    { 18, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1637), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1637) },
                    { 19, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1638), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1641) },
                    { 20, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1642), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1642) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1700), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1700) },
                    { 2, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1702), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1703) },
                    { 3, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1704), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1705) },
                    { 4, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1706), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1707) },
                    { 5, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1708), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1709) },
                    { 6, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1710), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1710) },
                    { 7, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1712), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1712) },
                    { 8, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1714), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1714) },
                    { 9, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1716), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1716) },
                    { 10, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1719), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1719) },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1720), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1721) },
                    { 12, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1722), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1723) },
                    { 13, new DateTime(2024, 9, 16, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1724), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1725) },
                    { 14, new DateTime(2024, 9, 17, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1726), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1727) },
                    { 15, new DateTime(2024, 9, 18, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1728), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1728) },
                    { 16, new DateTime(2024, 9, 19, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1730), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1730) },
                    { 17, new DateTime(2024, 9, 20, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1732), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1732) },
                    { 18, new DateTime(2024, 9, 21, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1733), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1734) },
                    { 19, new DateTime(2024, 9, 22, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1735), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1735) },
                    { 20, new DateTime(2024, 9, 23, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1740), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1740) },
                    { 21, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1742), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1742) },
                    { 22, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1743), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1744) },
                    { 23, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1745), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1746) },
                    { 24, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1747), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1747) },
                    { 25, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1748), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1749) },
                    { 26, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1750), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1751) },
                    { 27, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1752), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1753) },
                    { 28, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1754), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1754) },
                    { 29, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1755), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1756) },
                    { 30, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1757), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1760) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1798), new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1798), new DateTime(2024, 8, 25, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1796), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 26, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1797), 100.00m },
                    { 2, new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1802), new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1802), new DateTime(2024, 8, 26, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1801), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1801), 200.00m },
                    { 3, new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1806), new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1806), new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1804), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1805), 300.00m },
                    { 4, new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1809), new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1812), new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1808), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1809), 400.00m },
                    { 5, new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1815), new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1816), new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1814), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1815), 500.00m },
                    { 6, new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1819), new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1820), new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1818), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1819), 600.00m },
                    { 7, new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1823), new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1824), new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1822), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1822), 700.00m },
                    { 8, new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1827), new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1828), new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1826), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1826), 800.00m },
                    { 9, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1834), new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1834), new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1829), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1830), 900.00m },
                    { 10, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1837), new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1838), new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1836), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1837), 1000.00m },
                    { 11, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1841), new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1842), new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1840), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1841), 1100.00m },
                    { 12, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1846), new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1846), new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1845), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1845), 1200.00m },
                    { 13, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1850), new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1850), new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1848), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1849), 1300.00m },
                    { 14, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1855), new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1855), new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1853), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1854), 1400.00m },
                    { 15, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1859), new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1859), new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1857), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1858), 1500.00m },
                    { 16, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1862), new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1863), new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1861), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1861), 1600.00m },
                    { 17, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1866), new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1867), new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1865), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1865), 1700.00m },
                    { 18, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1871), new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1871), new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1869), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1870), 1800.00m },
                    { 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1874), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1875), new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1873), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1873), 1900.00m },
                    { 20, new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 9, 15, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1877), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1877), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2077), 8, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2077), 1 },
                    { 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2080), 9, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2080), 1 },
                    { 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2082), 10, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2082), 1 },
                    { 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2083), 11, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2084), 1 },
                    { 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2085), 12, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2086), 1 },
                    { 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2087), 13, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2087), 1 },
                    { 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2089), 14, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2089), 1 },
                    { 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2090), 15, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2091), 1 },
                    { 9, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2092), 16, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2092), 1 },
                    { 10, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2094), 17, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2094), 1 },
                    { 11, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2095), 18, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2096), 1 },
                    { 12, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2097), 19, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2097), 1 },
                    { 13, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2098), 20, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2099), 1 },
                    { 14, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2103), 8, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2104), 2 },
                    { 15, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2105), 9, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2105), 2 },
                    { 16, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2106), 10, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2107), 2 },
                    { 17, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2108), 11, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2108), 2 },
                    { 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2109), 12, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2110), 2 },
                    { 19, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2111), 13, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2111), 2 },
                    { 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2112), 14, 1, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2113), 2 },
                    { 21, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2114), 8, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2114), 3 },
                    { 22, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2115), 9, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2116), 3 },
                    { 23, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2117), 10, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2117), 3 },
                    { 24, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2119), 11, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2119), 3 },
                    { 25, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2120), 12, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2120), 4 },
                    { 26, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2122), 13, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2122), 4 },
                    { 27, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2125), 14, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2125), 4 },
                    { 28, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2126), 15, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2127), 5 },
                    { 29, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2128), 16, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2128), 5 },
                    { 30, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2129), 17, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2130), 5 },
                    { 31, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2131), 18, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2131), 6 },
                    { 32, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2132), 19, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2133), 6 },
                    { 33, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2134), 20, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2134), 0 },
                    { 34, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2135), 8, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2136), 1 },
                    { 35, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2137), 9, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2137), 1 },
                    { 36, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2138), 10, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2139), 1 },
                    { 37, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2140), 11, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2140), 2 },
                    { 38, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2141), 12, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2142), 2 },
                    { 39, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2146), 13, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2146), 2 },
                    { 40, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2147), 14, 2, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2148), 2 },
                    { 41, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2149), 8, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2149), 2 },
                    { 42, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2150), 9, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2151), 2 },
                    { 43, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2152), 10, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2153), 2 },
                    { 44, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2154), 11, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2154), 2 },
                    { 45, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2155), 12, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2156), 3 },
                    { 46, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2157), 13, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2157), 3 },
                    { 47, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2160), 14, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2161), 3 },
                    { 48, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2162), 15, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2162), 4 },
                    { 49, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2163), 16, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2163), 4 },
                    { 50, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2165), 17, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2165), 4 },
                    { 51, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2169), 18, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2169), 5 },
                    { 52, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2170), 19, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2171), 5 },
                    { 53, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2172), 20, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2172), 6 },
                    { 54, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2173), 8, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2174), 0 },
                    { 55, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2196), 9, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2196), 0 },
                    { 56, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2198), 10, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2198), 1 },
                    { 57, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2199), 11, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2200), 1 },
                    { 58, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2201), 12, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2201), 1 },
                    { 59, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2202), 13, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2204), 1 },
                    { 60, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2205), 14, 3, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2237), 2 },
                    { 61, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2238), 8, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2239), 1 },
                    { 62, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2240), 9, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2240), 1 },
                    { 63, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2242), 10, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2245), 1 },
                    { 64, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2246), 11, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2248), 1 },
                    { 65, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2251), 12, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2251), 1 },
                    { 66, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2255), 13, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2255), 1 },
                    { 67, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2256), 8, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2257), 2 },
                    { 68, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2258), 9, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2258), 2 },
                    { 69, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2259), 10, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2260), 2 },
                    { 70, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2261), 11, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2261), 2 },
                    { 71, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2262), 12, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2263), 2 },
                    { 72, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2264), 13, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2264), 2 },
                    { 73, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2265), 8, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2266), 3 },
                    { 74, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2267), 9, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2267), 3 },
                    { 75, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2268), 10, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2269), 3 },
                    { 76, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2273), 11, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2273), 3 },
                    { 77, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2274), 12, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2274), 3 },
                    { 78, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2275), 13, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2276), 3 },
                    { 79, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2277), 8, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2277), 4 },
                    { 80, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2278), 9, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2279), 4 },
                    { 81, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2280), 10, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2280), 4 },
                    { 82, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2282), 11, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2282), 4 },
                    { 83, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2283), 12, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2284), 4 },
                    { 84, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2285), 13, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2285), 4 },
                    { 85, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2286), 8, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2287), 5 },
                    { 86, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2288), 9, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2288), 5 },
                    { 87, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2289), 10, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2290), 5 },
                    { 88, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2293), 11, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2294), 5 },
                    { 89, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2295), 12, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2295), 5 },
                    { 90, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2296), 13, 4, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2297), 5 },
                    { 91, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2298), 8, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2298), 1 },
                    { 92, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2299), 9, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2300), 1 },
                    { 93, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2301), 10, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2301), 1 },
                    { 94, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2303), 11, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2303), 1 },
                    { 95, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2304), 12, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2305), 2 },
                    { 96, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2306), 13, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2306), 2 },
                    { 97, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2307), 14, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2308), 2 },
                    { 98, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2309), 8, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2309), 3 },
                    { 99, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2310), 9, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2311), 3 },
                    { 100, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2312), 10, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2314), 3 },
                    { 101, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2315), 11, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2316), 3 },
                    { 102, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2317), 12, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2317), 3 },
                    { 103, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2318), 8, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2319), 4 },
                    { 104, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2321), 9, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2322), 4 },
                    { 105, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2323), 10, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2323), 4 },
                    { 106, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2324), 11, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2324), 4 },
                    { 107, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2326), 12, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2326), 4 },
                    { 108, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2328), 8, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2328), 5 },
                    { 109, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2329), 9, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2329), 5 },
                    { 110, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2330), 10, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2331), 5 },
                    { 111, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2332), 11, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2332), 5 },
                    { 112, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2333), 12, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2334), 6 },
                    { 113, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2338), 13, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2338), 6 },
                    { 114, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2339), 14, 5, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2340), 6 },
                    { 115, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2341), 10, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2341), 1 },
                    { 116, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2342), 11, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2342), 1 },
                    { 117, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2344), 12, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2344), 1 },
                    { 118, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2345), 13, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2346), 1 },
                    { 119, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2347), 15, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2347), 2 },
                    { 120, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2348), 16, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2349), 2 },
                    { 121, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2350), 17, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2350), 2 },
                    { 122, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2351), 10, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2351), 3 },
                    { 123, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2353), 11, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2353), 3 },
                    { 124, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2355), 12, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2355), 3 },
                    { 125, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2356), 13, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2356), 3 },
                    { 126, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2357), 9, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2358), 4 },
                    { 127, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2359), 10, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2359), 4 },
                    { 128, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2360), 11, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2361), 4 },
                    { 129, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2362), 14, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2362), 5 },
                    { 130, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2364), 15, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2364), 5 },
                    { 131, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2365), 16, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2365), 5 },
                    { 132, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2367), 18, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2368), 6 },
                    { 133, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2369), 19, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2369), 6 },
                    { 134, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2370), 20, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2371), 6 },
                    { 135, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2372), 21, 6, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2372), 6 },
                    { 136, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2373), 9, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2374), 0 },
                    { 137, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2378), 10, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2378), 0 },
                    { 138, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2379), 11, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2380), 1 },
                    { 139, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2381), 12, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2381), 1 },
                    { 140, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2382), 13, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2383), 1 },
                    { 141, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2384), 14, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2384), 2 },
                    { 142, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2386), 15, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2386), 2 },
                    { 143, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2387), 16, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2388), 2 },
                    { 144, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2389), 18, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2389), 3 },
                    { 145, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2390), 19, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2391), 3 },
                    { 146, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2392), 20, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2392), 3 },
                    { 147, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2393), 21, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2394), 3 },
                    { 148, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2395), 8, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2395), 4 },
                    { 149, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2397), 9, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2397), 4 },
                    { 150, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2401), 10, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2401), 4 },
                    { 151, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2403), 12, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2403), 5 },
                    { 152, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2404), 13, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2405), 5 },
                    { 153, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2406), 14, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2406), 5 },
                    { 154, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2407), 16, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2408), 6 },
                    { 155, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2409), 17, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2409), 6 },
                    { 156, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2410), 18, 7, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2411), 6 },
                    { 157, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2412), 9, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2412), 0 },
                    { 158, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2413), 10, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2414), 0 },
                    { 159, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2415), 11, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2415), 0 },
                    { 160, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2417), 12, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2417), 0 },
                    { 161, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2418), 14, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2419), 1 },
                    { 162, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2422), 15, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2423), 1 },
                    { 163, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2424), 16, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2424), 1 },
                    { 164, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2425), 17, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2426), 1 },
                    { 165, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2427), 18, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2427), 2 },
                    { 166, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2466), 19, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2467), 2 },
                    { 167, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2468), 20, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2468), 2 },
                    { 168, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2470), 21, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2470), 2 },
                    { 169, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2471), 8, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2472), 3 },
                    { 170, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2473), 9, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2473), 3 },
                    { 171, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2475), 10, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2475), 3 },
                    { 172, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2476), 11, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2476), 3 },
                    { 173, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2478), 13, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2478), 4 },
                    { 174, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2480), 14, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2481), 4 },
                    { 175, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2482), 15, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2482), 4 },
                    { 176, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2483), 17, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2484), 5 },
                    { 177, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2485), 18, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2485), 5 },
                    { 178, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2486), 19, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2487), 5 },
                    { 179, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2488), 20, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2488), 6 },
                    { 180, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2489), 21, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2490), 6 },
                    { 181, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2491), 22, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2491), 6 },
                    { 182, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2492), 23, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2493), 6 },
                    { 183, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2494), 12, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2494), 0 },
                    { 184, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2495), 13, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2496), 0 },
                    { 185, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2497), 14, 8, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2497), 0 }
                });

            migrationBuilder.InsertData(
                table: "WatchLists",
                columns: new[] { "WatchListId", "CourseId", "FollowerId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 },
                    { 11, 11, 11 },
                    { 12, 12, 12 },
                    { 13, 13, 13 },
                    { 14, 14, 14 },
                    { 15, 15, 15 },
                    { 16, 16, 16 },
                    { 17, 17, 17 },
                    { 18, 18, 18 },
                    { 19, 19, 19 },
                    { 20, 20, 20 }
                });

            migrationBuilder.InsertData(
                table: "WorkExperiences",
                columns: new[] { "WorkExperienceId", "CDate", "MemberId", "UDate", "WorkEndDate", "WorkExperienceFile", "WorkName", "WorkStartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2582), 1, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2583), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2581), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2580) },
                    { 2, new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2586), 2, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2587), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2585), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2584) },
                    { 3, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2589), 3, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2590), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2589), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2588) },
                    { 4, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2592), 4, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2593), new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2592), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2591) },
                    { 5, new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2595), 5, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2596), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2595), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2594) },
                    { 6, new DateTime(2017, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2598), 6, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2599), new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2598), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2597) },
                    { 7, new DateTime(2016, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2601), 7, new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2602), new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2601), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2600) },
                    { 8, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2604), 8, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2605), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2604), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2603) },
                    { 9, new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2608), 9, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2608), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2607), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2606) },
                    { 10, new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2611), 10, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2611), new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2610), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2610) },
                    { 11, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2613), 11, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2614), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2613), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2612) },
                    { 12, new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2616), 12, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2617), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2616), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2615) },
                    { 13, new DateTime(2017, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2620), 13, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2621), new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2620), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2619) },
                    { 14, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2623), 14, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2624), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2623), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2622) },
                    { 15, new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2629), 15, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2630), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2628), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2625) },
                    { 16, new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2632), 16, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2633), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2631), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2631) },
                    { 17, new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2635), 17, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2635), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2634), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2634) },
                    { 18, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2637), 18, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2638), new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2637), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2637) },
                    { 19, new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2640), 19, new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2641), new DateTime(2023, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2640), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2639) },
                    { 20, new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2643), 20, new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2644), new DateTime(2022, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2643), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2642) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "CourseCategory", "CourseId", "CourseSubject", "CourseTitle", "CourseType", "DiscountPrice", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "語言學習", 2, "日文", "日文會話", (short)1, 10.00m, (short)10, 900.00m, 100.00m },
                    { 2, 2, "語言學習", 2, "日文", "日文會話", (short)1, 20.00m, (short)5, 980.00m, 200.00m },
                    { 3, 3, "程式設計", 3, "C#", "C# 基礎", (short)1, 30.00m, (short)3, 870.00m, 300.00m },
                    { 4, 4, "程式設計", 4, "SQL", "SQL進階", (short)2, 40.00m, (short)2, 760.00m, 400.00m },
                    { 5, 5, "程式設計", 5, "Java", "Java 進階", (short)2, 50.00m, (short)4, 1950.00m, 500.00m },
                    { 6, 6, "升學科目", 6, "數學", "數學基礎", (short)1, 60.00m, (short)1, 540.00m, 600.00m },
                    { 7, 7, "升學科目", 7, "物理", "物理基礎", (short)1, 70.00m, (short)3, 1890.00m, 700.00m },
                    { 8, 8, "升學科目", 8, "化學", "化學進階", (short)2, 80.00m, (short)2, 1520.00m, 800.00m },
                    { 9, 9, "升學科目", 9, "歷史", "歷史進階", (short)2, 90.00m, (short)1, 810.00m, 900.00m },
                    { 10, 10, "升學科目", 10, "地理", "地理基礎", (short)1, 100.00m, (short)2, 1900.00m, 1000.00m },
                    { 11, 11, "升學科目", 11, "生物", "生物基礎", (short)1, 110.00m, (short)1, 990.00m, 1100.00m },
                    { 12, 12, "語言學習", 12, "英文", "英文進階", (short)2, 120.00m, (short)4, 4680.00m, 1200.00m },
                    { 13, 13, "語言學習", 13, "日文", "日文基礎", (short)1, 130.00m, (short)3, 3690.00m, 1300.00m },
                    { 14, 14, "語言學習", 14, "中文", "中文進階", (short)2, 140.00m, (short)2, 2660.00m, 1400.00m },
                    { 15, 15, "語言學習", 15, "德文", "德文基礎", (short)1, 150.00m, (short)5, 7050.00m, 1500.00m },
                    { 16, 16, "語言學習", 16, "法文", "法文基礎", (short)1, 160.00m, (short)4, 6240.00m, 1600.00m },
                    { 17, 17, "語言學習", 17, "西班牙文", "西班牙文進階", (short)2, 170.00m, (short)2, 3230.00m, 1700.00m },
                    { 18, 18, "程式設計", 18, "HTML/CSS", "HTML/CSS進階", (short)2, 180.00m, (short)1, 1620.00m, 1800.00m },
                    { 19, 19, "程式設計", 19, "JavaScript", "JavaScript基礎", (short)1, 190.00m, (short)4, 7370.00m, 1900.00m },
                    { 20, 20, "程式設計", 20, "Python", "Python進階", (short)2, 200.00m, (short)2, 3800.00m, 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartBookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "MemberId", "TempShoppingCartId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 8, 25), (short)10, new DateTime(2024, 8, 25, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1956), 1, 1, 1, new DateTime(2024, 8, 26, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1957) },
                    { 2, new DateOnly(2024, 8, 26), (short)11, new DateTime(2024, 8, 26, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1959), 2, 2, 2, new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1960) },
                    { 3, new DateOnly(2024, 8, 27), (short)12, new DateTime(2024, 8, 27, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1963), 3, 3, 3, new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1963) },
                    { 4, new DateOnly(2024, 8, 28), (short)13, new DateTime(2024, 8, 28, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1966), 4, 4, 4, new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1966) },
                    { 5, new DateOnly(2024, 8, 29), (short)14, new DateTime(2024, 8, 29, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1998), 5, 5, 5, new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(1998) },
                    { 6, new DateOnly(2024, 8, 30), (short)15, new DateTime(2024, 8, 30, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2001), 6, 6, 6, new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2002) },
                    { 7, new DateOnly(2024, 8, 31), (short)16, new DateTime(2024, 8, 31, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2004), 7, 7, 7, new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2005) },
                    { 8, new DateOnly(2024, 9, 1), (short)17, new DateTime(2024, 9, 1, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2007), 8, 8, 8, new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2008) },
                    { 9, new DateOnly(2024, 9, 2), (short)18, new DateTime(2024, 9, 2, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2013), 9, 9, 9, new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2014) },
                    { 10, new DateOnly(2024, 9, 3), (short)19, new DateTime(2024, 9, 3, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2017), 10, 10, 10, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2018) },
                    { 11, new DateOnly(2024, 9, 4), (short)20, new DateTime(2024, 9, 4, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2020), 11, 11, 11, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2021) },
                    { 12, new DateOnly(2024, 9, 5), (short)21, new DateTime(2024, 9, 5, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2023), 12, 12, 12, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2024) },
                    { 13, new DateOnly(2024, 9, 6), (short)22, new DateTime(2024, 9, 6, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2026), 13, 13, 13, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2027) },
                    { 14, new DateOnly(2024, 9, 7), (short)23, new DateTime(2024, 9, 7, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2029), 14, 14, 14, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2030) },
                    { 15, new DateOnly(2024, 9, 8), (short)24, new DateTime(2024, 9, 8, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2035), 15, 15, 15, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2036) },
                    { 16, new DateOnly(2024, 9, 9), (short)25, new DateTime(2024, 9, 9, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2038), 16, 16, 16, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2039) },
                    { 17, new DateOnly(2024, 9, 10), (short)26, new DateTime(2024, 9, 10, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2041), 17, 17, 17, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2042) },
                    { 18, new DateOnly(2024, 9, 11), (short)27, new DateTime(2024, 9, 11, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2044), 18, 18, 18, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2045) },
                    { 19, new DateOnly(2024, 9, 12), (short)28, new DateTime(2024, 9, 12, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2047), 19, 19, 19, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2048) },
                    { 20, new DateOnly(2024, 9, 13), (short)29, new DateTime(2024, 9, 13, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2050), 20, 20, 20, new DateTime(2024, 9, 14, 0, 24, 49, 847, DateTimeKind.Local).AddTicks(2051) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyLists_MemberId",
                table: "ApplyLists",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CourseId",
                table: "Bookings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseImages_CourseId",
                table: "CourseImages",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseCategoryId",
                table: "CourseSubjects",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCoupons_CouponId",
                table: "MemberCoupons",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCoupons_MemberId",
                table: "MemberCoupons",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPreferences_MemberId",
                table: "MemberPreferences",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPreferences_SubjecId",
                table: "MemberPreferences",
                column: "SubjecId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_EducationId",
                table: "Members",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_NationId",
                table: "Members",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CourseId",
                table: "OrderDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberId",
                table: "Orders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLicenses_MemberId",
                table: "ProfessionalLicenses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseId",
                table: "Reviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentId",
                table: "Reviews",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartBookings_TempShoppingCartId",
                table: "ShoppingCartBookings",
                column: "TempShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CourseId",
                table: "ShoppingCarts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_MemberId",
                table: "ShoppingCarts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTimeSlots_CourseHourId",
                table: "TutorTimeSlots",
                column: "CourseHourId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTimeSlots_TutorID",
                table: "TutorTimeSlots",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_WatchLists_CourseId",
                table: "WatchLists",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_MemberId",
                table: "WorkExperiences",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyLists");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CourseImages");

            migrationBuilder.DropTable(
                name: "MemberCoupons");

            migrationBuilder.DropTable(
                name: "MemberPreferences");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProfessionalLicenses");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCartBookings");

            migrationBuilder.DropTable(
                name: "TutorTimeSlots");

            migrationBuilder.DropTable(
                name: "WatchLists");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "CourseSubjects");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "CourseHours");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Nations");
        }
    }
}
