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
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8784), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8782), true, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8784) },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8787), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8786), true, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8787) },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8790), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8789), false, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8790) },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8794), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8792), true, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8794) },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8796), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8796), false, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8797) },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8799), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8799), true, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8800) },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8803), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8803), false, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8804) },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8806), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8805), true, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8806) },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8809), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8808), false, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8809) },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8811), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8811), true, new DateTime(2024, 9, 24, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8812) },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8814), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8813), true, new DateTime(2024, 9, 25, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8814) },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8816), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8816), true, new DateTime(2024, 9, 26, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8817) },
                    { 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8819), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8818), false, new DateTime(2024, 9, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8819) },
                    { 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8822), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8821), true, new DateTime(2024, 9, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8822) },
                    { 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8826), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8825), true, new DateTime(2024, 9, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8826) },
                    { 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8828), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8827), true, new DateTime(2024, 9, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8829) },
                    { 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8831), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8830), true, new DateTime(2024, 10, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8831) },
                    { 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8833), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8832), true, new DateTime(2024, 10, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8834) },
                    { 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8836), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8835), true, new DateTime(2024, 10, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8836) },
                    { 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8838), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8837), true, new DateTime(2024, 10, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8839) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8436), null },
                    { 2, "程式設計", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8437), null },
                    { 3, "升學科目", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8438), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(60), "00:00", null },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(61), "01:00", null },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(63), "02:00", null },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(64), "03:00", null },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(65), "04:00", null },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(66), "05:00", null },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(67), "06:00", null },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(68), "07:00", null },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(123), "08:00", null },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(124), "09:00", null },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(125), "10:00", null },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(126), "11:00", null },
                    { 13, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(127), "12:00", null },
                    { 14, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(128), "13:00", null },
                    { 15, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(129), "14:00", null },
                    { 16, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(130), "15:00", null },
                    { 17, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(131), "16:00", null },
                    { 18, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(132), "17:00", null },
                    { 19, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(133), "18:00", null },
                    { 20, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(133), "19:00", null },
                    { 21, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(134), "20:00", null },
                    { 22, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(135), "21:00", null },
                    { 23, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(136), "22:00", null },
                    { 24, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(137), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7828), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7847), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7848), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7849), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7851), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7852), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7854), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7855), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7856), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7857), "Biology", "University of Toronto", 2016, 2012, null }
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
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8463), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8464), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8465), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8467), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8468), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8469), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8470), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8471), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8472), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8473), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8474), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8475), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8476), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8477), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8478), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8479), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8505), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8506), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8229), (short)1, "適合初學者的英文課程", 595m, true, "從零開始學英文", 1, "/image/thumb_nails/thumbnail_demo_tw_001.webp", "基礎英文", 1, 350m, null, "https://www.youtube.com/embed/1ZYbU82GVz4" },
                    { 2, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8232), (short)1, "基礎日語語法和詞彙", 680m, true, "日語學習的基礎", 2, "/image/thumb_nails/thumbnail_demo_jp_001.webp", "日語入門", 2, 400m, null, "https://www.youtube.com/embed/BWAK0J8Uhzk" },
                    { 3, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8235), (short)1, "全面學習中文語法", 875m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 500m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8238), (short)1, "提高德語口語能力", 935m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 550m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8241), (short)1, "提升法語閱讀能力", 510m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 300m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8244), (short)1, "提高西班牙語寫作能力", 1440m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 800m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8246), (short)1, "從頭開始學習HTML和CSS", 765m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 450m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8285), (short)1, "學習JavaScript語法和應用", 1050m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 600m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8288), (short)1, "深入學習C#編程", 1620m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 900m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8290), (short)1, "從零開始學習SQL", 595m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 350m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8294), (short)1, "從頭開始學習Python編程", 935m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 550m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8297), (short)1, "從零開始學習Java語言", 1080m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 600m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8299), (short)1, "提升數學基礎知識", 540m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 300m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8302), (short)1, "物理學基礎知識", 630m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 350m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8305), (short)1, "全面了解化學基礎知識", 680m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 400m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8308), (short)1, "歷史事件和背景的深入分析", 1050m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 600m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8310), (short)1, "全面了解地理學的基礎", 875m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 500m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8312), (short)1, "深入學習生物學的基本概念", 1350m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 750m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8316), (short)1, "深入練習英語會話和詞彙", 1135m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 650m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8319), (short)1, "提升日語會話和語法能力", 1225m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 700m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8321), (short)1, "深入學習中文語法和詞彙", 1480m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 850m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8323), (short)1, "德語會話和詞彙的深入練習", 990m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 550m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8326), (short)1, "法語閱讀和寫作的深入研究", 1365m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 780m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8328), (short)1, "西班牙語寫作和語法的深入練習", 1620m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 900m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8331), (short)1, "高級網頁設計和開發技術", 925m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 500m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8333), (short)1, "JavaScript編程的高級應用和技巧", 1530m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 850m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8337), (short)1, "深入掌握C#編程的高級技術", 1225m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 700m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8339), (short)1, "SQL資料庫管理和優化的高級技術", 1080m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 600m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8372), (short)1, "Python編程的高級應用和數據處理", 1620m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 900m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8374), (short)1, "Java編程的高級技術和應用", 1350m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 750m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8377), (short)1, "高等數學理論和應用", 890m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 500m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8379), (short)1, "物理學的高級理論和應用", 1350m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 750m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8382), (short)1, "化學的高級理論和應用", 900m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 500m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8384), (short)1, "歷史研究的高級技術和方法", 1050m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 600m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8388), (short)1, "地理學的高級理論和應用", 1080m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 600m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8391), (short)1, "生物學的高級理論和應用", 1620m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 900m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8393), (short)1, "專業英文寫作的高級技巧", 935m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 550m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8396), (short)1, "專業日語寫作的高級技巧", 720m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 400m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8398), (short)1, "專業中文寫作的高級技巧", 1260m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 700m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8400), (short)1, "專業德語寫作的高級技巧", 1170m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 650m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7891), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7910), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7911) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7914), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7916), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7916) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7919), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7922), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7922) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7925), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7928), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7929) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7931), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7933), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7933) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7962), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7964), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7965) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7967), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7969), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7970) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7972), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7974), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7974) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7977), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7980), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7981) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7983), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7985), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7985) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7988), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7990), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7990) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7993), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7994), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7995) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7997), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7999), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(7999) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8003), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8005), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8005) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8008), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8009), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8010) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8012), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8014), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8014) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8017), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8018), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8019) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8021), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8023), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8023) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8027), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8029), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8029) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8056), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8058), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8058) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8061), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8062), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8063) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8065), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8067), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8067) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8070), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8073), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8073) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8076), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8077), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8078) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8080), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8082), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8082) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8085), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8086), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8087) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8089), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8091), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8091) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8093), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8096), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8097) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8099), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8101), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8101) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8104), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8105), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8106) },
                    { 31, "henry_evans", 1, "1234567890", "031", new DateTime(1994, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8108), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8110), 1, "henry.evans@example.com", "Henry", (short)1, "https://randomuser.me/api/portraits/men/31.jpg", true, true, "Evans", 1, "English", "HenryE", "password31", "111222333", "English, Spanish", "Expert in English and Spanish", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8110) },
                    { 32, "chloe_scott", 2, "2345678901", "032", new DateTime(2000, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8112), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8114), 2, "chloe.scott@example.com", "Chloe", (short)2, "https://randomuser.me/api/portraits/women/32.jpg", true, false, "Scott", 2, "Japanese", "ChloeS", "password32", "444555666", "Japanese, English", "Japanese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8114) },
                    { 33, "jackson_mitchell", 1, "3456789012", "033", new DateTime(1995, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8118), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8120), 3, "jackson.mitchell@example.com", "Jackson", (short)1, "https://randomuser.me/api/portraits/men/33.jpg", true, true, "Mitchell", 3, "Korean", "JackM", "password33", "555666777", "Korean, English", "Korean language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8120) },
                    { 34, "amelia_martinez", 2, "4567890123", "034", new DateTime(1999, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8123), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8124), 4, "amelia.martinez@example.com", "Amelia", (short)2, "https://randomuser.me/api/portraits/women/34.jpg", true, false, "Martinez", 4, "German", "AmeliaM", "password34", "666777888", "German, English", "Expert in German language", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8125) },
                    { 35, "sebastian_morris", 1, "5678901234", "035", new DateTime(1998, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8141), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8142), 5, "sebastian.morris@example.com", "Sebastian", (short)1, "https://randomuser.me/api/portraits/men/35.jpg", true, true, "Morris", 5, "French", "SebM", "password35", "777888999", "French, English", "French language specialist", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8143) },
                    { 36, "grace_cooper", 2, "6789012345", "036", new DateTime(2001, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8145), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8147), 6, "grace.cooper@example.com", "Grace", (short)2, "https://randomuser.me/api/portraits/women/36.jpg", true, false, "Cooper", 6, "Spanish", "GraceC", "password36", "888999000", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8147) },
                    { 37, "aiden_perez", 1, "7890123456", "037", new DateTime(1993, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8150), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8151), 7, "aiden.perez@example.com", "Aiden", (short)1, "https://randomuser.me/api/portraits/men/37.jpg", true, true, "Perez", 7, "Chinese", "AidenP", "password37", "999000111", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8152) },
                    { 38, "avery_nelson", 2, "8901234567", "038", new DateTime(2002, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8156), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8158), 8, "avery.nelson@example.com", "Avery", (short)2, "https://randomuser.me/api/portraits/women/38.jpg", true, false, "Nelson", 8, "Russian", "AveryN", "password38", "000111222", "Russian, English", "Russian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8158) },
                    { 39, "oliver_king", 1, "0123456789", "039", new DateTime(1990, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8160), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8162), 9, "oliver.king@example.com", "Oliver", (short)1, "https://randomuser.me/api/portraits/men/39.jpg", true, true, "King", 9, "Italian", "OliverK", "password39", "111222333", "Italian, English", "Italian language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8162) },
                    { 40, "ella_wood", 2, "2345678901", "040", new DateTime(1996, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8165), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8166), 10, "ella.wood@example.com", "Ella", (short)2, "https://Infrastructure.Data.TalkingTopiaContextrandomuser.me/api/portraits/women/40.jpg", true, false, "Wood", 10, "Portuguese", "EllaW", "password40", "222333444", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8167) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8933), true, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8934), 1, null, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8935) },
                    { 2, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8936), false, null, 2, "Incomplete application", new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8937) },
                    { 3, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8938), true, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8939), 3, null, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8939) },
                    { 4, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8941), false, null, 4, "Failed verification", new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8941) },
                    { 5, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8943), true, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8943), 5, null, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8944) },
                    { 6, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8969), true, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8970), 6, null, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8971) },
                    { 7, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8972), false, null, 7, "Incorrect details", new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8973) },
                    { 8, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8974), true, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8975), 8, null, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8975) },
                    { 9, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8976), true, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8977), 9, null, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8978) },
                    { 10, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8979), false, null, 10, "Missing documents", new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8980) },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8981), true, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8981), 11, null, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8982) },
                    { 12, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8984), false, null, 12, "Not eligible", new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8984) },
                    { 13, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8986), true, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8986), 13, null, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8988) },
                    { 14, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8990), true, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8990), 14, null, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8991) },
                    { 15, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8992), false, null, 15, "Failed interview", new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8993) },
                    { 16, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8994), true, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8995), 16, null, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8995) },
                    { 17, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8996), true, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8997), 17, null, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8998) },
                    { 18, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8999), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8999) },
                    { 19, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9001), true, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9001), 19, null, new DateTime(2024, 9, 24, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9002) },
                    { 20, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9003), false, null, 20, "Unverified information", new DateTime(2024, 9, 25, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9004) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9031), (short)14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9032), 3, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9032) },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9035), (short)15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9035), 4, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9036) },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9037), (short)16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9037), 5, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9038) },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9039), (short)17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9040), 6, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9040) },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9041), (short)18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9041), 7, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9042) },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9043), (short)19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9043), 8, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9044) },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9045), (short)20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9045), 9, 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9046) },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9047), (short)12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9047), 10, 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9048) },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9049), (short)13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9049), 11, 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9050) },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9051), (short)14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9051), 12, 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9052) },
                    { 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9053), (short)15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9053), 13, 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9054) },
                    { 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9055), (short)16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9055), 14, 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9056) },
                    { 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9057), (short)17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9059), 15, 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9059) },
                    { 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9060), (short)18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9061), 16, 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9061) },
                    { 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9062), (short)19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9063), 17, 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9063) },
                    { 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9064), (short)20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9065), 18, 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9065) },
                    { 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9066), (short)12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9067), 19, 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9067) },
                    { 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9068), (short)13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9069), 20, 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9069) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8533), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8535), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8536), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8537), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8538), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8539), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8540), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8543), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8544), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8545), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8546), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8546), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8868), 1, 1, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8869) },
                    { 2, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8871), 2, 2, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8872) },
                    { 3, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8873), 3, 3, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8874) },
                    { 4, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8875), 4, 4, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8876) },
                    { 5, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8877), 5, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8878) },
                    { 6, new DateTime(2024, 3, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8879), 6, 6, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8879) },
                    { 7, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8881), 7, 7, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8881) },
                    { 8, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8882), 8, 8, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8883) },
                    { 9, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8884), 9, 9, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8885) },
                    { 10, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8886), 10, 10, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8887) },
                    { 11, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8888), 11, 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8889) },
                    { 12, new DateTime(2024, 3, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8890), 12, 12, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8890) },
                    { 13, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8891), 13, 13, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8892) },
                    { 14, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8893), 14, 14, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8894) },
                    { 15, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8896), 15, 15, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8897) },
                    { 16, new DateTime(2024, 7, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8898), 16, 16, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8899) },
                    { 17, new DateTime(2024, 8, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8900), 17, 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8901) },
                    { 18, new DateTime(2024, 3, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8902), 18, 18, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8902) },
                    { 19, new DateTime(2024, 4, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8903), 19, 1, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8904) },
                    { 20, new DateTime(2024, 5, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8905), 20, 2, new DateTime(2024, 6, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8906) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8581), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8572), new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8582), "12345678" },
                    { 2, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8585), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8583), new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8585), "22345678" },
                    { 3, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8588), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8587), new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8589), "32345678" },
                    { 4, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8593), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8593), "42345678" },
                    { 5, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8596), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8595), new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8597), "52345678" },
                    { 6, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8599), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8598), new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8600), "62345678" },
                    { 7, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8604), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8603), new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8605), "72345678" },
                    { 8, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8607), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8606), new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8608), "82345678" },
                    { 9, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8612), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8609), new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8613), "92345678" },
                    { 10, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8616), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8614), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8616), "01234567" },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8619), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8617), new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8619), "12345679" },
                    { 12, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8622), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8620), new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8622), "22345679" },
                    { 13, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8625), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8624), new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8625), "32345679" },
                    { 14, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8628), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8627), new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8630), "42345679" },
                    { 15, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8633), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8632), new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8633), "52345679" },
                    { 16, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8636), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8635), new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8636), "62345679" },
                    { 17, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8639), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8638), new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8639), "72345679" },
                    { 18, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8642), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8641), new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8643), "82345679" },
                    { 19, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8647), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8644), new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8647), "92345679" },
                    { 20, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8650), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8648), new DateTime(2024, 9, 24, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(8650), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9099), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9100) },
                    { 2, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9102), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9102) },
                    { 3, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9103), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9104) },
                    { 4, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9105), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9106) },
                    { 5, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9107), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9108) },
                    { 6, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9109), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9109) },
                    { 7, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9111), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9112) },
                    { 8, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9113), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9114) },
                    { 9, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9115), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9115) },
                    { 10, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9117), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9117) },
                    { 11, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9118), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9119) },
                    { 12, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9120), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9120) },
                    { 13, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9122), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9122) },
                    { 14, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9123), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9124) },
                    { 15, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9125), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9126) },
                    { 16, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9127), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9127) },
                    { 17, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9128), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9129) },
                    { 18, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9131), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9132) },
                    { 19, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9133), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9134) },
                    { 20, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9135), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9135) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9157), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9158) },
                    { 2, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9159), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9160) },
                    { 3, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9161), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9161) },
                    { 4, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9163), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9163) },
                    { 5, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9164), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9165) },
                    { 6, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9166), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9167) },
                    { 7, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9168), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9168) },
                    { 8, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9170), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9172) },
                    { 9, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9173), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9173) },
                    { 10, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9175), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9175) },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9176), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9177) },
                    { 12, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9178), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9179) },
                    { 13, new DateTime(2024, 9, 16, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9209), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9210) },
                    { 14, new DateTime(2024, 9, 17, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9211), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9211) },
                    { 15, new DateTime(2024, 9, 18, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9213), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9213) },
                    { 16, new DateTime(2024, 9, 19, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9214), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9215) },
                    { 17, new DateTime(2024, 9, 20, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9216), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9217) },
                    { 18, new DateTime(2024, 9, 21, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9218), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9218) },
                    { 19, new DateTime(2024, 9, 22, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9221), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9222) },
                    { 20, new DateTime(2024, 9, 23, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9223), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9223) },
                    { 21, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9224), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9225) },
                    { 22, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9226), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9227) },
                    { 23, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9228), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9229) },
                    { 24, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9230), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9230) },
                    { 25, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9231), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9232) },
                    { 26, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9233), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9234) },
                    { 27, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9235), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9235) },
                    { 28, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9237), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9237) },
                    { 29, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9238), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9240) },
                    { 30, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9242), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9242) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9274), new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9275), new DateTime(2024, 8, 25, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9273), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 26, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9274), 100.00m },
                    { 2, new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9280), new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9281), new DateTime(2024, 8, 26, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9279), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9279), 200.00m },
                    { 3, new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9284), new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9285), new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9283), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9283), 300.00m },
                    { 4, new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9290), new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9290), new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9287), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9287), 400.00m },
                    { 5, new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9293), new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9294), new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9292), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9293), 500.00m },
                    { 6, new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9297), new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9298), new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9296), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9297), 600.00m },
                    { 7, new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9302), new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9303), new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9300), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9301), 700.00m },
                    { 8, new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9306), new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9307), new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9305), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9305), 800.00m },
                    { 9, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9311), new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9312), new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9310), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9311), 900.00m },
                    { 10, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9315), new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9316), new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9314), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9315), 1000.00m },
                    { 11, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9319), new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9319), new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9318), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9318), 1100.00m },
                    { 12, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9323), new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9323), new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9321), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9322), 1200.00m },
                    { 13, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9328), new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9328), new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9325), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9327), 1300.00m },
                    { 14, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9331), new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9332), new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9330), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9331), 1400.00m },
                    { 15, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9334), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9334), 1500.00m },
                    { 16, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9338), new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9339), new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9337), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9338), 1600.00m },
                    { 17, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9342), new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9342), new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9341), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9341), 1700.00m },
                    { 18, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9347), new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9347), new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9345), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9346), 1800.00m },
                    { 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9350), new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9351), new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9349), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9349), 1900.00m },
                    { 20, new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9353), new DateTime(2024, 9, 15, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9354), new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9352), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9353), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9506), 8, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9507), 1 },
                    { 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9508), 9, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9509), 1 },
                    { 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9510), 10, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9510), 1 },
                    { 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9512), 11, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9512), 1 },
                    { 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9513), 12, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9514), 1 },
                    { 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9515), 13, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9515), 1 },
                    { 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9517), 14, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9517), 1 },
                    { 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9518), 15, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9519), 1 },
                    { 9, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9520), 16, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9521), 1 },
                    { 10, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9522), 17, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9522), 1 },
                    { 11, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9523), 18, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9524), 1 },
                    { 12, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9525), 19, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9525), 1 },
                    { 13, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9528), 20, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9529), 1 },
                    { 14, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9530), 8, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9530), 2 },
                    { 15, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9531), 9, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9532), 2 },
                    { 16, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9533), 10, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9533), 2 },
                    { 17, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9535), 11, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9535), 2 },
                    { 18, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9536), 12, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9537), 2 },
                    { 19, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9538), 13, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9538), 2 },
                    { 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9539), 14, 1, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9540), 2 },
                    { 21, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9541), 8, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9541), 3 },
                    { 22, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9542), 9, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9543), 3 },
                    { 23, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9544), 10, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9544), 3 },
                    { 24, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9545), 11, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9546), 3 },
                    { 25, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9550), 12, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9550), 4 },
                    { 26, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9551), 13, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9552), 4 },
                    { 27, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9553), 14, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9553), 4 },
                    { 28, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9554), 15, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9555), 5 },
                    { 29, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9556), 16, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9556), 5 },
                    { 30, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9557), 17, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9558), 5 },
                    { 31, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9559), 18, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9559), 6 },
                    { 32, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9560), 19, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9561), 6 },
                    { 33, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9562), 20, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9562), 0 },
                    { 34, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9563), 8, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9564), 1 },
                    { 35, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9565), 9, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9565), 1 },
                    { 36, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9566), 10, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9567), 1 },
                    { 37, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9568), 11, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9568), 2 },
                    { 38, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9571), 12, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9572), 2 },
                    { 39, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9574), 13, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9574), 2 },
                    { 40, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9577), 14, 2, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9577), 2 },
                    { 41, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9580), 8, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9580), 2 },
                    { 42, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9581), 9, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9582), 2 },
                    { 43, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9583), 10, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9583), 2 },
                    { 44, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9584), 11, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9586), 2 },
                    { 45, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9587), 12, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9587), 3 },
                    { 46, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9588), 13, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9588), 3 },
                    { 47, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9589), 14, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9590), 3 },
                    { 48, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9591), 15, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9591), 4 },
                    { 49, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9592), 16, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9593), 4 },
                    { 50, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9595), 17, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9596), 4 },
                    { 51, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9597), 18, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9597), 5 },
                    { 52, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9598), 19, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9599), 5 },
                    { 53, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9600), 20, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9600), 6 },
                    { 54, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9601), 8, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9602), 0 },
                    { 55, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9603), 9, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9603), 0 },
                    { 56, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9604), 10, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9604), 1 },
                    { 57, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9605), 11, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9606), 1 },
                    { 58, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9607), 12, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9607), 1 },
                    { 59, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9608), 13, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9609), 1 },
                    { 60, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9610), 14, 3, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9610), 2 },
                    { 61, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9612), 8, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9612), 1 },
                    { 62, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9614), 9, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9615), 1 },
                    { 63, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9616), 10, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9616), 1 },
                    { 64, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9617), 11, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9618), 1 },
                    { 65, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9619), 12, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9619), 1 },
                    { 66, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9620), 13, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9621), 1 },
                    { 67, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9622), 8, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9622), 2 },
                    { 68, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9623), 9, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9623), 2 },
                    { 69, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9625), 10, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9625), 2 },
                    { 70, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9626), 11, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9626), 2 },
                    { 71, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9628), 12, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9628), 2 },
                    { 72, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9629), 13, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9629), 2 },
                    { 73, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9631), 8, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9631), 3 },
                    { 74, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9632), 9, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9632), 3 },
                    { 75, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9633), 10, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9634), 3 },
                    { 76, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9653), 11, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9654), 3 },
                    { 77, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9655), 12, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9655), 3 },
                    { 78, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9656), 13, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9657), 3 },
                    { 79, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9658), 8, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9658), 4 },
                    { 80, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9659), 9, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9660), 4 },
                    { 81, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9661), 10, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9661), 4 },
                    { 82, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9662), 11, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9663), 4 },
                    { 83, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9664), 12, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9664), 4 },
                    { 84, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9665), 13, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9666), 4 },
                    { 85, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9667), 8, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9667), 5 },
                    { 86, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9668), 9, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9669), 5 },
                    { 87, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9672), 10, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9672), 5 },
                    { 88, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9673), 11, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9674), 5 },
                    { 89, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9675), 12, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9675), 5 },
                    { 90, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9676), 13, 4, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9676), 5 },
                    { 91, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9678), 8, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9678), 1 },
                    { 92, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9679), 9, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9680), 1 },
                    { 93, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9681), 10, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9681), 1 },
                    { 94, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9682), 11, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9682), 1 },
                    { 95, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9684), 12, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9684), 2 },
                    { 96, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9685), 13, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9685), 2 },
                    { 97, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9686), 14, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9687), 2 },
                    { 98, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9688), 8, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9688), 3 },
                    { 99, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9691), 9, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9691), 3 },
                    { 100, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9693), 10, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9693), 3 },
                    { 101, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9694), 11, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9694), 3 },
                    { 102, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9696), 12, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9696), 3 },
                    { 103, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9697), 8, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9698), 4 },
                    { 104, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9699), 9, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9700), 4 },
                    { 105, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9701), 10, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9701), 4 },
                    { 106, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9702), 11, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9703), 4 },
                    { 107, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9704), 12, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9704), 4 },
                    { 108, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9705), 8, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9706), 5 },
                    { 109, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9707), 9, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9707), 5 },
                    { 110, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9708), 10, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9708), 5 },
                    { 111, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9709), 11, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9711), 5 },
                    { 112, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9712), 12, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9713), 6 },
                    { 113, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9714), 13, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9714), 6 },
                    { 114, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9715), 14, 5, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9716), 6 },
                    { 115, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9717), 10, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9717), 1 },
                    { 116, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9718), 11, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9719), 1 },
                    { 117, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9720), 12, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9720), 1 },
                    { 118, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9721), 13, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9722), 1 },
                    { 119, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9723), 15, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9723), 2 },
                    { 120, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9724), 16, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9725), 2 },
                    { 121, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9726), 17, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9726), 2 },
                    { 122, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9727), 10, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9728), 3 },
                    { 123, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9729), 11, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9729), 3 },
                    { 124, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9732), 12, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9732), 3 },
                    { 125, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9733), 13, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9734), 3 },
                    { 126, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9735), 9, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9735), 4 },
                    { 127, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9736), 10, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9736), 4 },
                    { 128, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9738), 11, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9738), 4 },
                    { 129, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9739), 14, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9739), 5 },
                    { 130, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9741), 15, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9741), 5 },
                    { 131, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9742), 16, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9742), 5 },
                    { 132, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9743), 18, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9744), 6 },
                    { 133, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9745), 19, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9745), 6 },
                    { 134, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9746), 20, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9747), 6 },
                    { 135, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9748), 21, 6, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9748), 6 },
                    { 136, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9751), 9, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9751), 0 },
                    { 137, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9752), 10, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9753), 0 },
                    { 138, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9754), 11, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9754), 1 },
                    { 139, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9755), 12, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9756), 1 },
                    { 140, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9757), 13, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9757), 1 },
                    { 141, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9758), 14, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9758), 2 },
                    { 142, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9759), 15, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9760), 2 },
                    { 143, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9761), 16, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9761), 2 },
                    { 144, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9762), 18, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9763), 3 },
                    { 145, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9764), 19, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9764), 3 },
                    { 146, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9765), 20, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9766), 3 },
                    { 147, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9767), 21, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9767), 3 },
                    { 148, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9770), 8, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9770), 4 },
                    { 149, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9771), 9, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9772), 4 },
                    { 150, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9773), 10, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9773), 4 },
                    { 151, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9774), 12, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9775), 5 },
                    { 152, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9776), 13, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9776), 5 },
                    { 153, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9777), 14, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9778), 5 },
                    { 154, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9779), 16, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9779), 6 },
                    { 155, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9780), 17, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9781), 6 },
                    { 156, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9782), 18, 7, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9782), 6 },
                    { 157, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9783), 9, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9784), 0 },
                    { 158, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9785), 10, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9785), 0 },
                    { 159, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9786), 11, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9787), 0 },
                    { 160, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9788), 12, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9788), 0 },
                    { 161, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9791), 14, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9791), 1 },
                    { 162, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9792), 15, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9792), 1 },
                    { 163, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9793), 16, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9794), 1 },
                    { 164, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9795), 17, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9795), 1 },
                    { 165, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9796), 18, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9797), 2 },
                    { 166, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9798), 19, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9798), 2 },
                    { 167, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9799), 20, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9800), 2 },
                    { 168, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9801), 21, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9802), 2 },
                    { 169, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9803), 8, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9803), 3 },
                    { 170, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9804), 9, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9805), 3 },
                    { 171, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9806), 10, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9806), 3 },
                    { 172, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9807), 11, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9808), 3 },
                    { 173, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9810), 13, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9811), 4 },
                    { 174, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9812), 14, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9812), 4 },
                    { 175, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9813), 15, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9814), 4 },
                    { 176, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9815), 17, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9815), 5 },
                    { 177, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9816), 18, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9817), 5 },
                    { 178, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9818), 19, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9818), 5 },
                    { 179, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9819), 20, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9820), 6 },
                    { 180, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9821), 21, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9821), 6 },
                    { 181, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9822), 22, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9823), 6 },
                    { 182, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9824), 23, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9824), 6 },
                    { 183, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9825), 12, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9826), 0 },
                    { 184, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9827), 13, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9827), 0 },
                    { 185, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9829), 14, 8, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9829), 0 }
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
                    { 1, new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9972), 1, new DateTime(2022, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9973), new DateTime(2022, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9971), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9970) },
                    { 2, new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9976), 2, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9976), new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9975), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9974) },
                    { 3, new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9979), 3, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9979), new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9978), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9978) },
                    { 4, new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9982), 4, new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9983), new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9982), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9981) },
                    { 5, new DateTime(2018, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9985), 5, new DateTime(2022, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9986), new DateTime(2022, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9985), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9984) },
                    { 6, new DateTime(2017, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9988), 6, new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9989), new DateTime(2021, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9988), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9987) },
                    { 7, new DateTime(2016, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9993), 7, new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9993), new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9991), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9990) },
                    { 8, new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9996), 8, new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9997), new DateTime(2023, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9995), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9995) },
                    { 9, new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9999), 9, new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local), new DateTime(2022, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9999), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9998) },
                    { 10, new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(2), 10, new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(3), new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(2), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(1) },
                    { 11, new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(5), 11, new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(6), new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(5), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(4) },
                    { 12, new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(8), 12, new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(9), new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(7), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(7) },
                    { 13, new DateTime(2017, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(11), 13, new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(11), new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(10), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(10) },
                    { 14, new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(14), 14, new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(16), new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(13), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(13) },
                    { 15, new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(18), 15, new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(19), new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(18), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(17) },
                    { 16, new DateTime(2020, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(21), 16, new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(22), new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(21), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(20) },
                    { 17, new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(24), 17, new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(25), new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(24), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(23) },
                    { 18, new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(27), 18, new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(27), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(26) },
                    { 19, new DateTime(2020, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(30), 19, new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(30), new DateTime(2023, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(29), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(29) },
                    { 20, new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(33), 20, new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(33), new DateTime(2022, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(32), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 14, 15, 28, 22, 874, DateTimeKind.Local).AddTicks(32) }
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
                    { 1, new DateOnly(2024, 8, 25), (short)10, new DateTime(2024, 8, 25, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9393), 1, 1, 1, new DateTime(2024, 8, 26, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9394) },
                    { 2, new DateOnly(2024, 8, 26), (short)11, new DateTime(2024, 8, 26, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9396), 2, 2, 2, new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9397) },
                    { 3, new DateOnly(2024, 8, 27), (short)12, new DateTime(2024, 8, 27, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9399), 3, 3, 3, new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9400) },
                    { 4, new DateOnly(2024, 8, 28), (short)13, new DateTime(2024, 8, 28, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9402), 4, 4, 4, new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9403) },
                    { 5, new DateOnly(2024, 8, 29), (short)14, new DateTime(2024, 8, 29, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9405), 5, 5, 5, new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9406) },
                    { 6, new DateOnly(2024, 8, 30), (short)15, new DateTime(2024, 8, 30, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9408), 6, 6, 6, new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9409) },
                    { 7, new DateOnly(2024, 8, 31), (short)16, new DateTime(2024, 8, 31, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9411), 7, 7, 7, new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9412) },
                    { 8, new DateOnly(2024, 9, 1), (short)17, new DateTime(2024, 9, 1, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9414), 8, 8, 8, new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9415) },
                    { 9, new DateOnly(2024, 9, 2), (short)18, new DateTime(2024, 9, 2, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9418), 9, 9, 9, new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9419) },
                    { 10, new DateOnly(2024, 9, 3), (short)19, new DateTime(2024, 9, 3, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9421), 10, 10, 10, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9422) },
                    { 11, new DateOnly(2024, 9, 4), (short)20, new DateTime(2024, 9, 4, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9424), 11, 11, 11, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9425) },
                    { 12, new DateOnly(2024, 9, 5), (short)21, new DateTime(2024, 9, 5, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9427), 12, 12, 12, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9428) },
                    { 13, new DateOnly(2024, 9, 6), (short)22, new DateTime(2024, 9, 6, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9430), 13, 13, 13, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9430) },
                    { 14, new DateOnly(2024, 9, 7), (short)23, new DateTime(2024, 9, 7, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9433), 14, 14, 14, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9433) },
                    { 15, new DateOnly(2024, 9, 8), (short)24, new DateTime(2024, 9, 8, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9464), 15, 15, 15, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9465) },
                    { 16, new DateOnly(2024, 9, 9), (short)25, new DateTime(2024, 9, 9, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9467), 16, 16, 16, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9468) },
                    { 17, new DateOnly(2024, 9, 10), (short)26, new DateTime(2024, 9, 10, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9470), 17, 17, 17, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9471) },
                    { 18, new DateOnly(2024, 9, 11), (short)27, new DateTime(2024, 9, 11, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9473), 18, 18, 18, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9474) },
                    { 19, new DateOnly(2024, 9, 12), (short)28, new DateTime(2024, 9, 12, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9476), 19, 19, 19, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9477) },
                    { 20, new DateOnly(2024, 9, 13), (short)29, new DateTime(2024, 9, 13, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9479), 20, 20, 20, new DateTime(2024, 9, 14, 15, 28, 22, 873, DateTimeKind.Local).AddTicks(9480) }
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
