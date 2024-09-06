using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
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
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1213), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1207), true, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1214) },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1220), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1218), true, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1221) },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1226), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1224), false, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1227) },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1235), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1230), true, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1236) },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1240), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1239), false, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1242) },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1246), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1245), true, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1247) },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1252), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1251), false, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1253) },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1262), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1260), true, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1263) },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1268), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1266), false, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1268) },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1273), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1272), true, new DateTime(2024, 9, 15, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1274) },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1278), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1277), true, new DateTime(2024, 9, 16, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1279) },
                    { 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1284), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1282), true, new DateTime(2024, 9, 17, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1285) },
                    { 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1289), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1288), false, new DateTime(2024, 9, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1290) },
                    { 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1295), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1294), true, new DateTime(2024, 9, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1296) },
                    { 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1301), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1299), true, new DateTime(2024, 9, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1302) },
                    { 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1310), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1308), true, new DateTime(2024, 9, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1311) },
                    { 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1315), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1314), true, new DateTime(2024, 9, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1316) },
                    { 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1320), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1319), true, new DateTime(2024, 9, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1321) },
                    { 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1326), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1324), true, new DateTime(2024, 9, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1326) },
                    { 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1331), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1330), true, new DateTime(2024, 9, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1332) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(533), null },
                    { 2, "程式設計", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(536), null },
                    { 3, "升學科目", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(538), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3510), "00:00", null },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3512), "01:00", null },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3515), "02:00", null },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3517), "03:00", null },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3519), "04:00", null },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3521), "05:00", null },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3523), "06:00", null },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3525), "07:00", null },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3527), "08:00", null },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3529), "09:00", null },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3531), "10:00", null },
                    { 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3533), "11:00", null },
                    { 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3538), "12:00", null },
                    { 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3540), "13:00", null },
                    { 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3542), "14:00", null },
                    { 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3544), "15:00", null },
                    { 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3546), "16:00", null },
                    { 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3548), "17:00", null },
                    { 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3550), "18:00", null },
                    { 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3551), "19:00", null },
                    { 21, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3553), "20:00", null },
                    { 22, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3555), "21:00", null },
                    { 23, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3557), "22:00", null },
                    { 24, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3559), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9402), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9433), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9436), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9439), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9441), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9444), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9447), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9450), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9453), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9455), "Biology", "University of Toronto", 2016, 2012, null }
                });

            migrationBuilder.InsertData(
                table: "Nations",
                columns: new[] { "NationId", "FlagImage", "NationName" },
                values: new object[,]
                {
                    { 1, "https://flagcdn.com/w320/tw.png", "Taiwan" },
                    { 2, "https://flagcdn.com/w320/jp.png", "Japan" },
                    { 3, "https://flagcdn.com/w320/kr.png", "South Korea" },
                    { 4, "https://flagcdn.com/w320/us.png", "United States" },
                    { 5, "https://flagcdn.com/w320/de.png", "Germany" },
                    { 6, "https://flagcdn.com/w320/fr.png", "France" },
                    { 7, "https://flagcdn.com/w320/es.png", "Spain" },
                    { 8, "https://flagcdn.com/w320/gb.png", "United Kingdom" },
                    { 9, "https://flagcdn.com/w320/ca.png", "Canada" },
                    { 10, "https://flagcdn.com/w320/in.png", "India" }
                });

            migrationBuilder.InsertData(
                table: "CourseSubjects",
                columns: new[] { "SubjectId", "CDate", "CourseCategoryId", "SubjectName", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(574), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(577), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(580), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(583), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(585), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(587), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(590), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(592), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(594), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(597), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(599), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(601), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(656), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(658), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(660), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(662), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(664), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(666), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(99), (short)1, "適合初學者的英文課程", 90m, true, "從零開始學英文", 1, "https://example.com/courses/english.jpg", "基礎英文", 1, 50m, null, "https://example.com/courses/english_intro.mp4" },
                    { 2, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(105), (short)1, "基礎日語語法和詞彙", 100m, true, "日語學習的基礎", 2, "https://example.com/courses/japanese.jpg", "日語入門", 2, 60m, null, "https://example.com/courses/japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(111), (short)1, "全面學習中文語法", 120m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 70m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(117), (short)1, "提高德語口語能力", 110m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 65m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(122), (short)1, "提升法語閱讀能力", 95m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 55m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(128), (short)1, "提高西班牙語寫作能力", 100m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 60m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(187), (short)1, "從頭開始學習HTML和CSS", 125m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 75m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(200), (short)1, "學習JavaScript語法和應用", 140m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 85m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(206), (short)1, "深入學習C#編程", 150m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 90m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(211), (short)1, "從零開始學習SQL", 130m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 80m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(216), (short)1, "從頭開始學習Python編程", 140m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 85m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(222), (short)1, "從零開始學習Java語言", 150m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 90m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(227), (short)1, "提升數學基礎知識", 100m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 60m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(235), (short)1, "物理學基礎知識", 110m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 65m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(240), (short)1, "全面了解化學基礎知識", 120m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 70m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(248), (short)1, "歷史事件和背景的深入分析", 125m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 75m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(253), (short)1, "全面了解地理學的基礎", 110m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 65m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(259), (short)1, "深入學習生物學的基本概念", 120m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 70m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(264), (short)1, "深入練習英語會話和詞彙", 180m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 100m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(272), (short)1, "提升日語會話和語法能力", 200m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 110m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(278), (short)1, "深入學習中文語法和詞彙", 220m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 120m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(287), (short)1, "德語會話和詞彙的深入練習", 240m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 130m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(297), (short)1, "法語閱讀和寫作的深入研究", 230m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 125m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(303), (short)1, "西班牙語寫作和語法的深入練習", 250m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 135m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(308), (short)1, "高級網頁設計和開發技術", 270m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 150m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(314), (short)1, "JavaScript編程的高級應用和技巧", 280m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 160m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(319), (short)1, "深入掌握C#編程的高級技術", 300m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 170m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(375), (short)1, "SQL資料庫管理和優化的高級技術", 275m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 155m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(384), (short)1, "Python編程的高級應用和數據處理", 290m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 165m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(390), (short)1, "Java編程的高級技術和應用", 310m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 175m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(396), (short)1, "高等數學理論和應用", 250m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 140m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(401), (short)1, "物理學的高級理論和應用", 255m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 145m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(407), (short)1, "化學的高級理論和應用", 260m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 150m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(412), (short)1, "歷史研究的高級技術和方法", 275m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 160m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(418), (short)1, "地理學的高級理論和應用", 265m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 150m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(423), (short)1, "生物學的高級理論和應用", 275m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 160m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(431), (short)1, "專業英文寫作的高級技巧", 320m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 180m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(436), (short)1, "專業日語寫作的高級技巧", 340m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 190m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(442), (short)1, "專業中文寫作的高級技巧", 360m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 200m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(447), (short)1, "專業德語寫作的高級技巧", 380m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 210m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9530), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9566), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9567) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9575), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9582), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9583) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9590), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9595), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9597) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9603), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9607), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9608) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9614), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9618), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9619) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9628), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9632), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9633) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9639), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9642), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9643) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9707), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9711), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9712) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9717), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9721), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9722) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9728), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9731), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9736) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9742), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9745), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9746) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9752), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9756), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9757) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9763), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9766), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9767) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9773), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9776), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9777) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9783), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9789), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9790) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9796), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9799), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9800) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9805), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9808), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9809) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9815), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9818), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9819) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9824), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9828), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9829) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9837), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9841), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9842) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9847), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9850), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9851) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9856), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9860), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9861) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9918), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9922), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9922) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9928), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9931), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9932) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9941), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9944), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9945) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9950), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9954), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9955) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9960), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9963), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9964) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9969), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9973), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9974) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9979), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9983), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9984) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9993), new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9996), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 10, 32, 50, 126, DateTimeKind.Local).AddTicks(9997) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1644), true, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1648), 1, null, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1650) },
                    { 2, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1657), false, null, 2, "Incomplete application", new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1658) },
                    { 3, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1661), true, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1663), 3, null, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1664) },
                    { 4, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1667), false, null, 4, "Failed verification", new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1668) },
                    { 5, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1671), true, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1672), 5, null, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1674) },
                    { 6, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1677), true, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1678), 6, null, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1683) },
                    { 7, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1686), false, null, 7, "Incorrect details", new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1687) },
                    { 8, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1690), true, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1691), 8, null, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1693) },
                    { 9, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1695), true, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1697), 9, null, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1698) },
                    { 10, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1703), false, null, 10, "Missing documents", new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1704) },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1707), true, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1708), 11, null, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1709) },
                    { 12, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1715), false, null, 12, "Not eligible", new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1717) },
                    { 13, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1722), true, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1723), 13, null, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1727) },
                    { 14, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1733), true, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1734), 14, null, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1735) },
                    { 15, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1738), false, null, 15, "Failed interview", new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1739) },
                    { 16, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1742), true, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1743), 16, null, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1744) },
                    { 17, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1747), true, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1748), 17, null, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1749) },
                    { 18, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1752), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1753) },
                    { 19, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1756), true, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1757), 19, null, new DateTime(2024, 9, 15, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1759) },
                    { 20, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1762), false, null, 20, "Unverified information", new DateTime(2024, 9, 16, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1763) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1811), (short)900, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1814), 1, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1815) },
                    { 2, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1818), (short)1100, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1819), 2, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1821) },
                    { 3, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1823), (short)1400, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1829), 3, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1830) },
                    { 4, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1832), (short)1500, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1834), 4, 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1835) },
                    { 5, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1837), (short)1600, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1839), 5, 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1840) },
                    { 6, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1842), (short)1000, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1844), 6, 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1845) },
                    { 7, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1847), (short)900, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1849), 7, 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1850) },
                    { 8, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1852), (short)1100, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1854), 8, 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1855) },
                    { 9, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1857), (short)1400, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1859), 9, 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1860) },
                    { 10, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1862), (short)1500, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1864), 10, 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1865) },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1867), (short)1600, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1869), 11, 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1870) },
                    { 12, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1872), (short)1000, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1874), 12, 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1875) },
                    { 13, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1881), (short)900, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1882), 13, 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1883) },
                    { 14, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1886), (short)1100, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1887), 14, 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1888) },
                    { 15, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1890), (short)1400, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1892), 15, 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1893) },
                    { 16, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1895), (short)1500, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1897), 16, 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1898) },
                    { 17, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1900), (short)1600, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1901), 17, 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1903) },
                    { 18, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1905), (short)1000, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1906), 18, 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1907) },
                    { 19, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1909), (short)900, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1911), 19, 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1912) },
                    { 20, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1914), (short)1100, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1916), 20, 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1917) },
                    { 21, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1919), (short)1200, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1921), 21, 21, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1922) },
                    { 22, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1924), (short)1300, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1925), 22, 22, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1926) },
                    { 23, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1932), (short)900, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1933), 23, 23, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1934) },
                    { 24, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1939), (short)1100, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1941), 24, 24, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1942) },
                    { 25, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1944), (short)1400, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1946), 25, 25, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1947) },
                    { 26, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1949), (short)1500, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1950), 26, 26, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1952) },
                    { 27, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1954), (short)1600, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1955), 27, 27, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1957) },
                    { 28, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1959), (short)1000, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1960), 28, 28, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1961) },
                    { 29, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1963), (short)1200, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1965), 29, 29, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1966) },
                    { 30, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1968), (short)1400, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1970), 30, 30, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1971) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(719), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(722), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(724), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(726), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(728), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(730), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(732), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(734), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(737), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(739), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(741), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(743), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1390), 1, 1, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1392) },
                    { 2, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1400), 2, 2, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1401) },
                    { 3, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1405), 3, 3, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1406) },
                    { 4, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1409), 4, 4, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1410) },
                    { 5, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1413), 5, 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1414) },
                    { 6, new DateTime(2024, 3, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1420), 6, 6, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1423) },
                    { 7, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1430), 7, 7, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1434) },
                    { 8, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1436), 8, 8, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1438) },
                    { 9, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1440), 9, 9, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1442) },
                    { 10, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1445), 10, 10, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1446) },
                    { 11, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1448), 11, 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1450) },
                    { 12, new DateTime(2024, 3, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1452), 12, 12, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1453) },
                    { 13, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1456), 13, 13, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1457) },
                    { 14, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1460), 14, 14, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1461) },
                    { 15, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1464), 15, 15, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1465) },
                    { 16, new DateTime(2024, 7, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1468), 16, 16, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1469) },
                    { 17, new DateTime(2024, 8, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1475), 17, 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1476) },
                    { 18, new DateTime(2024, 3, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1481), 18, 18, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1487) },
                    { 19, new DateTime(2024, 4, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1499), 19, 1, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1500) },
                    { 20, new DateTime(2024, 5, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1508), 20, 2, new DateTime(2024, 6, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(1512) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(819), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(799), new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(820), "12345678" },
                    { 2, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(827), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(824), new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(828), "22345678" },
                    { 3, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(835), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(832), new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(836), "32345678" },
                    { 4, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(842), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(839), new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(844), "42345678" },
                    { 5, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(850), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(847), new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(851), "52345678" },
                    { 6, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(859), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(856), new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(861), "62345678" },
                    { 7, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(867), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(864), new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(868), "72345678" },
                    { 8, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(874), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(871), new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(876), "82345678" },
                    { 9, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(882), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(879), new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(883), "92345678" },
                    { 10, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(889), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(886), new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(891), "01234567" },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(899), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(896), new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(900), "12345679" },
                    { 12, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(906), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(903), new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(908), "22345679" },
                    { 13, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(914), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(911), new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(915), "32345679" },
                    { 14, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(921), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(918), new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(922), "42345679" },
                    { 15, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(928), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(925), new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(929), "52345679" },
                    { 16, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(939), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(936), new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(940), "62345679" },
                    { 17, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(946), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(943), new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(947), "72345679" },
                    { 18, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(953), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(950), new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(954), "82345679" },
                    { 19, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(960), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(957), new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(961), "92345679" },
                    { 20, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(967), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(964), new DateTime(2024, 9, 15, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(968), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2031), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2033) },
                    { 2, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2037), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2038) },
                    { 3, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2041), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2042) },
                    { 4, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2044), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2046) },
                    { 5, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2048), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2049) },
                    { 6, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2052), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2053) },
                    { 7, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2056), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2057) },
                    { 8, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2060), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2061) },
                    { 9, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2063), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2065) },
                    { 10, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2067), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2068) },
                    { 11, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2071), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2072) },
                    { 12, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2075), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2076) },
                    { 13, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2079), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2080) },
                    { 14, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2084), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2086) },
                    { 15, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2088), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2090) },
                    { 16, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2092), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2093) },
                    { 17, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2096), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2097) },
                    { 18, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2100), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2101) },
                    { 19, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2103), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2105) },
                    { 20, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2107), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2108) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2228), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2232) },
                    { 2, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2239), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2240) },
                    { 3, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2243), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2245) },
                    { 4, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2247), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2249) },
                    { 5, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2251), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2253) },
                    { 6, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2255), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2257) },
                    { 7, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2260), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2261) },
                    { 8, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2264), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2265) },
                    { 9, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2268), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2269) },
                    { 10, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2272), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2273) },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2276), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2277) },
                    { 12, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2280), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2281) },
                    { 13, new DateTime(2024, 9, 7, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2284), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2285) },
                    { 14, new DateTime(2024, 9, 8, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2291), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2292) },
                    { 15, new DateTime(2024, 9, 9, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2298), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2299) },
                    { 16, new DateTime(2024, 9, 10, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2302), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2303) },
                    { 17, new DateTime(2024, 9, 11, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2306), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2307) },
                    { 18, new DateTime(2024, 9, 12, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2310), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2311) },
                    { 19, new DateTime(2024, 9, 13, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2314), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2315) },
                    { 20, new DateTime(2024, 9, 14, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2318), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2319) },
                    { 21, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2321), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2323) },
                    { 22, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2325), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2326) },
                    { 23, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2329), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2330) },
                    { 24, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2333), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2334) },
                    { 25, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2337), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2338) },
                    { 26, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2341), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2342) },
                    { 27, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2348), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2350) },
                    { 28, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2352), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2353) },
                    { 29, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2356), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2357) },
                    { 30, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2360), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2361) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2427), new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2429), new DateTime(2024, 8, 16, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2424), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 17, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2425), 100.00m },
                    { 2, new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2436), new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2437), new DateTime(2024, 8, 17, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2433), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2434), 200.00m },
                    { 3, new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2447), new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2449), new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2445), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2446), 300.00m },
                    { 4, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2456), new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2457), new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2453), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2454), 400.00m },
                    { 5, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2463), new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2465), new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2461), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2462), 500.00m },
                    { 6, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2471), new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2473), new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2469), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2470), 600.00m },
                    { 7, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2479), new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2480), new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2476), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2477), 700.00m },
                    { 8, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2492), new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2493), new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2484), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2485), 800.00m },
                    { 9, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2499), new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2501), new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2497), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2498), 900.00m },
                    { 10, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2507), new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2509), new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2505), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2506), 1000.00m },
                    { 11, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2515), new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2516), new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2512), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2514), 1100.00m },
                    { 12, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2523), new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2524), new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2520), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2521), 1200.00m },
                    { 13, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2536), new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2541), new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2531), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2535), 1300.00m },
                    { 14, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2547), new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2548), new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2544), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2545), 1400.00m },
                    { 15, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2555), new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2556), new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2552), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2553), 1500.00m },
                    { 16, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2566), new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2567), new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2564), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2565), 1600.00m },
                    { 17, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2574), new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2575), new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2571), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2572), 1700.00m },
                    { 18, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2581), new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2579), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2580), 1800.00m },
                    { 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2589), new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2590), new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2587), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2588), 1900.00m },
                    { 20, new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 9, 6, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2598), new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2594), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2595), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2925), 8, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2927), 1 },
                    { 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2931), 9, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2932), 1 },
                    { 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2935), 10, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2936), 1 },
                    { 4, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2938), 11, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2939), 1 },
                    { 5, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2942), 12, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2943), 1 },
                    { 6, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2949), 13, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2950), 1 },
                    { 7, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2952), 14, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2953), 1 },
                    { 8, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2956), 15, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2957), 1 },
                    { 9, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2962), 16, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2963), 1 },
                    { 10, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2968), 17, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2969), 1 },
                    { 11, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2971), 18, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2972), 1 },
                    { 12, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2975), 19, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2976), 1 },
                    { 13, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2978), 20, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2979), 1 },
                    { 14, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2981), 8, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2982), 2 },
                    { 15, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2985), 9, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2986), 2 },
                    { 16, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2988), 10, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2989), 2 },
                    { 17, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2995), 11, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2996), 2 },
                    { 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2998), 12, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2999), 2 },
                    { 19, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3002), 13, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3002), 2 },
                    { 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3005), 14, 1, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3006), 2 },
                    { 21, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3008), 8, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3009), 3 },
                    { 22, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3011), 9, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3012), 3 },
                    { 23, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3015), 10, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3016), 3 },
                    { 24, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3018), 11, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3021), 3 },
                    { 25, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3026), 12, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3027), 4 },
                    { 26, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3035), 13, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3036), 4 },
                    { 27, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3038), 14, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3039), 4 },
                    { 28, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3045), 15, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3046), 5 },
                    { 29, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3048), 16, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3049), 5 },
                    { 30, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3054), 17, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3055), 5 },
                    { 31, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3058), 18, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3059), 6 },
                    { 32, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3061), 19, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3062), 6 },
                    { 33, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3064), 20, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3065), 7 },
                    { 34, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3068), 8, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3069), 1 },
                    { 35, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3071), 9, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3072), 1 },
                    { 36, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3074), 10, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3075), 1 },
                    { 37, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3078), 11, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3079), 2 },
                    { 38, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3081), 12, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3082), 2 },
                    { 39, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3084), 13, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3085), 2 },
                    { 40, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3088), 14, 2, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3089), 2 },
                    { 41, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3091), 8, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3092), 2 },
                    { 42, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3095), 9, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3098), 2 },
                    { 43, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3100), 10, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3101), 2 },
                    { 44, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3106), 11, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3107), 2 },
                    { 45, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3109), 12, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3110), 3 },
                    { 46, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3116), 13, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3117), 3 },
                    { 47, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3120), 14, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3120), 3 },
                    { 48, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3123), 15, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3124), 4 },
                    { 49, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3126), 16, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3127), 4 },
                    { 50, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3130), 17, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3131), 4 },
                    { 51, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3133), 18, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3134), 5 },
                    { 52, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3136), 19, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3137), 5 },
                    { 53, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3140), 20, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3141), 6 },
                    { 54, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3143), 8, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3144), 7 },
                    { 55, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3146), 9, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3147), 7 },
                    { 56, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3150), 10, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3151), 1 },
                    { 57, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3153), 11, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3154), 1 },
                    { 58, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3156), 12, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3157), 1 },
                    { 59, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3163), 13, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3164), 1 },
                    { 60, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3166), 14, 3, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3167), 2 }
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
                    { 1, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3307), 1, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3308), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3305), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3303) },
                    { 2, new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3315), 2, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3316), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3313), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3312) },
                    { 3, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3322), 3, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3324), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3321), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3319) },
                    { 4, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3329), 4, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3331), new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3328), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3327) },
                    { 5, new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3336), 5, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3337), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3335), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3333) },
                    { 6, new DateTime(2017, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3343), 6, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3344), new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3341), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3340) },
                    { 7, new DateTime(2016, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3353), 7, new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3354), new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3351), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3347) },
                    { 8, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3360), 8, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3362), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3359), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3358) },
                    { 9, new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3367), 9, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3366), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3365) },
                    { 10, new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3374), 10, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3375), new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3373), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3371) },
                    { 11, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3385), 11, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3387), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3379), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3378) },
                    { 12, new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3392), 12, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3393), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3391), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3389) },
                    { 13, new DateTime(2017, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3398), 13, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3400), new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3397), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3396) },
                    { 14, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3405), 14, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3406), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3404), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3403) },
                    { 15, new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3414), 15, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3415), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3413), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3412) },
                    { 16, new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3421), 16, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3422), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3420), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3418) },
                    { 17, new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3428), 17, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3429), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3426), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3425) },
                    { 18, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3434), 18, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3435), new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3433), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3432) },
                    { 19, new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3440), 19, new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3442), new DateTime(2023, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3439), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3438) },
                    { 20, new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3447), 20, new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3448), new DateTime(2022, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3446), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(3445) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "CourseCategory", "CourseId", "CourseSubject", "CourseTitle", "CourseType", "DiscountPrice", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "語言學習", 1, "英文", "英文基礎", (short)1, 10.00m, (short)10, 900.00m, 100.00m },
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
                    { 1, new DateOnly(2024, 8, 16), (short)10, new DateTime(2024, 8, 16, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2731), 1, 1, 1, new DateTime(2024, 8, 17, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2732) },
                    { 2, new DateOnly(2024, 8, 17), (short)11, new DateTime(2024, 8, 17, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2739), 2, 2, 2, new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2740) },
                    { 3, new DateOnly(2024, 8, 18), (short)12, new DateTime(2024, 8, 18, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2746), 3, 3, 3, new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2748) },
                    { 4, new DateOnly(2024, 8, 19), (short)13, new DateTime(2024, 8, 19, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2753), 4, 4, 4, new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2755) },
                    { 5, new DateOnly(2024, 8, 20), (short)14, new DateTime(2024, 8, 20, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2760), 5, 5, 5, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2762) },
                    { 6, new DateOnly(2024, 8, 21), (short)15, new DateTime(2024, 8, 21, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2767), 6, 6, 6, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2769) },
                    { 7, new DateOnly(2024, 8, 22), (short)16, new DateTime(2024, 8, 22, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2774), 7, 7, 7, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2776) },
                    { 8, new DateOnly(2024, 8, 23), (short)17, new DateTime(2024, 8, 23, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2781), 8, 8, 8, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2783) },
                    { 9, new DateOnly(2024, 8, 24), (short)18, new DateTime(2024, 8, 24, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2792), 9, 9, 9, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2793) },
                    { 10, new DateOnly(2024, 8, 25), (short)19, new DateTime(2024, 8, 25, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2798), 10, 10, 10, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2799) },
                    { 11, new DateOnly(2024, 8, 26), (short)20, new DateTime(2024, 8, 26, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2805), 11, 11, 11, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2806) },
                    { 12, new DateOnly(2024, 8, 27), (short)21, new DateTime(2024, 8, 27, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2812), 12, 12, 12, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2813) },
                    { 13, new DateOnly(2024, 8, 28), (short)22, new DateTime(2024, 8, 28, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2818), 13, 13, 13, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2819) },
                    { 14, new DateOnly(2024, 8, 29), (short)23, new DateTime(2024, 8, 29, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2824), 14, 14, 14, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2825) },
                    { 15, new DateOnly(2024, 8, 30), (short)24, new DateTime(2024, 8, 30, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2831), 15, 15, 15, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2834) },
                    { 16, new DateOnly(2024, 8, 31), (short)25, new DateTime(2024, 8, 31, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2839), 16, 16, 16, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2841) },
                    { 17, new DateOnly(2024, 9, 1), (short)26, new DateTime(2024, 9, 1, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2846), 17, 17, 17, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2847) },
                    { 18, new DateOnly(2024, 9, 2), (short)27, new DateTime(2024, 9, 2, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2852), 18, 18, 18, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2853) },
                    { 19, new DateOnly(2024, 9, 3), (short)28, new DateTime(2024, 9, 3, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2858), 19, 19, 19, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2859) },
                    { 20, new DateOnly(2024, 9, 4), (short)29, new DateTime(2024, 9, 4, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2864), 20, 20, 20, new DateTime(2024, 9, 5, 10, 32, 50, 127, DateTimeKind.Local).AddTicks(2866) }
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
