using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web.Entities;

public partial class TalkingTopiaContext : DbContext
{
    public TalkingTopiaContext()
    {
    }

    public TalkingTopiaContext(DbContextOptions<TalkingTopiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplyList> ApplyLists { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }

    public virtual DbSet<CourseHour> CourseHours { get; set; }

    public virtual DbSet<CourseImage> CourseImages { get; set; }

    public virtual DbSet<CourseSubject> CourseSubjects { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberCoupon> MemberCoupons { get; set; }

    public virtual DbSet<MemberPreference> MemberPreferences { get; set; }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ProfessionalLicense> ProfessionalLicenses { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<ShoppingCartBooking> ShoppingCartBookings { get; set; }

    public virtual DbSet<TutorTimeSlot> TutorTimeSlots { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=TalkingTopia;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplyList>(entity =>
        {
            entity.HasKey(e => e.ApplyId).HasName("PK__ApplyLis__F0687F91F95B14E5");

            entity.HasIndex(e => e.MemberId, "IX_ApplyLists_MemberId");

            entity.Property(e => e.ApplyId)
                .HasComment("申請Id")
                .HasColumnName("ApplyID");
            entity.Property(e => e.ApplyDateTime)
                .HasComment("申請日期")
                .HasColumnType("datetime");
            entity.Property(e => e.ApplyStatus).HasComment("申請狀態");
            entity.Property(e => e.ApprovedDateTime)
                .HasComment("審核通過時間")
                .HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(50)
                .HasComment("拒絕原因");
            entity.Property(e => e.UpdateStatusDateTime)
                .HasComment("更新審核通過時間")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.ApplyLists)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ApplyList__Membe__59FA5E80");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AEDF4836C80");

            entity.HasIndex(e => e.CourseId, "IX_Bookings_CourseId");

            entity.HasIndex(e => e.StudentId, "IX_Bookings_StudentId");

            entity.Property(e => e.BookingId).HasComment("預約Id");
            entity.Property(e => e.BookingDate).HasComment("預約上課日期");
            entity.Property(e => e.BookingTime).HasComment("預約上課時間");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.StudentId).HasComment("預約學生Id");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Course).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Course__5441852A");

            entity.HasOne(d => d.Student).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Member__534D60F1");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.CouponId).HasName("PK__Coupons__384AF1BAE1D06BB9");

            entity.Property(e => e.CouponId).HasComment("優惠折扣Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CouponCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("折扣代碼");
            entity.Property(e => e.CouponName)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength()
                .HasComment("優惠折扣名稱");
            entity.Property(e => e.Discount).HasComment("折扣");
            entity.Property(e => e.DiscountType).HasComment("折扣方式");
            entity.Property(e => e.ExpirationDate)
                .HasComment("折扣到期日")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasComment("是否有效");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7F51F70E3");

            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.CategoryId).HasComment("課程類別Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CoursesStatus).HasComment("課程審核狀態");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasComment("課程詳細描述");
            entity.Property(e => e.FiftyMinUnitPrice)
                .HasComment("50分鐘價")
                .HasColumnType("money");
            entity.Property(e => e.IsEnabled).HasComment("是否顯示");
            entity.Property(e => e.SubTitle)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("課程副標題");
            entity.Property(e => e.SubjectId).HasComment("科目Id");
            entity.Property(e => e.ThumbnailUrl)
                .IsRequired()
                .HasComment("影片封面");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("課程標題");
            entity.Property(e => e.TutorId).HasComment("學生Id");
            entity.Property(e => e.TwentyFiveMinUnitPrice)
                .HasComment("25分鐘價")
                .HasColumnType("money");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.VideoUrl)
                .IsRequired()
                .HasComment("影片路徑");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_CourseCategories");
        });

        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(e => e.CourseCategoryId).HasName("PK__CourseCa__4D67EBB68E28BA31");

            entity.Property(e => e.CourseCategoryId).HasComment("課程類別Id");
            entity.Property(e => e.CategorytName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("課程類別名稱");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<CourseHour>(entity =>
        {
            entity.HasKey(e => e.CourseHourId).HasName("PK__CourseHo__AE73575BBC30FF2E");

            entity.Property(e => e.CourseHourId).HasComment("課程時間Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Hour)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("小時時段");
            entity.Property(e => e.Udate)
                .HasComment("更改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<CourseImage>(entity =>
        {
            entity.HasKey(e => e.CourseImageId).HasName("PK__CourseIm__349B6FE480594337");

            entity.HasIndex(e => e.CourseId, "IX_CourseImages_CourseId");

            entity.Property(e => e.CourseImageId).HasComment("課程照片Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.ImageUrl)
                .IsRequired()
                .HasComment("圖片路徑");
            entity.Property(e => e.Udate)
                .HasComment("更改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseImages)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseIma__Cours__52593CB8");
        });

        modelBuilder.Entity<CourseSubject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__CourseSu__AC1BA3A8B5819935");

            entity.HasIndex(e => e.CourseCategoryId, "IX_CourseSubjects_CourseCategoryId");

            entity.Property(e => e.SubjectId).HasComment("課程科目Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseCategoryId).HasComment("課程類別Id");
            entity.Property(e => e.SubjectName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("課程科目名稱");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.CourseCategory).WithMany(p => p.CourseSubjects)
                .HasForeignKey(d => d.CourseCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseSub__Cours__59063A47");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE38058A56247B");

            entity.Property(e => e.EducationId).HasComment("學歷Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .HasComment("科系名稱");
            entity.Property(e => e.SchoolName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("學校名稱");
            entity.Property(e => e.StudyEndYear).HasComment("在學期間迄");
            entity.Property(e => e.StudyStartYear).HasComment("在學期間起");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B1808627D7C");

            entity.HasIndex(e => e.EducationId, "IX_Members_EducationId");

            entity.HasIndex(e => e.NationId, "IX_Members_NationId");

            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.Account).HasComment("帳號");
            entity.Property(e => e.AccountType).HasComment("帳號類型");
            entity.Property(e => e.BankAccount)
                .HasMaxLength(50)
                .HasComment("帳戶名稱");
            entity.Property(e => e.BankCode)
                .HasMaxLength(50)
                .HasComment("銀行代碼");
            entity.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnType("datetime");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.EducationId).HasComment("最高學歷Id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("電子郵件信箱");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("名字");
            entity.Property(e => e.Gender).HasComment("性別");
            entity.Property(e => e.HeadShotImage).HasComment("會員頭像");
            entity.Property(e => e.IsTutor).HasComment("是否為教師");
            entity.Property(e => e.IsVerifiedTutor).HasComment("優質會員");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("姓氏");
            entity.Property(e => e.NationId).HasComment("國籍Id");
            entity.Property(e => e.NativeLanguage)
                .HasMaxLength(255)
                .HasComment("母語");
            entity.Property(e => e.Nickname)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("綽號");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("密碼");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("電話");
            entity.Property(e => e.SpokenLanguage)
                .HasMaxLength(255)
                .HasComment("會的語言");
            entity.Property(e => e.TutorIntro).HasComment("教師自介");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Education).WithMany(p => p.Members)
                .HasForeignKey(d => d.EducationId)
                .HasConstraintName("FK__Members__Educati__49C3F6B7");

            entity.HasOne(d => d.Nation).WithMany(p => p.Members)
                .HasForeignKey(d => d.NationId)
                .HasConstraintName("FK__Members__NationI__48CFD27E");
        });

        modelBuilder.Entity<MemberCoupon>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CouponId, "IX_MemberCoupons_CouponId");

            entity.HasIndex(e => e.MemberId, "IX_MemberCoupons_MemberId");

            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CouponId).HasComment("優惠折扣Id");
            entity.Property(e => e.IsUsed).HasComment("是否使用");
            entity.Property(e => e.MemberCouponId).HasComment("會員優惠Id");
            entity.Property(e => e.MemberId).HasComment("會員Id");

            entity.HasOne(d => d.Coupon).WithMany()
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberCoupons_Coupons");

            entity.HasOne(d => d.Member).WithMany()
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberCoupons_Members");
        });

        modelBuilder.Entity<MemberPreference>(entity =>
        {
            entity.HasKey(e => e.MemberPreferenceId).HasName("PK__MemberPr__5B2A2D7058311916");

            entity.HasIndex(e => e.MemberId, "IX_MemberPreferences_MemberId");

            entity.HasIndex(e => e.SubjecId, "IX_MemberPreferences_SubjecId");

            entity.Property(e => e.MemberPreferenceId).HasComment("會員偏好Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.SubjecId).HasComment("主題Id");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberPreferences)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPre__Membe__5AEE82B9");

            entity.HasOne(d => d.Subjec).WithMany(p => p.MemberPreferences)
                .HasForeignKey(d => d.SubjecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPre__Subje__52593CB8");
        });

        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.NationId).HasName("PK__Nations__211B9BBEE3B01F5C");

            entity.Property(e => e.NationId).HasComment("國籍Id");
            entity.Property(e => e.FlagImage)
                .IsRequired()
                .HasComment("國籍圖片路徑");
            entity.Property(e => e.NationName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("國籍名稱");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCFBCC07793");

            entity.HasIndex(e => e.MemberId, "IX_Orders_MemberId");

            entity.Property(e => e.OrderId).HasComment("訂單Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CouponPrice)
                .HasComment("優惠金額")
                .HasColumnType("money");
            entity.Property(e => e.InvoiceType).HasComment("發票類型");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.OrderStatusId).HasComment("訂單狀態");
            entity.Property(e => e.PaymentType)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("付款方式");
            entity.Property(e => e.SentVatemail)
                .HasMaxLength(100)
                .HasComment("寄送Mail")
                .HasColumnName("SentVATEmail");
            entity.Property(e => e.TaxIdNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("統一編號");
            entity.Property(e => e.TotalPrice)
                .HasComment("總金額")
                .HasColumnType("money");
            entity.Property(e => e.TransactionDate)
                .HasComment("交易日期")
                .HasColumnType("datetime");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.Vatnumber)
                .HasMaxLength(8)
                .HasComment("發票號碼")
                .HasColumnName("VATNumber");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__MemberId__4BAC3F29");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderDetailId, e.OrderId }).HasName("PK__OrderDet__3F80D6D0305DA525");

            entity.HasIndex(e => e.CourseId, "IX_OrderDetails_CourseId");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedOnAdd()
                .HasComment("訂單明細Id");
            entity.Property(e => e.OrderId).HasComment("訂單Id");
            entity.Property(e => e.CourseCategory)
                .HasMaxLength(50)
                .HasComment("課程類別");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.CourseSubject)
                .HasMaxLength(50)
                .HasComment("課程主題");
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(255)
                .HasComment("課程名稱");
            entity.Property(e => e.CourseType).HasComment("課程類別");
            entity.Property(e => e.DiscountPrice)
                .HasComment("折扣金額")
                .HasColumnType("money");
            entity.Property(e => e.Quantity).HasComment("購買堂數");
            entity.Property(e => e.TotalPrice)
                .HasComment("總價")
                .HasColumnType("money");
            entity.Property(e => e.UnitPrice)
                .HasComment("課程單價")
                .HasColumnType("money");

            entity.HasOne(d => d.Course).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Cours__4E88ABD4");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__4D94879B");
        });

        modelBuilder.Entity<ProfessionalLicense>(entity =>
        {
            entity.HasKey(e => e.ProfessionalLicenseId).HasName("PK__Professi__E1630CEE26905146");

            entity.HasIndex(e => e.MemberId, "IX_ProfessionalLicenses_MemberId");

            entity.Property(e => e.ProfessionalLicenseId).HasComment("證照Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.ProfessionalLicenseName)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("證照名稱");
            entity.Property(e => e.ProfessionalLicenseUrl)
                .IsRequired()
                .HasComment("證照路徑");
            entity.Property(e => e.Udate)
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Member).WithMany(p => p.ProfessionalLicenses)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professio__Membe__5165187F");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CE821ED086");

            entity.HasIndex(e => e.CourseId, "IX_Reviews_CourseId");

            entity.HasIndex(e => e.StudentId, "IX_Reviews_StudentId");

            entity.Property(e => e.ReviewId).HasComment("課程評論Id");
            entity.Property(e => e.Cdate)
                .HasComment("評論日期")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CommentText).HasComment("評論內容");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.Rating).HasComment("評分");
            entity.Property(e => e.StudentId).HasComment("學生Id");
            entity.Property(e => e.Udate)
                .HasComment("修改日期")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Course).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__CourseI__5070F446");

            entity.HasOne(d => d.Student).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__MemberI__4F7CD00D");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.ShoppingCartId).HasName("PK__TempOrde__38D216B780E2926D");

            entity.HasIndex(e => e.CourseId, "IX_ShoppingCarts_CourseId");

            entity.HasIndex(e => e.MemberId, "IX_ShoppingCarts_MemberId");

            entity.Property(e => e.ShoppingCartId).HasComment("購物車Id");
            entity.Property(e => e.BookingDate)
                .HasComment("預約日期")
                .HasColumnType("datetime");
            entity.Property(e => e.BookingTime)
                .HasComment("預約時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.CourseType).HasComment("課程類型");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.Quantity).HasComment("購買堂數");
            entity.Property(e => e.TotalPrice)
                .HasComment("單筆總價")
                .HasColumnType("money");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.UnitPrice)
                .HasComment("課程單價")
                .HasColumnType("money");

            entity.HasOne(d => d.Course).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCarts_Courses");

            entity.HasOne(d => d.Member).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCarts_Members");
        });

        modelBuilder.Entity<ShoppingCartBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Shopping__73951AED7A624397");

            entity.HasIndex(e => e.TempShoppingCartId, "IX_ShoppingCartBookings_TempShoppingCartId");

            entity.Property(e => e.BookingId).HasComment("課程預定Id");
            entity.Property(e => e.BookingDate).HasComment("預約日期");
            entity.Property(e => e.BookingTime).HasComment("預約時間");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseId).HasComment("課程Id");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.TempShoppingCart).WithMany(p => p.ShoppingCartBookings)
                .HasForeignKey(d => d.TempShoppingCartId)
                .HasConstraintName("FK__TempShopp__TempS__60A75C0F");
        });

        modelBuilder.Entity<TutorTimeSlot>(entity =>
        {
            entity.HasKey(e => e.TutorTimeSlotId).HasName("PK__TutorTim__E709EE17B13CB862");

            entity.HasIndex(e => e.BookingId, "IX_TutorTimeSlots_BookingId");

            entity.HasIndex(e => e.CourseHourId, "IX_TutorTimeSlots_CourseHourId");

            entity.HasIndex(e => e.TutorId, "IX_TutorTimeSlots_TutorID");

            entity.Property(e => e.TutorTimeSlotId).HasComment("教師可預約Id");
            entity.Property(e => e.BookingId).HasComment("預約課程Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CourseHourId).HasComment("開課時間");
            entity.Property(e => e.TutorId)
                .HasComment("老師Id")
                .HasColumnName("TutorID");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.Weekday).HasComment("開課星期");

            entity.HasOne(d => d.Booking).WithMany(p => p.TutorTimeSlots)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorTime__Booki__5DCAEF64");

            entity.HasOne(d => d.CourseHour).WithMany(p => p.TutorTimeSlots)
                .HasForeignKey(d => d.CourseHourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorTime__Cours__5EBF139D");

            entity.HasOne(d => d.Tutor).WithMany(p => p.TutorTimeSlots)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorTime__Membe__5535A963");
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.WorkExperienceId).HasName("PK__WorkExpe__55A2B889201583D4");

            entity.HasIndex(e => e.MemberId, "IX_WorkExperiences_MemberId");

            entity.Property(e => e.WorkExperienceId).HasComment("工作經驗Id");
            entity.Property(e => e.Cdate)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.MemberId).HasComment("會員Id");
            entity.Property(e => e.Udate)
                .HasComment("修改時間")
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.WorkEndDate)
                .HasComment("工作結束日")
                .HasColumnType("datetime");
            entity.Property(e => e.WorkExperienceFile)
                .IsRequired()
                .HasComment("工作經驗檔案路徑");
            entity.Property(e => e.WorkName)
                .HasMaxLength(50)
                .HasComment("工作經驗名稱");
            entity.Property(e => e.WorkStartDate)
                .HasComment("工作起始日")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkExper__Membe__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);

        #region 假資料內容
        modelBuilder.Entity<Nation>().HasData(
    new Nation { NationId = 1, NationName = "台灣", FlagImage = "taiwan.jpg" },
    new Nation { NationId = 2, NationName = "日本", FlagImage = "japan.jpg" },
    new Nation { NationId = 3, NationName = "美國", FlagImage = "usa.jpg" }
);
        modelBuilder.Entity<Education>().HasData(
    new Education { EducationId = 1, SchoolName = "台灣大學", StudyStartYear = 2010, StudyEndYear = 2014, DepartmentName = "資訊工程", Cdate = DateTime.Now, Udate = DateTime.Now },
    new Education { EducationId = 2, SchoolName = "東京大學", StudyStartYear = 2012, StudyEndYear = 2016, DepartmentName = "數學系", Cdate = DateTime.Now, Udate = DateTime.Now },
    new Education { EducationId = 3, SchoolName = "哈佛大學", StudyStartYear = 2015, StudyEndYear = 2019, DepartmentName = "經濟系", Cdate = DateTime.Now, Udate = DateTime.Now }
);

        modelBuilder.Entity<Member>().HasData(
    new Member
    {
        MemberId = 1,
        HeadShotImage = "xiaoming.jpg",
        NationId = 1,
        IsVerifiedTutor = true,
        FirstName = "小明",
        LastName = "王",
        Password = "hashedpassword1",
        Email = "xiaoming@example.com",
        Nickname = "明哥",
        Phone = "0912345678",
        Birthday = new DateTime(1990, 5, 20),
        Gender = 1,
        NativeLanguage = "中文",
        SpokenLanguage = "英文",
        BankCode = "123",
        BankAccount = "12345678",
        EducationId = 1,
        TutorIntro = "專業C#講師",
        Account = "xiaoming_account",
        AccountType = 1,
        Cdate = DateTime.Now,
        Udate = DateTime.Now,
        IsTutor = true
    },
    new Member
    {
        MemberId = 2,
        HeadShotImage = "ken.jpg",
        NationId = 2,
        IsVerifiedTutor = false,
        FirstName = "健",
        LastName = "佐藤",
        Password = "hashedpassword2",
        Email = "ken@example.com",
        Nickname = "健哥",
        Phone = "0800123456",
        Birthday = new DateTime(1985, 8, 15),
        Gender = 1,
        NativeLanguage = "日語",
        SpokenLanguage = "中文",
        BankCode = "456",
        BankAccount = "87654321",
        EducationId = 2,
        TutorIntro = "日語教學專家",
        Account = "ken_account",
        AccountType = 2,
        Cdate = DateTime.Now,
        Udate = DateTime.Now,
        IsTutor = false
    },
    new Member
    {
        MemberId = 3,
        HeadShotImage = "john_doe.jpg",
        NationId = 3,
        IsVerifiedTutor = true,
        FirstName = "John",
        LastName = "Doe",
        Password = "hashedpassword3",
        Email = "john@example.com",
        Nickname = "Johnny",
        Phone = "0700123456",
        Birthday = new DateTime(1992, 11, 30),
        Gender = 1,
        NativeLanguage = "英文",
        SpokenLanguage = "西班牙語",
        BankCode = "789",
        BankAccount = "98765432",
        EducationId = 3,
        TutorIntro = "資深英語導師",
        Account = "john_doe_account",
        AccountType = 1,
        Cdate = DateTime.Now,
        Udate = DateTime.Now,
        IsTutor = true
    },
    new Member
    {
        MemberId = 4,
        HeadShotImage = "~/image/tutor_headshot_imgs/tutor_demo_jp_001.webp",
        NationId = 2,
        IsVerifiedTutor = true,
        FirstName = "Akimo",
        LastName = "Sato",
        Password = "hashedpassword4",
        Email = "akimo@example.com",
        Nickname = "Akimo",
        Phone = "0711111111",
        Birthday = new DateTime(1990, 7, 7),
        Gender = 0,
        NativeLanguage = "日文",
        SpokenLanguage = "日文",
        BankCode = "700",
        BankAccount = "98765432",
        EducationId = 3,
        TutorIntro = "こんにちは！👋 私は Akimoです。生まれも育ちも日本で、日本語を教えることに情熱を持っています。🇯🇵 私は大学で日本語教育を専攻し、修士課程を修了後、さまざまな学校や語学機関で7年間教鞭を執ってきました。📚 これまでに、世界中の多くの学生たちに日本語の魅力を伝え、彼らが日本語能力試験に合格し、仕事や日常生活で日本語を自由に使えるようにサポートしてきました。🎓\r\n\r\n私は、生徒一人ひとりの個性を大切にし、それぞれの目標に応じた最適な学習プランを提供します。🎯 私の授業では、単なる文法や単語の暗記だけでなく、実際に使える日本語を身につけることに重点を置いています。具体的な場面を想定した会話練習や、文化についてのディスカッションを通じて、言葉の背景にある日本の文化や価値観も理解していただけるよう努めています。🎌\r\n\r\n私の目標は、皆さんが日本語を学ぶ楽しさを実感し、自信を持って日本語を使えるようになることです。💪 一緒に日本語の世界を探求し、新しい可能性を広げていきましょう！🚀 お会いできるのを楽しみにしています。😊",
        Account = "akimo_account",
        AccountType = 1,
        Cdate = DateTime.Now,
        Udate = DateTime.Now,
        IsTutor = true
    },
    new Member
    {
        MemberId = 5,
        HeadShotImage = "~/image/tutor_headshot_imgs/tutor_head_002.png",
        NationId = 1,
        IsVerifiedTutor = false,
        FirstName = "大衛",
        LastName = "李",
        Password = "hashedpassword5",
        Email = "todd@example.com",
        Nickname = "David",
        Phone = "0700222454",
        Birthday = new DateTime(1993, 11, 5),
        Gender = 1,
        NativeLanguage = "英文",
        SpokenLanguage = "英文 中文",
        BankCode = "789",
        BankAccount = "98765432",
        EducationId = 3,
        TutorIntro = "嗨！我是 👩‍🏫 李老師，擁有 10 年的教學經驗！📚\r\n\r\n🎓 我持有 英文教師證 的證書，並且擁有多次國際英語教學的實戰經驗。對於不同年齡層的學生，我都有教學的方法與技巧，尤其擅長讓學習變得有趣且富有成效。🌈\r\n\r\n在這堂課中，我會根據學生的需求和程度量身定製教學計畫，讓每一位學生都能在輕鬆的氛圍中學習。課程的設計旨在建立自信心，讓你能夠在日常生活中自如地使用英語，無論是與朋友交談、旅遊還是商務會議中，都能夠流利溝通。🚀",
        Account = "david_account",
        AccountType = 1,
        Cdate = DateTime.Now,
        Udate = DateTime.Now,
        IsTutor = true
    }
);


        modelBuilder.Entity<Course>().HasData(
        new Course
        {
            CourseId = 1,
            CategoryId = 1,
            SubjectId = 1,
            TutorId = 1,
            Title = "C# 入門",
            SubTitle = "從零開始學習 C#",
            TwentyFiveMinUnitPrice = 500,
            FiftyMinUnitPrice = 900,
            Description = "適合初學者的 C# 課程",
            IsEnabled = true,
            ThumbnailUrl = "csharp.jpg",
            VideoUrl = "csharp_intro.mp4",
            CoursesStatus = 1,
            Cdate = DateTime.Now
        },
        new Course
        {
            CourseId = 2,
            CategoryId = 2,
            SubjectId = 2,
            TutorId = 2,
            Title = "日語 N5",
            SubTitle = "基礎日語學習",
            TwentyFiveMinUnitPrice = 400,
            FiftyMinUnitPrice = 800,
            Description = "日語入門課程",
            IsEnabled = true,
            ThumbnailUrl = "japanese.jpg",
            VideoUrl = "japanese_intro.mp4",
            CoursesStatus = 1,
            Cdate = DateTime.Now
        },
        new Course
        {
            CourseId = 3,
            CategoryId = 1,
            SubjectId = 2,
            TutorId = 4,
            Title = "Akimo老師 🔥精通日語：掌握這門全球流行語言的鑰匙！",
            SubTitle = "💡 從基礎到高階語法—全面提升你的日語能力！",
            TwentyFiveMinUnitPrice = 560,
            FiftyMinUnitPrice = 1088,
            Description = "📅 隨時隨地進行日文學習，靈活安排時間，讓學習變得更自由！\r\n🗣️ 專屬一對一視訊教學，根據你的需求量身訂製課程內容！✨\r\n\r\n課程介紹文案：\r\n🌟 在全球化的今天，會一門外語是多麼重要！🌍 無論是工作、旅遊✈️還是單純的興趣，學習日文將為你開啟通往日本文化的大門！我們提供專業的線上日文家教，讓你隨時隨地都能學習日文📖，無需擔心地理限制和時間安排的困擾！透過我們的一對一教學，你可以根據自身的學習進度隨時提出問題，獲得即時回饋！💬\r\n\r\n🎥 透過高品質的視訊平台，專業的老師將與你進行一對一的互動，這樣不僅能建立更密切的師生關係\U0001f91d，也能確保每堂課都能充分關注你的學習進度和需求。這是在傳統教室中難以實現的優勢！我們的老師將幫助你克服任何學習上的障礙，並給予鼓勵💪，讓學習不再孤單。\r\n\r\n🎳 無論你是語言學習的新手，還是想要進一步提升日文能力的學生，我們的課程都可以根據你的基礎和目標來調整！📈無論是學習日常對話、商務日文📊還是準備JLPT考試🚀，我們都能提供最合適的學習計畫！從發音基礎到語法結構，每一個細節都不會被忽略。\r\n\r\n📚 我們的教師將利用各種多媒體教材📹和互動練習🎮，讓你愉快地學習日文，這包括視聽材料、遊戲、角色扮演及小組討論等多種形式，提升你的聽、說、讀、寫能力。即使是最枯燥的文法📜，在這種輕鬆的氛圍下也變得趣味盎然！\r\n\r\n🌈 除了語言課程，我們的教師將額外分享豐富的日本文化🇯🇵，包括日本的習俗、音樂🎶、美食🍱等，讓你在學習日文的同時，也能欣賞到日本的美好文化。每一堂課都會為你帶來全新的文化體驗😍，讓你不僅是學習文字，更是了解背後的故事！\r\n\r\n🍣 課程中不僅僅是口語練習，老師還將分享正宗的日本料理🍜食譜，幫助你在學習語言的同時，學會一些日本美食的製作！👩‍🍳 你會驚喜於食物背後的文化和歷史，這樣的學習過程使得每堂課都更生動且充滿趣味。\r\n\r\n🏆 現在就加入我們的線上日文家教，設定你自己的學習目標🎯，並開始輕鬆學習！不再只是枯燥的背單字，讓我們用互動式教學讓每次課堂都成為你期待的學習時光！⏰ 在老師的指導下，你很快將能日常自信地用日文交流！\r\n\r\n🎉 無論是準備考試📚、赴日旅行✈️或職場交流，專屬的老師會全力支持你，幫助你達成目標！報名後，無需花費時間尋找合適的教材📦，我們將為你精心準備學習資源，讓你快速進步！🚀 快來預約你的第一堂課，開始放飛你的日文夢想，開啟一段全新的學習旅程吧！🌟",
            IsEnabled = true,
            ThumbnailUrl = "~/image/thumb_nails/thumbnail_demo_jp_001.webp",
            VideoUrl = "https://www.youtube.com/embed/MAhD37a7AlE",
            CoursesStatus = 1,
            Cdate = DateTime.Now
        },
        new Course
        {
            CourseId = 4,
            CategoryId = 1,
            SubjectId = 1,
            TutorId = 5,
            Title = "🌟 英語口說提升班：讓你自信流利講英語的最佳選擇",
            SubTitle = "✨ 從零開始，到流利對話的輕鬆之旅！",
            TwentyFiveMinUnitPrice = 700,
            FiftyMinUnitPrice = 1100,
            Description = "課程亮點\r\n👶 無論你是剛開始學習英語的初學者，還是想進一步提升口說能力的中級者，我都有合適的教材與方法，讓你逐步克服語言學習的恐懼。\r\n💪 我會引導你在小組討論中與同學練習，透過彼此交流增強口語表達能力。藉助故事、角色扮演以及多媒體資源，我們將一起深入了解英語的美妙！\r\n\r\n自我介紹\r\n❤️ 我熱愛教育，並堅信教育的力量。看到學生從一開始的羞怯逐漸轉變為自信的表達者，這讓我感到無比的成就感。\r\n🎭 在課堂上，我將使用多樣化的教學方法，透過互動遊戲和小組活動，讓你們在享受學習的過程中輕鬆掌握英語。\r\n🌟 我相信，每位學生都是獨一無二的，所以我會耐心地了解每個人的學習需求，並提供針對性的建議和指導。\r\n\r\n課程內容\r\n💬 課程涵蓋日常對話、商業英語、旅遊英語等多個主題，無論你的學習目的為何，都能找到適合的學習內容。\r\n🎉 我會設計有趣的實境練習，讓你能在模擬情境中實踐所學，並且定期進行小組演講和討論，讓你能夠在實際對話中應用所學的知識。\r\n📚 課後，我會提供額外的學習資源和練習題，幫助你持續進步，如影片推薦、English podcasts、以及值得一試的線上學習平台。\r\n\r\n新生福利\r\n🎁 加入我們的課程後，你將獲得一份專屬學習計畫，這份計畫將幫助你規劃和追蹤自己的學習進度，讓你時刻在正確的方向前進。\r\n🌈 我會定期提供語言測試和反饋，確保每位學生都能清楚自己的進步狀況，並持續調整學習策略。\r\n\U0001f973 特別的學習小禮物也會隨著課程頒發，如實用的英語學習工具和資源，讓你的學習之路充滿驚喜！\r\n\r\n期待在課堂上與你見面，一同展開這段精彩的英語學習旅程吧！讓我們一起成為英語口說的高手！👋",
            IsEnabled = true,
            ThumbnailUrl = "~/image/thumb_nails/thumbnail_demo_tw_001.webp",
            VideoUrl = "https://www.youtube.com/embed/YX6KZIcUeY8?list=PLqivELodHt3jq3oWBZfdhMu0GE7774HBW",
            CoursesStatus = 1,
            Cdate = DateTime.Now
        }
);

        modelBuilder.Entity<CourseCategory>().HasData(
    new CourseCategory { CourseCategoryId = 1, CategorytName = "語言學習", CourseId = 1, Cdate = DateTime.Now },
    new CourseCategory { CourseCategoryId = 2, CategorytName = "程式設計", CourseId = 2, Cdate = DateTime.Now },
    new CourseCategory { CourseCategoryId = 3, CategorytName = "升學科目", CourseId = 2, Cdate = DateTime.Now }
);
        modelBuilder.Entity<CourseSubject>().HasData(
    new CourseSubject { SubjectId = 1, SubjectName = "英文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 2, SubjectName = "日文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 3, SubjectName = "中文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 4, SubjectName = "德文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 5, SubjectName = "法文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 6, SubjectName = "西班牙文", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 7, SubjectName = "HTML/CSS", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 8, SubjectName = "JavaScript", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 9, SubjectName = "C#", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 10, SubjectName = "SQL", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 11, SubjectName = "Python", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 12, SubjectName = "Java", CourseCategoryId = 2, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 13, SubjectName = "數學", CourseCategoryId = 3, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 14, SubjectName = "物理", CourseCategoryId = 3, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 15, SubjectName = "化學", CourseCategoryId = 3, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 16, SubjectName = "歷史", CourseCategoryId = 3, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 17, SubjectName = "地理", CourseCategoryId = 3, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 18, SubjectName = "生物", CourseCategoryId = 3, Cdate = DateTime.Now }
);

        modelBuilder.Entity<CourseImage>().HasData(
    // CourseId = 1
    new CourseImage { CourseImageId = 1, CourseId = 1, ImageUrl = "https://picsum.photos/id/100/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 2, CourseId = 1, ImageUrl = "https://picsum.photos/id/101/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 3, CourseId = 1, ImageUrl = "https://picsum.photos/id/102/450/300", Cdate = DateTime.Now },

    // CourseId = 2
    new CourseImage { CourseImageId = 4, CourseId = 2, ImageUrl = "https://picsum.photos/id/103/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 5, CourseId = 2, ImageUrl = "https://picsum.photos/id/104/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 6, CourseId = 2, ImageUrl = "https://picsum.photos/id/105/450/300", Cdate = DateTime.Now },

    // CourseId = 3
    new CourseImage { CourseImageId = 7, CourseId = 3, ImageUrl = "https://picsum.photos/id/106/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 8, CourseId = 3, ImageUrl = "https://picsum.photos/id/107/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 9, CourseId = 3, ImageUrl = "https://picsum.photos/id/108/450/300", Cdate = DateTime.Now },

    // CourseId = 4
    new CourseImage { CourseImageId = 10, CourseId = 4, ImageUrl = "https://picsum.photos/id/109/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 11, CourseId = 4, ImageUrl = "https://picsum.photos/id/110/450/300", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 12, CourseId = 4, ImageUrl = "https://picsum.photos/id/111/450/300", Cdate = DateTime.Now }
        );
        modelBuilder.Entity<Order>().HasData(
    new Order { OrderId = 1, MemberId = 1, PaymentType = "Credit Card", TotalPrice = 1000, TransactionDate = DateTime.Now, InvoiceType = 1, OrderStatusId = 1, Cdate = DateTime.Now },
    new Order { OrderId = 2, MemberId = 2, PaymentType = "Paypal", TotalPrice = 2000, TransactionDate = DateTime.Now, InvoiceType = 1, OrderStatusId = 1, Cdate = DateTime.Now }
);
        modelBuilder.Entity<OrderDetail>().HasData(
    new OrderDetail { OrderDetailId = 1, OrderId = 1, CourseId = 1, UnitPrice = 500, Quantity = 2, TotalPrice = 1000, CourseType = 1, CourseTitle = "C# 入門", CourseCategory = "程式設計", CourseSubject = "C#" },
    new OrderDetail { OrderDetailId = 2, OrderId = 2, CourseId = 2, UnitPrice = 1000, Quantity = 2, TotalPrice = 2000, CourseType = 1, CourseTitle = "日語 N5", CourseCategory = "語言學習", CourseSubject = "日語" }
);
        modelBuilder.Entity<Coupon>().HasData(
    new Coupon { CouponId = 1, CouponName = "夏季優惠", CouponCode = "SUMMER2024", DiscountType = 1, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(1), IsActive = true, Cdate = DateTime.Now },
    new Coupon { CouponId = 2, CouponName = "新用戶優惠", CouponCode = "WELCOME2024", DiscountType = 1, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(3), IsActive = true, Cdate = DateTime.Now }
);

        //    modelBuilder.Entity<MemberCoupon>().HasData(
        //new MemberCoupon { MemberCouponId = 1, MemberId = 1, CouponId = 1, IsUsed = false, Cdate = DateTime.Now },
        //new MemberCoupon { MemberCouponId = 2, MemberId = 2, CouponId = 2, IsUsed = true, Cdate = DateTime.Now }
        //    );

        modelBuilder.Entity<MemberPreference>().HasData(
    new MemberPreference { MemberPreferenceId = 1, MemberId = 1, SubjecId = 1, Cdate = DateTime.Now },
    new MemberPreference { MemberPreferenceId = 2, MemberId = 2, SubjecId = 2, Cdate = DateTime.Now }
);

        modelBuilder.Entity<ApplyList>().HasData(
    new ApplyList { ApplyId = 1, MemberId = 1, ApplyStatus = true, ApplyDateTime = DateTime.Now, ApprovedDateTime = DateTime.Now, UpdateStatusDateTime = DateTime.Now, RejectReason = "無" },
    new ApplyList { ApplyId = 2, MemberId = 2, ApplyStatus = false, ApplyDateTime = DateTime.Now, ApprovedDateTime = DateTime.Now, UpdateStatusDateTime = DateTime.Now, RejectReason = "不符合資格" }
);


        modelBuilder.Entity<Booking>().HasData(
    new Booking { BookingId = 1, CourseId = 1, BookingDate = DateTime.Now, BookingTime = 800, StudentId = 1, Cdate = DateTime.Now },
    new Booking { BookingId = 2, CourseId = 2, BookingDate = DateTime.Today, BookingTime = 900, StudentId = 2, Cdate = DateTime.Now }
);

        modelBuilder.Entity<ProfessionalLicense>().HasData(
    new ProfessionalLicense { ProfessionalLicenseId = 1, MemberId = 1, ProfessionalLicenseName = "C# 認證", ProfessionalLicenseUrl = "csharp_certificate.jpg", Cdate = DateTime.Now },
    new ProfessionalLicense { ProfessionalLicenseId = 2, MemberId = 2, ProfessionalLicenseName = "日語能力測驗 N1", ProfessionalLicenseUrl = "jlpt_n1.jpg", Cdate = DateTime.Now }
);


        modelBuilder.Entity<Review>().HasData(
    new Review { ReviewId = 1, StudentId = 1, CourseId = 1, Rating = 5, CommentText = "很棒的課程！", Cdate = DateTime.Now },
    new Review { ReviewId = 2, StudentId = 2, CourseId = 2, Rating = 4, CommentText = "非常實用！", Cdate = DateTime.Now },
    new Review { ReviewId = 3, StudentId = 2, CourseId = 1, Rating = 4, CommentText = "講得不錯! 但笑話有點冷", Cdate = DateTime.Now },
    new Review { ReviewId = 4, StudentId = 3, CourseId = 1, Rating = 4, CommentText = "讚讚讚", Cdate = DateTime.Now }
);


        modelBuilder.Entity<ShoppingCart>().HasData(
    new ShoppingCart { ShoppingCartId = 1, CourseId = 1, UnitPrice = 500, Quantity = 2, TotalPrice = 1000, MemberId = 1, CourseType = 1, Cdate = DateTime.Now },
    new ShoppingCart { ShoppingCartId = 2, CourseId = 2, UnitPrice = 1000, Quantity = 1, TotalPrice = 1000, MemberId = 2, CourseType = 1, Cdate = DateTime.Now }
);


        modelBuilder.Entity<ShoppingCartBooking>().HasData(
    new ShoppingCartBooking { BookingId = 1, CourseId = 1, BookingTime = 800, MemberId = 1, TempShoppingCartId = 1, Cdate = DateTime.Now },
    new ShoppingCartBooking { BookingId = 2, CourseId = 2, BookingTime = 900, MemberId = 2, TempShoppingCartId = 2, Cdate = DateTime.Now }
);


        modelBuilder.Entity<TutorTimeSlot>().HasData(
    new TutorTimeSlot { TutorTimeSlotId = 1, TutorId = 1, Weekday = 1, CourseHourId = 1, BookingId = 1, Cdate = DateTime.Now },
    new TutorTimeSlot { TutorTimeSlotId = 2, TutorId = 2, Weekday = 2, CourseHourId = 2, BookingId = 2, Cdate = DateTime.Now }
);


        modelBuilder.Entity<WorkExperience>().HasData(
    new WorkExperience { WorkExperienceId = 1, MemberId = 1, WorkExperienceFile = "csharp_experience.pdf", WorkStartDate = DateTime.Now.AddYears(-3), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now },
    new WorkExperience { WorkExperienceId = 2, MemberId = 2, WorkExperienceFile = "japanese_experience.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now }
);

        modelBuilder.Entity<CourseHour>().HasData(
            new CourseHour { CourseHourId = 1, Hour = "00:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 2, Hour = "01:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 3, Hour = "02:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 4, Hour = "03:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 5, Hour = "04:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 6, Hour = "05:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 7, Hour = "06:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 8, Hour = "07:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 9, Hour = "08:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 10, Hour = "09:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 11, Hour = "10:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 12, Hour = "11:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 13, Hour = "12:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 14, Hour = "13:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 15, Hour = "14:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 16, Hour = "15:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 17, Hour = "16:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 18, Hour = "17:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 19, Hour = "18:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 20, Hour = "19:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 21, Hour = "20:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 22, Hour = "21:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 23, Hour = "22:00", Cdate = DateTime.Now },
            new CourseHour { CourseHourId = 24, Hour = "23:00", Cdate = DateTime.Now }
            );


        #endregion
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
