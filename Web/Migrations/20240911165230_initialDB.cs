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

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CDate", "CouponCode", "CouponName", "Discount", "DiscountType", "ExpirationDate", "IsActive", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3931), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3930), true, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3932) },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3934), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3933), true, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3935) },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3937), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3936), false, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3937) },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3941), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3939), true, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3941) },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3944), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3943), false, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3944) },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3946), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3946), true, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3947) },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3949), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3948), false, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3949) },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3952), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3951), true, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3952) },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3954), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3953), false, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3955) },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3957), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3956), true, new DateTime(2024, 9, 22, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3957) },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3959), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3959), true, new DateTime(2024, 9, 23, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3960) },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3964), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3963), true, new DateTime(2024, 9, 24, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3964) },
                    { 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3966), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3965), false, new DateTime(2024, 9, 25, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3967) },
                    { 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3969), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3968), true, new DateTime(2024, 9, 26, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3969) },
                    { 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3971), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3971), true, new DateTime(2024, 9, 27, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3972) },
                    { 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3974), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3973), true, new DateTime(2024, 9, 28, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3974) },
                    { 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3976), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3976), true, new DateTime(2024, 9, 29, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3977) },
                    { 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3979), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3978), true, new DateTime(2024, 9, 30, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3979) },
                    { 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3981), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3981), true, new DateTime(2024, 10, 1, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3982) },
                    { 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3985), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3985), true, new DateTime(2024, 10, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3986) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3626), null },
                    { 2, "程式設計", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3627), null },
                    { 3, "升學科目", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3628), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4880), "00:00", null },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4881), "01:00", null },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4882), "02:00", null },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4883), "03:00", null },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4884), "04:00", null },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4885), "05:00", null },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4886), "06:00", null },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4887), "07:00", null },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4887), "08:00", null },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4888), "09:00", null },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4889), "10:00", null },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4890), "11:00", null },
                    { 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4891), "12:00", null },
                    { 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4892), "13:00", null },
                    { 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4893), "14:00", null },
                    { 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4894), "15:00", null },
                    { 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4895), "16:00", null },
                    { 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4896), "17:00", null },
                    { 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4897), "18:00", null },
                    { 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4898), "19:00", null },
                    { 21, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4898), "20:00", null },
                    { 22, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4899), "21:00", null },
                    { 23, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4900), "22:00", null },
                    { 24, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4901), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2965), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2978), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2979), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2981), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2982), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2983), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2985), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2986), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2987), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(2989), "Biology", "University of Toronto", 2016, 2012, null }
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
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3649), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3650), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3651), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3652), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3653), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3654), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3655), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3656), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3657), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3658), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3659), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3660), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3661), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3662), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3663), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3664), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3665), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3666), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3419), (short)1, "適合初學者的英文課程", 90m, true, "從零開始學英文", 1, "https://example.com/courses/english.jpg", "基礎英文", 1, 50m, null, "https://example.com/courses/english_intro.mp4" },
                    { 2, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3424), (short)1, "基礎日語語法和詞彙", 100m, true, "日語學習的基礎", 2, "https://example.com/courses/japanese.jpg", "日語入門", 2, 60m, null, "https://example.com/courses/japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3432), (short)1, "全面學習中文語法", 120m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 70m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3441), (short)1, "提高德語口語能力", 110m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 65m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3446), (short)1, "提升法語閱讀能力", 95m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 55m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3450), (short)1, "提高西班牙語寫作能力", 100m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 60m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3452), (short)1, "從頭開始學習HTML和CSS", 125m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 75m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3455), (short)1, "學習JavaScript語法和應用", 140m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 85m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3457), (short)1, "深入學習C#編程", 150m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 90m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3460), (short)1, "從零開始學習SQL", 130m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 80m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3462), (short)1, "從頭開始學習Python編程", 140m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 85m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3465), (short)1, "從零開始學習Java語言", 150m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 90m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3467), (short)1, "提升數學基礎知識", 100m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 60m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3472), (short)1, "物理學基礎知識", 110m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 65m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3476), (short)1, "全面了解化學基礎知識", 120m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 70m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3481), (short)1, "歷史事件和背景的深入分析", 125m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 75m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3485), (short)1, "全面了解地理學的基礎", 110m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 65m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3487), (short)1, "深入學習生物學的基本概念", 120m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 70m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3490), (short)1, "深入練習英語會話和詞彙", 180m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 100m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3492), (short)1, "提升日語會話和語法能力", 200m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 110m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3494), (short)1, "深入學習中文語法和詞彙", 220m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 120m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3520), (short)1, "德語會話和詞彙的深入練習", 240m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 130m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3522), (short)1, "法語閱讀和寫作的深入研究", 230m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 125m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3525), (short)1, "西班牙語寫作和語法的深入練習", 250m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 135m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3529), (short)1, "高級網頁設計和開發技術", 270m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 150m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3531), (short)1, "JavaScript編程的高級應用和技巧", 280m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 160m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3534), (short)1, "深入掌握C#編程的高級技術", 300m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 170m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3536), (short)1, "SQL資料庫管理和優化的高級技術", 275m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 155m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3538), (short)1, "Python編程的高級應用和數據處理", 290m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 165m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3541), (short)1, "Java編程的高級技術和應用", 310m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 175m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3543), (short)1, "高等數學理論和應用", 250m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 140m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3546), (short)1, "物理學的高級理論和應用", 255m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 145m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3550), (short)1, "化學的高級理論和應用", 260m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 150m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3552), (short)1, "歷史研究的高級技術和方法", 275m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 160m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3554), (short)1, "地理學的高級理論和應用", 265m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 150m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3556), (short)1, "生物學的高級理論和應用", 275m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 160m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3559), (short)1, "專業英文寫作的高級技巧", 320m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 180m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3561), (short)1, "專業日語寫作的高級技巧", 340m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 190m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3563), (short)1, "專業中文寫作的高級技巧", 360m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 200m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3566), (short)1, "專業德語寫作的高級技巧", 380m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 210m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3094), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3095) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3098), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3100), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3100) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3104), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3106), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3106) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3109), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3111), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3111) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3114), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3116), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3116) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3119), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3120), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3121) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3124), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3125), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3126) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3128), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3130), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3132) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3134), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3136), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3136) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3139), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3140), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3141) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3143), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3145), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3145) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3147), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3149), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3149) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3153), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3156), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3156) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3159), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3163), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3163) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3189), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3192), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3192) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3195), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3196), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3197) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3201), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3202), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3203) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3205), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3207), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3207) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3210), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3212), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3212) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3215), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3217), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3217) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3220), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3222), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3222) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3225), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3226), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3227) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3231), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3232), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3233) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3235), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3237), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3237) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3240), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3241), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3242) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3244), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3246), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3246) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3250), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3251) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3254), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3256), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3257) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3281), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3283), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3283) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3286), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3287), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3288) },
                    { 31, "henry_evans", 1, "1234567890", "031", new DateTime(1994, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3290), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3292), 1, "henry.evans@example.com", "Henry", (short)1, "https://randomuser.me/api/portraits/men/31.jpg", true, true, "Evans", 1, "English", "HenryE", "password31", "111222333", "English, Spanish", "Expert in English and Spanish", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3292) },
                    { 32, "chloe_scott", 2, "2345678901", "032", new DateTime(2000, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3295), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3298), 2, "chloe.scott@example.com", "Chloe", (short)2, "https://randomuser.me/api/portraits/women/32.jpg", true, false, "Scott", 2, "Japanese", "ChloeS", "password32", "444555666", "Japanese, English", "Japanese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3298) },
                    { 33, "jackson_mitchell", 1, "3456789012", "033", new DateTime(1995, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3301), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3302), 3, "jackson.mitchell@example.com", "Jackson", (short)1, "https://randomuser.me/api/portraits/men/33.jpg", true, true, "Mitchell", 3, "Korean", "JackM", "password33", "555666777", "Korean, English", "Korean language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3303) },
                    { 34, "amelia_martinez", 2, "4567890123", "034", new DateTime(1999, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3305), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3307), 4, "amelia.martinez@example.com", "Amelia", (short)2, "https://randomuser.me/api/portraits/women/34.jpg", true, false, "Martinez", 4, "German", "AmeliaM", "password34", "666777888", "German, English", "Expert in German language", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3307) },
                    { 35, "sebastian_morris", 1, "5678901234", "035", new DateTime(1998, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3309), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3311), 5, "sebastian.morris@example.com", "Sebastian", (short)1, "https://randomuser.me/api/portraits/men/35.jpg", true, true, "Morris", 5, "French", "SebM", "password35", "777888999", "French, English", "French language specialist", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3312) },
                    { 36, "grace_cooper", 2, "6789012345", "036", new DateTime(2001, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3314), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3316), 6, "grace.cooper@example.com", "Grace", (short)2, "https://randomuser.me/api/portraits/women/36.jpg", true, false, "Cooper", 6, "Spanish", "GraceC", "password36", "888999000", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3316) },
                    { 37, "aiden_perez", 1, "7890123456", "037", new DateTime(1993, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3318), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3323), 7, "aiden.perez@example.com", "Aiden", (short)1, "https://randomuser.me/api/portraits/men/37.jpg", true, true, "Perez", 7, "Chinese", "AidenP", "password37", "999000111", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3324) },
                    { 38, "avery_nelson", 2, "8901234567", "038", new DateTime(2002, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3329), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3331), 8, "avery.nelson@example.com", "Avery", (short)2, "https://randomuser.me/api/portraits/women/38.jpg", true, false, "Nelson", 8, "Russian", "AveryN", "password38", "000111222", "Russian, English", "Russian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3331) },
                    { 39, "oliver_king", 1, "0123456789", "039", new DateTime(1990, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3334), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3335), 9, "oliver.king@example.com", "Oliver", (short)1, "https://randomuser.me/api/portraits/men/39.jpg", true, true, "King", 9, "Italian", "OliverK", "password39", "111222333", "Italian, English", "Italian language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3336) },
                    { 40, "ella_wood", 2, "2345678901", "040", new DateTime(1996, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3339), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3341), 10, "ella.wood@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/40.jpg", true, false, "Wood", 10, "Portuguese", "EllaW", "password40", "222333444", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3342) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4114), true, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4115), 1, null, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4116) },
                    { 2, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4118), false, null, 2, "Incomplete application", new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4120) },
                    { 3, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4121), true, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4122), 3, null, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4124) },
                    { 4, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4125), false, null, 4, "Failed verification", new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4126) },
                    { 5, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4128), true, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4129), 5, null, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4129) },
                    { 6, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4131), true, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4131), 6, null, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4132) },
                    { 7, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4133), false, null, 7, "Incorrect details", new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4134) },
                    { 8, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4135), true, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4135), 8, null, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4136) },
                    { 9, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4137), true, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4138), 9, null, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4138) },
                    { 10, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4139), false, null, 10, "Missing documents", new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4142) },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4143), true, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4143), 11, null, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4144) },
                    { 12, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4145), false, null, 12, "Not eligible", new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4146) },
                    { 13, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4147), true, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4147), 13, null, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4148) },
                    { 14, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4149), true, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4149), 14, null, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4150) },
                    { 15, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4154), false, null, 15, "Failed interview", new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4154) },
                    { 16, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4158), true, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4159), 16, null, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4159) },
                    { 17, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4160), true, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4161), 17, null, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4161) },
                    { 18, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4163), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4163) },
                    { 19, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4166), true, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4166), 19, null, new DateTime(2024, 9, 22, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4167) },
                    { 20, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4168), false, null, 20, "Unverified information", new DateTime(2024, 9, 23, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4169) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4196), (short)14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4197), 3, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4198) },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4199), (short)15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4200), 4, 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4200) },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4201), (short)16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4202), 5, 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4202) },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4203), (short)17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4204), 6, 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4204) },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4205), (short)18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4206), 7, 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4206) },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4208), (short)19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4209), 8, 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4209) },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4210), (short)20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4211), 9, 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4212) },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4214), (short)12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4215), 10, 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4216) },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4218), (short)13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4219), 11, 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4219) },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4220), (short)14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4221), 12, 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4221) },
                    { 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4222), (short)15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4223), 13, 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4223) },
                    { 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4224), (short)16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4225), 14, 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4225) },
                    { 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4226), (short)17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4227), 15, 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4227) },
                    { 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4228), (short)18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4228), 16, 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4229) },
                    { 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4230), (short)19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4230), 17, 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4231) },
                    { 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4232), (short)20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4232), 18, 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4233) },
                    { 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4234), (short)12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4235), 19, 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4236) },
                    { 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4236), (short)13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4237), 20, 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4237) },
                    { 21, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4242), 1, 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4242) },
                    { 22, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4244), 2, 21, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4244) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3689), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3690), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3691), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3692), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3693), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3694), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3695), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3695), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3696), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3697), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3698), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3699), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4045), 1, 1, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4046) },
                    { 2, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4047), 2, 2, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4048) },
                    { 3, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4049), 3, 3, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4050) },
                    { 4, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4051), 4, 4, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4052) },
                    { 5, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4053), 5, 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4053) },
                    { 6, new DateTime(2024, 3, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4054), 6, 6, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4055) },
                    { 7, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4056), 7, 7, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4057) },
                    { 8, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4058), 8, 8, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4059) },
                    { 9, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4060), 9, 9, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4060) },
                    { 10, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4062), 10, 10, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4062) },
                    { 11, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4065), 11, 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4065) },
                    { 12, new DateTime(2024, 3, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4067), 12, 12, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4067) },
                    { 13, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4068), 13, 13, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4069) },
                    { 14, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4070), 14, 14, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4071) },
                    { 15, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4072), 15, 15, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4072) },
                    { 16, new DateTime(2024, 7, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4073), 16, 16, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4074) },
                    { 17, new DateTime(2024, 8, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4075), 17, 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4076) },
                    { 18, new DateTime(2024, 3, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4077), 18, 18, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4077) },
                    { 19, new DateTime(2024, 4, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4078), 19, 1, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4079) },
                    { 20, new DateTime(2024, 5, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4080), 20, 2, new DateTime(2024, 6, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4081) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3733), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3725), new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3733), "12345678" },
                    { 2, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3737), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3735), new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3737), "22345678" },
                    { 3, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3742), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3739), new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3743), "32345678" },
                    { 4, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3746), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3744), new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3746), "42345678" },
                    { 5, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3749), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3748), new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3750), "52345678" },
                    { 6, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3755), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3751), new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3756), "62345678" },
                    { 7, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3762), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3760), new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3762), "72345678" },
                    { 8, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3765), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3764), new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3766), "82345678" },
                    { 9, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3769), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3767), new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3769), "92345678" },
                    { 10, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3772), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3771), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3773), "01234567" },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3775), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3774), new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3776), "12345679" },
                    { 12, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3780), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3777), new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3780), "22345679" },
                    { 13, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3784), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3783), new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3785), "32345679" },
                    { 14, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3787), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3786), new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3788), "42345679" },
                    { 15, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3805), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3804), new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3806), "52345679" },
                    { 16, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3808), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3807), new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3809), "62345679" },
                    { 17, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3812), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3810), new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3812), "72345679" },
                    { 18, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3817), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3814), new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3818), "82345679" },
                    { 19, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3821), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3819), new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3821), "92345679" },
                    { 20, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3824), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3823), new DateTime(2024, 9, 22, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(3825), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4275), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4278) },
                    { 2, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4280), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4280) },
                    { 3, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4324), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4325) },
                    { 4, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4326), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4326) },
                    { 5, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4328), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4328) },
                    { 6, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4330), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4330) },
                    { 7, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4331), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4332) },
                    { 8, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4333), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4334) },
                    { 9, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4335), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4336) },
                    { 10, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4337), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4337) },
                    { 11, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4338), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4339) },
                    { 12, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4340), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4341) },
                    { 13, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4342), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4345) },
                    { 14, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4346), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4347) },
                    { 15, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4348), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4349) },
                    { 16, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4350), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4350) },
                    { 17, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4352), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4352) },
                    { 18, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4353), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4354) },
                    { 19, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4355), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4355) },
                    { 20, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4357), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4357) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4386), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4387) },
                    { 2, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4388), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4389) },
                    { 3, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4390), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4391) },
                    { 4, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4392), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4393) },
                    { 5, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4394), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4394) },
                    { 6, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4396), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4396) },
                    { 7, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4398), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4398) },
                    { 8, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4399), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4400) },
                    { 9, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4401), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4402) },
                    { 10, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4403), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4404) },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4405), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4406) },
                    { 12, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4408), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4409) },
                    { 13, new DateTime(2024, 9, 14, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4410), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4411) },
                    { 14, new DateTime(2024, 9, 15, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4412), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4412) },
                    { 15, new DateTime(2024, 9, 16, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4414), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4414) },
                    { 16, new DateTime(2024, 9, 17, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4415), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4416) },
                    { 17, new DateTime(2024, 9, 18, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4417), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4418) },
                    { 18, new DateTime(2024, 9, 19, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4420), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4421) },
                    { 19, new DateTime(2024, 9, 20, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4423), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4424) },
                    { 20, new DateTime(2024, 9, 21, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4425), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4426) },
                    { 21, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4427), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4427) },
                    { 22, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4429), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4429) },
                    { 23, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4431), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4431) },
                    { 24, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4432), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4433) },
                    { 25, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4434), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4435) },
                    { 26, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4436), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4437) },
                    { 27, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4438), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4438) },
                    { 28, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4440), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4440) },
                    { 29, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4441), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4442) },
                    { 30, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4443), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4444) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 25, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4473), new DateTime(2024, 8, 25, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4473), new DateTime(2024, 8, 23, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4471), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 24, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4472), 100.00m },
                    { 2, new DateTime(2024, 8, 26, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4477), new DateTime(2024, 8, 26, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4477), new DateTime(2024, 8, 24, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4475), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 25, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4476), 200.00m },
                    { 3, new DateTime(2024, 8, 27, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4480), new DateTime(2024, 8, 27, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4481), new DateTime(2024, 8, 25, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4479), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 26, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4480), 300.00m },
                    { 4, new DateTime(2024, 8, 28, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4484), new DateTime(2024, 8, 28, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 8, 26, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4483), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 27, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4483), 400.00m },
                    { 5, new DateTime(2024, 8, 29, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 8, 29, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4489), new DateTime(2024, 8, 27, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4486), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 28, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4487), 500.00m },
                    { 6, new DateTime(2024, 8, 30, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4494), new DateTime(2024, 8, 30, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4495), new DateTime(2024, 8, 28, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4493), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 29, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4493), 600.00m },
                    { 7, new DateTime(2024, 8, 31, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4498), new DateTime(2024, 8, 31, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4499), new DateTime(2024, 8, 29, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4497), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 8, 30, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4497), 700.00m },
                    { 8, new DateTime(2024, 9, 1, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4503), new DateTime(2024, 9, 1, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4504), new DateTime(2024, 8, 30, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4502), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 8, 31, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4502), 800.00m },
                    { 9, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4508), new DateTime(2024, 8, 31, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4506), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 9, 1, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4506), 900.00m },
                    { 10, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4511), new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4511), new DateTime(2024, 9, 1, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4509), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4510), 1000.00m },
                    { 11, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4514), new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4515), new DateTime(2024, 9, 2, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4513), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4514), 1100.00m },
                    { 12, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4518), new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4519), new DateTime(2024, 9, 3, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4517), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4518), 1200.00m },
                    { 13, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4523), new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4524), new DateTime(2024, 9, 4, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4522), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4523), 1300.00m },
                    { 14, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4527), new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4528), new DateTime(2024, 9, 5, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4526), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4526), 1400.00m },
                    { 15, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4531), new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4531), new DateTime(2024, 9, 6, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4530), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4530), 1500.00m },
                    { 16, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4535), new DateTime(2024, 9, 7, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4533), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4534), 1600.00m },
                    { 17, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4539), new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4540), new DateTime(2024, 9, 8, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4537), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4537), 1700.00m },
                    { 18, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4543), new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4544), new DateTime(2024, 9, 9, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4542), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4542), 1800.00m },
                    { 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4568), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4568), new DateTime(2024, 9, 10, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4567), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4567), 1900.00m },
                    { 20, new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4572), new DateTime(2024, 9, 13, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4572), new DateTime(2024, 9, 11, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4570), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4571), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4598), 8, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4599), 1 },
                    { 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4600), 9, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4600), 1 },
                    { 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4602), 10, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4602), 1 },
                    { 4, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4603), 11, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4604), 1 },
                    { 5, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4606), 12, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4607), 1 },
                    { 6, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4608), 13, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4608), 1 },
                    { 7, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4609), 14, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4610), 1 },
                    { 8, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4611), 15, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4611), 1 },
                    { 9, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4612), 16, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4613), 1 },
                    { 10, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4614), 17, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4614), 1 },
                    { 11, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4615), 18, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4616), 1 },
                    { 12, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4617), 19, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4617), 1 },
                    { 13, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4618), 20, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4619), 1 },
                    { 14, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4620), 8, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4620), 2 },
                    { 15, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4621), 9, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4622), 2 },
                    { 16, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4623), 10, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4623), 2 },
                    { 17, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4625), 11, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4625), 2 },
                    { 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4626), 12, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4626), 2 },
                    { 19, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4629), 13, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4630), 2 },
                    { 20, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4631), 14, 1, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4631), 2 },
                    { 21, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4632), 8, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4633), 3 },
                    { 22, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4634), 9, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4634), 3 },
                    { 23, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4635), 10, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4636), 3 },
                    { 24, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4637), 11, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4637), 3 },
                    { 25, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4638), 12, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4639), 4 },
                    { 26, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4640), 13, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4640), 4 },
                    { 27, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4641), 14, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4642), 4 },
                    { 28, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4643), 15, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4643), 5 },
                    { 29, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4644), 16, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4645), 5 },
                    { 30, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4646), 17, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4646), 5 },
                    { 31, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4647), 18, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4648), 6 },
                    { 32, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4649), 19, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4649), 6 },
                    { 33, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4652), 20, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4652), 0 },
                    { 34, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4653), 8, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4654), 1 },
                    { 35, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4655), 9, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4655), 1 },
                    { 36, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4656), 10, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4657), 1 },
                    { 37, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4658), 11, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4658), 2 },
                    { 38, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4659), 12, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4660), 2 },
                    { 39, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4661), 13, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4661), 2 },
                    { 40, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4662), 14, 2, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4663), 2 },
                    { 41, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4664), 8, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4664), 2 },
                    { 42, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4665), 9, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4666), 2 },
                    { 43, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4667), 10, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4668), 2 },
                    { 44, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4669), 11, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4669), 2 },
                    { 45, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4670), 12, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4671), 3 },
                    { 46, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4672), 13, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4672), 3 },
                    { 47, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4675), 14, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4675), 3 },
                    { 48, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4676), 15, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4676), 4 },
                    { 49, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4678), 16, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4678), 4 },
                    { 50, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4679), 17, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4679), 4 },
                    { 51, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4681), 18, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4681), 5 },
                    { 52, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4682), 19, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4682), 5 },
                    { 53, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4684), 20, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4684), 6 },
                    { 54, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4685), 8, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4685), 0 },
                    { 55, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4687), 9, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4687), 0 },
                    { 56, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4688), 10, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4689), 1 },
                    { 57, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4690), 11, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4690), 1 },
                    { 58, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4693), 12, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4693), 1 },
                    { 59, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4694), 13, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4695), 1 },
                    { 60, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4696), 14, 3, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4696), 2 }
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
                    { 1, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4736), 1, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4737), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4736), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4734) },
                    { 2, new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4740), 2, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4740), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4739), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4738) },
                    { 3, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4743), 3, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4744), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4742), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4742) },
                    { 4, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4746), 4, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4747), new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4746), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4745) },
                    { 5, new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4749), 5, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4750), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4749), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4748) },
                    { 6, new DateTime(2017, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4752), 6, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4753), new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4752), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4751) },
                    { 7, new DateTime(2016, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4756), 7, new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4756), new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4755), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4754) },
                    { 8, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4759), 8, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4760), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4758), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4758) },
                    { 9, new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4762), 9, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4763), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4762), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4761) },
                    { 10, new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4820), 10, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4821), new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4819), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4819) },
                    { 11, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4823), 11, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4824), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4823), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4822) },
                    { 12, new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4826), 12, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4827), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4826), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4825) },
                    { 13, new DateTime(2017, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4829), 13, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4830), new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4829), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4828) },
                    { 14, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4832), 14, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4833), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4831), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4831) },
                    { 15, new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4835), 15, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4835), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4834), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4834) },
                    { 16, new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4840), 16, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4840), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4839), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4838) },
                    { 17, new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4842), 17, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4843), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4842), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4841) },
                    { 18, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4845), 18, new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4846), new DateTime(2024, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4845), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4844) },
                    { 19, new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4848), 19, new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4849), new DateTime(2023, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4848), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4847) },
                    { 20, new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4851), 20, new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4852), new DateTime(2022, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4851), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 12, 0, 52, 29, 653, DateTimeKind.Local).AddTicks(4850) }
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
                name: "ShoppingCarts");

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
