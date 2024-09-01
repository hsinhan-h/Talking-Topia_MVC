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
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coupons__384AF1BAE1D06BB9", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "CourseHours",
                columns: table => new
                {
                    CourseHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseHo__AE73575BBC30FF2E", x => x.CourseHourId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TwentyFiveMinUnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    FiftyMinUnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesStatus = table.Column<short>(type: "smallint", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D71A7F51F70E3", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyStartYear = table.Column<int>(type: "int", nullable: false),
                    StudyEndYear = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Educatio__4BBE38058A56247B", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nations__211B9BBEE3B01F5C", x => x.NationId);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategorites",
                columns: table => new
                {
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorytName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseCa__4D67EBB68E28BA31", x => x.CourseCategoryId);
                    table.ForeignKey(
                        name: "FK__CourseCat__Cours__5812160E",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    CourseImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadShotImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationId = table.Column<int>(type: "int", nullable: true),
                    IsVerifiedTutor = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    NativeLanguage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpokenLanguage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BankCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationId = table.Column<int>(type: "int", nullable: true),
                    TutorIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsTutor = table.Column<bool>(type: "bit", nullable: false)
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
                name: "CourseSubjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseSu__AC1BA3A8B5819935", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK__CourseSub__Cours__59063A47",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategorites",
                        principalColumn: "CourseCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "ApplyLists",
                columns: table => new
                {
                    ApplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ApplyStatus = table.Column<bool>(type: "bit", nullable: false),
                    ApplyDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateStatusDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTime = table.Column<short>(type: "smallint", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    MemberCouponId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CouponPrice = table.Column<decimal>(type: "money", nullable: true),
                    TaxIdNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    InvoiceType = table.Column<short>(type: "smallint", nullable: false),
                    VATNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SentVATEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderStatusId = table.Column<short>(type: "smallint", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    ProfessionalLicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalLicenseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalLicenseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    CourseType = table.Column<short>(type: "smallint", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BookingTime = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkExperienceFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WorkEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WorkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "MemberPreferences",
                columns: table => new
                {
                    MemberPreferenceId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    SubjecId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "TutorTimeSlots",
                columns: table => new
                {
                    TutorTimeSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorID = table.Column<int>(type: "int", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    CourseHourId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TutorTim__E709EE17B13CB862", x => x.TutorTimeSlotId);
                    table.ForeignKey(
                        name: "FK__TutorTime__Booki__5DCAEF64",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
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
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "money", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    CourseType = table.Column<short>(type: "smallint", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CourseCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourseSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BookingTime = table.Column<short>(type: "smallint", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    TempShoppingCartId = table.Column<int>(type: "int", nullable: true),
                    CDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9980), "SUMMER2024", "夏季優惠", 10, 1, new DateTime(2024, 10, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9963), true, null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9983), "WELCOME2024", "新用戶優惠", 20, 1, new DateTime(2024, 12, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9982), true, null }
                });

            migrationBuilder.InsertData(
                table: "CourseHours",
                columns: new[] { "CourseHourId", "CDate", "Hour", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9723), "00:00", null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9726), "01:00", null },
                    { 3, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9727), "02:00", null },
                    { 4, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9729), "03:00", null },
                    { 5, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9730), "04:00", null },
                    { 6, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9731), "05:00", null },
                    { 7, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9733), "06:00", null },
                    { 8, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9734), "07:00", null },
                    { 9, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9736), "08:00", null },
                    { 10, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9737), "09:00", null },
                    { 11, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9738), "10:00", null },
                    { 12, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9740), "11:00", null },
                    { 13, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9741), "12:00", null },
                    { 14, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9742), "13:00", null },
                    { 15, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9744), "14:00", null },
                    { 16, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9745), "15:00", null },
                    { 17, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9746), "16:00", null },
                    { 18, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9747), "17:00", null },
                    { 19, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9749), "18:00", null },
                    { 20, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9750), "19:00", null },
                    { 21, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9751), "20:00", null },
                    { 22, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9753), "21:00", null },
                    { 23, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9754), "22:00", null },
                    { 24, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9755), "23:00", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CDate", "CoursesStatus", "Description", "FiftyMinUnitPrice", "IsEnabled", "SubTitle", "SubjectId", "ThumbnailUrl", "Title", "TutorId", "TwentyFiveMinUnitPrice", "UDate", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9673), (short)1, "適合初學者的 C# 課程", 900m, true, "從零開始學習 C#", 1, "csharp.jpg", "C# 入門", 1, 500m, null, "csharp_intro.mp4" },
                    { 2, 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9681), (short)1, "日語入門課程", 800m, true, "基礎日語學習", 2, "japanese.jpg", "日語 N5", 2, 400m, null, "japanese_intro.mp4" },
                    { 3, 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9685), (short)1, "📅 隨時隨地進行日文學習，靈活安排時間，讓學習變得更自由！\r\n🗣️ 專屬一對一視訊教學，根據你的需求量身訂製課程內容！✨\r\n\r\n課程介紹文案：\r\n🌟 在全球化的今天，會一門外語是多麼重要！🌍 無論是工作、旅遊✈️還是單純的興趣，學習日文將為你開啟通往日本文化的大門！我們提供專業的線上日文家教，讓你隨時隨地都能學習日文📖，無需擔心地理限制和時間安排的困擾！透過我們的一對一教學，你可以根據自身的學習進度隨時提出問題，獲得即時回饋！💬\r\n\r\n🎥 透過高品質的視訊平台，專業的老師將與你進行一對一的互動，這樣不僅能建立更密切的師生關係🤝，也能確保每堂課都能充分關注你的學習進度和需求。這是在傳統教室中難以實現的優勢！我們的老師將幫助你克服任何學習上的障礙，並給予鼓勵💪，讓學習不再孤單。\r\n\r\n🎳 無論你是語言學習的新手，還是想要進一步提升日文能力的學生，我們的課程都可以根據你的基礎和目標來調整！📈無論是學習日常對話、商務日文📊還是準備JLPT考試🚀，我們都能提供最合適的學習計畫！從發音基礎到語法結構，每一個細節都不會被忽略。\r\n\r\n📚 我們的教師將利用各種多媒體教材📹和互動練習🎮，讓你愉快地學習日文，這包括視聽材料、遊戲、角色扮演及小組討論等多種形式，提升你的聽、說、讀、寫能力。即使是最枯燥的文法📜，在這種輕鬆的氛圍下也變得趣味盎然！\r\n\r\n🌈 除了語言課程，我們的教師將額外分享豐富的日本文化🇯🇵，包括日本的習俗、音樂🎶、美食🍱等，讓你在學習日文的同時，也能欣賞到日本的美好文化。每一堂課都會為你帶來全新的文化體驗😍，讓你不僅是學習文字，更是了解背後的故事！\r\n\r\n🍣 課程中不僅僅是口語練習，老師還將分享正宗的日本料理🍜食譜，幫助你在學習語言的同時，學會一些日本美食的製作！👩‍🍳 你會驚喜於食物背後的文化和歷史，這樣的學習過程使得每堂課都更生動且充滿趣味。\r\n\r\n🏆 現在就加入我們的線上日文家教，設定你自己的學習目標🎯，並開始輕鬆學習！不再只是枯燥的背單字，讓我們用互動式教學讓每次課堂都成為你期待的學習時光！⏰ 在老師的指導下，你很快將能日常自信地用日文交流！\r\n\r\n🎉 無論是準備考試📚、赴日旅行✈️或職場交流，專屬的老師會全力支持你，幫助你達成目標！報名後，無需花費時間尋找合適的教材📦，我們將為你精心準備學習資源，讓你快速進步！🚀 快來預約你的第一堂課，開始放飛你的日文夢想，開啟一段全新的學習旅程吧！🌟", 1088m, true, "💡 從基礎到高階語法—全面提升你的日語能力！", 2, "~/image/thumb_nails/thumbnail_demo_jp_001.webp", "Akimo老師 🔥精通日語：掌握這門全球流行語言的鑰匙！", 4, 560m, null, "https://www.youtube.com/embed/MAhD37a7AlE" },
                    { 4, 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9689), (short)1, "嗨！我是 👩‍🏫 Todd，擁有 10 年的教學經驗！📚\r\n\r\n🎓 我持有 英文教師證 的證書，並且擁有多次國際英語教學的實戰經驗。對於不同年齡層的學生，我都有教學的方法與技巧，尤其擅長讓學習變得有趣且富有成效。🌈\r\n\r\n在這堂課中，我會根據學生的需求和程度量身定製教學計畫，讓每一位學生都能在輕鬆的氛圍中學習。課程的設計旨在建立自信心，讓你能夠在日常生活中自如地使用英語，無論是與朋友交談、旅遊還是商務會議中，都能夠流利溝通。🚀", 1100m, true, "Expert! 🏅 Basic to Advanced😀", 1, "~/image/thumb_nails/tutor002_thumbnail.jpg", "Todd American Teacher!🏅Kid's English🔥精通英文：掌握這門全球流行語言的鑰匙！", 5, 700m, null, "https://www.youtube.com/embed/xXsfl6RBuhQ" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CDate", "DepartmentName", "SchoolName", "StudyEndYear", "StudyStartYear", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9455), "資訊工程", "台灣大學", 2014, 2010, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9480) },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9489), "數學系", "東京大學", 2016, 2012, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9489) },
                    { 3, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9491), "經濟系", "哈佛大學", 2019, 2015, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9492) }
                });

            migrationBuilder.InsertData(
                table: "Nations",
                columns: new[] { "NationId", "FlagImage", "NationName" },
                values: new object[,]
                {
                    { 1, "~/image/flag_imgs/taiwan_flag.jpg", "台灣" },
                    { 2, "~/image/flag_imgs/japan_flag.png", "日本" },
                    { 3, "~/image/flag_imgs/us_flag.png", "美國" }
                });

            migrationBuilder.InsertData(
                table: "CourseCategorites",
                columns: new[] { "CourseCategoryId", "CategorytName", "CDate", "CourseId", "UDate" },
                values: new object[,]
                {
                    { 1, "程式設計", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9791), 1, null },
                    { 2, "語言學習", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9793), 2, null }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "CourseImageId", "CDate", "CourseId", "ImageUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9880), 1, "csharp_image.jpg", null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9882), 2, "japanese_image.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Account", "AccountType", "BankAccount", "BankCode", "Birthday", "CDate", "EducationId", "Email", "FirstName", "Gender", "HeadShotImage", "IsTutor", "IsVerifiedTutor", "LastName", "NationId", "NativeLanguage", "Nickname", "Password", "Phone", "SpokenLanguage", "TutorIntro", "UDate" },
                values: new object[,]
                {
                    { 1, "xiaoming_account", 1, "12345678", "123", new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9547), 1, "xiaoming@example.com", "小明", (short)1, "xiaoming.jpg", true, true, "王", 1, "中文", "明哥", "hashedpassword1", "0912345678", "英文", "專業C#講師", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9548) },
                    { 2, "ken_account", 2, "87654321", "456", new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9599), 2, "ken@example.com", "健", (short)1, "ken.jpg", false, false, "佐藤", 2, "日語", "健哥", "hashedpassword2", "0800123456", "中文", "日語教學專家", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9600) },
                    { 3, "john_doe_account", 1, "98765432", "789", new DateTime(1992, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9607), 3, "john@example.com", "John", (short)1, "john_doe.jpg", true, true, "Doe", 3, "英文", "Johnny", "hashedpassword3", "0700123456", "西班牙語", "資深英語導師", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9608) },
                    { 4, "akimo_account", 1, "98765432", "700", new DateTime(1990, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9614), 3, "akimo@example.com", "Akimo", (short)0, "~/image/tutor_headshot_imgs/tutor_demo_jp_001.webp", true, true, "Sato", 2, "日文", "Akimo", "hashedpassword4", "0711111111", "日文", "こんにちは！👋 私は Akimoです。生まれも育ちも日本で、日本語を教えることに情熱を持っています。🇯🇵 私は大学で日本語教育を専攻し、修士課程を修了後、さまざまな学校や語学機関で7年間教鞭を執ってきました。📚 これまでに、世界中の多くの学生たちに日本語の魅力を伝え、彼らが日本語能力試験に合格し、仕事や日常生活で日本語を自由に使えるようにサポートしてきました。🎓\r\n\r\n私は、生徒一人ひとりの個性を大切にし、それぞれの目標に応じた最適な学習プランを提供します。🎯 私の授業では、単なる文法や単語の暗記だけでなく、実際に使える日本語を身につけることに重点を置いています。具体的な場面を想定した会話練習や、文化についてのディスカッションを通じて、言葉の背景にある日本の文化や価値観も理解していただけるよう努めています。🎌\r\n\r\n私の目標は、皆さんが日本語を学ぶ楽しさを実感し、自信を持って日本語を使えるようになることです。💪 一緒に日本語の世界を探求し、新しい可能性を広げていきましょう！🚀 お会いできるのを楽しみにしています。😊", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9614) },
                    { 5, "todd_account", 1, "98765432", "789", new DateTime(1963, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9620), 3, "todd@example.com", "Todd", (short)1, "~/image/tutor_headshot_imgs/tutor_head_002.png", true, true, "Smith", 3, "英文", "Toddy", "hashedpassword5", "0700222454", "英文 西班牙語", "嗨！我是 👩‍🏫 Todd，擁有 10 年的教學經驗！📚\r\n\r\n🎓 我持有 英文教師證 的證書，並且擁有多次國際英語教學的實戰經驗。對於不同年齡層的學生，我都有教學的方法與技巧，尤其擅長讓學習變得有趣且富有成效。🌈\r\n\r\n在這堂課中，我會根據學生的需求和程度量身定製教學計畫，讓每一位學生都能在輕鬆的氛圍中學習。課程的設計旨在建立自信心，讓你能夠在日常生活中自如地使用英語，無論是與朋友交談、旅遊還是商務會議中，都能夠流利溝通。🚀", new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9621) }
                });

            migrationBuilder.InsertData(
                table: "ApplyLists",
                columns: new[] { "ApplyID", "ApplyDateTime", "ApplyStatus", "ApprovedDateTime", "MemberId", "RejectReason", "UpdateStatusDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(30), true, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(34), 1, "無", new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(35) },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(37), false, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(38), 2, "不符合資格", new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(39) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(59), (short)800, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(60), 1, 1, null },
                    { 2, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), (short)900, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(69), 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "CourseSubjects",
                columns: new[] { "SubjectId", "CDate", "CourseCategoryId", "SubjectName", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9861), 1, "C#", null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9863), 2, "日語", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CDate", "CouponPrice", "InvoiceType", "MemberId", "OrderStatusId", "PaymentType", "SentVATEmail", "TaxIdNumber", "TotalPrice", "TransactionDate", "UDate", "VATNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9913), null, (short)1, 1, (short)1, "Credit Card", null, null, 1000m, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9907), null, null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9916), null, (short)1, 2, (short)1, "Paypal", null, null, 2000m, new DateTime(2024, 9, 1, 14, 18, 51, 441, DateTimeKind.Local).AddTicks(9915), null, null }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalLicenseId", "CDate", "MemberId", "ProfessionalLicenseName", "ProfessionalLicenseUrl", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(91), 1, "C# 認證", "csharp_certificate.jpg", null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(93), 2, "日語能力測驗 N1", "jlpt_n1.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(112), "很棒的課程！", 1, (byte)5, 1, null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(114), "非常實用！", 2, (byte)4, 2, null },
                    { 3, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(116), "講得不錯! 但笑話有點冷", 1, (byte)4, 2, null },
                    { 4, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(117), "讚讚讚", 1, (byte)4, 3, null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "BookingDate", "BookingTime", "CDate", "CourseId", "CourseType", "MemberId", "Quantity", "TotalPrice", "UDate", "UnitPrice" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(152), 1, (short)1, 1, (short)2, 1000m, null, 500m },
                    { 2, null, null, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(154), 2, (short)1, 2, (short)1, 1000m, null, 1000m }
                });

            migrationBuilder.InsertData(
                table: "WorkExperiences",
                columns: new[] { "WorkExperienceId", "CDate", "MemberId", "UDate", "WorkEndDate", "WorkExperienceFile", "WorkName", "WorkStartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(232), 1, null, new DateTime(2023, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(231), "csharp_experience.pdf", null, new DateTime(2021, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(229) },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(235), 2, null, new DateTime(2022, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(234), "japanese_experience.pdf", null, new DateTime(2019, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(233) }
                });

            migrationBuilder.InsertData(
                table: "MemberPreferences",
                columns: new[] { "MemberPreferenceId", "CDate", "MemberId", "SubjecId", "UDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(5), 1, 1, null },
                    { 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(6), 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "CourseCategory", "CourseId", "CourseSubject", "CourseTitle", "CourseType", "DiscountPrice", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "程式設計", 1, "C#", "C# 入門", (short)1, null, (short)2, 1000m, 500m },
                    { 2, 2, "語言學習", 2, "日語", "日語 N5", (short)1, null, (short)2, 2000m, 1000m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartBookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "CDate", "CourseId", "MemberId", "TempShoppingCartId", "UDate" },
                values: new object[,]
                {
                    { 1, null, (short)800, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(184), 1, 1, 1, null },
                    { 2, null, (short)900, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(187), 2, 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "TutorTimeSlots",
                columns: new[] { "TutorTimeSlotId", "BookingId", "CDate", "CourseHourId", "TutorID", "UDate", "Weekday" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(210), 1, 1, null, 1 },
                    { 2, 2, new DateTime(2024, 9, 1, 14, 18, 51, 442, DateTimeKind.Local).AddTicks(212), 2, 2, null, 2 }
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
                name: "IX_CourseCategorites_CourseId",
                table: "CourseCategorites",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseImages_CourseId",
                table: "CourseImages",
                column: "CourseId");

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
                name: "IX_TutorTimeSlots_BookingId",
                table: "TutorTimeSlots",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTimeSlots_CourseHourId",
                table: "TutorTimeSlots",
                column: "CourseHourId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorTimeSlots_TutorID",
                table: "TutorTimeSlots",
                column: "TutorID");

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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CourseHours");

            migrationBuilder.DropTable(
                name: "CourseCategorites");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Nations");
        }
    }
}
