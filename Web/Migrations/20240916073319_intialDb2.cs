using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class intialDb2 : Migration
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
                    CouponName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true, comment: "優惠折扣名稱"),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "折扣代碼"),
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
                    CategorytName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "課程類別名稱"),
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
                    Hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "小時時段"),
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
                    SchoolName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "學校名稱"),
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
                    NationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "國籍名稱"),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "國籍圖片路徑")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nations__211B9BBEE3B01F5C", x => x.NationId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "課程標題"),
                    SubTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "課程副標題"),
                    TwentyFiveMinUnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "25分鐘價"),
                    FiftyMinUnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "50分鐘價"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "課程詳細描述"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "是否顯示"),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "影片封面"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "影片路徑"),
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
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "課程科目名稱"),
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
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "名字"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "姓氏"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "密碼"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "電子郵件信箱"),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "綽號"),
                    Phone = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true, comment: "電話"),
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
                    IsTutor = table.Column<bool>(type: "bit", nullable: false, comment: "是否為教師"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Members__0CF04B1808627D7C", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    CourseImageId = table.Column<int>(type: "int", nullable: false, comment: "課程照片Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "課程Id"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "圖片路徑"),
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
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "付款方式"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false, comment: "總金額"),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "交易日期"),
                    CouponPrice = table.Column<decimal>(type: "money", nullable: true, comment: "優惠金額"),
                    TaxIdNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "統一編號"),
                    InvoiceType = table.Column<short>(type: "smallint", nullable: false, comment: "發票類型"),
                    Vatnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ProfessionalLicenseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "證照名稱"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "會員Id"),
                    ProfessionalLicenseUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "證照路徑"),
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
                    WorkExperienceFile = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "工作經驗檔案路徑"),
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
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3208), "WELCOME10", "Welcome10", 10, 1, new DateTime(2024, 10, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3203), true, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3208) },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3211), "SUMMER20", "SummerSale", 20, 2, new DateTime(2024, 11, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3210), true, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3212) },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3214), "FALL15", "FallSavings", 15, 1, new DateTime(2024, 12, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3214), false, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3215) },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3217), "WINTER25", "WinterDeal", 25, 2, new DateTime(2025, 1, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3216), true, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3218) },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3219), "SPRING30", "SpringSave", 30, 1, new DateTime(2025, 2, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3219), false, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3220) },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3222), "HOLIDAY50", "Holiday50", 50, 2, new DateTime(2025, 3, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3221), true, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3222) },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3224), "NEWYEAR15", "NewYear15", 15, 1, new DateTime(2025, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3223), false, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3224) },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3226), "CYBER20", "CyberMonday", 20, 2, new DateTime(2025, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3226), true, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3226) },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3228), "BLACK30", "BlackFriday", 30, 1, new DateTime(2025, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3228), false, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3229) },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3231), "WELCOME5", "WelcomeBack", 5, 2, new DateTime(2025, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3230), true, new DateTime(2024, 9, 26, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3231) },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3233), "SCHOOL25", "BackToSchool", 25, 1, new DateTime(2025, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3232), true, new DateTime(2024, 9, 27, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3233) },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3235), "EARLY10", "EarlyBird", 10, 2, new DateTime(2025, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3234), true, new DateTime(2024, 9, 28, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3235) },
                    { 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3237), "FLASH50", "FlashSale", 50, 1, new DateTime(2025, 10, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3237), false, new DateTime(2024, 9, 29, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3238) },
                    { 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3240), "NEWCUST20", "NewCustomer", 20, 2, new DateTime(2025, 11, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3239), true, new DateTime(2024, 9, 30, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3240) },
                    { 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3242), "LOYALTY10", "LoyaltyReward", 10, 1, new DateTime(2025, 12, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3242), true, new DateTime(2024, 10, 1, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3242) },
                    { 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3244), "REFERRAL15", "ReferralBonus", 15, 2, new DateTime(2026, 1, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3244), true, new DateTime(2024, 10, 2, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3245) },
                    { 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3247), "SUMMER10", "SummerSpecial", 10, 1, new DateTime(2026, 2, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3246), true, new DateTime(2024, 10, 3, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3247) },
                    { 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3249), "WINTER20", "WinterWonder", 20, 2, new DateTime(2026, 3, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3248), true, new DateTime(2024, 10, 4, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3249) },
                    { 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3251), "SPRING25", "SpringBlossom", 25, 1, new DateTime(2026, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3251), true, new DateTime(2024, 10, 5, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3252) },
                    { 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3253), "AUTUMN15", "AutumnLeaves", 15, 2, new DateTime(2026, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3253), true, new DateTime(2024, 10, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3254) }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "UDate" },
                values: new object[,]
                {
                    { 1, "語言學習", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2929), null },
                    { 2, "程式設計", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2931), null },
                    { 3, "升學科目", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2932), null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4213), "00:00", null },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4215), "01:00", null },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4216), "02:00", null },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4217), "03:00", null },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4218), "04:00", null },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4219), "05:00", null },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4220), "06:00", null },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4221), "07:00", null },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4222), "08:00", null },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4223), "09:00", null },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4223), "10:00", null },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4224), "11:00", null },
                    { 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4225), "12:00", null },
                    { 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4238), "13:00", null },
                    { 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4239), "14:00", null },
                    { 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4240), "15:00", null },
                    { 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4241), "16:00", null },
                    { 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4242), "17:00", null },
                    { 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4243), "18:00", null },
                    { 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4243), "19:00", null },
                    { 21, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4244), "20:00", null },
                    { 22, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4245), "21:00", null },
                    { 23, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4246), "22:00", null },
                    { 24, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4247), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2396), "Computer Science", "National Taiwan University", 2014, 2010, null },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2407), "Economics", "Kyoto University", 2016, 2012, null },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2409), "Engineering", "Seoul National University", 2015, 2011, null },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2410), "Law", "Harvard University", 2012, 2008, null },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2412), "Business", "Stanford University", 2013, 2009, null },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2413), "Philosophy", "University of Oxford", 2011, 2007, null },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2414), "Mathematics", "University of Cambridge", 2010, 2006, null },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2415), "Physics", "Massachusetts Institute of Technology", 2017, 2013, null },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2416), "Chemistry", "University of California, Berkeley", 2014, 2010, null },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2418), "Biology", "University of Toronto", 2016, 2012, null }
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
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2946), 1, "英文", null },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2947), 1, "日文", null },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2948), 1, "中文", null },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2949), 1, "德文", null },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2950), 1, "法文", null },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2951), 1, "西班牙文", null },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2952), 2, "HTML/CSS", null },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2953), 2, "JavaScript", null },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2954), 2, "C#", null },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2955), 2, "SQL", null },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2956), 2, "Python", null },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2957), 2, "Java", null },
                    { 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2958), 3, "數學", null },
                    { 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2959), 3, "物理", null },
                    { 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2960), 3, "化學", null },
                    { 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2961), 3, "歷史", null },
                    { 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2962), 3, "地理", null },
                    { 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2963), 3, "生物", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2764), (short)1, "適合初學者的英文課程", 595m, true, "從零開始學英文", 1, "/image/thumb_nails/thumbnail_demo_tw_001.webp", "基礎英文", 1, 350m, null, "https://www.youtube.com/embed/1ZYbU82GVz4" },
                    { 2, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2768), (short)1, "基礎日語語法和詞彙", 680m, true, "日語學習的基礎", 2, "/image/thumb_nails/thumbnail_demo_jp_001.webp", "日語入門", 2, 400m, null, "https://www.youtube.com/embed/BWAK0J8Uhzk" },
                    { 3, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2771), (short)1, "全面學習中文語法", 875m, true, "掌握中文語法", 3, "https://example.com/courses/chinese.jpg", "中文語法", 3, 500m, null, "https://example.com/courses/chinese_intro.mp4" },
                    { 4, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2773), (short)1, "提高德語口語能力", 935m, true, "學習德語會話技巧", 4, "https://example.com/courses/german.jpg", "德語會話", 4, 550m, null, "https://example.com/courses/german_intro.mp4" },
                    { 5, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2776), (short)1, "提升法語閱讀能力", 510m, true, "學習法語閱讀理解", 5, "https://example.com/courses/french.jpg", "法語閱讀", 5, 300m, null, "https://example.com/courses/french_intro.mp4" },
                    { 6, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2778), (short)1, "提高西班牙語寫作能力", 1440m, true, "掌握西班牙語寫作技巧", 6, "https://example.com/courses/spanish.jpg", "西班牙語寫作", 6, 800m, null, "https://example.com/courses/spanish_intro.mp4" },
                    { 7, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2780), (short)1, "從頭開始學習HTML和CSS", 765m, true, "學習網頁開發基礎", 7, "https://example.com/courses/html_css.jpg", "HTML/CSS 基礎", 7, 450m, null, "https://example.com/courses/html_css_intro.mp4" },
                    { 8, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2783), (short)1, "學習JavaScript語法和應用", 1050m, true, "JavaScript 編程基礎", 8, "https://example.com/courses/javascript.jpg", "JavaScript 編程", 8, 600m, null, "https://example.com/courses/javascript_intro.mp4" },
                    { 9, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2785), (short)1, "深入學習C#編程", 1620m, true, "掌握C#的進階技巧", 9, "https://example.com/courses/csharp.jpg", "C# 進階", 9, 900m, null, "https://example.com/courses/csharp_intro.mp4" },
                    { 10, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2788), (short)1, "從零開始學習SQL", 595m, true, "學習SQL語法和資料庫操作", 10, "https://example.com/courses/sql.jpg", "SQL 資料庫", 10, 350m, null, "https://example.com/courses/sql_intro.mp4" },
                    { 11, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2791), (short)1, "從頭開始學習Python編程", 935m, true, "掌握Python的基礎知識", 11, "https://example.com/courses/python.jpg", "Python 入門", 11, 550m, null, "https://example.com/courses/python_intro.mp4" },
                    { 12, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2793), (short)1, "從零開始學習Java語言", 1080m, true, "Java編程的入門課程", 12, "https://example.com/courses/java.jpg", "Java 基礎", 12, 600m, null, "https://example.com/courses/java_intro.mp4" },
                    { 13, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2795), (short)1, "提升數學基礎知識", 540m, true, "學習數學的基本概念", 13, "https://example.com/courses/math.jpg", "數學基礎", 13, 300m, null, "https://example.com/courses/math_intro.mp4" },
                    { 14, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2798), (short)1, "物理學基礎知識", 630m, true, "學習物理的基本理論", 14, "https://example.com/courses/physics.jpg", "物理入門", 14, 350m, null, "https://example.com/courses/physics_intro.mp4" },
                    { 15, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2800), (short)1, "全面了解化學基礎知識", 680m, true, "學習化學的基本概念", 15, "https://example.com/courses/chemistry.jpg", "化學基礎", 15, 400m, null, "https://example.com/courses/chemistry_intro.mp4" },
                    { 16, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2803), (short)1, "歷史事件和背景的深入分析", 1050m, true, "深入了解歷史事件", 16, "https://example.com/courses/history.jpg", "歷史研究", 16, 600m, null, "https://example.com/courses/history_intro.mp4" },
                    { 17, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2805), (short)1, "全面了解地理學的基礎", 875m, true, "學習地理的基本知識", 17, "https://example.com/courses/geography.jpg", "地理概論", 17, 500m, null, "https://example.com/courses/geography_intro.mp4" },
                    { 18, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2808), (short)1, "深入學習生物學的基本概念", 1350m, true, "深入理解生物學", 18, "https://example.com/courses/biology.jpg", "生物學基礎", 18, 750m, null, "https://example.com/courses/biology_intro.mp4" },
                    { 19, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2810), (short)1, "深入練習英語會話和詞彙", 1135m, true, "提升英語會話能力", 1, "https://example.com/courses/advanced_english.jpg", "高級英文", 19, 650m, null, "https://example.com/courses/advanced_english_intro.mp4" },
                    { 20, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2813), (short)1, "提升日語會話和語法能力", 1225m, true, "提升日語語法和會話技巧", 2, "https://example.com/courses/advanced_japanese.jpg", "進階日語", 20, 700m, null, "https://example.com/courses/advanced_japanese_intro.mp4" },
                    { 21, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2826), (short)1, "深入學習中文語法和詞彙", 1480m, true, "提升中文語法和詞彙", 3, "https://example.com/courses/advanced_chinese.jpg", "高級中文", 21, 850m, null, "https://example.com/courses/advanced_chinese_intro.mp4" },
                    { 22, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2828), (short)1, "德語會話和詞彙的深入練習", 990m, true, "提升德語會話技巧", 4, "https://example.com/courses/advanced_german.jpg", "高級德語", 22, 550m, null, "https://example.com/courses/advanced_german_intro.mp4" },
                    { 23, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2831), (short)1, "法語閱讀和寫作的深入研究", 1365m, true, "提升法語閱讀和寫作能力", 5, "https://example.com/courses/advanced_french.jpg", "高級法語", 23, 780m, null, "https://example.com/courses/advanced_french_intro.mp4" },
                    { 24, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2833), (short)1, "西班牙語寫作和語法的深入練習", 1620m, true, "提升西班牙語寫作和語法", 6, "https://example.com/courses/advanced_spanish.jpg", "高級西班牙語", 24, 900m, null, "https://example.com/courses/advanced_spanish_intro.mp4" },
                    { 25, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2835), (short)1, "高級網頁設計和開發技術", 925m, true, "深入學習HTML和CSS技術", 7, "https://example.com/courses/advanced_html_css.jpg", "高級HTML/CSS", 25, 500m, null, "https://example.com/courses/advanced_html_css_intro.mp4" },
                    { 26, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2839), (short)1, "JavaScript編程的高級應用和技巧", 1530m, true, "深入掌握JavaScript編程", 8, "https://example.com/courses/advanced_javascript.jpg", "高級JavaScript", 26, 850m, null, "https://example.com/courses/advanced_javascript_intro.mp4" },
                    { 27, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2841), (short)1, "深入掌握C#編程的高級技術", 1225m, true, "學習C#的高級應用技術", 9, "https://example.com/courses/advanced_csharp.jpg", "C# 高級應用", 27, 700m, null, "https://example.com/courses/advanced_csharp_intro.mp4" },
                    { 28, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2843), (short)1, "SQL資料庫管理和優化的高級技術", 1080m, true, "深入學習SQL資料庫管理", 10, "https://example.com/courses/advanced_sql.jpg", "SQL 高級資料庫操作", 28, 600m, null, "https://example.com/courses/advanced_sql_intro.mp4" },
                    { 29, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2846), (short)1, "Python編程的高級應用和數據處理", 1620m, true, "深入學習Python的高級應用", 11, "https://example.com/courses/advanced_python.jpg", "Python 高級應用", 29, 900m, null, "https://example.com/courses/advanced_python_intro.mp4" },
                    { 30, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2848), (short)1, "Java編程的高級技術和應用", 1350m, true, "深入學習Java的高級應用技術", 12, "https://example.com/courses/advanced_java.jpg", "Java 高級應用", 30, 750m, null, "https://example.com/courses/advanced_java_intro.mp4" },
                    { 31, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2851), (short)1, "高等數學理論和應用", 890m, true, "深入學習數學的高級概念", 13, "https://example.com/courses/advanced_math.jpg", "高等數學", 31, 500m, null, "https://example.com/courses/advanced_math_intro.mp4" },
                    { 32, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2853), (short)1, "物理學的高級理論和應用", 1350m, true, "深入理解物理學的高級理論", 14, "https://example.com/courses/advanced_physics.jpg", "高等物理", 32, 750m, null, "https://example.com/courses/advanced_physics_intro.mp4" },
                    { 33, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2855), (short)1, "化學的高級理論和應用", 900m, true, "深入理解化學的高級理論", 15, "https://example.com/courses/advanced_chemistry.jpg", "高等化學", 33, 500m, null, "https://example.com/courses/advanced_chemistry_intro.mp4" },
                    { 34, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2858), (short)1, "歷史研究的高級技術和方法", 1050m, true, "深入分析歷史事件和背景", 16, "https://example.com/courses/advanced_history.jpg", "高等歷史研究", 34, 600m, null, "https://example.com/courses/advanced_history_intro.mp4" },
                    { 35, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2861), (short)1, "地理學的高級理論和應用", 1080m, true, "深入理解地理學的高級概念", 17, "https://example.com/courses/advanced_geography.jpg", "高等地理學", 35, 600m, null, "https://example.com/courses/advanced_geography_intro.mp4" },
                    { 36, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2863), (short)1, "生物學的高級理論和應用", 1620m, true, "深入理解生物學的高級理論", 18, "https://example.com/courses/advanced_biology.jpg", "高等生物學", 36, 900m, null, "https://example.com/courses/advanced_biology_intro.mp4" },
                    { 37, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2865), (short)1, "專業英文寫作的高級技巧", 935m, true, "掌握專業英文寫作技巧", 1, "https://example.com/courses/professional_english.jpg", "專業英文寫作", 37, 550m, null, "https://example.com/courses/professional_english_intro.mp4" },
                    { 38, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2868), (short)1, "專業日語寫作的高級技巧", 720m, true, "掌握專業日語寫作技巧", 2, "https://example.com/courses/professional_japanese.jpg", "專業日語寫作", 38, 400m, null, "https://example.com/courses/professional_japanese_intro.mp4" },
                    { 39, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2870), (short)1, "專業中文寫作的高級技巧", 1260m, true, "掌握專業中文寫作技巧", 3, "https://example.com/courses/professional_chinese.jpg", "專業中文寫作", 39, 700m, null, "https://example.com/courses/professional_chinese_intro.mp4" },
                    { 40, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2872), (short)1, "專業德語寫作的高級技巧", 1170m, true, "掌握專業德語寫作技巧", 4, "https://example.com/courses/professional_german.jpg", "專業德語寫作", 40, 650m, null, "https://example.com/courses/professional_german_intro.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate", "UserId" },
                values: new object[,]
                {
                    { 1, "john_doe", 1, "1234567890", "001", new DateTime(1994, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2465), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2476), 1, "john.doe@example.com", "John", (short)1, "https://randomuser.me/api/portraits/men/1.jpg", true, true, "Doe", 1, "English", "JohnD", "password1", "123456789", "English", "Experienced English tutor", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2477), null },
                    { 2, "jane_smith", 2, "2345678901", "002", new DateTime(1999, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2480), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2483), 2, "jane.smith@example.com", "Jane", (short)2, "https://randomuser.me/api/portraits/women/2.jpg", true, false, "Smith", 2, "Japanese", "JaneS", "password2", "987654321", "Japanese", "Japanese language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2483), null },
                    { 3, "mark_brown", 1, "3456789012", "003", new DateTime(1996, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2486), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2489), 3, "mark.brown@example.com", "Mark", (short)1, "https://randomuser.me/api/portraits/men/3.jpg", true, true, "Brown", 3, "Korean", "MarkB", "password3", "123123123", "Korean, English", "Korean language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2490), null },
                    { 4, "chris_taylor", 1, "4567890123", "004", new DateTime(1991, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2493), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2495), 4, "chris.taylor@example.com", "Chris", (short)1, "https://randomuser.me/api/portraits/men/4.jpg", true, true, "Taylor", 4, "German", "ChrisT", "password4", "444555666", "German, English", "German language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2496), null },
                    { 5, "sam_white", 2, "5678901234", "005", new DateTime(1997, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2498), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2500), 5, "samantha.white@example.com", "Samantha", (short)2, "https://randomuser.me/api/portraits/women/5.jpg", true, false, "White", 5, "French", "SamW", "password5", "555666777", "French, English", "French language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2500), null },
                    { 6, "paul_walker", 1, "6789012345", "006", new DateTime(1992, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2503), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2504), 6, "paul.walker@example.com", "Paul", (short)1, "https://randomuser.me/api/portraits/men/6.jpg", true, true, "Walker", 6, "Spanish", "PaulW", "password6", "666777888", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2505), null },
                    { 7, "laura_martin", 2, "7890123456", "007", new DateTime(1995, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2507), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2509), 7, "laura.martin@example.com", "Laura", (short)2, "https://randomuser.me/api/portraits/women/7.jpg", true, false, "Martin", 7, "Chinese", "LauraM", "password7", "777888999", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2509), null },
                    { 8, "david_jones", 1, "8901234567", "008", new DateTime(1993, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2514), 8, "david.jones@example.com", "David", (short)1, "https://randomuser.me/api/portraits/men/8.jpg", true, true, "Jones", 8, "Russian", "DavidJ", "password8", "888999000", "Russian, English", "Russian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2514), null },
                    { 9, "emily_davis", 2, "9012345678", "009", new DateTime(1998, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2517), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2518), 9, "emily.davis@example.com", "Emily", (short)2, "https://randomuser.me/api/portraits/women/9.jpg", true, false, "Davis", 9, "Italian", "EmilyD", "password9", "999000111", "Italian, English", "Italian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2519), null },
                    { 10, "michael_wilson", 1, "0123456789", "010", new DateTime(1990, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2521), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2523), 10, "michael.wilson@example.com", "Michael", (short)1, "https://randomuser.me/api/portraits/men/10.jpg", true, true, "Wilson", 10, "Portuguese", "MichaelW", "password10", "000111222", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2523), null },
                    { 11, "carlos_miller", 1, "3456781234", "011", new DateTime(1995, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2526), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2527), 1, "carlos.miller@example.com", "Carlos", (short)1, "https://randomuser.me/api/portraits/men/11.jpg", true, true, "Miller", 1, "English", "CarlosM", "password11", "101010101", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2528), null },
                    { 12, "olivia_brown", 2, "4567892345", "012", new DateTime(2000, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2530), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2532), 2, "olivia.brown@example.com", "Olivia", (short)2, "https://randomuser.me/api/portraits/women/12.jpg", true, false, "Brown", 2, "Japanese", "OliviaB", "password12", "202020202", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2532), null },
                    { 13, "james_johnson", 1, "5678913456", "013", new DateTime(1989, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2535), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2536), 3, "james.johnson@example.com", "James", (short)1, "https://randomuser.me/api/portraits/men/13.jpg", true, true, "Johnson", 3, "Korean", "JamesJ", "password13", "303030303", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2537), null },
                    { 14, "emma_garcia", 2, "6789124567", "014", new DateTime(2002, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2539), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2540), 4, "emma.garcia@example.com", "Emma", (short)2, "https://randomuser.me/api/portraits/women/14.jpg", true, false, "Garcia", 4, "German", "EmmaG", "password14", "404040404", "German, English", "Expert in German language", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2541), null },
                    { 15, "robert_martinez", 1, "7891235678", "015", new DateTime(1998, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2565), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2567), 5, "robert.martinez@example.com", "Robert", (short)1, "https://randomuser.me/api/portraits/men/15.jpg", true, true, "Martinez", 5, "French", "RobertM", "password15", "505050505", "French, English", "French language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2567), null },
                    { 16, "sophia_rodriguez", 2, "8902346789", "016", new DateTime(2003, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2570), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2571), 6, "sophia.rodriguez@example.com", "Sophia", (short)2, "https://randomuser.me/api/portraits/women/16.jpg", true, false, "Rodriguez", 6, "Spanish", "SophiaR", "password16", "606060606", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2572), null },
                    { 17, "liam_hernandez", 1, "9013457890", "017", new DateTime(1991, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2574), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2576), 7, "liam.hernandez@example.com", "Liam", (short)1, "https://randomuser.me/api/portraits/men/17.jpg", true, true, "Hernandez", 7, "Chinese", "LiamH", "password17", "707070707", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2576), null },
                    { 18, "isabella_lopez", 2, "0123456789", "018", new DateTime(2004, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2579), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2581), 8, "isabella.lopez@example.com", "Isabella", (short)2, "https://randomuser.me/api/portraits/women/18.jpg", true, false, "Lopez", 8, "Russian", "IsabellaL", "password18", "808080808", "Russian, English", "Russian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2581), null },
                    { 19, "benjamin_gonzalez", 1, "1234567890", "019", new DateTime(1996, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2584), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2585), 9, "benjamin.gonzalez@example.com", "Benjamin", (short)1, "https://randomuser.me/api/portraits/men/19.jpg", true, true, "Gonzalez", 9, "Italian", "BenG", "password19", "909090909", "Italian, English", "Italian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2586), null },
                    { 20, "mia_wilson", 2, "2345678901", "020", new DateTime(1997, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2588), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2590), 10, "mia.wilson@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/20.jpg", true, false, "Wilson", 10, "Portuguese", "MiaW", "password20", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2590), null },
                    { 21, "daniel_anderson", 1, "3456781234", "021", new DateTime(1995, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2593), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2594), 1, "daniel.anderson@example.com", "Daniel", (short)1, "https://randomuser.me/api/portraits/men/21.jpg", true, true, "Anderson", 1, "English", "DanA", "password21", "111111111", "English, Spanish", "Experienced tutor in English and Spanish", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2594), null },
                    { 22, "ava_thomas", 2, "4567892345", "022", new DateTime(2000, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2600), 2, "ava.thomas@example.com", "Ava", (short)2, "https://randomuser.me/api/portraits/women/22.jpg", true, false, "Thomas", 2, "Japanese", "AvaT", "password22", "222222222", "Japanese, English", "Expert in Japanese language", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2600), null },
                    { 23, "matthew_jackson", 1, "5678913456", "023", new DateTime(1989, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2602), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2604), 3, "matthew.jackson@example.com", "Matthew", (short)1, "https://randomuser.me/api/portraits/men/23.jpg", true, true, "Jackson", 3, "Korean", "MattJ", "password23", "333333333", "Korean, English", "Korean language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2604), null },
                    { 24, "ella_harris", 2, "6789124567", "024", new DateTime(2002, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2607), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2608), 4, "ella.harris@example.com", "Ella", (short)2, "https://randomuser.me/api/portraits/women/24.jpg", true, false, "Harris", 4, "German", "EllaH", "password24", "444444444", "German, English", "Expert in German language", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2609), null },
                    { 25, "lucas_clark", 1, "7891235678", "025", new DateTime(1998, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2611), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2613), 5, "lucas.clark@example.com", "Lucas", (short)1, "https://randomuser.me/api/portraits/men/25.jpg", true, true, "Clark", 5, "French", "LukeC", "password25", "555555555", "French, English", "French language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2613), null },
                    { 26, "mia_lewis", 2, "8902346789", "026", new DateTime(2003, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2615), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2617), 6, "mia.lewis@example.com", "Mia", (short)2, "https://randomuser.me/api/portraits/women/26.jpg", true, false, "Lewis", 6, "Spanish", "MiaL", "password26", "666666666", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2617), null },
                    { 27, "logan_young", 1, "9013457890", "027", new DateTime(1991, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2620), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2626), 7, "logan.young@example.com", "Logan", (short)1, "https://randomuser.me/api/portraits/men/27.jpg", true, true, "Young", 7, "Chinese", "LoganY", "password27", "777777777", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2626), null },
                    { 28, "aria_king", 2, "0123456789", "028", new DateTime(2004, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2628), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2630), 8, "aria.king@example.com", "Aria", (short)2, "https://randomuser.me/api/portraits/women/28.jpg", true, false, "King", 8, "Russian", "AriaK", "password28", "888888888", "Russian, English", "Russian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2630), null },
                    { 29, "ethan_wright", 1, "1234567890", "029", new DateTime(1996, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2651), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2653), 9, "ethan.wright@example.com", "Ethan", (short)1, "https://randomuser.me/api/portraits/men/29.jpg", true, true, "Wright", 9, "Italian", "EthanW", "password29", "999999999", "Italian, English", "Italian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2653), null },
                    { 30, "charlotte_hill", 2, "2345678901", "030", new DateTime(1997, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2656), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2658), 10, "charlotte.hill@example.com", "Charlotte", (short)2, "https://randomuser.me/api/portraits/women/30.jpg", true, false, "Hill", 10, "Portuguese", "CharlotteH", "password30", "1010101010", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2658), null },
                    { 31, "henry_evans", 1, "1234567890", "031", new DateTime(1994, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2661), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2662), 1, "henry.evans@example.com", "Henry", (short)1, "https://randomuser.me/api/portraits/men/31.jpg", true, true, "Evans", 1, "English", "HenryE", "password31", "111222333", "English, Spanish", "Expert in English and Spanish", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2663), null },
                    { 32, "chloe_scott", 2, "2345678901", "032", new DateTime(2000, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2666), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2668), 2, "chloe.scott@example.com", "Chloe", (short)2, "https://randomuser.me/api/portraits/women/32.jpg", true, false, "Scott", 2, "Japanese", "ChloeS", "password32", "444555666", "Japanese, English", "Japanese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2668), null },
                    { 33, "jackson_mitchell", 1, "3456789012", "033", new DateTime(1995, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2672), 3, "jackson.mitchell@example.com", "Jackson", (short)1, "https://randomuser.me/api/portraits/men/33.jpg", true, true, "Mitchell", 3, "Korean", "JackM", "password33", "555666777", "Korean, English", "Korean language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2672), null },
                    { 34, "amelia_martinez", 2, "4567890123", "034", new DateTime(1999, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2675), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2676), 4, "amelia.martinez@example.com", "Amelia", (short)2, "https://randomuser.me/api/portraits/women/34.jpg", true, false, "Martinez", 4, "German", "AmeliaM", "password34", "666777888", "German, English", "Expert in German language", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2677), null },
                    { 35, "sebastian_morris", 1, "5678901234", "035", new DateTime(1998, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2679), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2681), 5, "sebastian.morris@example.com", "Sebastian", (short)1, "https://randomuser.me/api/portraits/men/35.jpg", true, true, "Morris", 5, "French", "SebM", "password35", "777888999", "French, English", "French language specialist", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2681), null },
                    { 36, "grace_cooper", 2, "6789012345", "036", new DateTime(2001, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2683), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2685), 6, "grace.cooper@example.com", "Grace", (short)2, "https://randomuser.me/api/portraits/women/36.jpg", true, false, "Cooper", 6, "Spanish", "GraceC", "password36", "888999000", "Spanish, English", "Spanish language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2685), null },
                    { 37, "aiden_perez", 1, "7890123456", "037", new DateTime(1993, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2688), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2690), 7, "aiden.perez@example.com", "Aiden", (short)1, "https://randomuser.me/api/portraits/men/37.jpg", true, true, "Perez", 7, "Chinese", "AidenP", "password37", "999000111", "Chinese, English", "Chinese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2690), null },
                    { 38, "avery_nelson", 2, "8901234567", "038", new DateTime(2002, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2693), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2694), 8, "avery.nelson@example.com", "Avery", (short)2, "https://randomuser.me/api/portraits/women/38.jpg", true, false, "Nelson", 8, "Russian", "AveryN", "password38", "000111222", "Russian, English", "Russian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2695), null },
                    { 39, "oliver_king", 1, "0123456789", "039", new DateTime(1990, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2697), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2699), 9, "oliver.king@example.com", "Oliver", (short)1, "https://randomuser.me/api/portraits/men/39.jpg", true, true, "King", 9, "Italian", "OliverK", "password39", "111222333", "Italian, English", "Italian language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2699), null },
                    { 40, "ella_wood", 2, "2345678901", "040", new DateTime(1996, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2701), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2703), 10, "ella.wood@example.com", "Ella", (short)2, "https://Infrastructure.Data.TalkingTopiaContextrandomuser.me/api/portraits/women/40.jpg", true, false, "Wood", 10, "Portuguese", "EllaW", "password40", "222333444", "Portuguese, English", "Portuguese language expert", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2704), null }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3355), true, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3356), 1, null, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3357) },
                    { 2, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3359), false, null, 2, "Incomplete application", new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3359) },
                    { 3, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3361), true, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3361), 3, null, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3362) },
                    { 4, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3363), false, null, 4, "Failed verification", new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3364) },
                    { 5, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3365), true, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3365), 5, null, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3366) },
                    { 6, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3367), true, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3367), 6, null, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3368) },
                    { 7, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3369), false, null, 7, "Incorrect details", new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3370) },
                    { 8, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3371), true, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3371), 8, null, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3372) },
                    { 9, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3373), true, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3374), 9, null, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3374) },
                    { 10, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3375), false, null, 10, "Missing documents", new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3376) },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3377), true, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3378), 11, null, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3378) },
                    { 12, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3379), false, null, 12, "Not eligible", new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3380) },
                    { 13, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3381), true, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3382), 13, null, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3382) },
                    { 14, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3383), true, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3384), 14, null, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3384) },
                    { 15, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3385), false, null, 15, "Failed interview", new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3386) },
                    { 16, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3387), true, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3388), 16, null, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3388) },
                    { 17, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3389), true, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3390), 17, null, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3390) },
                    { 18, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3391), false, null, 18, "Incorrect documentation", new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3392) },
                    { 19, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3393), true, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3393), 19, null, new DateTime(2024, 9, 26, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3394) },
                    { 20, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3395), false, null, 20, "Unverified information", new DateTime(2024, 9, 27, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3396) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3417), (short)14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3418), 3, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3419) },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3420), (short)15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3421), 4, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3421) },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3422), (short)16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3422), 5, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3423) },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3424), (short)17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3424), 6, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3425) },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3426), (short)18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3426), 7, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3426) },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3427), (short)19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3428), 8, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3428) },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3429), (short)20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3430), 9, 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3430) },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3431), (short)12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3431), 10, 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3432) },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3432), (short)13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3433), 11, 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3433) },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3434), (short)14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3435), 12, 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3435) },
                    { 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3436), (short)15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3436), 13, 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3437) },
                    { 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3437), (short)16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3438), 14, 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3438) },
                    { 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3439), (short)17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3440), 15, 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3440) },
                    { 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3441), (short)18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3441), 16, 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3442) },
                    { 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3443), (short)19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3443), 17, 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3443) },
                    { 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3444), (short)20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3445), 18, 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3445) },
                    { 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3446), (short)12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3446), 19, 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3447) },
                    { 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3448), (short)13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3448), 20, 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3449) }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2984), 1, "https://picsum.photos/id/100/450/300", null },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2985), 1, "https://picsum.photos/id/101/450/300", null },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2986), 1, "https://picsum.photos/id/102/450/300", null },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2987), 2, "https://picsum.photos/id/103/450/300", null },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2988), 2, "https://picsum.photos/id/104/450/300", null },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2989), 2, "https://picsum.photos/id/105/450/300", null },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2990), 3, "https://picsum.photos/id/106/450/300", null },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2990), 3, "https://picsum.photos/id/107/450/300", null },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2991), 3, "https://picsum.photos/id/108/450/300", null },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2992), 4, "https://picsum.photos/id/109/450/300", null },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2993), 4, "https://picsum.photos/id/110/450/300", null },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(2994), 4, "https://picsum.photos/id/111/450/300", null }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3298), 1, 1, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3300) },
                    { 2, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3301), 2, 2, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3302) },
                    { 3, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3303), 3, 3, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3304) },
                    { 4, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3305), 4, 4, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3306) },
                    { 5, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3307), 5, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3307) },
                    { 6, new DateTime(2024, 3, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3308), 6, 6, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3309) },
                    { 7, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3310), 7, 7, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3310) },
                    { 8, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3312), 8, 8, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3312) },
                    { 9, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3313), 9, 9, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3314) },
                    { 10, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3315), 10, 10, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3315) },
                    { 11, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3317), 11, 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3317) },
                    { 12, new DateTime(2024, 3, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3318), 12, 12, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3319) },
                    { 13, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3320), 13, 13, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3320) },
                    { 14, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3322), 14, 14, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3322) },
                    { 15, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3323), 15, 15, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3324) },
                    { 16, new DateTime(2024, 7, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3325), 16, 16, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3325) },
                    { 17, new DateTime(2024, 8, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3327), 17, 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3327) },
                    { 18, new DateTime(2024, 3, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3328), 18, 18, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3328) },
                    { 19, new DateTime(2024, 4, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3330), 19, 1, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3330) },
                    { 20, new DateTime(2024, 5, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3331), 20, 2, new DateTime(2024, 6, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3332) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "Vatnumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3023), 100.00m, (short)1, 1, (short)1, "CreditCard", "order1@domain.com", "A123456789", 1000.00m, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3017), new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3024), null },
                    { 2, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3027), 150.00m, (short)2, 2, (short)2, "PayPal", "order2@domain.com", "B123456789", 1500.00m, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3026), new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3028), null },
                    { 3, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3031), 200.00m, (short)1, 3, (short)3, "BankTransfer", "order3@domain.com", "C123456789", 2000.00m, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3029), new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3031), null },
                    { 4, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3034), 250.00m, (short)2, 4, (short)1, "CreditCard", "order4@domain.com", "D123456789", 2500.00m, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3033), new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3034), null },
                    { 5, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3037), 300.00m, (short)1, 5, (short)2, "PayPal", "order5@domain.com", "E123456789", 3000.00m, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3038), null },
                    { 6, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3041), 350.00m, (short)2, 6, (short)3, "BankTransfer", "order6@domain.com", "F123456789", 3500.00m, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3039), new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3041), null },
                    { 7, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3044), 400.00m, (short)1, 7, (short)1, "CreditCard", "order7@domain.com", "G123456789", 4000.00m, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3042), new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3044), null },
                    { 8, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3047), 450.00m, (short)2, 8, (short)2, "PayPal", "order8@domain.com", "H123456789", 4500.00m, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3045), new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3048), null },
                    { 9, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3051), 500.00m, (short)1, 9, (short)3, "BankTransfer", "order9@domain.com", "I123456789", 5000.00m, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3049), new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3051), null },
                    { 10, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3054), 550.00m, (short)2, 10, (short)1, "CreditCard", "order10@domain.com", "J123456789", 5500.00m, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3053), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3054), null },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3057), 600.00m, (short)1, 11, (short)1, "CreditCard", "order11@domain.com", "K123456789", 6000.00m, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3056), new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3057), null },
                    { 12, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3060), 650.00m, (short)2, 12, (short)2, "PayPal", "order12@domain.com", "L123456789", 6500.00m, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3059), new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3060), null },
                    { 13, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3090), 700.00m, (short)1, 13, (short)3, "BankTransfer", "order13@domain.com", "M123456789", 7000.00m, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3088), new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3090), null },
                    { 14, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3093), 750.00m, (short)2, 14, (short)1, "CreditCard", "order14@domain.com", "N123456789", 7500.00m, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3092), new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3093), null },
                    { 15, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3096), 800.00m, (short)1, 15, (short)2, "PayPal", "order15@domain.com", "O123456789", 8000.00m, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3095), new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3097), null },
                    { 16, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3100), 850.00m, (short)2, 16, (short)3, "BankTransfer", "order16@domain.com", "P123456789", 8500.00m, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3098), new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3101), null },
                    { 17, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3103), 900.00m, (short)1, 17, (short)1, "CreditCard", "order17@domain.com", "Q123456789", 9000.00m, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3102), new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3104), null },
                    { 18, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3107), 950.00m, (short)2, 18, (short)2, "PayPal", "order18@domain.com", "R123456789", 9500.00m, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3105), new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3107), null },
                    { 19, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3111), 1000.00m, (short)1, 19, (short)3, "BankTransfer", "order19@domain.com", "S123456789", 10000.00m, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3110), new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3112), null },
                    { 20, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3114), 1050.00m, (short)2, 20, (short)1, "CreditCard", "order20@domain.com", "T123456789", 10500.00m, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3113), new DateTime(2024, 9, 26, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3115), null }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3475), 1, "Certified Java Developer", "https://example.com/licenses/java_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3475) },
                    { 2, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3494), 2, "Certified Python Developer", "https://example.com/licenses/python_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3495) },
                    { 3, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3496), 3, "Certified C# Developer", "https://example.com/licenses/csharp_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3496) },
                    { 4, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3497), 4, "Certified SQL Developer", "https://example.com/licenses/sql_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3498) },
                    { 5, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3499), 5, "Certified JavaScript Developer", "https://example.com/licenses/js_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3499) },
                    { 6, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3500), 6, "Certified Data Analyst", "https://example.com/licenses/data_analyst_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3501) },
                    { 7, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3502), 7, "Certified Project Manager", "https://example.com/licenses/project_manager_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3502) },
                    { 8, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3503), 8, "Certified Network Engineer", "https://example.com/licenses/network_engineer_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3504) },
                    { 9, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3505), 9, "Certified Cloud Architect", "https://example.com/licenses/cloud_architect_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3506) },
                    { 10, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3507), 10, "Certified DevOps Engineer", "https://example.com/licenses/devops_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3507) },
                    { 11, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3508), 11, "Certified Ethical Hacker", "https://example.com/licenses/ethical_hacker_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3509) },
                    { 12, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3510), 12, "Certified AI Engineer", "https://example.com/licenses/ai_engineer_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3510) },
                    { 13, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3511), 13, "Certified ML Engineer", "https://example.com/licenses/ml_engineer_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3512) },
                    { 14, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3513), 14, "Certified Blockchain Developer", "https://example.com/licenses/blockchain_dev_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3513) },
                    { 15, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3514), 15, "Certified UX Designer", "https://example.com/licenses/ux_designer_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3515) },
                    { 16, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3516), 16, "Certified UI Designer", "https://example.com/licenses/ui_designer_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3517) },
                    { 17, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3519), 17, "Certified Product Manager", "https://example.com/licenses/product_manager_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3519) },
                    { 18, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3520), 18, "Certified IT Security Specialist", "https://example.com/licenses/it_security_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3521) },
                    { 19, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3522), 19, "Certified Web Developer", "https://example.com/licenses/web_dev_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3522) },
                    { 20, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3523), 20, "Certified Software Tester", "https://example.com/licenses/software_tester_certified.jpg", new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3524) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3550), "Great course!", 1, (byte)5, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3551) },
                    { 2, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3552), "Very informative.", 2, (byte)4, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3553) },
                    { 3, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3554), "Excellent content.", 3, (byte)5, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3555) },
                    { 4, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3556), "Good explanations.", 4, (byte)4, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3556) },
                    { 5, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3558), "Highly recommend.", 5, (byte)5, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3558) },
                    { 6, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3559), "Well structured.", 6, (byte)4, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3560) },
                    { 7, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3561), "Learned a lot.", 7, (byte)5, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3561) },
                    { 8, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3563), "Great examples.", 8, (byte)4, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3563) },
                    { 9, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3564), "In-depth knowledge.", 9, (byte)5, 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3565) },
                    { 10, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3566), "Comprehensive.", 10, (byte)4, 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3566) },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3568), "Loved it!", 11, (byte)5, 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3568) },
                    { 12, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3569), "Very useful.", 12, (byte)4, 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3570) },
                    { 13, new DateTime(2024, 9, 18, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3571), "Fantastic course!", 13, (byte)5, 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3571) },
                    { 14, new DateTime(2024, 9, 19, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3572), "Great teacher.", 14, (byte)4, 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3573) },
                    { 15, new DateTime(2024, 9, 20, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3574), "Well explained.", 15, (byte)5, 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3575) },
                    { 16, new DateTime(2024, 9, 21, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3576), "Good coverage.", 16, (byte)4, 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3576) },
                    { 17, new DateTime(2024, 9, 22, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3577), "Loved the content.", 17, (byte)5, 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3578) },
                    { 18, new DateTime(2024, 9, 23, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3580), "Very clear.", 18, (byte)4, 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3580) },
                    { 19, new DateTime(2024, 9, 24, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3581), "Highly informative.", 19, (byte)5, 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3582) },
                    { 20, new DateTime(2024, 9, 25, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3583), "Helpful.", 20, (byte)4, 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3583) },
                    { 21, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3584), "Amazing course!", 21, (byte)5, 21, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3585) },
                    { 22, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3586), "Well organized.", 22, (byte)4, 22, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3586) },
                    { 23, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3587), "Great insights.", 23, (byte)5, 23, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3588) },
                    { 24, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3589), "Valuable lessons.", 24, (byte)4, 24, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3589) },
                    { 25, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3591), "Excellent teaching.", 25, (byte)5, 25, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3591) },
                    { 26, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3592), "Clear and concise.", 26, (byte)4, 26, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3593) },
                    { 27, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3594), "Very educational.", 27, (byte)5, 27, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3594) },
                    { 28, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3596), "Useful information.", 28, (byte)4, 28, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3597) },
                    { 29, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3598), "Well presented.", 29, (byte)5, 29, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3598) },
                    { 30, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3599), "Good pacing.", 30, (byte)4, 30, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3600) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 29, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3629), new DateTime(2024, 8, 29, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3630), new DateTime(2024, 8, 27, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3628), 1, (short)1, 1, (short)10, 1000.00m, new DateTime(2024, 8, 28, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3629), 100.00m },
                    { 2, new DateTime(2024, 8, 30, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3634), new DateTime(2024, 8, 30, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3634), new DateTime(2024, 8, 28, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3633), 2, (short)2, 2, (short)5, 1000.00m, new DateTime(2024, 8, 29, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3633), 200.00m },
                    { 3, new DateTime(2024, 8, 31, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3637), new DateTime(2024, 8, 31, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3638), new DateTime(2024, 8, 29, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3636), 3, (short)1, 3, (short)3, 900.00m, new DateTime(2024, 8, 30, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3637), 300.00m },
                    { 4, new DateTime(2024, 9, 1, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3641), new DateTime(2024, 9, 1, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3641), new DateTime(2024, 8, 30, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3640), 4, (short)2, 4, (short)2, 800.00m, new DateTime(2024, 8, 31, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3640), 400.00m },
                    { 5, new DateTime(2024, 9, 2, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3644), new DateTime(2024, 9, 2, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3644), new DateTime(2024, 8, 31, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3643), 5, (short)1, 5, (short)4, 2000.00m, new DateTime(2024, 9, 1, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3643), 500.00m },
                    { 6, new DateTime(2024, 9, 3, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3647), new DateTime(2024, 9, 3, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3648), new DateTime(2024, 9, 1, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3646), 6, (short)2, 6, (short)1, 600.00m, new DateTime(2024, 9, 2, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3647), 600.00m },
                    { 7, new DateTime(2024, 9, 4, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3650), new DateTime(2024, 9, 4, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3651), new DateTime(2024, 9, 2, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3649), 7, (short)1, 7, (short)3, 2100.00m, new DateTime(2024, 9, 3, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3650), 700.00m },
                    { 8, new DateTime(2024, 9, 5, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3655), new DateTime(2024, 9, 5, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3655), new DateTime(2024, 9, 3, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3653), 8, (short)2, 8, (short)2, 1600.00m, new DateTime(2024, 9, 4, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3653), 800.00m },
                    { 9, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3658), new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3658), new DateTime(2024, 9, 4, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3657), 9, (short)1, 9, (short)1, 900.00m, new DateTime(2024, 9, 5, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3657), 900.00m },
                    { 10, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3661), new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3661), new DateTime(2024, 9, 5, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3660), 10, (short)2, 10, (short)2, 2000.00m, new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3660), 1000.00m },
                    { 11, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3664), new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3665), new DateTime(2024, 9, 6, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3663), 11, (short)1, 11, (short)4, 4400.00m, new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3664), 1100.00m },
                    { 12, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3667), new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3668), new DateTime(2024, 9, 7, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3666), 12, (short)2, 12, (short)3, 3600.00m, new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3667), 1200.00m },
                    { 13, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3671), new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3672), new DateTime(2024, 9, 8, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3670), 13, (short)1, 13, (short)5, 6500.00m, new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3671), 1300.00m },
                    { 14, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3675), new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3675), new DateTime(2024, 9, 9, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3674), 14, (short)2, 14, (short)2, 2800.00m, new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3674), 1400.00m },
                    { 15, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3678), new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3678), new DateTime(2024, 9, 10, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3677), 15, (short)1, 15, (short)1, 1500.00m, new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3677), 1500.00m },
                    { 16, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3681), new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3681), new DateTime(2024, 9, 11, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3680), 16, (short)2, 16, (short)3, 4800.00m, new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3680), 1600.00m },
                    { 17, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3685), new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3685), new DateTime(2024, 9, 12, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3684), 17, (short)1, 17, (short)2, 3400.00m, new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3684), 1700.00m },
                    { 18, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3708), new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3708), new DateTime(2024, 9, 13, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3707), 18, (short)2, 18, (short)4, 7200.00m, new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3707), 1800.00m },
                    { 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3711), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3712), new DateTime(2024, 9, 14, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3710), 19, (short)1, 19, (short)1, 1900.00m, new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3711), 1900.00m },
                    { 20, new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3714), new DateTime(2024, 9, 17, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3715), new DateTime(2024, 9, 15, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3713), 20, (short)2, 20, (short)2, 4000.00m, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3714), 2000.00m }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3739), 8, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3739), 1 },
                    { 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3741), 9, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3741), 1 },
                    { 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3743), 10, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3743), 1 },
                    { 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3744), 11, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3744), 1 },
                    { 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3745), 12, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3746), 1 },
                    { 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3747), 13, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3747), 1 },
                    { 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3748), 14, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3749), 1 },
                    { 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3750), 15, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3750), 1 },
                    { 9, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3751), 16, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3751), 1 },
                    { 10, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3752), 17, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3753), 1 },
                    { 11, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3754), 18, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3754), 1 },
                    { 12, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3755), 19, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3755), 1 },
                    { 13, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3756), 20, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3757), 1 },
                    { 14, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3758), 8, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3758), 2 },
                    { 15, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3759), 9, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3760), 2 },
                    { 16, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3761), 10, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3761), 2 },
                    { 17, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3762), 11, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3763), 2 },
                    { 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3763), 12, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3764), 2 },
                    { 19, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3765), 13, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3765), 2 },
                    { 20, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3766), 14, 1, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3766), 2 },
                    { 21, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3767), 8, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3768), 3 },
                    { 22, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3769), 9, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3769), 3 },
                    { 23, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3770), 10, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3770), 3 },
                    { 24, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3771), 11, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3772), 3 },
                    { 25, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3773), 12, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3773), 4 },
                    { 26, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3774), 13, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3774), 4 },
                    { 27, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3776), 14, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3776), 4 },
                    { 28, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3780), 15, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3780), 5 },
                    { 29, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3781), 16, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3781), 5 },
                    { 30, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3782), 17, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3783), 5 },
                    { 31, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3784), 18, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3784), 6 },
                    { 32, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3785), 19, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3786), 6 },
                    { 33, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3786), 20, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3787), 0 },
                    { 34, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3788), 8, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3788), 1 },
                    { 35, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3789), 9, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3790), 1 },
                    { 36, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3791), 10, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3791), 1 },
                    { 37, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3792), 11, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3792), 2 },
                    { 38, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3793), 12, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3794), 2 },
                    { 39, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3795), 13, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3795), 2 },
                    { 40, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3797), 14, 2, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3797), 2 },
                    { 41, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3798), 8, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3799), 2 },
                    { 42, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3800), 9, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3800), 2 },
                    { 43, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3801), 10, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3801), 2 },
                    { 44, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3802), 11, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3803), 2 },
                    { 45, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3804), 12, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3804), 3 },
                    { 46, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3805), 13, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3805), 3 },
                    { 47, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3806), 14, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3807), 3 },
                    { 48, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3808), 15, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3808), 4 },
                    { 49, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3809), 16, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3809), 4 },
                    { 50, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3810), 17, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3811), 4 },
                    { 51, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3812), 18, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3812), 5 },
                    { 52, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3814), 19, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3814), 5 },
                    { 53, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3815), 20, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3815), 6 },
                    { 54, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3817), 8, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3817), 0 },
                    { 55, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3818), 9, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3818), 0 },
                    { 56, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3819), 10, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3820), 1 },
                    { 57, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3821), 11, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3821), 1 },
                    { 58, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3822), 12, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3822), 1 },
                    { 59, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3823), 13, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3824), 1 },
                    { 60, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3825), 14, 3, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3825), 2 },
                    { 61, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3826), 8, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3826), 1 },
                    { 62, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3827), 9, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3828), 1 },
                    { 63, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3829), 10, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3829), 1 },
                    { 64, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3830), 11, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3830), 1 },
                    { 65, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3832), 12, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3833), 1 },
                    { 66, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3834), 13, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3834), 1 },
                    { 67, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3835), 8, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3835), 2 },
                    { 68, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3836), 9, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3837), 2 },
                    { 69, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3838), 10, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3838), 2 },
                    { 70, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3839), 11, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3840), 2 },
                    { 71, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3841), 12, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3841), 2 },
                    { 72, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3842), 13, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3842), 2 },
                    { 73, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3843), 8, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3844), 3 },
                    { 74, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3845), 9, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3845), 3 },
                    { 75, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3848), 10, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3848), 3 },
                    { 76, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3849), 11, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3849), 3 },
                    { 77, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3850), 12, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3851), 3 },
                    { 78, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3871), 13, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3872), 3 },
                    { 79, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3873), 8, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3873), 4 },
                    { 80, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3874), 9, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3874), 4 },
                    { 81, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3875), 10, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3876), 4 },
                    { 82, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3877), 11, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3877), 4 },
                    { 83, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3878), 12, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3878), 4 },
                    { 84, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3879), 13, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3880), 4 },
                    { 85, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3881), 8, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3881), 5 },
                    { 86, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3882), 9, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3882), 5 },
                    { 87, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3883), 10, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3884), 5 },
                    { 88, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3886), 11, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3886), 5 },
                    { 89, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3887), 12, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3887), 5 },
                    { 90, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3888), 13, 4, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3889), 5 },
                    { 91, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3890), 8, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3890), 1 },
                    { 92, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3891), 9, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3892), 1 },
                    { 93, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3893), 10, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3893), 1 },
                    { 94, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3894), 11, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3894), 1 },
                    { 95, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3896), 12, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3896), 2 },
                    { 96, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3897), 13, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3897), 2 },
                    { 97, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3898), 14, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3899), 2 },
                    { 98, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3900), 8, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3900), 3 },
                    { 99, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3901), 9, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3901), 3 },
                    { 100, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3902), 10, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3903), 3 },
                    { 101, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3904), 11, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3905), 3 },
                    { 102, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3906), 12, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3906), 3 },
                    { 103, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3907), 8, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3908), 4 },
                    { 104, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3909), 9, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3909), 4 },
                    { 105, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3910), 10, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3911), 4 },
                    { 106, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3912), 11, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3912), 4 },
                    { 107, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3913), 12, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3913), 4 },
                    { 108, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3914), 8, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3915), 5 },
                    { 109, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3916), 9, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3916), 5 },
                    { 110, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3917), 10, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3918), 5 },
                    { 111, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3919), 11, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3919), 5 },
                    { 112, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3920), 12, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3920), 6 },
                    { 113, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3921), 13, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3922), 6 },
                    { 114, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3924), 14, 5, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3924), 6 },
                    { 115, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3926), 10, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3926), 1 },
                    { 116, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3927), 11, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3928), 1 },
                    { 117, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3929), 12, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3929), 1 },
                    { 118, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3930), 13, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3930), 1 },
                    { 119, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3931), 15, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3932), 2 },
                    { 120, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3933), 16, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3933), 2 },
                    { 121, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3934), 17, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3934), 2 },
                    { 122, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3935), 10, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3936), 3 },
                    { 123, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3937), 11, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3937), 3 },
                    { 124, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3939), 12, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3939), 3 },
                    { 125, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3940), 13, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3940), 3 },
                    { 126, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3941), 9, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3942), 4 },
                    { 127, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3943), 10, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3943), 4 },
                    { 128, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3944), 11, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3944), 4 },
                    { 129, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3945), 14, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3946), 5 },
                    { 130, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3947), 15, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3947), 5 },
                    { 131, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3948), 16, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3948), 5 },
                    { 132, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3949), 18, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3950), 6 },
                    { 133, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3951), 19, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3951), 6 },
                    { 134, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3952), 20, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3952), 6 },
                    { 135, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3953), 21, 6, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3954), 6 },
                    { 136, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3955), 9, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3955), 0 },
                    { 137, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3956), 10, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3956), 0 },
                    { 138, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3957), 11, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3958), 1 },
                    { 139, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3959), 12, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3960), 1 },
                    { 140, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3961), 13, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3961), 1 },
                    { 141, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3962), 14, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3962), 2 },
                    { 142, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3963), 15, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3964), 2 },
                    { 143, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3965), 16, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3965), 2 },
                    { 144, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3966), 18, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3967), 3 },
                    { 145, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3968), 19, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3968), 3 },
                    { 146, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3969), 20, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3969), 3 },
                    { 147, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3970), 21, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3971), 3 },
                    { 148, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3972), 8, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3972), 4 },
                    { 149, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3973), 9, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3973), 4 },
                    { 150, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3974), 10, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3975), 4 },
                    { 151, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3977), 12, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3977), 5 },
                    { 152, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3978), 13, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3978), 5 },
                    { 153, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3979), 14, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3980), 5 },
                    { 154, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3981), 16, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3981), 6 },
                    { 155, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3983), 17, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3983), 6 },
                    { 156, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3984), 18, 7, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3984), 6 },
                    { 157, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3985), 9, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3986), 0 },
                    { 158, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3987), 10, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3987), 0 },
                    { 159, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3988), 11, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3988), 0 },
                    { 160, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3989), 12, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3990), 0 },
                    { 161, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3991), 14, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3991), 1 },
                    { 162, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3992), 15, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3992), 1 },
                    { 163, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3997), 16, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3997), 1 },
                    { 164, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3999), 17, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(3999), 1 },
                    { 165, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4000), 18, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4000), 2 },
                    { 166, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4001), 19, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4002), 2 },
                    { 167, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4003), 20, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4003), 2 },
                    { 168, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4004), 21, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4004), 2 },
                    { 169, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4005), 8, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4006), 3 },
                    { 170, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4006), 9, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4007), 3 },
                    { 171, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4008), 10, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4008), 3 },
                    { 172, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4009), 11, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4010), 3 },
                    { 173, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4011), 13, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4011), 4 },
                    { 174, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4012), 14, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4012), 4 },
                    { 175, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4014), 15, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4014), 4 },
                    { 176, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4015), 17, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4016), 5 },
                    { 177, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4017), 18, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4017), 5 },
                    { 178, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4018), 19, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4018), 5 },
                    { 179, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4019), 20, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4020), 6 },
                    { 180, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4021), 21, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4021), 6 },
                    { 181, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4022), 22, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4022), 6 },
                    { 182, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4023), 23, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4024), 6 },
                    { 183, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4025), 12, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4025), 0 },
                    { 184, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4026), 13, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4026), 0 },
                    { 185, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4027), 14, 8, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4028), 0 }
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
                    { 1, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4133), 1, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4134), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4132), "https://example.com/resume/software_engineer_1.pdf", "Software Engineer", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4131) },
                    { 2, new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4137), 2, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4137), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4136), "https://example.com/resume/data_analyst_2.pdf", "Data Analyst", new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4135) },
                    { 3, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4140), 3, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4140), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4139), "https://example.com/resume/web_developer_3.pdf", "Web Developer", new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4139) },
                    { 4, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4143), 4, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4143), new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4142), "https://example.com/resume/db_admin_4.pdf", "Database Administrator", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4142) },
                    { 5, new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4146), 5, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4146), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4145), "https://example.com/resume/network_engineer_5.pdf", "Network Engineer", new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4144) },
                    { 6, new DateTime(2017, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4148), 6, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4149), new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4148), "https://example.com/resume/system_analyst_6.pdf", "System Analyst", new DateTime(2017, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4147) },
                    { 7, new DateTime(2016, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4151), 7, new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4152), new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4151), "https://example.com/resume/project_manager_7.pdf", "Project Manager", new DateTime(2016, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4150) },
                    { 8, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4154), 8, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4155), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4154), "https://example.com/resume/ui_ux_designer_8.pdf", "UI/UX Designer", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4153) },
                    { 9, new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4160), 9, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4160), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4159), "https://example.com/resume/devops_engineer_9.pdf", "DevOps Engineer", new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4158) },
                    { 10, new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4162), 10, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4163), new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4162), "https://example.com/resume/software_architect_10.pdf", "Software Architect", new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4161) },
                    { 11, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4165), 11, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4166), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4165), "https://example.com/resume/business_analyst_11.pdf", "Business Analyst", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4164) },
                    { 12, new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4168), 12, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4168), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4167), "https://example.com/resume/product_manager_12.pdf", "Product Manager", new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4167) },
                    { 13, new DateTime(2017, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4171), 13, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4171), new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4170), "https://example.com/resume/marketing_specialist_13.pdf", "Marketing Specialist", new DateTime(2017, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4170) },
                    { 14, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4173), 14, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4174), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4173), "https://example.com/resume/seo_specialist_14.pdf", "SEO Specialist", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4172) },
                    { 15, new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4176), 15, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4177), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4176), "https://example.com/resume/content_manager_15.pdf", "Content Manager", new DateTime(2018, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4175) },
                    { 16, new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4179), 16, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4180), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4179), "https://example.com/resume/cybersecurity_specialist_16.pdf", "Cybersecurity Specialist", new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4178) },
                    { 17, new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4182), 17, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4182), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4182), "https://example.com/resume/ai_engineer_17.pdf", "AI Engineer", new DateTime(2021, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4181) },
                    { 18, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4184), 18, new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4185), new DateTime(2024, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4184), "https://example.com/resume/ml_engineer_18.pdf", "Machine Learning Engineer", new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4184) },
                    { 19, new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4187), 19, new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4187), new DateTime(2023, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4186), "https://example.com/resume/blockchain_developer_19.pdf", "Blockchain Developer", new DateTime(2020, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4186) },
                    { 20, new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4189), 20, new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4190), new DateTime(2022, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4189), "https://example.com/resume/full_stack_developer_20.pdf", "Full Stack Developer", new DateTime(2019, 9, 16, 15, 33, 18, 922, DateTimeKind.Local).AddTicks(4189) }
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
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

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
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

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
                name: "UserRoles");

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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Nations");
        }
    }
}
