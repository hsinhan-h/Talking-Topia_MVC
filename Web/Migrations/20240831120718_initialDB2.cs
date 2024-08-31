using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class initialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplyLists",
                keyColumn: "ApplyID",
                keyValue: 1,
                columns: new[] { "ApplyDateTime", "ApprovedDateTime", "UpdateStatusDateTime" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7271), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7272), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "ApplyLists",
                keyColumn: "ApplyID",
                keyValue: 2,
                columns: new[] { "ApplyDateTime", "ApprovedDateTime", "UpdateStatusDateTime" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7274), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7274), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "BookingDate", "CDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7291), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7292) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                columns: new[] { "CDate", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7207), new DateTime(2024, 9, 30, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                columns: new[] { "CDate", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7209), new DateTime(2024, 11, 30, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "CourseCategorites",
                keyColumn: "CourseCategoryId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "CourseCategorites",
                keyColumn: "CourseCategoryId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "CourseHours",
                keyColumn: "CourseHourId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "CourseHours",
                keyColumn: "CourseHourId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "CourseImages",
                keyColumn: "CourseImageId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "CourseImages",
                keyColumn: "CourseImageId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "CourseSubjects",
                keyColumn: "SubjectId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "CourseSubjects",
                keyColumn: "SubjectId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6971), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6985) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6991), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6991) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6992), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "MemberPreferences",
                keyColumn: "MemberPreferenceId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "MemberPreferences",
                keyColumn: "MemberPreferenceId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7032), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7037), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "CDate", "TransactionDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7152), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "CDate", "TransactionDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7154), new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "ProfessionalLicenses",
                keyColumn: "ProfessionalLicenseId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "ProfessionalLicenses",
                keyColumn: "ProfessionalLicenseId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CDate", "CommentText", "CourseId", "Rating", "StudentId", "UDate" },
                values: new object[] { 4, new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7330), "讚讚", 1, (byte)4, 3, null });

            migrationBuilder.UpdateData(
                table: "ShoppingCartBookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "ShoppingCartBookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "TutorTimeSlots",
                keyColumn: "TutorTimeSlotId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "TutorTimeSlots",
                keyColumn: "TutorTimeSlotId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "WorkExperienceId",
                keyValue: 1,
                columns: new[] { "CDate", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7406), new DateTime(2023, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7405), new DateTime(2021, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "WorkExperienceId",
                keyValue: 2,
                columns: new[] { "CDate", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new DateTime(2024, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7408), new DateTime(2022, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7407), new DateTime(2019, 8, 31, 20, 7, 17, 749, DateTimeKind.Local).AddTicks(7407) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ApplyLists",
                keyColumn: "ApplyID",
                keyValue: 1,
                columns: new[] { "ApplyDateTime", "ApprovedDateTime", "UpdateStatusDateTime" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3255), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3255), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "ApplyLists",
                keyColumn: "ApplyID",
                keyValue: 2,
                columns: new[] { "ApplyDateTime", "ApprovedDateTime", "UpdateStatusDateTime" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3257), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3258), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "BookingDate", "CDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3272), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                columns: new[] { "CDate", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3214), new DateTime(2024, 9, 30, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3206) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                columns: new[] { "CDate", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3216), new DateTime(2024, 11, 30, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3215) });

            migrationBuilder.UpdateData(
                table: "CourseCategorites",
                keyColumn: "CourseCategoryId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "CourseCategorites",
                keyColumn: "CourseCategoryId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "CourseHours",
                keyColumn: "CourseHourId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "CourseHours",
                keyColumn: "CourseHourId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "CourseImages",
                keyColumn: "CourseImageId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "CourseImages",
                keyColumn: "CourseImageId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "CourseSubjects",
                keyColumn: "SubjectId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "CourseSubjects",
                keyColumn: "SubjectId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2981), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2981) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2982), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "MemberPreferences",
                keyColumn: "MemberPreferenceId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "MemberPreferences",
                keyColumn: "MemberPreferenceId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3013), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3021), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                columns: new[] { "CDate", "UDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3027), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3028) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "CDate", "TransactionDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3172), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3171) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "CDate", "TransactionDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3174), new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "ProfessionalLicenses",
                keyColumn: "ProfessionalLicenseId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "ProfessionalLicenses",
                keyColumn: "ProfessionalLicenseId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "ShoppingCartBookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "ShoppingCartBookings",
                keyColumn: "BookingId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "TutorTimeSlots",
                keyColumn: "TutorTimeSlotId",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "TutorTimeSlots",
                keyColumn: "TutorTimeSlotId",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "WorkExperienceId",
                keyValue: 1,
                columns: new[] { "CDate", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3407), new DateTime(2023, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3407), new DateTime(2021, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "WorkExperienceId",
                keyValue: 2,
                columns: new[] { "CDate", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new DateTime(2024, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3410), new DateTime(2022, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3409), new DateTime(2019, 8, 31, 19, 51, 42, 32, DateTimeKind.Local).AddTicks(3408) });
        }
    }
}
