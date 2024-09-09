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
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5999), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5993), true, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6000) },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6005), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6004), true, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6006) },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6010), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6009), false, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6011) },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6015), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6013), true, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6016) },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6019), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6018), false, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6022) },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6026), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6025), true, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6027) },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6034), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6033), false, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6035) },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6038), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6037), true, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6039) },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6045), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6044), false, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6046) },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6050), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6049), true, new DateTime(2024, 9, 18, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6051) },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6058), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6057), true, new DateTime(2024, 9, 19, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6059) },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6062), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6061), true, new DateTime(2024, 9, 20, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6063) },
                    { 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6067), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6066), false, new DateTime(2024, 9, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6067) },
                    { 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6074), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6073), true, new DateTime(2024, 9, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6075) },
                    { 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6079), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6077), true, new DateTime(2024, 9, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6079) },
                    { 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6083), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6082), true, new DateTime(2024, 9, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6084) },
                    { 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6087), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6086), true, new DateTime(2024, 9, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6088) },
                    { 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6092), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6090), true, new DateTime(2024, 9, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6092) },
                    { 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6096), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6095), true, new DateTime(2024, 9, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6097) },
                    { 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6100), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6099), true, new DateTime(2024, 9, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6101) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5418), null },
                    { 2, "程式設計", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5420), null },
                    { 3, "升學科目", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5422), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7708), "00:00", null },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7710), "01:00", null },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7711), "02:00", null },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7713), "03:00", null },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7715), "04:00", null },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7716), "05:00", null },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7718), "06:00", null },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7720), "07:00", null },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7722), "08:00", null },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7723), "09:00", null },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7725), "10:00", null },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7726), "11:00", null },
                    { 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7728), "12:00", null },
                    { 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7730), "13:00", null },
                    { 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7734), "14:00", null },
                    { 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7736), "15:00", null },
                    { 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7737), "16:00", null },
                    { 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7739), "17:00", null },
                    { 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7741), "18:00", null },
                    { 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7742), "19:00", null },
                    { 21, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7744), "20:00", null },
                    { 22, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7745), "21:00", null },
                    { 23, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7747), "22:00", null },
                    { 24, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7748), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4391), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4423), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4426), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4428), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4430), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4433), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4436), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4440), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4443), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4447), "Biology", "University of Toronto", 2016, 2012, null }
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
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5454), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5456), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5458), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5459), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5462), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5464), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5465), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5467), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5469), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5470), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5472), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5474), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5476), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5477), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5479), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5481), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5482), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5484), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4961), (short)1, "適合初學者的英文課程", 90m, true, "從零開始學英文", 1, "https://example.com/courses/english.jpg", "基礎英文", 1, 50m, null, "https://example.com/courses/english_intro.mp4" },
                    { 2, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4967), (short)1, "基礎日語語法和詞彙", 100m, true, "日語學習的基礎", 2, "https://example.com/courses/japanese.jpg", "日語入門", 2, 60m, null, "https://example.com/courses/japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4971), (short)1, "全面學習中文語法", 120m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 70m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4979), (short)1, "提高德語口語能力", 110m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 65m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4989), (short)1, "提升法語閱讀能力", 95m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 55m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4998), (short)1, "提高西班牙語寫作能力", 100m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 60m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5002), (short)1, "從頭開始學習HTML和CSS", 125m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 75m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5007), (short)1, "學習JavaScript語法和應用", 140m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 85m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5094), (short)1, "深入學習C#編程", 150m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 90m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5101), (short)1, "從零開始學習SQL", 130m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 80m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5105), (short)1, "從頭開始學習Python編程", 140m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 85m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5113), (short)1, "從零開始學習Java語言", 150m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 90m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5131), (short)1, "提升數學基礎知識", 100m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 60m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5145), (short)1, "物理學基礎知識", 110m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 65m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5154), (short)1, "全面了解化學基礎知識", 120m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 70m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5161), (short)1, "歷史事件和背景的深入分析", 125m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 75m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5165), (short)1, "全面了解地理學的基礎", 110m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 65m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5169), (short)1, "深入學習生物學的基本概念", 120m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 70m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5174), (short)1, "深入練習英語會話和詞彙", 180m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 100m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5181), (short)1, "提升日語會話和語法能力", 200m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 110m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5185), (short)1, "深入學習中文語法和詞彙", 220m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 120m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5189), (short)1, "德語會話和詞彙的深入練習", 240m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 130m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5199), (short)1, "法語閱讀和寫作的深入研究", 230m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 125m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5204), (short)1, "西班牙語寫作和語法的深入練習", 250m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 135m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5211), (short)1, "高級網頁設計和開發技術", 270m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 150m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5222), (short)1, "JavaScript編程的高級應用和技巧", 280m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 160m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5229), (short)1, "深入掌握C#編程的高級技術", 300m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 170m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5233), (short)1, "SQL資料庫管理和優化的高級技術", 275m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 155m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5237), (short)1, "Python編程的高級應用和數據處理", 290m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 165m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5306), (short)1, "Java編程的高級技術和應用", 310m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 175m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5310), (short)1, "高等數學理論和應用", 250m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 140m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5314), (short)1, "物理學的高級理論和應用", 255m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 145m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5318), (short)1, "化學的高級理論和應用", 260m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 150m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5322), (short)1, "歷史研究的高級技術和方法", 275m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 160m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5330), (short)1, "地理學的高級理論和應用", 265m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 150m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5334), (short)1, "生物學的高級理論和應用", 275m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 160m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5338), (short)1, "專業英文寫作的高級技巧", 320m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 180m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5342), (short)1, "專業日語寫作的高級技巧", 340m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 190m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5346), (short)1, "專業中文寫作的高級技巧", 360m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 200m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5350), (short)1, "專業德語寫作的高級技巧", 380m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 210m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4538), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4539) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4544), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4547), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4548) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4552), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4557), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4558) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4563), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4566), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4567) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4574), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4577), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4578) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4582), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4585), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4586) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4590), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4593), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4594) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4601), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4602) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4610), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4613), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4614) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4669), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4675), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4675) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4680), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4686), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4687) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4691), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4694), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4695) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4702), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4705), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4706) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4710), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4713), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4713) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4717), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4720), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4721) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4725), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4728), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4729) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4733), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4736), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4736) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4740), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4743), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4744) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4752), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4755), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4756) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4760), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4762), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4763) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4767), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4770), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4771) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4775), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4778), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4779) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4783), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4786), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4786) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4820), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4823), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4824) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4829), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4831), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4832) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4836), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4839), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4840) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4844), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4847), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4847) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4851), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4858), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4859) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4863), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4866), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4867) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4871), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4874), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(4875) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6249), true, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6250), 1, null, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6251) },
                    { 2, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6254), false, null, 2, "Incomplete application", new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6255) },
                    { 3, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6258), true, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6259), 3, null, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6260) },
                    { 4, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6262), false, null, 4, "Failed verification", new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6263) },
                    { 5, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6266), true, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6267), 5, null, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6268) },
                    { 6, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6270), true, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6271), 6, null, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6272) },
                    { 7, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6274), false, null, 7, "Incorrect details", new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6276) },
                    { 8, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6278), true, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6279), 8, null, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6280) },
                    { 9, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6323), true, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6324), 9, null, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6325) },
                    { 10, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6327), false, null, 10, "Missing documents", new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6329) },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6331), true, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6332), 11, null, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6333) },
                    { 12, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6335), false, null, 12, "Not eligible", new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6336) },
                    { 13, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6341), true, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6342), 13, null, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6344) },
                    { 14, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6346), true, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6347), 14, null, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6351) },
                    { 15, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6353), false, null, 15, "Failed interview", new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6356) },
                    { 16, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6360), true, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6361), 16, null, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6365) },
                    { 17, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6369), true, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6370), 17, null, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6371) },
                    { 18, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6377), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6378) },
                    { 19, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6380), true, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6381), 19, null, new DateTime(2024, 9, 18, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6382) },
                    { 20, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6384), false, null, 20, "Unverified information", new DateTime(2024, 9, 19, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6385) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6431), (short)14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6437), 3, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6438) },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6442), (short)15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6443), 4, 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6444) },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6446), (short)16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6447), 5, 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6447) },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6449), (short)17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6450), 6, 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6451) },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6453), (short)18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6454), 7, 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6454) },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6456), (short)19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6457), 8, 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6458) },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6460), (short)20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6461), 9, 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6464) },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6468), (short)12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6469), 10, 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6470) },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6475), (short)13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6477), 11, 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6478) },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6482), (short)14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6484), 12, 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6484) },
                    { 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6486), (short)15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6487), 13, 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6488) },
                    { 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6492), (short)16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6496), 14, 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6496) },
                    { 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6498), (short)17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6499), 15, 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6500) },
                    { 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6501), (short)18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6502), 16, 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6503) },
                    { 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6505), (short)19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6506), 17, 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6507) },
                    { 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6508), (short)20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6509), 18, 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6510) },
                    { 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6512), (short)12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6513), 19, 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6514) },
                    { 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6515), (short)13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6516), 20, 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6517) },
                    { 21, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6526), 1, 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6526) },
                    { 22, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6529), 2, 21, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6530) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5568), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5570), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5572), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5574), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5575), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5577), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5579), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5583), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5584), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5586), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5588), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5589), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6136), 1, 1, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6137) },
                    { 2, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6140), 2, 2, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6144) },
                    { 3, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6146), 3, 3, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6147) },
                    { 4, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6150), 4, 4, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6151) },
                    { 5, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6153), 5, 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6154) },
                    { 6, new DateTime(2024, 3, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6156), 6, 6, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6157) },
                    { 7, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6159), 7, 7, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6160) },
                    { 8, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6162), 8, 8, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6163) },
                    { 9, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6165), 9, 9, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6167) },
                    { 10, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6169), 10, 10, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6170) },
                    { 11, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6172), 11, 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6173) },
                    { 12, new DateTime(2024, 3, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6175), 12, 12, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6176) },
                    { 13, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6178), 13, 13, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6179) },
                    { 14, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6184), 14, 14, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6185) },
                    { 15, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6187), 15, 15, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6188) },
                    { 16, new DateTime(2024, 7, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6190), 16, 16, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6191) },
                    { 17, new DateTime(2024, 8, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6193), 17, 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6193) },
                    { 18, new DateTime(2024, 3, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6195), 18, 18, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6196) },
                    { 19, new DateTime(2024, 4, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6198), 19, 1, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6199) },
                    { 20, new DateTime(2024, 5, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6201), 20, 2, new DateTime(2024, 6, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6202) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5646), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5631), new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5647), "12345678" },
                    { 2, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5653), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5651), new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5654), "22345678" },
                    { 3, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5660), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5657), new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5661), "32345678" },
                    { 4, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5666), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5663), new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5670), "42345678" },
                    { 5, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5675), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5673), new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5676), "52345678" },
                    { 6, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5682), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5679), new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5683), "62345678" },
                    { 7, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5688), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5685), new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5688), "72345678" },
                    { 8, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5694), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5691), new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5695), "82345678" },
                    { 9, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5700), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5697), new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5703), "92345678" },
                    { 10, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5708), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5706), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5709), "01234567" },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5714), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5712), new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5715), "12345679" },
                    { 12, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5720), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5717), new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5721), "22345679" },
                    { 13, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5733), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5726), new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5734), "32345679" },
                    { 14, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5739), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5737), new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5740), "42345679" },
                    { 15, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5745), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5742), new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5746), "52345679" },
                    { 16, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5750), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5748), new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5751), "62345679" },
                    { 17, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5756), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5754), new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5757), "72345679" },
                    { 18, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5762), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5759), new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5763), "82345679" },
                    { 19, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5773), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5768), new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5774), "92345679" },
                    { 20, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5779), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5776), new DateTime(2024, 9, 18, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(5780), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6576), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6577) },
                    { 2, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6580), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6581) },
                    { 3, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6583), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6584) },
                    { 4, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6586), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6590) },
                    { 5, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6595), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6596) },
                    { 6, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6598), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6601) },
                    { 7, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6606), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6607) },
                    { 8, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6609), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6610) },
                    { 9, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6612), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6613) },
                    { 10, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6615), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6616) },
                    { 11, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6618), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6619) },
                    { 12, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6621), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6622) },
                    { 13, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6624), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6625) },
                    { 14, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6627), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6628) },
                    { 15, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6630), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6631) },
                    { 16, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6633), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6634) },
                    { 17, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6636), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6637) },
                    { 18, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6642), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6643) },
                    { 19, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6645), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6646) },
                    { 20, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6648), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6649) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6688), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6690) },
                    { 2, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6692), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6693) },
                    { 3, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6695), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6696) },
                    { 4, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6699), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6700) },
                    { 5, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6702), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6703) },
                    { 6, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6705), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6706) },
                    { 7, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6708), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6709) },
                    { 8, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6712), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6712) },
                    { 9, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6715), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6716) },
                    { 10, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6718), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6719) },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6722), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6722) },
                    { 12, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6725), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6726) },
                    { 13, new DateTime(2024, 9, 10, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6728), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6729) },
                    { 14, new DateTime(2024, 9, 11, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6731), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6732) },
                    { 15, new DateTime(2024, 9, 12, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6774), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6775) },
                    { 16, new DateTime(2024, 9, 13, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6778), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6779) },
                    { 17, new DateTime(2024, 9, 14, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6781), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6782) },
                    { 18, new DateTime(2024, 9, 15, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6784), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6785) },
                    { 19, new DateTime(2024, 9, 16, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6787), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6788) },
                    { 20, new DateTime(2024, 9, 17, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6794), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6795) },
                    { 21, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6797), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6798) },
                    { 22, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6801), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6802) },
                    { 23, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6804), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6805) },
                    { 24, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6807), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6808) },
                    { 25, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6810), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6811) },
                    { 26, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6813), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6814) },
                    { 27, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6817), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6818) },
                    { 28, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6823), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6824) },
                    { 29, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6826), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6827) },
                    { 30, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6829), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6830) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6887), new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6888), new DateTime(2024, 8, 19, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6884), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 20, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6886), 100.00m },
                    { 2, new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6898), new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6899), new DateTime(2024, 8, 20, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6893), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6897), 200.00m },
                    { 3, new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6905), new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6906), new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6903), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6904), 300.00m },
                    { 4, new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6912), new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6913), new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6910), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6911), 400.00m },
                    { 5, new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6922), new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6923), new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6916), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6917), 500.00m },
                    { 6, new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6929), new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6930), new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6926), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6927), 600.00m },
                    { 7, new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6935), new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6936), new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6933), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6934), 700.00m },
                    { 8, new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6942), new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6943), new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6940), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6941), 800.00m },
                    { 9, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6949), new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6950), new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6946), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6947), 900.00m },
                    { 10, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6959), new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6960), new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6957), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6957), 1000.00m },
                    { 11, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6965), new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6966), new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6963), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6964), 1100.00m },
                    { 12, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6972), new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6973), new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6970), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6971), 1200.00m },
                    { 13, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6978), new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6980), new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6976), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6977), 1300.00m },
                    { 14, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6985), new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6989), new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6983), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6984), 1400.00m },
                    { 15, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6994), new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6995), new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6992), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6993), 1500.00m },
                    { 16, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7000), new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7001), new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6998), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(6999), 1600.00m },
                    { 17, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7007), new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7008), new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7005), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7006), 1700.00m },
                    { 18, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7013), new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7014), new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7011), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7012), 1800.00m },
                    { 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7022), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7023), new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7017), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7021), 1900.00m },
                    { 20, new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7028), new DateTime(2024, 9, 9, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7029), new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7026), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7027), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7297), 8, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7298), 1 },
                    { 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7301), 9, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7302), 1 },
                    { 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7304), 10, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7304), 1 },
                    { 4, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7306), 11, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7307), 1 },
                    { 5, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7309), 12, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7310), 1 },
                    { 6, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7312), 13, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7313), 1 },
                    { 7, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7315), 14, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7316), 1 },
                    { 8, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7321), 15, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7321), 1 },
                    { 9, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7323), 16, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7324), 1 },
                    { 10, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7326), 17, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7327), 1 },
                    { 11, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7329), 18, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7330), 1 },
                    { 12, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7332), 19, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7332), 1 },
                    { 13, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7334), 20, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7335), 1 },
                    { 14, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7337), 8, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7338), 2 },
                    { 15, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7340), 9, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7341), 2 },
                    { 16, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7343), 10, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7343), 2 },
                    { 17, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7345), 11, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7346), 2 },
                    { 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7348), 12, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7349), 2 },
                    { 19, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7351), 13, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7352), 2 },
                    { 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7354), 14, 1, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7354), 2 },
                    { 21, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7356), 8, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7357), 3 },
                    { 22, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7362), 9, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7363), 3 },
                    { 23, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7365), 10, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7365), 3 },
                    { 24, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7367), 11, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7368), 3 },
                    { 25, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7370), 12, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7371), 4 },
                    { 26, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7372), 13, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7373), 4 },
                    { 27, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7375), 14, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7376), 4 },
                    { 28, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7378), 15, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7378), 5 },
                    { 29, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7380), 16, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7381), 5 },
                    { 30, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7383), 17, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7384), 5 },
                    { 31, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7386), 18, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7386), 6 },
                    { 32, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7388), 19, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7389), 6 },
                    { 33, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7391), 20, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7392), 0 },
                    { 34, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7394), 8, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7394), 1 },
                    { 35, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7396), 9, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7397), 1 },
                    { 36, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7402), 10, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7402), 1 },
                    { 37, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7404), 11, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7405), 2 },
                    { 38, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7407), 12, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7408), 2 },
                    { 39, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7410), 13, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7410), 2 },
                    { 40, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7412), 14, 2, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7413), 2 },
                    { 41, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7415), 8, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7416), 2 },
                    { 42, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7418), 9, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7418), 2 },
                    { 43, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7420), 10, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7421), 2 },
                    { 44, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7423), 11, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7424), 2 },
                    { 45, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7426), 12, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7426), 3 },
                    { 46, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7428), 13, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7429), 3 },
                    { 47, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7431), 14, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7432), 3 },
                    { 48, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7434), 15, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7434), 4 },
                    { 49, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7436), 16, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7437), 4 },
                    { 50, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7442), 17, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7443), 4 },
                    { 51, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7445), 18, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7445), 5 },
                    { 52, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7447), 19, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7448), 5 },
                    { 53, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7450), 20, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7451), 6 },
                    { 54, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7453), 8, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7453), 0 },
                    { 55, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7455), 9, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7456), 0 },
                    { 56, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7458), 10, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7459), 1 },
                    { 57, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7461), 11, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7461), 1 },
                    { 58, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7463), 12, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7464), 1 },
                    { 59, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7466), 13, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7467), 1 },
                    { 60, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7469), 14, 3, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7469), 2 }
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
                    { 1, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7534), 1, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7535), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7533), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7531) },
                    { 2, new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7540), 2, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7541), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7539), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7538) },
                    { 3, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7545), 3, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7546), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7544), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7543) },
                    { 4, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7550), 4, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7551), new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7549), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7548) },
                    { 5, new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7555), 5, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7556), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7554), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7553) },
                    { 6, new DateTime(2017, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7560), 6, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7561), new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7560), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7559) },
                    { 7, new DateTime(2016, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7566), 7, new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7567), new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7565), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7564) },
                    { 8, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7572), 8, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7573), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7571), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7570) },
                    { 9, new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7602), 9, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7603), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7601), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7599) },
                    { 10, new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7607), 10, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7608), new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7606), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7605) },
                    { 11, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7613), 11, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7614), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7612), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7611) },
                    { 12, new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7618), 12, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7619), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7617), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7616) },
                    { 13, new DateTime(2017, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7624), 13, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7625), new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7623), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7622) },
                    { 14, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7629), 14, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7630), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7628), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7627) },
                    { 15, new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7634), 15, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7635), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7633), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7632) },
                    { 16, new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7639), 16, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7641), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7638), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7637) },
                    { 17, new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7648), 17, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7649), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7644), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7643) },
                    { 18, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7653), 18, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7654), new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7652), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7651) },
                    { 19, new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7658), 19, new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7659), new DateTime(2023, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7657), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7656) },
                    { 20, new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7663), 20, new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7664), new DateTime(2022, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7662), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7661) }
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
                    { 1, new DateOnly(2024, 8, 19), (short)10, new DateTime(2024, 8, 19, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7097), 1, 1, 1, new DateTime(2024, 8, 20, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7098) },
                    { 2, new DateOnly(2024, 8, 20), (short)11, new DateTime(2024, 8, 20, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7103), 2, 2, 2, new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7104) },
                    { 3, new DateOnly(2024, 8, 21), (short)12, new DateTime(2024, 8, 21, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7108), 3, 3, 3, new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7109) },
                    { 4, new DateOnly(2024, 8, 22), (short)13, new DateTime(2024, 8, 22, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7114), 4, 4, 4, new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7115) },
                    { 5, new DateOnly(2024, 8, 23), (short)14, new DateTime(2024, 8, 23, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7123), 5, 5, 5, new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7124) },
                    { 6, new DateOnly(2024, 8, 24), (short)15, new DateTime(2024, 8, 24, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7128), 6, 6, 6, new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7129) },
                    { 7, new DateOnly(2024, 8, 25), (short)16, new DateTime(2024, 8, 25, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7134), 7, 7, 7, new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7135) },
                    { 8, new DateOnly(2024, 8, 26), (short)17, new DateTime(2024, 8, 26, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7139), 8, 8, 8, new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7141) },
                    { 9, new DateOnly(2024, 8, 27), (short)18, new DateTime(2024, 8, 27, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7145), 9, 9, 9, new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7146) },
                    { 10, new DateOnly(2024, 8, 28), (short)19, new DateTime(2024, 8, 28, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7150), 10, 10, 10, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7151) },
                    { 11, new DateOnly(2024, 8, 29), (short)20, new DateTime(2024, 8, 29, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7159), 11, 11, 11, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7160) },
                    { 12, new DateOnly(2024, 8, 30), (short)21, new DateTime(2024, 8, 30, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7164), 12, 12, 12, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7165) },
                    { 13, new DateOnly(2024, 8, 31), (short)22, new DateTime(2024, 8, 31, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7169), 13, 13, 13, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7170) },
                    { 14, new DateOnly(2024, 9, 1), (short)23, new DateTime(2024, 9, 1, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7175), 14, 14, 14, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7176) },
                    { 15, new DateOnly(2024, 9, 2), (short)24, new DateTime(2024, 9, 2, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7180), 15, 15, 15, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7181) },
                    { 16, new DateOnly(2024, 9, 3), (short)25, new DateTime(2024, 9, 3, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7185), 16, 16, 16, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7186) },
                    { 17, new DateOnly(2024, 9, 4), (short)26, new DateTime(2024, 9, 4, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7235), 17, 17, 17, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7236) },
                    { 18, new DateOnly(2024, 9, 5), (short)27, new DateTime(2024, 9, 5, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7243), 18, 18, 18, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7244) },
                    { 19, new DateOnly(2024, 9, 6), (short)28, new DateTime(2024, 9, 6, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7249), 19, 19, 19, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7250) },
                    { 20, new DateOnly(2024, 9, 7), (short)29, new DateTime(2024, 9, 7, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7254), 20, 20, 20, new DateTime(2024, 9, 8, 14, 34, 40, 179, DateTimeKind.Local).AddTicks(7255) }
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
