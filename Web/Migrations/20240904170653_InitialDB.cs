using System;
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
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7193), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7191), true, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7193) },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7196), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7195), true, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7197) },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7199), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7198), false, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7199) },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7202), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7201), true, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7202) },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7204), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7203), false, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7205) },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7207), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7206), true, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7207) },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7209), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7208), false, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7209) },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7211), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7211), true, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7212) },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7214), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7213), false, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7214) },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7217), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7216), true, new DateTime(2024, 9, 15, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7217) },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7219), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7218), true, new DateTime(2024, 9, 16, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7219) },
                    { 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7221), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7220), true, new DateTime(2024, 9, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7221) },
                    { 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7223), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7223), false, new DateTime(2024, 9, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7224) },
                    { 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7229), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7228), true, new DateTime(2024, 9, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7229) },
                    { 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7231), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7230), true, new DateTime(2024, 9, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7231) },
                    { 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7233), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7233), true, new DateTime(2024, 9, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7234) },
                    { 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7236), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7235), true, new DateTime(2024, 9, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7236) },
                    { 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7245), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7237), true, new DateTime(2024, 9, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7246) },
                    { 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7248), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7247), true, new DateTime(2024, 9, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7248) },
                    { 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7254), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7253), true, new DateTime(2024, 9, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7254) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6815), null },
                    { 2, "程式設計", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6816), null },
                    { 3, "升學科目", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6817), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8300), "00:00", null },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8302), "01:00", null },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8303), "02:00", null },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8304), "03:00", null },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8305), "04:00", null },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8306), "05:00", null },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8307), "06:00", null },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8307), "07:00", null },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8308), "08:00", null },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8309), "09:00", null },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8310), "10:00", null },
                    { 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8311), "11:00", null },
                    { 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8312), "12:00", null },
                    { 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8313), "13:00", null },
                    { 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8313), "14:00", null },
                    { 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8314), "15:00", null },
                    { 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8315), "16:00", null },
                    { 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8316), "17:00", null },
                    { 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8317), "18:00", null },
                    { 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8318), "19:00", null },
                    { 21, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8319), "20:00", null },
                    { 22, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8320), "21:00", null },
                    { 23, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8321), "22:00", null },
                    { 24, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8322), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6176), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6191), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6192), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6193), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6195), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6196), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6197), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6246), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6247), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6248), "Biology", "University of Toronto", 2016, 2012, null }
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
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6838), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6840), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6841), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6842), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6843), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6844), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6845), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6848), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6849), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6850), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6850), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6851), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6852), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6853), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6854), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6855), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6856), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6857), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6580), (short)1, "適合初學者的英文課程", 90m, true, "從零開始學英文", 1, "https://example.com/courses/english.jpg", "基礎英文", 1, 50m, null, "https://example.com/courses/english_intro.mp4" },
                    { 2, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6584), (short)1, "基礎日語語法和詞彙", 100m, true, "日語學習的基礎", 2, "https://example.com/courses/japanese.jpg", "日語入門", 2, 60m, null, "https://example.com/courses/japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6587), (short)1, "全面學習中文語法", 120m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 70m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6590), (short)1, "提高德語口語能力", 110m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 65m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6592), (short)1, "提升法語閱讀能力", 95m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 55m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6595), (short)1, "提高西班牙語寫作能力", 100m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 60m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6598), (short)1, "從頭開始學習HTML和CSS", 125m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 75m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6601), (short)1, "學習JavaScript語法和應用", 140m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 85m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6603), (short)1, "深入學習C#編程", 150m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 90m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6606), (short)1, "從零開始學習SQL", 130m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 80m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6609), (short)1, "從頭開始學習Python編程", 140m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 85m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6611), (short)1, "從零開始學習Java語言", 150m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 90m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6614), (short)1, "提升數學基礎知識", 100m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 60m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6668), (short)1, "物理學基礎知識", 110m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 65m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6671), (short)1, "全面了解化學基礎知識", 120m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 70m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6674), (short)1, "歷史事件和背景的深入分析", 125m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 75m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6677), (short)1, "全面了解地理學的基礎", 110m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 65m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6679), (short)1, "深入學習生物學的基本概念", 120m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 70m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6682), (short)1, "深入練習英語會話和詞彙", 180m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 100m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6684), (short)1, "提升日語會話和語法能力", 200m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 110m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6687), (short)1, "深入學習中文語法和詞彙", 220m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 120m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6689), (short)1, "德語會話和詞彙的深入練習", 240m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 130m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6698), (short)1, "法語閱讀和寫作的深入研究", 230m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 125m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6701), (short)1, "西班牙語寫作和語法的深入練習", 250m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 135m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6703), (short)1, "高級網頁設計和開發技術", 270m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 150m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6706), (short)1, "JavaScript編程的高級應用和技巧", 280m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 160m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6708), (short)1, "深入掌握C#編程的高級技術", 300m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 170m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6711), (short)1, "SQL資料庫管理和優化的高級技術", 275m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 155m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6713), (short)1, "Python編程的高級應用和數據處理", 290m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 165m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6716), (short)1, "Java編程的高級技術和應用", 310m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 175m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6719), (short)1, "高等數學理論和應用", 250m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 140m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6722), (short)1, "物理學的高級理論和應用", 255m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 145m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6724), (short)1, "化學的高級理論和應用", 260m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 150m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6727), (short)1, "歷史研究的高級技術和方法", 275m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 160m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6755), (short)1, "地理學的高級理論和應用", 265m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 150m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6758), (short)1, "生物學的高級理論和應用", 275m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 160m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6760), (short)1, "專業英文寫作的高級技巧", 320m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 180m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6764), (short)1, "專業日語寫作的高級技巧", 340m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 190m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6766), (short)1, "專業中文寫作的高級技巧", 360m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 200m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6771), (short)1, "專業德語寫作的高級技巧", 380m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 210m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6285), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6297), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6298) },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6302), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6304), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6305) },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6308), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6310), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6311) },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6317), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6319), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6319) },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6322), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6324), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6324) },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6327), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6328), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6329) },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6332), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6334), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6334) },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6337), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6338), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6339) },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6341), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6343), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6343) },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6346), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6348), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6348) },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6351), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6352), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6354) },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6356), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6358), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6358) },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6405), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6408), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6408) },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6411), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6413), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6413) },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6416), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6417), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6418) },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6420), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6423), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6423) },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6427), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6429), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6430) },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6432), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6434), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6434) },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6437), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6439), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6440) },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6443), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6444), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6445) },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6448), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6450), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6450) },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6453), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6454), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6455) },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6458), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6459), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6459) },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6462), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6468), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6469) },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6471), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6474), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6474) },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6477), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6478), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6479) },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6507), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6509), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6509) },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6512), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6514), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6514) },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6517), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6518), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6519) },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6522), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6524), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6524) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7383), true, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7384), 1, null, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7384) },
                    { 2, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7386), false, null, 2, "Incomplete application", new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7387) },
                    { 3, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7388), true, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7388), 3, null, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7389) },
                    { 4, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7390), false, null, 4, "Failed verification", new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7391) },
                    { 5, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7392), true, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7392), 5, null, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7393) },
                    { 6, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7394), true, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7395), 6, null, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7395) },
                    { 7, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7396), false, null, 7, "Incorrect details", new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7397) },
                    { 8, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7398), true, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7398), 8, null, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7399) },
                    { 9, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7400), true, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7401), 9, null, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7401) },
                    { 10, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7403), false, null, 10, "Missing documents", new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7403) },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7405), true, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7405), 11, null, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7406) },
                    { 12, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7407), false, null, 12, "Not eligible", new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7407) },
                    { 13, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7409), true, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7409), 13, null, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7410) },
                    { 14, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7411), true, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7411), 14, null, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7412) },
                    { 15, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7413), false, null, 15, "Failed interview", new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7414) },
                    { 16, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7415), true, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7415), 16, null, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7416) },
                    { 17, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7417), true, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7418), 17, null, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7418) },
                    { 18, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7419), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7420) },
                    { 19, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7422), true, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7422), 19, null, new DateTime(2024, 9, 15, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7423) },
                    { 20, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7424), false, null, 20, "Unverified information", new DateTime(2024, 9, 16, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7424) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7521), (short)900, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7522), 1, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7522) },
                    { 2, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7524), (short)1100, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7524), 2, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7525) },
                    { 3, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7526), (short)1400, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7527), 3, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7527) },
                    { 4, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7528), (short)1500, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7532), 4, 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7532) },
                    { 5, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7533), (short)1600, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7534), 5, 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7534) },
                    { 6, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7535), (short)1000, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7536), 6, 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7536) },
                    { 7, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7537), (short)900, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7538), 7, 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7538) },
                    { 8, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7539), (short)1100, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7540), 8, 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7541) },
                    { 9, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7542), (short)1400, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7542), 9, 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7543) },
                    { 10, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7544), (short)1500, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7544), 10, 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7545) },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7546), (short)1600, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7547), 11, 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7547) },
                    { 12, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7548), (short)1000, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7549), 12, 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7549) },
                    { 13, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7550), (short)900, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7551), 13, 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7551) },
                    { 14, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7552), (short)1100, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7553), 14, 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7553) },
                    { 15, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7554), (short)1400, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7554), 15, 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7555) },
                    { 16, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7556), (short)1500, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7556), 16, 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7557) },
                    { 17, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7558), (short)1600, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7558), 17, 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7559) },
                    { 18, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7560), (short)1000, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7560), 18, 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7561) },
                    { 19, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7562), (short)900, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7563), 19, 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7563) },
                    { 20, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7564), (short)1100, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7565), 20, 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7565) },
                    { 21, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7566), (short)1200, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7567), 21, 21, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7567) },
                    { 22, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7568), (short)1300, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7569), 22, 22, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7569) },
                    { 23, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7570), (short)900, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7571), 23, 23, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7571) },
                    { 24, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7572), (short)1100, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7573), 24, 24, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7573) },
                    { 25, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7574), (short)1400, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7574), 25, 25, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7575) },
                    { 26, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7576), (short)1500, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7576), 26, 26, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7577) },
                    { 27, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7578), (short)1600, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7578), 27, 27, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7579) },
                    { 28, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7580), (short)1000, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7580), 28, 28, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7581) },
                    { 29, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7582), (short)1200, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7583), 29, 29, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7583) },
                    { 30, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7584), (short)1400, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7585), 30, 30, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7585) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6884), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6886), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6886), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6887), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6888), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6889), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6890), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6891), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6891), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6892), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6893), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6894), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7304), 1, 1, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7308) },
                    { 2, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7313), 2, 2, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7314) },
                    { 3, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7315), 3, 3, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7315) },
                    { 4, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7316), 4, 4, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7319) },
                    { 5, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7320), 5, 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7320) },
                    { 6, new DateTime(2024, 3, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7321), 6, 6, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7322) },
                    { 7, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7323), 7, 7, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7324) },
                    { 8, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7325), 8, 8, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7325) },
                    { 9, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7327), 9, 9, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7328) },
                    { 10, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7329), 10, 10, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7329) },
                    { 11, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7330), 11, 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7331) },
                    { 12, new DateTime(2024, 3, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7332), 12, 12, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7332) },
                    { 13, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7334), 13, 13, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7334) },
                    { 14, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7335), 14, 14, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7336) },
                    { 15, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7337), 15, 15, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7338) },
                    { 16, new DateTime(2024, 7, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7339), 16, 16, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7340) },
                    { 17, new DateTime(2024, 8, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7341), 17, 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7341) },
                    { 18, new DateTime(2024, 3, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7342), 18, 18, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7343) },
                    { 19, new DateTime(2024, 4, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7344), 19, 1, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7344) },
                    { 20, new DateTime(2024, 5, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7345), 20, 2, new DateTime(2024, 6, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7346) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6991), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6984), new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6992), "12345678" },
                    { 2, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6996), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6994), new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(6996), "22345678" },
                    { 3, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7002), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7001), new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7003), "32345678" },
                    { 4, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7005), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7004), new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7006), "42345678" },
                    { 5, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7008), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7007), new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7009), "52345678" },
                    { 6, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7011), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7010), new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7013), "62345678" },
                    { 7, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7015), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7014), new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7016), "72345678" },
                    { 8, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7018), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7017), new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7019), "82345678" },
                    { 9, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7021), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7022), "92345678" },
                    { 10, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7024), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7023), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7025), "01234567" },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7027), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7027), "12345679" },
                    { 12, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7031), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7029), new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7031), "22345679" },
                    { 13, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7034), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7033), new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7034), "32345679" },
                    { 14, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7037), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7036), new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7037), "42345679" },
                    { 15, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7040), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7039), new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7040), "52345679" },
                    { 16, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7043), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7042), new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7044), "62345679" },
                    { 17, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7047), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7046), new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7048), "72345679" },
                    { 18, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7050), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7049), new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7051), "82345679" },
                    { 19, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7054), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7052), new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7054), "92345679" },
                    { 20, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7057), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7055), new DateTime(2024, 9, 15, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7058), "01234579" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7626), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7628) },
                    { 2, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7630), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7630) },
                    { 3, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7631), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7632) },
                    { 4, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7633), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7634) },
                    { 5, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7635), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7635) },
                    { 6, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7636), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7637) },
                    { 7, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7638), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7639) },
                    { 8, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7640), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7640) },
                    { 9, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7641), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7642) },
                    { 10, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7643), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7643) },
                    { 11, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7645), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7646) },
                    { 12, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7647), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7647) },
                    { 13, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7648), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7649) },
                    { 14, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7650), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7650) },
                    { 15, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7651), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7652) },
                    { 16, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7653), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7653) },
                    { 17, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7654), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7655) },
                    { 18, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7656), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7656) },
                    { 19, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7657), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7658) },
                    { 20, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7659), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7660) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7689), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7690) },
                    { 2, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7692), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7692) },
                    { 3, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7694), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7695) },
                    { 4, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7696), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7696) },
                    { 5, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7697), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7698) },
                    { 6, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7699), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7699) },
                    { 7, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7701), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7702) },
                    { 8, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7703), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7703) },
                    { 9, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7704), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7705) },
                    { 10, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7706), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7706) },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7708), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7709) },
                    { 12, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7710), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7710) },
                    { 13, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7711), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7712) },
                    { 14, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7714), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7715) },
                    { 15, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7716), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7717) },
                    { 16, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7718), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7719) },
                    { 17, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7720), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7720) },
                    { 18, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7722), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7722) },
                    { 19, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7723), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7724) },
                    { 20, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7725), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7725) },
                    { 21, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7727), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7728) },
                    { 22, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7730), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7730) },
                    { 23, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7732), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7732) },
                    { 24, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7810), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7810) },
                    { 25, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7811), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7812) },
                    { 26, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7814), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7814) },
                    { 27, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7817), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7817) },
                    { 28, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7819), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7820) },
                    { 29, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7821), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7822) },
                    { 30, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7824), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7825) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7866), new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7867), new DateTime(2024, 8, 16, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7863), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7865), 100.00m },
                    { 2, new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7872), new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7873), new DateTime(2024, 8, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7871), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7872), 200.00m },
                    { 3, new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7877), new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7877), new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7875), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7876), 300.00m },
                    { 4, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7880), new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7881), new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7879), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7880), 400.00m },
                    { 5, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7885), new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7886), new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7884), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7885), 500.00m },
                    { 6, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7889), new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7889), new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7888), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7888), 600.00m },
                    { 7, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7894), new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7895), new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7892), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7893), 700.00m },
                    { 8, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7898), new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7898), new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7897), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7897), 800.00m },
                    { 9, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7901), new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7902), new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7900), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7900), 900.00m },
                    { 10, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7904), new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7905), new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7903), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7904), 1000.00m },
                    { 11, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7907), new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7908), new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7906), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7907), 1100.00m },
                    { 12, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7914), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7914), 1200.00m },
                    { 13, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7918), new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7919), new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7917), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7917), 1300.00m },
                    { 14, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7922), new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7924), new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7920), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7921), 1400.00m },
                    { 15, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7927), new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7927), new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7925), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7926), 1500.00m },
                    { 16, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7930), new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7931), new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7929), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7930), 1600.00m },
                    { 17, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7936), new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7936), new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7934), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7935), 1700.00m },
                    { 18, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7940), new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7941), new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7938), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7939), 1800.00m },
                    { 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7944), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7945), new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7943), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7944), 1900.00m },
                    { 20, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7949), new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7950), new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7947), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7948), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8143), 1, 1, new DateTime(2024, 9, 6, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8144), 1 },
                    { 2, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8146), 2, 2, new DateTime(2024, 9, 7, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8146), 2 },
                    { 3, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8148), 3, 3, new DateTime(2024, 9, 8, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8148), 3 },
                    { 4, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8149), 4, 4, new DateTime(2024, 9, 9, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8150), 4 },
                    { 5, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8151), 5, 5, new DateTime(2024, 9, 10, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8152), 5 },
                    { 6, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8153), 6, 6, new DateTime(2024, 9, 11, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8153), 6 },
                    { 7, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8154), 7, 7, new DateTime(2024, 9, 12, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8155), 7 },
                    { 8, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8156), 8, 8, new DateTime(2024, 9, 13, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8156), 1 },
                    { 9, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8159), 9, 9, new DateTime(2024, 9, 14, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8160), 2 },
                    { 10, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8161), 10, 10, new DateTime(2024, 9, 15, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8161), 3 },
                    { 11, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8163), 11, 11, new DateTime(2024, 9, 16, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8163), 4 },
                    { 12, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8164), 12, 12, new DateTime(2024, 9, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8165), 5 },
                    { 13, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8166), 13, 13, new DateTime(2024, 9, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8166), 6 },
                    { 14, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8168), 14, 14, new DateTime(2024, 9, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8169), 7 },
                    { 15, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8170), 15, 15, new DateTime(2024, 9, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8170), 1 },
                    { 16, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8171), 16, 16, new DateTime(2024, 9, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8172), 2 },
                    { 17, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8173), 17, 17, new DateTime(2024, 9, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8174), 3 },
                    { 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8175), 18, 18, new DateTime(2024, 9, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8175), 4 },
                    { 19, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8176), 19, 19, new DateTime(2024, 9, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8177), 5 },
                    { 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8178), 20, 20, new DateTime(2024, 9, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8178), 6 }
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
                    { 1, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8209), 1, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8210), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8208), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8207) },
                    { 2, new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8212), 2, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8213), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8212), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8211) },
                    { 3, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8218), 3, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8218), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8217), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8216) },
                    { 4, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8221), 4, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8221), new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8220), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8219) },
                    { 5, new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8223), 5, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8224), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8223), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8222) },
                    { 6, new DateTime(2017, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8226), 6, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8227), new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8226), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8225) },
                    { 7, new DateTime(2016, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8229), 7, new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8230), new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8229), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8228) },
                    { 8, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8233), 8, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8233), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8232), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8231) },
                    { 9, new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8236), 9, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8237), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8236), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8235) },
                    { 10, new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8239), 10, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8240), new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8239), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8238) },
                    { 11, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8243), 11, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8243), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8242), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8242) },
                    { 12, new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8246), 12, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8246), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8245), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8245) },
                    { 13, new DateTime(2017, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8249), 13, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8250), new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8248), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8248) },
                    { 14, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8252), 14, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8253), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8251), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8251) },
                    { 15, new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8255), 15, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8255), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8254), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8254) },
                    { 16, new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8258), 16, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8258), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8257), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8257) },
                    { 17, new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8261), 17, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8261), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8260), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8260) },
                    { 18, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8264), 18, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8264), new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8263), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8263) },
                    { 19, new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8267), 19, new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8268), new DateTime(2023, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8267), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8265) },
                    { 20, new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8270), 20, new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8271), new DateTime(2022, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8270), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8269) }
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
                    { 1, new DateOnly(2024, 8, 16), (short)10, new DateTime(2024, 8, 16, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7996), 1, 1, 1, new DateTime(2024, 8, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(7997) },
                    { 2, new DateOnly(2024, 8, 17), (short)11, new DateTime(2024, 8, 17, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8000), 2, 2, 2, new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8001) },
                    { 3, new DateOnly(2024, 8, 18), (short)12, new DateTime(2024, 8, 18, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8003), 3, 3, 3, new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8004) },
                    { 4, new DateOnly(2024, 8, 19), (short)13, new DateTime(2024, 8, 19, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8007), 4, 4, 4, new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8008) },
                    { 5, new DateOnly(2024, 8, 20), (short)14, new DateTime(2024, 8, 20, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8011), 5, 5, 5, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8011) },
                    { 6, new DateOnly(2024, 8, 21), (short)15, new DateTime(2024, 8, 21, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8013), 6, 6, 6, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8014) },
                    { 7, new DateOnly(2024, 8, 22), (short)16, new DateTime(2024, 8, 22, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8017), 7, 7, 7, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8017) },
                    { 8, new DateOnly(2024, 8, 23), (short)17, new DateTime(2024, 8, 23, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8020), 8, 8, 8, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8020) },
                    { 9, new DateOnly(2024, 8, 24), (short)18, new DateTime(2024, 8, 24, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8023), 9, 9, 9, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8024) },
                    { 10, new DateOnly(2024, 8, 25), (short)19, new DateTime(2024, 8, 25, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8026), 10, 10, 10, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8026) },
                    { 11, new DateOnly(2024, 8, 26), (short)20, new DateTime(2024, 8, 26, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8029), 11, 11, 11, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8029) },
                    { 12, new DateOnly(2024, 8, 27), (short)21, new DateTime(2024, 8, 27, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8031), 12, 12, 12, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8032) },
                    { 13, new DateOnly(2024, 8, 28), (short)22, new DateTime(2024, 8, 28, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8034), 13, 13, 13, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8035) },
                    { 14, new DateOnly(2024, 8, 29), (short)23, new DateTime(2024, 8, 29, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8037), 14, 14, 14, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8037) },
                    { 15, new DateOnly(2024, 8, 30), (short)24, new DateTime(2024, 8, 30, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8040), 15, 15, 15, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8041) },
                    { 16, new DateOnly(2024, 8, 31), (short)25, new DateTime(2024, 8, 31, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8043), 16, 16, 16, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8044) },
                    { 17, new DateOnly(2024, 9, 1), (short)26, new DateTime(2024, 9, 1, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8046), 17, 17, 17, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8046) },
                    { 18, new DateOnly(2024, 9, 2), (short)27, new DateTime(2024, 9, 2, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8048), 18, 18, 18, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8049) },
                    { 19, new DateOnly(2024, 9, 3), (short)28, new DateTime(2024, 9, 3, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8051), 19, 19, 19, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8052) },
                    { 20, new DateOnly(2024, 9, 4), (short)29, new DateTime(2024, 9, 4, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8054), 20, 20, 20, new DateTime(2024, 9, 5, 1, 6, 52, 831, DateTimeKind.Local).AddTicks(8054) }
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
