using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web.Data;

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

    public virtual DbSet<TutorTimeSlot> TutorTimeSlots { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

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

            entity.HasIndex(e => e.CategoryId, "IX_Courses_CategoryId");

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
            entity.Property(e => e.VATNumber)
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

        modelBuilder.Entity<TutorTimeSlot>(entity =>
        {
            entity.HasKey(e => e.TutorTimeSlotId).HasName("PK__TutorTim__E709EE17B13CB862");

            entity.HasIndex(e => e.CourseHourId, "IX_TutorTimeSlots_CourseHourId");

            entity.HasIndex(e => e.TutorId, "IX_TutorTimeSlots_TutorID");

            entity.Property(e => e.TutorTimeSlotId).HasComment("教師可預約Id");
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

            entity.HasOne(d => d.CourseHour).WithMany(p => p.TutorTimeSlots)
                .HasForeignKey(d => d.CourseHourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorTime__Cours__5EBF139D");

            entity.HasOne(d => d.Tutor).WithMany(p => p.TutorTimeSlots)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorTime__Membe__5535A963");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.Property(e => e.WatchListId)
                .ValueGeneratedOnAdd()
                .HasComment("關注Id");
            entity.Property(e => e.CourseId).HasComment("關注的課程");
            entity.Property(e => e.FollowerId).HasComment("送出關注的人");

            entity.HasOne(d => d.Course).WithMany(p => p.WatchLists)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_WatchLists_Courses");

            entity.HasOne(d => d.WatchListNavigation).WithOne(p => p.WatchList)
                .HasForeignKey<WatchList>(d => d.WatchListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchLists_WatchLists");
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
    new Nation { NationId = 1, NationName = "Taiwan", FlagImage = "https://flagcdn.com/w320/tw.png" },
    new Nation { NationId = 2, NationName = "Japan", FlagImage = "https://flagcdn.com/w320/jp.png" },
    new Nation { NationId = 3, NationName = "South Korea", FlagImage = "https://flagcdn.com/w320/kr.png" },
    new Nation { NationId = 4, NationName = "United States", FlagImage = "https://flagcdn.com/w320/us.png" },
    new Nation { NationId = 5, NationName = "Germany", FlagImage = "https://flagcdn.com/w320/de.png" },
    new Nation { NationId = 6, NationName = "France", FlagImage = "https://flagcdn.com/w320/fr.png" },
    new Nation { NationId = 7, NationName = "Spain", FlagImage = "https://flagcdn.com/w320/es.png" },
    new Nation { NationId = 8, NationName = "United Kingdom", FlagImage = "https://flagcdn.com/w320/gb.png" },
    new Nation { NationId = 9, NationName = "Canada", FlagImage = "https://flagcdn.com/w320/ca.png" },
    new Nation { NationId = 10, NationName = "India", FlagImage = "https://flagcdn.com/w320/in.png" }
);
        modelBuilder.Entity<Education>().HasData(
    new Education { EducationId = 1, SchoolName = "National Taiwan University", StudyStartYear = 2010, StudyEndYear = 2014, DepartmentName = "Computer Science", Cdate = DateTime.Now },
    new Education { EducationId = 2, SchoolName = "Kyoto University", StudyStartYear = 2012, StudyEndYear = 2016, DepartmentName = "Economics", Cdate = DateTime.Now },
    new Education { EducationId = 3, SchoolName = "Seoul National University", StudyStartYear = 2011, StudyEndYear = 2015, DepartmentName = "Engineering", Cdate = DateTime.Now },
    new Education { EducationId = 4, SchoolName = "Harvard University", StudyStartYear = 2008, StudyEndYear = 2012, DepartmentName = "Law", Cdate = DateTime.Now },
    new Education { EducationId = 5, SchoolName = "Stanford University", StudyStartYear = 2009, StudyEndYear = 2013, DepartmentName = "Business", Cdate = DateTime.Now },
    new Education { EducationId = 6, SchoolName = "University of Oxford", StudyStartYear = 2007, StudyEndYear = 2011, DepartmentName = "Philosophy", Cdate = DateTime.Now },
    new Education { EducationId = 7, SchoolName = "University of Cambridge", StudyStartYear = 2006, StudyEndYear = 2010, DepartmentName = "Mathematics", Cdate = DateTime.Now },
    new Education { EducationId = 8, SchoolName = "Massachusetts Institute of Technology", StudyStartYear = 2013, StudyEndYear = 2017, DepartmentName = "Physics", Cdate = DateTime.Now },
    new Education { EducationId = 9, SchoolName = "University of California, Berkeley", StudyStartYear = 2010, StudyEndYear = 2014, DepartmentName = "Chemistry", Cdate = DateTime.Now },
    new Education { EducationId = 10, SchoolName = "University of Toronto", StudyStartYear = 2012, StudyEndYear = 2016, DepartmentName = "Biology", Cdate = DateTime.Now }
);
        modelBuilder.Entity<Member>().HasData(
    new Member { MemberId = 1, HeadShotImage = "https://randomuser.me/api/portraits/men/1.jpg", NationId = 1, IsVerifiedTutor = true, FirstName = "John", LastName = "Doe", Password = "password1", Email = "john.doe@example.com", Nickname = "JohnD", Phone = "123456789", Birthday = DateTime.Now.AddYears(-30), Gender = 1, NativeLanguage = "English", SpokenLanguage = "English", BankCode = "001", BankAccount = "1234567890", EducationId = 1, TutorIntro = "Experienced English tutor", Account = "john_doe", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 2, HeadShotImage = "https://randomuser.me/api/portraits/women/2.jpg", NationId = 2, IsVerifiedTutor = false, FirstName = "Jane", LastName = "Smith", Password = "password2", Email = "jane.smith@example.com", Nickname = "JaneS", Phone = "987654321", Birthday = DateTime.Now.AddYears(-25), Gender = 2, NativeLanguage = "Japanese", SpokenLanguage = "Japanese", BankCode = "002", BankAccount = "2345678901", EducationId = 2, TutorIntro = "Japanese language specialist", Account = "jane_smith", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 3, HeadShotImage = "https://randomuser.me/api/portraits/men/3.jpg", NationId = 3, IsVerifiedTutor = true, FirstName = "Mark", LastName = "Brown", Password = "password3", Email = "mark.brown@example.com", Nickname = "MarkB", Phone = "123123123", Birthday = DateTime.Now.AddYears(-28), Gender = 1, NativeLanguage = "Korean", SpokenLanguage = "Korean, English", BankCode = "003", BankAccount = "3456789012", EducationId = 3, TutorIntro = "Korean language expert", Account = "mark_brown", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 4, HeadShotImage = "https://randomuser.me/api/portraits/men/4.jpg", NationId = 4, IsVerifiedTutor = true, FirstName = "Chris", LastName = "Taylor", Password = "password4", Email = "chris.taylor@example.com", Nickname = "ChrisT", Phone = "444555666", Birthday = DateTime.Now.AddYears(-33), Gender = 1, NativeLanguage = "German", SpokenLanguage = "German, English", BankCode = "004", BankAccount = "4567890123", EducationId = 4, TutorIntro = "German language expert", Account = "chris_taylor", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 5, HeadShotImage = "https://randomuser.me/api/portraits/women/5.jpg", NationId = 5, IsVerifiedTutor = false, FirstName = "Samantha", LastName = "White", Password = "password5", Email = "samantha.white@example.com", Nickname = "SamW", Phone = "555666777", Birthday = DateTime.Now.AddYears(-27), Gender = 2, NativeLanguage = "French", SpokenLanguage = "French, English", BankCode = "005", BankAccount = "5678901234", EducationId = 5, TutorIntro = "French language expert", Account = "sam_white", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 6, HeadShotImage = "https://randomuser.me/api/portraits/men/6.jpg", NationId = 6, IsVerifiedTutor = true, FirstName = "Paul", LastName = "Walker", Password = "password6", Email = "paul.walker@example.com", Nickname = "PaulW", Phone = "666777888", Birthday = DateTime.Now.AddYears(-32), Gender = 1, NativeLanguage = "Spanish", SpokenLanguage = "Spanish, English", BankCode = "006", BankAccount = "6789012345", EducationId = 6, TutorIntro = "Spanish language expert", Account = "paul_walker", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 7, HeadShotImage = "https://randomuser.me/api/portraits/women/7.jpg", NationId = 7, IsVerifiedTutor = false, FirstName = "Laura", LastName = "Martin", Password = "password7", Email = "laura.martin@example.com", Nickname = "LauraM", Phone = "777888999", Birthday = DateTime.Now.AddYears(-29), Gender = 2, NativeLanguage = "Chinese", SpokenLanguage = "Chinese, English", BankCode = "007", BankAccount = "7890123456", EducationId = 7, TutorIntro = "Chinese language expert", Account = "laura_martin", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 8, HeadShotImage = "https://randomuser.me/api/portraits/men/8.jpg", NationId = 8, IsVerifiedTutor = true, FirstName = "David", LastName = "Jones", Password = "password8", Email = "david.jones@example.com", Nickname = "DavidJ", Phone = "888999000", Birthday = DateTime.Now.AddYears(-31), Gender = 1, NativeLanguage = "Russian", SpokenLanguage = "Russian, English", BankCode = "008", BankAccount = "8901234567", EducationId = 8, TutorIntro = "Russian language expert", Account = "david_jones", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 9, HeadShotImage = "https://randomuser.me/api/portraits/women/9.jpg", NationId = 9, IsVerifiedTutor = false, FirstName = "Emily", LastName = "Davis", Password = "password9", Email = "emily.davis@example.com", Nickname = "EmilyD", Phone = "999000111", Birthday = DateTime.Now.AddYears(-26), Gender = 2, NativeLanguage = "Italian", SpokenLanguage = "Italian, English", BankCode = "009", BankAccount = "9012345678", EducationId = 9, TutorIntro = "Italian language expert", Account = "emily_davis", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 10, HeadShotImage = "https://randomuser.me/api/portraits/men/10.jpg", NationId = 10, IsVerifiedTutor = true, FirstName = "Michael", LastName = "Wilson", Password = "password10", Email = "michael.wilson@example.com", Nickname = "MichaelW", Phone = "000111222", Birthday = DateTime.Now.AddYears(-34), Gender = 1, NativeLanguage = "Portuguese", SpokenLanguage = "Portuguese, English", BankCode = "010", BankAccount = "0123456789", EducationId = 10, TutorIntro = "Portuguese language expert", Account = "michael_wilson", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
     new Member { MemberId = 11, HeadShotImage = "https://randomuser.me/api/portraits/men/11.jpg", NationId = 1, IsVerifiedTutor = true, FirstName = "Carlos", LastName = "Miller", Password = "password11", Email = "carlos.miller@example.com", Nickname = "CarlosM", Phone = "101010101", Birthday = DateTime.Now.AddYears(-29), Gender = 1, NativeLanguage = "English", SpokenLanguage = "English, Spanish", BankCode = "011", BankAccount = "3456781234", EducationId = 1, TutorIntro = "Experienced tutor in English and Spanish", Account = "carlos_miller", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 12, HeadShotImage = "https://randomuser.me/api/portraits/women/12.jpg", NationId = 2, IsVerifiedTutor = false, FirstName = "Olivia", LastName = "Brown", Password = "password12", Email = "olivia.brown@example.com", Nickname = "OliviaB", Phone = "202020202", Birthday = DateTime.Now.AddYears(-24), Gender = 2, NativeLanguage = "Japanese", SpokenLanguage = "Japanese, English", BankCode = "012", BankAccount = "4567892345", EducationId = 2, TutorIntro = "Expert in Japanese language", Account = "olivia_brown", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 13, HeadShotImage = "https://randomuser.me/api/portraits/men/13.jpg", NationId = 3, IsVerifiedTutor = true, FirstName = "James", LastName = "Johnson", Password = "password13", Email = "james.johnson@example.com", Nickname = "JamesJ", Phone = "303030303", Birthday = DateTime.Now.AddYears(-35), Gender = 1, NativeLanguage = "Korean", SpokenLanguage = "Korean, English", BankCode = "013", BankAccount = "5678913456", EducationId = 3, TutorIntro = "Korean language specialist", Account = "james_johnson", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 14, HeadShotImage = "https://randomuser.me/api/portraits/women/14.jpg", NationId = 4, IsVerifiedTutor = false, FirstName = "Emma", LastName = "Garcia", Password = "password14", Email = "emma.garcia@example.com", Nickname = "EmmaG", Phone = "404040404", Birthday = DateTime.Now.AddYears(-22), Gender = 2, NativeLanguage = "German", SpokenLanguage = "German, English", BankCode = "014", BankAccount = "6789124567", EducationId = 4, TutorIntro = "Expert in German language", Account = "emma_garcia", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 15, HeadShotImage = "https://randomuser.me/api/portraits/men/15.jpg", NationId = 5, IsVerifiedTutor = true, FirstName = "Robert", LastName = "Martinez", Password = "password15", Email = "robert.martinez@example.com", Nickname = "RobertM", Phone = "505050505", Birthday = DateTime.Now.AddYears(-26), Gender = 1, NativeLanguage = "French", SpokenLanguage = "French, English", BankCode = "015", BankAccount = "7891235678", EducationId = 5, TutorIntro = "French language specialist", Account = "robert_martinez", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 16, HeadShotImage = "https://randomuser.me/api/portraits/women/16.jpg", NationId = 6, IsVerifiedTutor = false, FirstName = "Sophia", LastName = "Rodriguez", Password = "password16", Email = "sophia.rodriguez@example.com", Nickname = "SophiaR", Phone = "606060606", Birthday = DateTime.Now.AddYears(-21), Gender = 2, NativeLanguage = "Spanish", SpokenLanguage = "Spanish, English", BankCode = "016", BankAccount = "8902346789", EducationId = 6, TutorIntro = "Spanish language expert", Account = "sophia_rodriguez", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 17, HeadShotImage = "https://randomuser.me/api/portraits/men/17.jpg", NationId = 7, IsVerifiedTutor = true, FirstName = "Liam", LastName = "Hernandez", Password = "password17", Email = "liam.hernandez@example.com", Nickname = "LiamH", Phone = "707070707", Birthday = DateTime.Now.AddYears(-33), Gender = 1, NativeLanguage = "Chinese", SpokenLanguage = "Chinese, English", BankCode = "017", BankAccount = "9013457890", EducationId = 7, TutorIntro = "Chinese language expert", Account = "liam_hernandez", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 18, HeadShotImage = "https://randomuser.me/api/portraits/women/18.jpg", NationId = 8, IsVerifiedTutor = false, FirstName = "Isabella", LastName = "Lopez", Password = "password18", Email = "isabella.lopez@example.com", Nickname = "IsabellaL", Phone = "808080808", Birthday = DateTime.Now.AddYears(-20), Gender = 2, NativeLanguage = "Russian", SpokenLanguage = "Russian, English", BankCode = "018", BankAccount = "0123456789", EducationId = 8, TutorIntro = "Russian language expert", Account = "isabella_lopez", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 19, HeadShotImage = "https://randomuser.me/api/portraits/men/19.jpg", NationId = 9, IsVerifiedTutor = true, FirstName = "Benjamin", LastName = "Gonzalez", Password = "password19", Email = "benjamin.gonzalez@example.com", Nickname = "BenG", Phone = "909090909", Birthday = DateTime.Now.AddYears(-28), Gender = 1, NativeLanguage = "Italian", SpokenLanguage = "Italian, English", BankCode = "019", BankAccount = "1234567890", EducationId = 9, TutorIntro = "Italian language expert", Account = "benjamin_gonzalez", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 20, HeadShotImage = "https://randomuser.me/api/portraits/women/20.jpg", NationId = 10, IsVerifiedTutor = false, FirstName = "Mia", LastName = "Wilson", Password = "password20", Email = "mia.wilson@example.com", Nickname = "MiaW", Phone = "1010101010", Birthday = DateTime.Now.AddYears(-27), Gender = 2, NativeLanguage = "Portuguese", SpokenLanguage = "Portuguese, English", BankCode = "020", BankAccount = "2345678901", EducationId = 10, TutorIntro = "Portuguese language expert", Account = "mia_wilson", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
     new Member { MemberId = 21, HeadShotImage = "https://randomuser.me/api/portraits/men/21.jpg", NationId = 1, IsVerifiedTutor = true, FirstName = "Daniel", LastName = "Anderson", Password = "password21", Email = "daniel.anderson@example.com", Nickname = "DanA", Phone = "111111111", Birthday = DateTime.Now.AddYears(-29), Gender = 1, NativeLanguage = "English", SpokenLanguage = "English, Spanish", BankCode = "021", BankAccount = "3456781234", EducationId = 1, TutorIntro = "Experienced tutor in English and Spanish", Account = "daniel_anderson", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 22, HeadShotImage = "https://randomuser.me/api/portraits/women/22.jpg", NationId = 2, IsVerifiedTutor = false, FirstName = "Ava", LastName = "Thomas", Password = "password22", Email = "ava.thomas@example.com", Nickname = "AvaT", Phone = "222222222", Birthday = DateTime.Now.AddYears(-24), Gender = 2, NativeLanguage = "Japanese", SpokenLanguage = "Japanese, English", BankCode = "022", BankAccount = "4567892345", EducationId = 2, TutorIntro = "Expert in Japanese language", Account = "ava_thomas", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 23, HeadShotImage = "https://randomuser.me/api/portraits/men/23.jpg", NationId = 3, IsVerifiedTutor = true, FirstName = "Matthew", LastName = "Jackson", Password = "password23", Email = "matthew.jackson@example.com", Nickname = "MattJ", Phone = "333333333", Birthday = DateTime.Now.AddYears(-35), Gender = 1, NativeLanguage = "Korean", SpokenLanguage = "Korean, English", BankCode = "023", BankAccount = "5678913456", EducationId = 3, TutorIntro = "Korean language specialist", Account = "matthew_jackson", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 24, HeadShotImage = "https://randomuser.me/api/portraits/women/24.jpg", NationId = 4, IsVerifiedTutor = false, FirstName = "Ella", LastName = "Harris", Password = "password24", Email = "ella.harris@example.com", Nickname = "EllaH", Phone = "444444444", Birthday = DateTime.Now.AddYears(-22), Gender = 2, NativeLanguage = "German", SpokenLanguage = "German, English", BankCode = "024", BankAccount = "6789124567", EducationId = 4, TutorIntro = "Expert in German language", Account = "ella_harris", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 25, HeadShotImage = "https://randomuser.me/api/portraits/men/25.jpg", NationId = 5, IsVerifiedTutor = true, FirstName = "Lucas", LastName = "Clark", Password = "password25", Email = "lucas.clark@example.com", Nickname = "LukeC", Phone = "555555555", Birthday = DateTime.Now.AddYears(-26), Gender = 1, NativeLanguage = "French", SpokenLanguage = "French, English", BankCode = "025", BankAccount = "7891235678", EducationId = 5, TutorIntro = "French language specialist", Account = "lucas_clark", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 26, HeadShotImage = "https://randomuser.me/api/portraits/women/26.jpg", NationId = 6, IsVerifiedTutor = false, FirstName = "Mia", LastName = "Lewis", Password = "password26", Email = "mia.lewis@example.com", Nickname = "MiaL", Phone = "666666666", Birthday = DateTime.Now.AddYears(-21), Gender = 2, NativeLanguage = "Spanish", SpokenLanguage = "Spanish, English", BankCode = "026", BankAccount = "8902346789", EducationId = 6, TutorIntro = "Spanish language expert", Account = "mia_lewis", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 27, HeadShotImage = "https://randomuser.me/api/portraits/men/27.jpg", NationId = 7, IsVerifiedTutor = true, FirstName = "Logan", LastName = "Young", Password = "password27", Email = "logan.young@example.com", Nickname = "LoganY", Phone = "777777777", Birthday = DateTime.Now.AddYears(-33), Gender = 1, NativeLanguage = "Chinese", SpokenLanguage = "Chinese, English", BankCode = "027", BankAccount = "9013457890", EducationId = 7, TutorIntro = "Chinese language expert", Account = "logan_young", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 28, HeadShotImage = "https://randomuser.me/api/portraits/women/28.jpg", NationId = 8, IsVerifiedTutor = false, FirstName = "Aria", LastName = "King", Password = "password28", Email = "aria.king@example.com", Nickname = "AriaK", Phone = "888888888", Birthday = DateTime.Now.AddYears(-20), Gender = 2, NativeLanguage = "Russian", SpokenLanguage = "Russian, English", BankCode = "028", BankAccount = "0123456789", EducationId = 8, TutorIntro = "Russian language expert", Account = "aria_king", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 29, HeadShotImage = "https://randomuser.me/api/portraits/men/29.jpg", NationId = 9, IsVerifiedTutor = true, FirstName = "Ethan", LastName = "Wright", Password = "password29", Email = "ethan.wright@example.com", Nickname = "EthanW", Phone = "999999999", Birthday = DateTime.Now.AddYears(-28), Gender = 1, NativeLanguage = "Italian", SpokenLanguage = "Italian, English", BankCode = "029", BankAccount = "1234567890", EducationId = 9, TutorIntro = "Italian language expert", Account = "ethan_wright", AccountType = 1, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true },
    new Member { MemberId = 30, HeadShotImage = "https://randomuser.me/api/portraits/women/30.jpg", NationId = 10, IsVerifiedTutor = false, FirstName = "Charlotte", LastName = "Hill", Password = "password30", Email = "charlotte.hill@example.com", Nickname = "CharlotteH", Phone = "1010101010", Birthday = DateTime.Now.AddYears(-27), Gender = 2, NativeLanguage = "Portuguese", SpokenLanguage = "Portuguese, English", BankCode = "030", BankAccount = "2345678901", EducationId = 10, TutorIntro = "Portuguese language expert", Account = "charlotte_hill", AccountType = 2, Cdate = DateTime.Now, Udate = DateTime.Now, IsTutor = true }



);
        modelBuilder.Entity<Course>().HasData(
 new Course { CourseId = 1, CategoryId = 1, SubjectId = 1, TutorId = 1, Title = "基礎英文", SubTitle = "從零開始學英文", TwentyFiveMinUnitPrice = 50m, FiftyMinUnitPrice = 90m, Description = "適合初學者的英文課程", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/english.jpg", VideoUrl = "https://example.com/courses/english_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 2, CategoryId = 1, SubjectId = 2, TutorId = 2, Title = "日語入門", SubTitle = "日語學習的基礎", TwentyFiveMinUnitPrice = 60m, FiftyMinUnitPrice = 100m, Description = "基礎日語語法和詞彙", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/japanese.jpg", VideoUrl = "https://example.com/courses/japanese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 3, CategoryId = 1, SubjectId = 3, TutorId = 3, Title = "中文語法", SubTitle = "掌握中文語法", TwentyFiveMinUnitPrice = 70m, FiftyMinUnitPrice = 120m, Description = "全面學習中文語法", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/chinese.jpg", VideoUrl = "https://example.com/courses/chinese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 4, CategoryId = 1, SubjectId = 4, TutorId = 4, Title = "德語會話", SubTitle = "學習德語會話技巧", TwentyFiveMinUnitPrice = 65m, FiftyMinUnitPrice = 110m, Description = "提高德語口語能力", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/german.jpg", VideoUrl = "https://example.com/courses/german_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 5, CategoryId = 1, SubjectId = 5, TutorId = 5, Title = "法語閱讀", SubTitle = "學習法語閱讀理解", TwentyFiveMinUnitPrice = 55m, FiftyMinUnitPrice = 95m, Description = "提升法語閱讀能力", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/french.jpg", VideoUrl = "https://example.com/courses/french_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 6, CategoryId = 1, SubjectId = 6, TutorId = 6, Title = "西班牙語寫作", SubTitle = "掌握西班牙語寫作技巧", TwentyFiveMinUnitPrice = 60m, FiftyMinUnitPrice = 100m, Description = "提高西班牙語寫作能力", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/spanish.jpg", VideoUrl = "https://example.com/courses/spanish_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 7, CategoryId = 2, SubjectId = 7, TutorId = 7, Title = "HTML/CSS 基礎", SubTitle = "學習網頁開發基礎", TwentyFiveMinUnitPrice = 75m, FiftyMinUnitPrice = 125m, Description = "從頭開始學習HTML和CSS", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/html_css.jpg", VideoUrl = "https://example.com/courses/html_css_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 8, CategoryId = 2, SubjectId = 8, TutorId = 8, Title = "JavaScript 編程", SubTitle = "JavaScript 編程基礎", TwentyFiveMinUnitPrice = 85m, FiftyMinUnitPrice = 140m, Description = "學習JavaScript語法和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/javascript.jpg", VideoUrl = "https://example.com/courses/javascript_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 9, CategoryId = 2, SubjectId = 9, TutorId = 9, Title = "C# 進階", SubTitle = "掌握C#的進階技巧", TwentyFiveMinUnitPrice = 90m, FiftyMinUnitPrice = 150m, Description = "深入學習C#編程", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/csharp.jpg", VideoUrl = "https://example.com/courses/csharp_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 10, CategoryId = 2, SubjectId = 10, TutorId = 10, Title = "SQL 資料庫", SubTitle = "學習SQL語法和資料庫操作", TwentyFiveMinUnitPrice = 80m, FiftyMinUnitPrice = 130m, Description = "從零開始學習SQL", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/sql.jpg", VideoUrl = "https://example.com/courses/sql_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 11, CategoryId = 2, SubjectId = 11, TutorId = 11, Title = "Python 入門", SubTitle = "掌握Python的基礎知識", TwentyFiveMinUnitPrice = 85m, FiftyMinUnitPrice = 140m, Description = "從頭開始學習Python編程", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/python.jpg", VideoUrl = "https://example.com/courses/python_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 12, CategoryId = 2, SubjectId = 12, TutorId = 12, Title = "Java 基礎", SubTitle = "Java編程的入門課程", TwentyFiveMinUnitPrice = 90m, FiftyMinUnitPrice = 150m, Description = "從零開始學習Java語言", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/java.jpg", VideoUrl = "https://example.com/courses/java_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 13, CategoryId = 3, SubjectId = 13, TutorId = 13, Title = "數學基礎", SubTitle = "學習數學的基本概念", TwentyFiveMinUnitPrice = 60m, FiftyMinUnitPrice = 100m, Description = "提升數學基礎知識", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/math.jpg", VideoUrl = "https://example.com/courses/math_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 14, CategoryId = 3, SubjectId = 14, TutorId = 14, Title = "物理入門", SubTitle = "學習物理的基本理論", TwentyFiveMinUnitPrice = 65m, FiftyMinUnitPrice = 110m, Description = "物理學基礎知識", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/physics.jpg", VideoUrl = "https://example.com/courses/physics_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 15, CategoryId = 3, SubjectId = 15, TutorId = 15, Title = "化學基礎", SubTitle = "學習化學的基本概念", TwentyFiveMinUnitPrice = 70m, FiftyMinUnitPrice = 120m, Description = "全面了解化學基礎知識", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/chemistry.jpg", VideoUrl = "https://example.com/courses/chemistry_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 16, CategoryId = 3, SubjectId = 16, TutorId = 16, Title = "歷史研究", SubTitle = "深入了解歷史事件", TwentyFiveMinUnitPrice = 75m, FiftyMinUnitPrice = 125m, Description = "歷史事件和背景的深入分析", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/history.jpg", VideoUrl = "https://example.com/courses/history_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 17, CategoryId = 3, SubjectId = 17, TutorId = 17, Title = "地理概論", SubTitle = "學習地理的基本知識", TwentyFiveMinUnitPrice = 65m, FiftyMinUnitPrice = 110m, Description = "全面了解地理學的基礎", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/geography.jpg", VideoUrl = "https://example.com/courses/geography_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 18, CategoryId = 3, SubjectId = 18, TutorId = 18, Title = "生物學基礎", SubTitle = "深入理解生物學", TwentyFiveMinUnitPrice = 70m, FiftyMinUnitPrice = 120m, Description = "深入學習生物學的基本概念", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/biology.jpg", VideoUrl = "https://example.com/courses/biology_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 19, CategoryId = 1, SubjectId = 1, TutorId = 19, Title = "高級英文", SubTitle = "提升英語會話能力", TwentyFiveMinUnitPrice = 100m, FiftyMinUnitPrice = 180m, Description = "深入練習英語會話和詞彙", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_english.jpg", VideoUrl = "https://example.com/courses/advanced_english_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 20, CategoryId = 1, SubjectId = 2, TutorId = 20, Title = "進階日語", SubTitle = "提升日語語法和會話技巧", TwentyFiveMinUnitPrice = 110m, FiftyMinUnitPrice = 200m, Description = "提升日語會話和語法能力", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_japanese.jpg", VideoUrl = "https://example.com/courses/advanced_japanese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 21, CategoryId = 1, SubjectId = 3, TutorId = 21, Title = "高級中文", SubTitle = "提升中文語法和詞彙", TwentyFiveMinUnitPrice = 120m, FiftyMinUnitPrice = 220m, Description = "深入學習中文語法和詞彙", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_chinese.jpg", VideoUrl = "https://example.com/courses/advanced_chinese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 22, CategoryId = 1, SubjectId = 4, TutorId = 22, Title = "高級德語", SubTitle = "提升德語會話技巧", TwentyFiveMinUnitPrice = 130m, FiftyMinUnitPrice = 240m, Description = "德語會話和詞彙的深入練習", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_german.jpg", VideoUrl = "https://example.com/courses/advanced_german_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 23, CategoryId = 1, SubjectId = 5, TutorId = 23, Title = "高級法語", SubTitle = "提升法語閱讀和寫作能力", TwentyFiveMinUnitPrice = 125m, FiftyMinUnitPrice = 230m, Description = "法語閱讀和寫作的深入研究", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_french.jpg", VideoUrl = "https://example.com/courses/advanced_french_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 24, CategoryId = 1, SubjectId = 6, TutorId = 24, Title = "高級西班牙語", SubTitle = "提升西班牙語寫作和語法", TwentyFiveMinUnitPrice = 135m, FiftyMinUnitPrice = 250m, Description = "西班牙語寫作和語法的深入練習", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_spanish.jpg", VideoUrl = "https://example.com/courses/advanced_spanish_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 25, CategoryId = 2, SubjectId = 7, TutorId = 25, Title = "高級HTML/CSS", SubTitle = "深入學習HTML和CSS技術", TwentyFiveMinUnitPrice = 150m, FiftyMinUnitPrice = 270m, Description = "高級網頁設計和開發技術", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_html_css.jpg", VideoUrl = "https://example.com/courses/advanced_html_css_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 26, CategoryId = 2, SubjectId = 8, TutorId = 26, Title = "高級JavaScript", SubTitle = "深入掌握JavaScript編程", TwentyFiveMinUnitPrice = 160m, FiftyMinUnitPrice = 280m, Description = "JavaScript編程的高級應用和技巧", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_javascript.jpg", VideoUrl = "https://example.com/courses/advanced_javascript_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 27, CategoryId = 2, SubjectId = 9, TutorId = 27, Title = "C# 高級應用", SubTitle = "學習C#的高級應用技術", TwentyFiveMinUnitPrice = 170m, FiftyMinUnitPrice = 300m, Description = "深入掌握C#編程的高級技術", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_csharp.jpg", VideoUrl = "https://example.com/courses/advanced_csharp_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 28, CategoryId = 2, SubjectId = 10, TutorId = 28, Title = "SQL 高級資料庫操作", SubTitle = "深入學習SQL資料庫管理", TwentyFiveMinUnitPrice = 155m, FiftyMinUnitPrice = 275m, Description = "SQL資料庫管理和優化的高級技術", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_sql.jpg", VideoUrl = "https://example.com/courses/advanced_sql_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 29, CategoryId = 2, SubjectId = 11, TutorId = 29, Title = "Python 高級應用", SubTitle = "深入學習Python的高級應用", TwentyFiveMinUnitPrice = 165m, FiftyMinUnitPrice = 290m, Description = "Python編程的高級應用和數據處理", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_python.jpg", VideoUrl = "https://example.com/courses/advanced_python_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 30, CategoryId = 2, SubjectId = 12, TutorId = 30, Title = "Java 高級應用", SubTitle = "深入學習Java的高級應用技術", TwentyFiveMinUnitPrice = 175m, FiftyMinUnitPrice = 310m, Description = "Java編程的高級技術和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_java.jpg", VideoUrl = "https://example.com/courses/advanced_java_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 31, CategoryId = 3, SubjectId = 13, TutorId = 31, Title = "高等數學", SubTitle = "深入學習數學的高級概念", TwentyFiveMinUnitPrice = 140m, FiftyMinUnitPrice = 250m, Description = "高等數學理論和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_math.jpg", VideoUrl = "https://example.com/courses/advanced_math_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 32, CategoryId = 3, SubjectId = 14, TutorId = 32, Title = "高等物理", SubTitle = "深入理解物理學的高級理論", TwentyFiveMinUnitPrice = 145m, FiftyMinUnitPrice = 255m, Description = "物理學的高級理論和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_physics.jpg", VideoUrl = "https://example.com/courses/advanced_physics_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 33, CategoryId = 3, SubjectId = 15, TutorId = 33, Title = "高等化學", SubTitle = "深入理解化學的高級理論", TwentyFiveMinUnitPrice = 150m, FiftyMinUnitPrice = 260m, Description = "化學的高級理論和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_chemistry.jpg", VideoUrl = "https://example.com/courses/advanced_chemistry_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 34, CategoryId = 3, SubjectId = 16, TutorId = 34, Title = "高等歷史研究", SubTitle = "深入分析歷史事件和背景", TwentyFiveMinUnitPrice = 160m, FiftyMinUnitPrice = 275m, Description = "歷史研究的高級技術和方法", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_history.jpg", VideoUrl = "https://example.com/courses/advanced_history_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 35, CategoryId = 3, SubjectId = 17, TutorId = 35, Title = "高等地理學", SubTitle = "深入理解地理學的高級概念", TwentyFiveMinUnitPrice = 150m, FiftyMinUnitPrice = 265m, Description = "地理學的高級理論和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_geography.jpg", VideoUrl = "https://example.com/courses/advanced_geography_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 36, CategoryId = 3, SubjectId = 18, TutorId = 36, Title = "高等生物學", SubTitle = "深入理解生物學的高級理論", TwentyFiveMinUnitPrice = 160m, FiftyMinUnitPrice = 275m, Description = "生物學的高級理論和應用", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/advanced_biology.jpg", VideoUrl = "https://example.com/courses/advanced_biology_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 37, CategoryId = 1, SubjectId = 1, TutorId = 37, Title = "專業英文寫作", SubTitle = "掌握專業英文寫作技巧", TwentyFiveMinUnitPrice = 180m, FiftyMinUnitPrice = 320m, Description = "專業英文寫作的高級技巧", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/professional_english.jpg", VideoUrl = "https://example.com/courses/professional_english_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 38, CategoryId = 1, SubjectId = 2, TutorId = 38, Title = "專業日語寫作", SubTitle = "掌握專業日語寫作技巧", TwentyFiveMinUnitPrice = 190m, FiftyMinUnitPrice = 340m, Description = "專業日語寫作的高級技巧", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/professional_japanese.jpg", VideoUrl = "https://example.com/courses/professional_japanese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 39, CategoryId = 1, SubjectId = 3, TutorId = 39, Title = "專業中文寫作", SubTitle = "掌握專業中文寫作技巧", TwentyFiveMinUnitPrice = 200m, FiftyMinUnitPrice = 360m, Description = "專業中文寫作的高級技巧", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/professional_chinese.jpg", VideoUrl = "https://example.com/courses/professional_chinese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
 new Course { CourseId = 40, CategoryId = 1, SubjectId = 4, TutorId = 40, Title = "專業德語寫作", SubTitle = "掌握專業德語寫作技巧", TwentyFiveMinUnitPrice = 210m, FiftyMinUnitPrice = 380m, Description = "專業德語寫作的高級技巧", IsEnabled = true, ThumbnailUrl = "https://example.com/courses/professional_german.jpg", VideoUrl = "https://example.com/courses/professional_german_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now });
        modelBuilder.Entity<CourseCategory>().HasData(
    new CourseCategory { CourseCategoryId = 1, CategorytName = "語言學習", Cdate = DateTime.Now },
    new CourseCategory { CourseCategoryId = 2, CategorytName = "程式設計", Cdate = DateTime.Now },
    new CourseCategory { CourseCategoryId = 3, CategorytName = "升學科目", Cdate = DateTime.Now }
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
    new Order { OrderId = 1, MemberId = 1, PaymentType = "CreditCard", TotalPrice = 1000.00m, TransactionDate = DateTime.Now.AddDays(-10), CouponPrice = 100.00m, TaxIdNumber = "A123456789", InvoiceType = 1, VATNumber = "12345678", SentVatemail = "order1@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(-10), Udate = DateTime.Now.AddDays(-9) },
    new Order { OrderId = 2, MemberId = 2, PaymentType = "PayPal", TotalPrice = 1500.00m, TransactionDate = DateTime.Now.AddDays(-9), CouponPrice = 150.00m, TaxIdNumber = "B123456789", InvoiceType = 2, VATNumber = "22345678", SentVatemail = "order2@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(-9), Udate = DateTime.Now.AddDays(-8) },
    new Order { OrderId = 3, MemberId = 3, PaymentType = "BankTransfer", TotalPrice = 2000.00m, TransactionDate = DateTime.Now.AddDays(-8), CouponPrice = 200.00m, TaxIdNumber = "C123456789", InvoiceType = 1, VATNumber = "32345678", SentVatemail = "order3@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(-8), Udate = DateTime.Now.AddDays(-7) },
    new Order { OrderId = 4, MemberId = 4, PaymentType = "CreditCard", TotalPrice = 2500.00m, TransactionDate = DateTime.Now.AddDays(-7), CouponPrice = 250.00m, TaxIdNumber = "D123456789", InvoiceType = 2, VATNumber = "42345678", SentVatemail = "order4@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(-7), Udate = DateTime.Now.AddDays(-6) },
    new Order { OrderId = 5, MemberId = 5, PaymentType = "PayPal", TotalPrice = 3000.00m, TransactionDate = DateTime.Now.AddDays(-6), CouponPrice = 300.00m, TaxIdNumber = "E123456789", InvoiceType = 1, VATNumber = "52345678", SentVatemail = "order5@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(-6), Udate = DateTime.Now.AddDays(-5) },
    new Order { OrderId = 6, MemberId = 6, PaymentType = "BankTransfer", TotalPrice = 3500.00m, TransactionDate = DateTime.Now.AddDays(-5), CouponPrice = 350.00m, TaxIdNumber = "F123456789", InvoiceType = 2, VATNumber = "62345678", SentVatemail = "order6@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(-5), Udate = DateTime.Now.AddDays(-4) },
    new Order { OrderId = 7, MemberId = 7, PaymentType = "CreditCard", TotalPrice = 4000.00m, TransactionDate = DateTime.Now.AddDays(-4), CouponPrice = 400.00m, TaxIdNumber = "G123456789", InvoiceType = 1, VATNumber = "72345678", SentVatemail = "order7@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(-4), Udate = DateTime.Now.AddDays(-3) },
    new Order { OrderId = 8, MemberId = 8, PaymentType = "PayPal", TotalPrice = 4500.00m, TransactionDate = DateTime.Now.AddDays(-3), CouponPrice = 450.00m, TaxIdNumber = "H123456789", InvoiceType = 2, VATNumber = "82345678", SentVatemail = "order8@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(-3), Udate = DateTime.Now.AddDays(-2) },
    new Order { OrderId = 9, MemberId = 9, PaymentType = "BankTransfer", TotalPrice = 5000.00m, TransactionDate = DateTime.Now.AddDays(-2), CouponPrice = 500.00m, TaxIdNumber = "I123456789", InvoiceType = 1, VATNumber = "92345678", SentVatemail = "order9@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(-2), Udate = DateTime.Now.AddDays(-1) },
    new Order { OrderId = 10, MemberId = 10, PaymentType = "CreditCard", TotalPrice = 5500.00m, TransactionDate = DateTime.Now.AddDays(-1), CouponPrice = 550.00m, TaxIdNumber = "J123456789", InvoiceType = 2, VATNumber = "01234567", SentVatemail = "order10@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(-1), Udate = DateTime.Now },
    new Order { OrderId = 11, MemberId = 11, PaymentType = "CreditCard", TotalPrice = 6000.00m, TransactionDate = DateTime.Now, CouponPrice = 600.00m, TaxIdNumber = "K123456789", InvoiceType = 1, VATNumber = "12345679", SentVatemail = "order11@domain.com", OrderStatusId = 1, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(1) },
    new Order { OrderId = 12, MemberId = 12, PaymentType = "PayPal", TotalPrice = 6500.00m, TransactionDate = DateTime.Now.AddDays(1), CouponPrice = 650.00m, TaxIdNumber = "L123456789", InvoiceType = 2, VATNumber = "22345679", SentVatemail = "order12@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(1), Udate = DateTime.Now.AddDays(2) },
    new Order { OrderId = 13, MemberId = 13, PaymentType = "BankTransfer", TotalPrice = 7000.00m, TransactionDate = DateTime.Now.AddDays(2), CouponPrice = 700.00m, TaxIdNumber = "M123456789", InvoiceType = 1, VATNumber = "32345679", SentVatemail = "order13@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(2), Udate = DateTime.Now.AddDays(3) },
    new Order { OrderId = 14, MemberId = 14, PaymentType = "CreditCard", TotalPrice = 7500.00m, TransactionDate = DateTime.Now.AddDays(3), CouponPrice = 750.00m, TaxIdNumber = "N123456789", InvoiceType = 2, VATNumber = "42345679", SentVatemail = "order14@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(3), Udate = DateTime.Now.AddDays(4) },
    new Order { OrderId = 15, MemberId = 15, PaymentType = "PayPal", TotalPrice = 8000.00m, TransactionDate = DateTime.Now.AddDays(4), CouponPrice = 800.00m, TaxIdNumber = "O123456789", InvoiceType = 1, VATNumber = "52345679", SentVatemail = "order15@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(4), Udate = DateTime.Now.AddDays(5) },
    new Order { OrderId = 16, MemberId = 16, PaymentType = "BankTransfer", TotalPrice = 8500.00m, TransactionDate = DateTime.Now.AddDays(5), CouponPrice = 850.00m, TaxIdNumber = "P123456789", InvoiceType = 2, VATNumber = "62345679", SentVatemail = "order16@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(5), Udate = DateTime.Now.AddDays(6) },
    new Order { OrderId = 17, MemberId = 17, PaymentType = "CreditCard", TotalPrice = 9000.00m, TransactionDate = DateTime.Now.AddDays(6), CouponPrice = 900.00m, TaxIdNumber = "Q123456789", InvoiceType = 1, VATNumber = "72345679", SentVatemail = "order17@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(6), Udate = DateTime.Now.AddDays(7) },
    new Order { OrderId = 18, MemberId = 18, PaymentType = "PayPal", TotalPrice = 9500.00m, TransactionDate = DateTime.Now.AddDays(7), CouponPrice = 950.00m, TaxIdNumber = "R123456789", InvoiceType = 2, VATNumber = "82345679", SentVatemail = "order18@domain.com", OrderStatusId = 2, Cdate = DateTime.Now.AddDays(7), Udate = DateTime.Now.AddDays(8) },
    new Order { OrderId = 19, MemberId = 19, PaymentType = "BankTransfer", TotalPrice = 10000.00m, TransactionDate = DateTime.Now.AddDays(8), CouponPrice = 1000.00m, TaxIdNumber = "S123456789", InvoiceType = 1, VATNumber = "92345679", SentVatemail = "order19@domain.com", OrderStatusId = 3, Cdate = DateTime.Now.AddDays(8), Udate = DateTime.Now.AddDays(9) },
    new Order { OrderId = 20, MemberId = 20, PaymentType = "CreditCard", TotalPrice = 10500.00m, TransactionDate = DateTime.Now.AddDays(9), CouponPrice = 1050.00m, TaxIdNumber = "T123456789", InvoiceType = 2, VATNumber = "01234579", SentVatemail = "order20@domain.com", OrderStatusId = 1, Cdate = DateTime.Now.AddDays(9), Udate = DateTime.Now.AddDays(10) }
);
        modelBuilder.Entity<OrderDetail>().HasData(
     new OrderDetail { OrderDetailId = 1, OrderId = 1, CourseId = 2, UnitPrice = 100.00m, Quantity = 10, DiscountPrice = 10.00m, TotalPrice = 900.00m, CourseType = 1, CourseTitle = "日文會話", CourseCategory = "語言學習", CourseSubject = "日文" },
     new OrderDetail { OrderDetailId = 2, OrderId = 2, CourseId = 2, UnitPrice = 200.00m, Quantity = 5, DiscountPrice = 20.00m, TotalPrice = 980.00m, CourseType = 1, CourseTitle = "日文會話", CourseCategory = "語言學習", CourseSubject = "日文" },
     new OrderDetail { OrderDetailId = 3, OrderId = 3, CourseId = 3, UnitPrice = 300.00m, Quantity = 3, DiscountPrice = 30.00m, TotalPrice = 870.00m, CourseType = 1, CourseTitle = "C# 基礎", CourseCategory = "程式設計", CourseSubject = "C#" },
     new OrderDetail { OrderDetailId = 4, OrderId = 4, CourseId = 4, UnitPrice = 400.00m, Quantity = 2, DiscountPrice = 40.00m, TotalPrice = 760.00m, CourseType = 2, CourseTitle = "SQL進階", CourseCategory = "程式設計", CourseSubject = "SQL" },
     new OrderDetail { OrderDetailId = 5, OrderId = 5, CourseId = 5, UnitPrice = 500.00m, Quantity = 4, DiscountPrice = 50.00m, TotalPrice = 1950.00m, CourseType = 2, CourseTitle = "Java 進階", CourseCategory = "程式設計", CourseSubject = "Java" },
     new OrderDetail { OrderDetailId = 6, OrderId = 6, CourseId = 6, UnitPrice = 600.00m, Quantity = 1, DiscountPrice = 60.00m, TotalPrice = 540.00m, CourseType = 1, CourseTitle = "數學基礎", CourseCategory = "升學科目", CourseSubject = "數學" },
     new OrderDetail { OrderDetailId = 7, OrderId = 7, CourseId = 7, UnitPrice = 700.00m, Quantity = 3, DiscountPrice = 70.00m, TotalPrice = 1890.00m, CourseType = 1, CourseTitle = "物理基礎", CourseCategory = "升學科目", CourseSubject = "物理" },
     new OrderDetail { OrderDetailId = 8, OrderId = 8, CourseId = 8, UnitPrice = 800.00m, Quantity = 2, DiscountPrice = 80.00m, TotalPrice = 1520.00m, CourseType = 2, CourseTitle = "化學進階", CourseCategory = "升學科目", CourseSubject = "化學" },
     new OrderDetail { OrderDetailId = 9, OrderId = 9, CourseId = 9, UnitPrice = 900.00m, Quantity = 1, DiscountPrice = 90.00m, TotalPrice = 810.00m, CourseType = 2, CourseTitle = "歷史進階", CourseCategory = "升學科目", CourseSubject = "歷史" },
     new OrderDetail { OrderDetailId = 10, OrderId = 10, CourseId = 10, UnitPrice = 1000.00m, Quantity = 2, DiscountPrice = 100.00m, TotalPrice = 1900.00m, CourseType = 1, CourseTitle = "地理基礎", CourseCategory = "升學科目", CourseSubject = "地理" },
     new OrderDetail { OrderDetailId = 11, OrderId = 11, CourseId = 11, UnitPrice = 1100.00m, Quantity = 1, DiscountPrice = 110.00m, TotalPrice = 990.00m, CourseType = 1, CourseTitle = "生物基礎", CourseCategory = "升學科目", CourseSubject = "生物" },
     new OrderDetail { OrderDetailId = 12, OrderId = 12, CourseId = 12, UnitPrice = 1200.00m, Quantity = 4, DiscountPrice = 120.00m, TotalPrice = 4680.00m, CourseType = 2, CourseTitle = "英文進階", CourseCategory = "語言學習", CourseSubject = "英文" },
     new OrderDetail { OrderDetailId = 13, OrderId = 13, CourseId = 13, UnitPrice = 1300.00m, Quantity = 3, DiscountPrice = 130.00m, TotalPrice = 3690.00m, CourseType = 1, CourseTitle = "日文基礎", CourseCategory = "語言學習", CourseSubject = "日文" },
     new OrderDetail { OrderDetailId = 14, OrderId = 14, CourseId = 14, UnitPrice = 1400.00m, Quantity = 2, DiscountPrice = 140.00m, TotalPrice = 2660.00m, CourseType = 2, CourseTitle = "中文進階", CourseCategory = "語言學習", CourseSubject = "中文" },
     new OrderDetail { OrderDetailId = 15, OrderId = 15, CourseId = 15, UnitPrice = 1500.00m, Quantity = 5, DiscountPrice = 150.00m, TotalPrice = 7050.00m, CourseType = 1, CourseTitle = "德文基礎", CourseCategory = "語言學習", CourseSubject = "德文" },
     new OrderDetail { OrderDetailId = 16, OrderId = 16, CourseId = 16, UnitPrice = 1600.00m, Quantity = 4, DiscountPrice = 160.00m, TotalPrice = 6240.00m, CourseType = 1, CourseTitle = "法文基礎", CourseCategory = "語言學習", CourseSubject = "法文" },
     new OrderDetail { OrderDetailId = 17, OrderId = 17, CourseId = 17, UnitPrice = 1700.00m, Quantity = 2, DiscountPrice = 170.00m, TotalPrice = 3230.00m, CourseType = 2, CourseTitle = "西班牙文進階", CourseCategory = "語言學習", CourseSubject = "西班牙文" },
     new OrderDetail { OrderDetailId = 18, OrderId = 18, CourseId = 18, UnitPrice = 1800.00m, Quantity = 1, DiscountPrice = 180.00m, TotalPrice = 1620.00m, CourseType = 2, CourseTitle = "HTML/CSS進階", CourseCategory = "程式設計", CourseSubject = "HTML/CSS" },
     new OrderDetail { OrderDetailId = 19, OrderId = 19, CourseId = 19, UnitPrice = 1900.00m, Quantity = 4, DiscountPrice = 190.00m, TotalPrice = 7370.00m, CourseType = 1, CourseTitle = "JavaScript基礎", CourseCategory = "程式設計", CourseSubject = "JavaScript" },
     new OrderDetail { OrderDetailId = 20, OrderId = 20, CourseId = 20, UnitPrice = 2000.00m, Quantity = 2, DiscountPrice = 200.00m, TotalPrice = 3800.00m, CourseType = 2, CourseTitle = "Python進階", CourseCategory = "程式設計", CourseSubject = "Python" }
 );
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { CouponId = 1, CouponName = "Welcome10", CouponCode = "WELCOME10", DiscountType = 1, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(1), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(1) },
new Coupon { CouponId = 2, CouponName = "SummerSale", CouponCode = "SUMMER20", DiscountType = 2, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(2), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(2) },
new Coupon { CouponId = 3, CouponName = "FallSavings", CouponCode = "FALL15", DiscountType = 1, Discount = 15, ExpirationDate = DateTime.Now.AddMonths(3), IsActive = false, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(3) },
new Coupon { CouponId = 4, CouponName = "WinterDeal", CouponCode = "WINTER25", DiscountType = 2, Discount = 25, ExpirationDate = DateTime.Now.AddMonths(4), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(4) },
new Coupon { CouponId = 5, CouponName = "SpringSave", CouponCode = "SPRING30", DiscountType = 1, Discount = 30, ExpirationDate = DateTime.Now.AddMonths(5), IsActive = false, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(5) },
new Coupon { CouponId = 6, CouponName = "Holiday50", CouponCode = "HOLIDAY50", DiscountType = 2, Discount = 50, ExpirationDate = DateTime.Now.AddMonths(6), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(6) },
new Coupon { CouponId = 7, CouponName = "NewYear15", CouponCode = "NEWYEAR15", DiscountType = 1, Discount = 15, ExpirationDate = DateTime.Now.AddMonths(7), IsActive = false, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(7) },
new Coupon { CouponId = 8, CouponName = "CyberMonday", CouponCode = "CYBER20", DiscountType = 2, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(8), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(8) },
new Coupon { CouponId = 9, CouponName = "BlackFriday", CouponCode = "BLACK30", DiscountType = 1, Discount = 30, ExpirationDate = DateTime.Now.AddMonths(9), IsActive = false, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(9) },
new Coupon { CouponId = 10, CouponName = "WelcomeBack", CouponCode = "WELCOME5", DiscountType = 2, Discount = 5, ExpirationDate = DateTime.Now.AddMonths(10), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(10) },
new Coupon { CouponId = 11, CouponName = "BackToSchool", CouponCode = "SCHOOL25", DiscountType = 1, Discount = 25, ExpirationDate = DateTime.Now.AddMonths(11), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(11) },
new Coupon { CouponId = 12, CouponName = "EarlyBird", CouponCode = "EARLY10", DiscountType = 2, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(12), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(12) },
new Coupon { CouponId = 13, CouponName = "FlashSale", CouponCode = "FLASH50", DiscountType = 1, Discount = 50, ExpirationDate = DateTime.Now.AddMonths(13), IsActive = false, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(13) },
new Coupon { CouponId = 14, CouponName = "NewCustomer", CouponCode = "NEWCUST20", DiscountType = 2, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(14), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(14) },
new Coupon { CouponId = 15, CouponName = "LoyaltyReward", CouponCode = "LOYALTY10", DiscountType = 1, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(15), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(15) },
new Coupon { CouponId = 16, CouponName = "ReferralBonus", CouponCode = "REFERRAL15", DiscountType = 2, Discount = 15, ExpirationDate = DateTime.Now.AddMonths(16), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(16) },
new Coupon { CouponId = 17, CouponName = "SummerSpecial", CouponCode = "SUMMER10", DiscountType = 1, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(17), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(17) },
new Coupon { CouponId = 18, CouponName = "WinterWonder", CouponCode = "WINTER20", DiscountType = 2, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(18), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(18) },
new Coupon { CouponId = 19, CouponName = "SpringBlossom", CouponCode = "SPRING25", DiscountType = 1, Discount = 25, ExpirationDate = DateTime.Now.AddMonths(19), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(19) },
new Coupon { CouponId = 20, CouponName = "AutumnLeaves", CouponCode = "AUTUMN15", DiscountType = 2, Discount = 15, ExpirationDate = DateTime.Now.AddMonths(20), IsActive = true, Cdate = DateTime.Now, Udate = DateTime.Now.AddDays(20) }
);

        //    modelBuilder.Entity<MemberCoupon>().HasData(
        //new MemberCoupon { MemberCouponId = 1, MemberId = 1, CouponId = 1, IsUsed = false, Cdate = DateTime.Now },
        //new MemberCoupon { MemberCouponId = 2, MemberId = 2, CouponId = 2, IsUsed = true, Cdate = DateTime.Now }
        //    );

        modelBuilder.Entity<MemberPreference>().HasData(
          new MemberPreference { MemberPreferenceId = 1, MemberId = 1, SubjecId = 1, Cdate = DateTime.Now.AddMonths(-5), Udate = DateTime.Now.AddMonths(-4) },
new MemberPreference { MemberPreferenceId = 2, MemberId = 2, SubjecId = 2, Cdate = DateTime.Now.AddMonths(-4), Udate = DateTime.Now.AddMonths(-3) },
new MemberPreference { MemberPreferenceId = 3, MemberId = 3, SubjecId = 3, Cdate = DateTime.Now.AddMonths(-3), Udate = DateTime.Now.AddMonths(-2) },
new MemberPreference { MemberPreferenceId = 4, MemberId = 4, SubjecId = 4, Cdate = DateTime.Now.AddMonths(-2), Udate = DateTime.Now.AddMonths(-1) },
new MemberPreference { MemberPreferenceId = 5, MemberId = 5, SubjecId = 5, Cdate = DateTime.Now.AddMonths(-1), Udate = DateTime.Now },
new MemberPreference { MemberPreferenceId = 6, MemberId = 6, SubjecId = 6, Cdate = DateTime.Now.AddMonths(-6), Udate = DateTime.Now.AddMonths(-5) },
new MemberPreference { MemberPreferenceId = 7, MemberId = 7, SubjecId = 7, Cdate = DateTime.Now.AddMonths(-5), Udate = DateTime.Now.AddMonths(-4) },
new MemberPreference { MemberPreferenceId = 8, MemberId = 8, SubjecId = 8, Cdate = DateTime.Now.AddMonths(-4), Udate = DateTime.Now.AddMonths(-3) },
new MemberPreference { MemberPreferenceId = 9, MemberId = 9, SubjecId = 9, Cdate = DateTime.Now.AddMonths(-3), Udate = DateTime.Now.AddMonths(-2) },
new MemberPreference { MemberPreferenceId = 10, MemberId = 10, SubjecId = 10, Cdate = DateTime.Now.AddMonths(-2), Udate = DateTime.Now.AddMonths(-1) },
new MemberPreference { MemberPreferenceId = 11, MemberId = 11, SubjecId = 11, Cdate = DateTime.Now.AddMonths(-1), Udate = DateTime.Now },
new MemberPreference { MemberPreferenceId = 12, MemberId = 12, SubjecId = 12, Cdate = DateTime.Now.AddMonths(-6), Udate = DateTime.Now.AddMonths(-5) },
new MemberPreference { MemberPreferenceId = 13, MemberId = 13, SubjecId = 13, Cdate = DateTime.Now.AddMonths(-5), Udate = DateTime.Now.AddMonths(-4) },
new MemberPreference { MemberPreferenceId = 14, MemberId = 14, SubjecId = 14, Cdate = DateTime.Now.AddMonths(-4), Udate = DateTime.Now.AddMonths(-3) },
new MemberPreference { MemberPreferenceId = 15, MemberId = 15, SubjecId = 15, Cdate = DateTime.Now.AddMonths(-3), Udate = DateTime.Now.AddMonths(-2) },
new MemberPreference { MemberPreferenceId = 16, MemberId = 16, SubjecId = 16, Cdate = DateTime.Now.AddMonths(-2), Udate = DateTime.Now.AddMonths(-1) },
new MemberPreference { MemberPreferenceId = 17, MemberId = 17, SubjecId = 17, Cdate = DateTime.Now.AddMonths(-1), Udate = DateTime.Now },
new MemberPreference { MemberPreferenceId = 18, MemberId = 18, SubjecId = 18, Cdate = DateTime.Now.AddMonths(-6), Udate = DateTime.Now.AddMonths(-5) },
new MemberPreference { MemberPreferenceId = 19, MemberId = 19, SubjecId = 1, Cdate = DateTime.Now.AddMonths(-5), Udate = DateTime.Now.AddMonths(-4) },
new MemberPreference { MemberPreferenceId = 20, MemberId = 20, SubjecId = 2, Cdate = DateTime.Now.AddMonths(-4), Udate = DateTime.Now.AddMonths(-3) }
);
        modelBuilder.Entity<ApplyList>().HasData(
    new ApplyList { ApplyId = 1, MemberId = 1, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-10), ApprovedDateTime = DateTime.Now.AddDays(-8), UpdateStatusDateTime = DateTime.Now.AddDays(-7), RejectReason = null },
new ApplyList { ApplyId = 2, MemberId = 2, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(-9), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(-6), RejectReason = "Incomplete application" },
new ApplyList { ApplyId = 3, MemberId = 3, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-8), ApprovedDateTime = DateTime.Now.AddDays(-7), UpdateStatusDateTime = DateTime.Now.AddDays(-5), RejectReason = null },
new ApplyList { ApplyId = 4, MemberId = 4, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(-7), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(-4), RejectReason = "Failed verification" },
new ApplyList { ApplyId = 5, MemberId = 5, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-6), ApprovedDateTime = DateTime.Now.AddDays(-5), UpdateStatusDateTime = DateTime.Now.AddDays(-3), RejectReason = null },
new ApplyList { ApplyId = 6, MemberId = 6, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-5), ApprovedDateTime = DateTime.Now.AddDays(-3), UpdateStatusDateTime = DateTime.Now.AddDays(-2), RejectReason = null },
new ApplyList { ApplyId = 7, MemberId = 7, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(-4), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(-1), RejectReason = "Incorrect details" },
new ApplyList { ApplyId = 8, MemberId = 8, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-3), ApprovedDateTime = DateTime.Now.AddDays(-2), UpdateStatusDateTime = DateTime.Now, RejectReason = null },
new ApplyList { ApplyId = 9, MemberId = 9, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(-2), ApprovedDateTime = DateTime.Now, UpdateStatusDateTime = DateTime.Now.AddDays(1), RejectReason = null },
new ApplyList { ApplyId = 10, MemberId = 10, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(-1), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(2), RejectReason = "Missing documents" },
new ApplyList { ApplyId = 11, MemberId = 11, ApplyStatus = true, ApplyDateTime = DateTime.Now, ApprovedDateTime = DateTime.Now.AddDays(1), UpdateStatusDateTime = DateTime.Now.AddDays(2), RejectReason = null },
new ApplyList { ApplyId = 12, MemberId = 12, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(1), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(3), RejectReason = "Not eligible" },
new ApplyList { ApplyId = 13, MemberId = 13, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(2), ApprovedDateTime = DateTime.Now.AddDays(3), UpdateStatusDateTime = DateTime.Now.AddDays(4), RejectReason = null },
new ApplyList { ApplyId = 14, MemberId = 14, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(3), ApprovedDateTime = DateTime.Now.AddDays(4), UpdateStatusDateTime = DateTime.Now.AddDays(5), RejectReason = null },
new ApplyList { ApplyId = 15, MemberId = 15, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(4), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(6), RejectReason = "Failed interview" },
new ApplyList { ApplyId = 16, MemberId = 16, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(5), ApprovedDateTime = DateTime.Now.AddDays(6), UpdateStatusDateTime = DateTime.Now.AddDays(7), RejectReason = null },
new ApplyList { ApplyId = 17, MemberId = 17, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(6), ApprovedDateTime = DateTime.Now.AddDays(7), UpdateStatusDateTime = DateTime.Now.AddDays(8), RejectReason = null },
new ApplyList { ApplyId = 18, MemberId = 18, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(7), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(9), RejectReason = "Incorrect documentation" },
new ApplyList { ApplyId = 19, MemberId = 19, ApplyStatus = true, ApplyDateTime = DateTime.Now.AddDays(8), ApprovedDateTime = DateTime.Now.AddDays(9), UpdateStatusDateTime = DateTime.Now.AddDays(10), RejectReason = null },
new ApplyList { ApplyId = 20, MemberId = 20, ApplyStatus = false, ApplyDateTime = DateTime.Now.AddDays(9), ApprovedDateTime = null, UpdateStatusDateTime = DateTime.Now.AddDays(11), RejectReason = "Unverified information" }

);
        modelBuilder.Entity<Booking>().HasData(
    new Booking { BookingId = 3, CourseId = 3, BookingDate = DateTime.Now, BookingTime = 14, StudentId = 3, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 4, CourseId = 4, BookingDate = DateTime.Now, BookingTime = 15, StudentId = 4, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 5, CourseId = 5, BookingDate = DateTime.Now, BookingTime = 16, StudentId = 5, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 6, CourseId = 6, BookingDate = DateTime.Now, BookingTime = 17, StudentId = 6, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 7, CourseId = 7, BookingDate = DateTime.Now, BookingTime = 18, StudentId = 7, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 8, CourseId = 8, BookingDate = DateTime.Now, BookingTime = 19, StudentId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 9, CourseId = 9, BookingDate = DateTime.Now, BookingTime = 20, StudentId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 10, CourseId = 10, BookingDate = DateTime.Now, BookingTime = 12, StudentId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 11, CourseId = 11, BookingDate = DateTime.Now, BookingTime = 13, StudentId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 12, CourseId = 12, BookingDate = DateTime.Now, BookingTime = 14, StudentId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 13, CourseId = 13, BookingDate = DateTime.Now, BookingTime = 15, StudentId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 14, CourseId = 14, BookingDate = DateTime.Now, BookingTime = 16, StudentId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 15, CourseId = 15, BookingDate = DateTime.Now, BookingTime = 17, StudentId = 15, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 16, CourseId = 16, BookingDate = DateTime.Now, BookingTime = 18, StudentId = 16, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 17, CourseId = 17, BookingDate = DateTime.Now, BookingTime = 19, StudentId = 17, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 18, CourseId = 18, BookingDate = DateTime.Now, BookingTime = 20, StudentId = 18, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 19, CourseId = 19, BookingDate = DateTime.Now, BookingTime = 12, StudentId = 19, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 20, CourseId = 20, BookingDate = DateTime.Now, BookingTime = 13, StudentId = 20, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 21, CourseId = 1, BookingDate = new DateTime(2024, 9, 9), BookingTime = 13, StudentId = 20, Cdate = DateTime.Now, Udate = DateTime.Now },
new Booking { BookingId = 22, CourseId = 2, BookingDate = new DateTime(2024, 9, 10), BookingTime = 16, StudentId = 21, Cdate = DateTime.Now, Udate = DateTime.Now }

);
        modelBuilder.Entity<ProfessionalLicense>().HasData(
            new ProfessionalLicense { ProfessionalLicenseId = 1, ProfessionalLicenseName = "Certified Java Developer", MemberId = 1, ProfessionalLicenseUrl = "https://example.com/licenses/java_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 2, ProfessionalLicenseName = "Certified Python Developer", MemberId = 2, ProfessionalLicenseUrl = "https://example.com/licenses/python_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 3, ProfessionalLicenseName = "Certified C# Developer", MemberId = 3, ProfessionalLicenseUrl = "https://example.com/licenses/csharp_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 4, ProfessionalLicenseName = "Certified SQL Developer", MemberId = 4, ProfessionalLicenseUrl = "https://example.com/licenses/sql_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 5, ProfessionalLicenseName = "Certified JavaScript Developer", MemberId = 5, ProfessionalLicenseUrl = "https://example.com/licenses/js_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 6, ProfessionalLicenseName = "Certified Data Analyst", MemberId = 6, ProfessionalLicenseUrl = "https://example.com/licenses/data_analyst_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 7, ProfessionalLicenseName = "Certified Project Manager", MemberId = 7, ProfessionalLicenseUrl = "https://example.com/licenses/project_manager_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 8, ProfessionalLicenseName = "Certified Network Engineer", MemberId = 8, ProfessionalLicenseUrl = "https://example.com/licenses/network_engineer_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 9, ProfessionalLicenseName = "Certified Cloud Architect", MemberId = 9, ProfessionalLicenseUrl = "https://example.com/licenses/cloud_architect_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 10, ProfessionalLicenseName = "Certified DevOps Engineer", MemberId = 10, ProfessionalLicenseUrl = "https://example.com/licenses/devops_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 11, ProfessionalLicenseName = "Certified Ethical Hacker", MemberId = 11, ProfessionalLicenseUrl = "https://example.com/licenses/ethical_hacker_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 12, ProfessionalLicenseName = "Certified AI Engineer", MemberId = 12, ProfessionalLicenseUrl = "https://example.com/licenses/ai_engineer_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 13, ProfessionalLicenseName = "Certified ML Engineer", MemberId = 13, ProfessionalLicenseUrl = "https://example.com/licenses/ml_engineer_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 14, ProfessionalLicenseName = "Certified Blockchain Developer", MemberId = 14, ProfessionalLicenseUrl = "https://example.com/licenses/blockchain_dev_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 15, ProfessionalLicenseName = "Certified UX Designer", MemberId = 15, ProfessionalLicenseUrl = "https://example.com/licenses/ux_designer_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 16, ProfessionalLicenseName = "Certified UI Designer", MemberId = 16, ProfessionalLicenseUrl = "https://example.com/licenses/ui_designer_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 17, ProfessionalLicenseName = "Certified Product Manager", MemberId = 17, ProfessionalLicenseUrl = "https://example.com/licenses/product_manager_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 18, ProfessionalLicenseName = "Certified IT Security Specialist", MemberId = 18, ProfessionalLicenseUrl = "https://example.com/licenses/it_security_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 19, ProfessionalLicenseName = "Certified Web Developer", MemberId = 19, ProfessionalLicenseUrl = "https://example.com/licenses/web_dev_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now },
            new ProfessionalLicense { ProfessionalLicenseId = 20, ProfessionalLicenseName = "Certified Software Tester", MemberId = 20, ProfessionalLicenseUrl = "https://example.com/licenses/software_tester_certified.jpg", Cdate = DateTime.Now.AddYears(-1), Udate = DateTime.Now }
        );
        modelBuilder.Entity<Review>().HasData(
    new Review { ReviewId = 1, StudentId = 1, CourseId = 1, Rating = 5, CommentText = "Great course!", Cdate = DateTime.Now.AddDays(-10), Udate = DateTime.Now },
new Review { ReviewId = 2, StudentId = 2, CourseId = 2, Rating = 4, CommentText = "Very informative.", Cdate = DateTime.Now.AddDays(-9), Udate = DateTime.Now },
new Review { ReviewId = 3, StudentId = 3, CourseId = 3, Rating = 5, CommentText = "Excellent content.", Cdate = DateTime.Now.AddDays(-8), Udate = DateTime.Now },
new Review { ReviewId = 4, StudentId = 4, CourseId = 4, Rating = 4, CommentText = "Good explanations.", Cdate = DateTime.Now.AddDays(-7), Udate = DateTime.Now },
new Review { ReviewId = 5, StudentId = 5, CourseId = 5, Rating = 5, CommentText = "Highly recommend.", Cdate = DateTime.Now.AddDays(-6), Udate = DateTime.Now },
new Review { ReviewId = 6, StudentId = 6, CourseId = 6, Rating = 4, CommentText = "Well structured.", Cdate = DateTime.Now.AddDays(-5), Udate = DateTime.Now },
new Review { ReviewId = 7, StudentId = 7, CourseId = 7, Rating = 5, CommentText = "Learned a lot.", Cdate = DateTime.Now.AddDays(-4), Udate = DateTime.Now },
new Review { ReviewId = 8, StudentId = 8, CourseId = 8, Rating = 4, CommentText = "Great examples.", Cdate = DateTime.Now.AddDays(-3), Udate = DateTime.Now },
new Review { ReviewId = 9, StudentId = 9, CourseId = 9, Rating = 5, CommentText = "In-depth knowledge.", Cdate = DateTime.Now.AddDays(-2), Udate = DateTime.Now },
new Review { ReviewId = 10, StudentId = 10, CourseId = 10, Rating = 4, CommentText = "Comprehensive.", Cdate = DateTime.Now.AddDays(-1), Udate = DateTime.Now },
new Review { ReviewId = 11, StudentId = 11, CourseId = 11, Rating = 5, CommentText = "Loved it!", Cdate = DateTime.Now, Udate = DateTime.Now },
new Review { ReviewId = 12, StudentId = 12, CourseId = 12, Rating = 4, CommentText = "Very useful.", Cdate = DateTime.Now.AddDays(1), Udate = DateTime.Now },
new Review { ReviewId = 13, StudentId = 13, CourseId = 13, Rating = 5, CommentText = "Fantastic course!", Cdate = DateTime.Now.AddDays(2), Udate = DateTime.Now },
new Review { ReviewId = 14, StudentId = 14, CourseId = 14, Rating = 4, CommentText = "Great teacher.", Cdate = DateTime.Now.AddDays(3), Udate = DateTime.Now },
new Review { ReviewId = 15, StudentId = 15, CourseId = 15, Rating = 5, CommentText = "Well explained.", Cdate = DateTime.Now.AddDays(4), Udate = DateTime.Now },
new Review { ReviewId = 16, StudentId = 16, CourseId = 16, Rating = 4, CommentText = "Good coverage.", Cdate = DateTime.Now.AddDays(5), Udate = DateTime.Now },
new Review { ReviewId = 17, StudentId = 17, CourseId = 17, Rating = 5, CommentText = "Loved the content.", Cdate = DateTime.Now.AddDays(6), Udate = DateTime.Now },
new Review { ReviewId = 18, StudentId = 18, CourseId = 18, Rating = 4, CommentText = "Very clear.", Cdate = DateTime.Now.AddDays(7), Udate = DateTime.Now },
new Review { ReviewId = 19, StudentId = 19, CourseId = 19, Rating = 5, CommentText = "Highly informative.", Cdate = DateTime.Now.AddDays(8), Udate = DateTime.Now },
new Review { ReviewId = 20, StudentId = 20, CourseId = 20, Rating = 4, CommentText = "Helpful.", Cdate = DateTime.Now.AddDays(9), Udate = DateTime.Now },
new Review { ReviewId = 21, StudentId = 21, CourseId = 21, Rating = 5, CommentText = "Amazing course!", Cdate = DateTime.Now.AddDays(-10), Udate = DateTime.Now },
new Review { ReviewId = 22, StudentId = 22, CourseId = 22, Rating = 4, CommentText = "Well organized.", Cdate = DateTime.Now.AddDays(-9), Udate = DateTime.Now },
new Review { ReviewId = 23, StudentId = 23, CourseId = 23, Rating = 5, CommentText = "Great insights.", Cdate = DateTime.Now.AddDays(-8), Udate = DateTime.Now },
new Review { ReviewId = 24, StudentId = 24, CourseId = 24, Rating = 4, CommentText = "Valuable lessons.", Cdate = DateTime.Now.AddDays(-7), Udate = DateTime.Now },
new Review { ReviewId = 25, StudentId = 25, CourseId = 25, Rating = 5, CommentText = "Excellent teaching.", Cdate = DateTime.Now.AddDays(-6), Udate = DateTime.Now },
new Review { ReviewId = 26, StudentId = 26, CourseId = 26, Rating = 4, CommentText = "Clear and concise.", Cdate = DateTime.Now.AddDays(-5), Udate = DateTime.Now },
new Review { ReviewId = 27, StudentId = 27, CourseId = 27, Rating = 5, CommentText = "Very educational.", Cdate = DateTime.Now.AddDays(-4), Udate = DateTime.Now },
new Review { ReviewId = 28, StudentId = 28, CourseId = 28, Rating = 4, CommentText = "Useful information.", Cdate = DateTime.Now.AddDays(-3), Udate = DateTime.Now },
new Review { ReviewId = 29, StudentId = 29, CourseId = 29, Rating = 5, CommentText = "Well presented.", Cdate = DateTime.Now.AddDays(-2), Udate = DateTime.Now },
new Review { ReviewId = 30, StudentId = 30, CourseId = 30, Rating = 4, CommentText = "Good pacing.", Cdate = DateTime.Now.AddDays(-1), Udate = DateTime.Now }

);
        modelBuilder.Entity<ShoppingCart>().HasData(
new ShoppingCart { ShoppingCartId = 1, CourseId = 1, UnitPrice = 100.00m, Quantity = 10, TotalPrice = 1000.00m, MemberId = 1, CourseType = 1, Cdate = DateTime.Now.AddDays(-20), Udate = DateTime.Now.AddDays(-19), BookingDate = DateTime.Now.AddDays(-18), BookingTime = DateTime.Now.AddDays(-18) },
new ShoppingCart { ShoppingCartId = 2, CourseId = 2, UnitPrice = 200.00m, Quantity = 5, TotalPrice = 1000.00m, MemberId = 2, CourseType = 2, Cdate = DateTime.Now.AddDays(-19), Udate = DateTime.Now.AddDays(-18), BookingDate = DateTime.Now.AddDays(-17), BookingTime = DateTime.Now.AddDays(-17) },
new ShoppingCart { ShoppingCartId = 3, CourseId = 3, UnitPrice = 300.00m, Quantity = 3, TotalPrice = 900.00m, MemberId = 3, CourseType = 1, Cdate = DateTime.Now.AddDays(-18), Udate = DateTime.Now.AddDays(-17), BookingDate = DateTime.Now.AddDays(-16), BookingTime = DateTime.Now.AddDays(-16) },
new ShoppingCart { ShoppingCartId = 4, CourseId = 4, UnitPrice = 400.00m, Quantity = 2, TotalPrice = 800.00m, MemberId = 4, CourseType = 2, Cdate = DateTime.Now.AddDays(-17), Udate = DateTime.Now.AddDays(-16), BookingDate = DateTime.Now.AddDays(-15), BookingTime = DateTime.Now.AddDays(-15) },
new ShoppingCart { ShoppingCartId = 5, CourseId = 5, UnitPrice = 500.00m, Quantity = 4, TotalPrice = 2000.00m, MemberId = 5, CourseType = 1, Cdate = DateTime.Now.AddDays(-16), Udate = DateTime.Now.AddDays(-15), BookingDate = DateTime.Now.AddDays(-14), BookingTime = DateTime.Now.AddDays(-14) },
new ShoppingCart { ShoppingCartId = 6, CourseId = 6, UnitPrice = 600.00m, Quantity = 1, TotalPrice = 600.00m, MemberId = 6, CourseType = 2, Cdate = DateTime.Now.AddDays(-15), Udate = DateTime.Now.AddDays(-14), BookingDate = DateTime.Now.AddDays(-13), BookingTime = DateTime.Now.AddDays(-13) },
new ShoppingCart { ShoppingCartId = 7, CourseId = 7, UnitPrice = 700.00m, Quantity = 3, TotalPrice = 2100.00m, MemberId = 7, CourseType = 1, Cdate = DateTime.Now.AddDays(-14), Udate = DateTime.Now.AddDays(-13), BookingDate = DateTime.Now.AddDays(-12), BookingTime = DateTime.Now.AddDays(-12) },
new ShoppingCart { ShoppingCartId = 8, CourseId = 8, UnitPrice = 800.00m, Quantity = 2, TotalPrice = 1600.00m, MemberId = 8, CourseType = 2, Cdate = DateTime.Now.AddDays(-13), Udate = DateTime.Now.AddDays(-12), BookingDate = DateTime.Now.AddDays(-11), BookingTime = DateTime.Now.AddDays(-11) },
new ShoppingCart { ShoppingCartId = 9, CourseId = 9, UnitPrice = 900.00m, Quantity = 1, TotalPrice = 900.00m, MemberId = 9, CourseType = 1, Cdate = DateTime.Now.AddDays(-12), Udate = DateTime.Now.AddDays(-11), BookingDate = DateTime.Now.AddDays(-10), BookingTime = DateTime.Now.AddDays(-10) },
new ShoppingCart { ShoppingCartId = 10, CourseId = 10, UnitPrice = 1000.00m, Quantity = 2, TotalPrice = 2000.00m, MemberId = 10, CourseType = 2, Cdate = DateTime.Now.AddDays(-11), Udate = DateTime.Now.AddDays(-10), BookingDate = DateTime.Now.AddDays(-9), BookingTime = DateTime.Now.AddDays(-9) },
new ShoppingCart { ShoppingCartId = 11, CourseId = 11, UnitPrice = 1100.00m, Quantity = 4, TotalPrice = 4400.00m, MemberId = 11, CourseType = 1, Cdate = DateTime.Now.AddDays(-10), Udate = DateTime.Now.AddDays(-9), BookingDate = DateTime.Now.AddDays(-8), BookingTime = DateTime.Now.AddDays(-8) },
new ShoppingCart { ShoppingCartId = 12, CourseId = 12, UnitPrice = 1200.00m, Quantity = 3, TotalPrice = 3600.00m, MemberId = 12, CourseType = 2, Cdate = DateTime.Now.AddDays(-9), Udate = DateTime.Now.AddDays(-8), BookingDate = DateTime.Now.AddDays(-7), BookingTime = DateTime.Now.AddDays(-7) },
new ShoppingCart { ShoppingCartId = 13, CourseId = 13, UnitPrice = 1300.00m, Quantity = 5, TotalPrice = 6500.00m, MemberId = 13, CourseType = 1, Cdate = DateTime.Now.AddDays(-8), Udate = DateTime.Now.AddDays(-7), BookingDate = DateTime.Now.AddDays(-6), BookingTime = DateTime.Now.AddDays(-6) },
new ShoppingCart { ShoppingCartId = 14, CourseId = 14, UnitPrice = 1400.00m, Quantity = 2, TotalPrice = 2800.00m, MemberId = 14, CourseType = 2, Cdate = DateTime.Now.AddDays(-7), Udate = DateTime.Now.AddDays(-6), BookingDate = DateTime.Now.AddDays(-5), BookingTime = DateTime.Now.AddDays(-5) },
new ShoppingCart { ShoppingCartId = 15, CourseId = 15, UnitPrice = 1500.00m, Quantity = 1, TotalPrice = 1500.00m, MemberId = 15, CourseType = 1, Cdate = DateTime.Now.AddDays(-6), Udate = DateTime.Now.AddDays(-5), BookingDate = DateTime.Now.AddDays(-4), BookingTime = DateTime.Now.AddDays(-4) },
new ShoppingCart { ShoppingCartId = 16, CourseId = 16, UnitPrice = 1600.00m, Quantity = 3, TotalPrice = 4800.00m, MemberId = 16, CourseType = 2, Cdate = DateTime.Now.AddDays(-5), Udate = DateTime.Now.AddDays(-4), BookingDate = DateTime.Now.AddDays(-3), BookingTime = DateTime.Now.AddDays(-3) },
new ShoppingCart { ShoppingCartId = 17, CourseId = 17, UnitPrice = 1700.00m, Quantity = 2, TotalPrice = 3400.00m, MemberId = 17, CourseType = 1, Cdate = DateTime.Now.AddDays(-4), Udate = DateTime.Now.AddDays(-3), BookingDate = DateTime.Now.AddDays(-2), BookingTime = DateTime.Now.AddDays(-2) },
new ShoppingCart { ShoppingCartId = 18, CourseId = 18, UnitPrice = 1800.00m, Quantity = 4, TotalPrice = 7200.00m, MemberId = 18, CourseType = 2, Cdate = DateTime.Now.AddDays(-3), Udate = DateTime.Now.AddDays(-2), BookingDate = DateTime.Now.AddDays(-1), BookingTime = DateTime.Now.AddDays(-1) },
new ShoppingCart { ShoppingCartId = 19, CourseId = 19, UnitPrice = 1900.00m, Quantity = 1, TotalPrice = 1900.00m, MemberId = 19, CourseType = 1, Cdate = DateTime.Now.AddDays(-2), Udate = DateTime.Now.AddDays(-1), BookingDate = DateTime.Now, BookingTime = DateTime.Now },
new ShoppingCart { ShoppingCartId = 20, CourseId = 20, UnitPrice = 2000.00m, Quantity = 2, TotalPrice = 4000.00m, MemberId = 20, CourseType = 2, Cdate = DateTime.Now.AddDays(-1), Udate = DateTime.Now, BookingDate = DateTime.Now.AddDays(1), BookingTime = DateTime.Now.AddDays(1) }
        );
        modelBuilder.Entity<TutorTimeSlot>().HasData(
new TutorTimeSlot { TutorTimeSlotId = 1, TutorId = 1, Weekday = 1, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 2, TutorId = 1, Weekday = 1, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 3, TutorId = 1, Weekday = 1, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 4, TutorId = 1, Weekday = 1, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 5, TutorId = 1, Weekday = 1, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 6, TutorId = 1, Weekday = 1, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 7, TutorId = 1, Weekday = 1, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 8, TutorId = 1, Weekday = 1, CourseHourId = 15, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 9, TutorId = 1, Weekday = 1, CourseHourId = 16, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 10, TutorId = 1, Weekday = 1, CourseHourId = 17, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 11, TutorId = 1, Weekday = 1, CourseHourId = 18, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 12, TutorId = 1, Weekday = 1, CourseHourId = 19, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 13, TutorId = 1, Weekday = 1, CourseHourId = 20, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 14, TutorId = 1, Weekday = 2, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 15, TutorId = 1, Weekday = 2, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 16, TutorId = 1, Weekday = 2, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 17, TutorId = 1, Weekday = 2, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 18, TutorId = 1, Weekday = 2, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 19, TutorId = 1, Weekday = 2, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 20, TutorId = 1, Weekday = 2, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
// TutorId 2
new TutorTimeSlot { TutorTimeSlotId = 21, TutorId = 2, Weekday = 3, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 22, TutorId = 2, Weekday = 3, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 23, TutorId = 2, Weekday = 3, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 24, TutorId = 2, Weekday = 3, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 25, TutorId = 2, Weekday = 4, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 26, TutorId = 2, Weekday = 4, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 27, TutorId = 2, Weekday = 4, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 28, TutorId = 2, Weekday = 5, CourseHourId = 15, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 29, TutorId = 2, Weekday = 5, CourseHourId = 16, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 30, TutorId = 2, Weekday = 5, CourseHourId = 17, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 31, TutorId = 2, Weekday = 6, CourseHourId = 18, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 32, TutorId = 2, Weekday = 6, CourseHourId = 19, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 33, TutorId = 2, Weekday = 0, CourseHourId = 20, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 34, TutorId = 2, Weekday = 1, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 35, TutorId = 2, Weekday = 1, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 36, TutorId = 2, Weekday = 1, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 37, TutorId = 2, Weekday = 2, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 38, TutorId = 2, Weekday = 2, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 39, TutorId = 2, Weekday = 2, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 40, TutorId = 2, Weekday = 2, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
// TutorId 3
new TutorTimeSlot { TutorTimeSlotId = 41, TutorId = 3, Weekday = 2, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 42, TutorId = 3, Weekday = 2, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 43, TutorId = 3, Weekday = 2, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 44, TutorId = 3, Weekday = 2, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 45, TutorId = 3, Weekday = 3, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 46, TutorId = 3, Weekday = 3, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 47, TutorId = 3, Weekday = 3, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 48, TutorId = 3, Weekday = 4, CourseHourId = 15, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 49, TutorId = 3, Weekday = 4, CourseHourId = 16, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 50, TutorId = 3, Weekday = 4, CourseHourId = 17, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 51, TutorId = 3, Weekday = 5, CourseHourId = 18, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 52, TutorId = 3, Weekday = 5, CourseHourId = 19, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 53, TutorId = 3, Weekday = 6, CourseHourId = 20, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 54, TutorId = 3, Weekday = 0, CourseHourId = 8, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 55, TutorId = 3, Weekday = 0, CourseHourId = 9, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 56, TutorId = 3, Weekday = 1, CourseHourId = 10, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 57, TutorId = 3, Weekday = 1, CourseHourId = 11, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 58, TutorId = 3, Weekday = 1, CourseHourId = 12, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 59, TutorId = 3, Weekday = 1, CourseHourId = 13, Cdate = DateTime.Now, Udate = DateTime.Now },
new TutorTimeSlot { TutorTimeSlotId = 60, TutorId = 3, Weekday = 2, CourseHourId = 14, Cdate = DateTime.Now, Udate = DateTime.Now }
 );
        modelBuilder.Entity<WorkExperience>().HasData(
new WorkExperience { WorkExperienceId = 1, MemberId = 1, WorkName = "Software Engineer", WorkExperienceFile = "https://example.com/resume/software_engineer_1.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-2) },
new WorkExperience { WorkExperienceId = 2, MemberId = 2, WorkName = "Data Analyst", WorkExperienceFile = "https://example.com/resume/data_analyst_2.pdf", WorkStartDate = DateTime.Now.AddYears(-4), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-4), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 3, MemberId = 3, WorkName = "Web Developer", WorkExperienceFile = "https://example.com/resume/web_developer_3.pdf", WorkStartDate = DateTime.Now.AddYears(-3), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-3), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 4, MemberId = 4, WorkName = "Database Administrator", WorkExperienceFile = "https://example.com/resume/db_admin_4.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-3), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-3) },
new WorkExperience { WorkExperienceId = 5, MemberId = 5, WorkName = "Network Engineer", WorkExperienceFile = "https://example.com/resume/network_engineer_5.pdf", WorkStartDate = DateTime.Now.AddYears(-6), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-6), Udate = DateTime.Now.AddYears(-2) },
new WorkExperience { WorkExperienceId = 6, MemberId = 6, WorkName = "System Analyst", WorkExperienceFile = "https://example.com/resume/system_analyst_6.pdf", WorkStartDate = DateTime.Now.AddYears(-7), WorkEndDate = DateTime.Now.AddYears(-3), Cdate = DateTime.Now.AddYears(-7), Udate = DateTime.Now.AddYears(-3) },
new WorkExperience { WorkExperienceId = 7, MemberId = 7, WorkName = "Project Manager", WorkExperienceFile = "https://example.com/resume/project_manager_7.pdf", WorkStartDate = DateTime.Now.AddYears(-8), WorkEndDate = DateTime.Now.AddYears(-4), Cdate = DateTime.Now.AddYears(-8), Udate = DateTime.Now.AddYears(-4) },
new WorkExperience { WorkExperienceId = 8, MemberId = 8, WorkName = "UI/UX Designer", WorkExperienceFile = "https://example.com/resume/ui_ux_designer_8.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 9, MemberId = 9, WorkName = "DevOps Engineer", WorkExperienceFile = "https://example.com/resume/devops_engineer_9.pdf", WorkStartDate = DateTime.Now.AddYears(-4), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-4), Udate = DateTime.Now.AddYears(-2) },
new WorkExperience { WorkExperienceId = 10, MemberId = 10, WorkName = "Software Architect", WorkExperienceFile = "https://example.com/resume/software_architect_10.pdf", WorkStartDate = DateTime.Now.AddYears(-6), WorkEndDate = DateTime.Now.AddYears(-3), Cdate = DateTime.Now.AddYears(-6), Udate = DateTime.Now.AddYears(-3) },
new WorkExperience { WorkExperienceId = 11, MemberId = 11, WorkName = "Business Analyst", WorkExperienceFile = "https://example.com/resume/business_analyst_11.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-2) },
new WorkExperience { WorkExperienceId = 12, MemberId = 12, WorkName = "Product Manager", WorkExperienceFile = "https://example.com/resume/product_manager_12.pdf", WorkStartDate = DateTime.Now.AddYears(-6), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-6), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 13, MemberId = 13, WorkName = "Marketing Specialist", WorkExperienceFile = "https://example.com/resume/marketing_specialist_13.pdf", WorkStartDate = DateTime.Now.AddYears(-7), WorkEndDate = DateTime.Now.AddYears(-3), Cdate = DateTime.Now.AddYears(-7), Udate = DateTime.Now.AddYears(-3) },
new WorkExperience { WorkExperienceId = 14, MemberId = 14, WorkName = "SEO Specialist", WorkExperienceFile = "https://example.com/resume/seo_specialist_14.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 15, MemberId = 15, WorkName = "Content Manager", WorkExperienceFile = "https://example.com/resume/content_manager_15.pdf", WorkStartDate = DateTime.Now.AddYears(-6), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-6), Udate = DateTime.Now.AddYears(-2) },
new WorkExperience { WorkExperienceId = 16, MemberId = 16, WorkName = "Cybersecurity Specialist", WorkExperienceFile = "https://example.com/resume/cybersecurity_specialist_16.pdf", WorkStartDate = DateTime.Now.AddYears(-4), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-4), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 17, MemberId = 17, WorkName = "AI Engineer", WorkExperienceFile = "https://example.com/resume/ai_engineer_17.pdf", WorkStartDate = DateTime.Now.AddYears(-3), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-3), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 18, MemberId = 18, WorkName = "Machine Learning Engineer", WorkExperienceFile = "https://example.com/resume/ml_engineer_18.pdf", WorkStartDate = DateTime.Now.AddYears(-2), WorkEndDate = DateTime.Now, Cdate = DateTime.Now.AddYears(-2), Udate = DateTime.Now },
new WorkExperience { WorkExperienceId = 19, MemberId = 19, WorkName = "Blockchain Developer", WorkExperienceFile = "https://example.com/resume/blockchain_developer_19.pdf", WorkStartDate = DateTime.Now.AddYears(-4), WorkEndDate = DateTime.Now.AddYears(-1), Cdate = DateTime.Now.AddYears(-4), Udate = DateTime.Now.AddYears(-1) },
new WorkExperience { WorkExperienceId = 20, MemberId = 20, WorkName = "Full Stack Developer", WorkExperienceFile = "https://example.com/resume/full_stack_developer_20.pdf", WorkStartDate = DateTime.Now.AddYears(-5), WorkEndDate = DateTime.Now.AddYears(-2), Cdate = DateTime.Now.AddYears(-5), Udate = DateTime.Now.AddYears(-2) }
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
        modelBuilder.Entity<WatchList>().HasData(
    new WatchList { WatchListId = 1, FollowerId = 1, CourseId = 1 },
    new WatchList { WatchListId = 2, FollowerId = 2, CourseId = 2 },
    new WatchList { WatchListId = 3, FollowerId = 3, CourseId = 3 },
    new WatchList { WatchListId = 4, FollowerId = 4, CourseId = 4 },
    new WatchList { WatchListId = 5, FollowerId = 5, CourseId = 5 },
    new WatchList { WatchListId = 6, FollowerId = 6, CourseId = 6 },
    new WatchList { WatchListId = 7, FollowerId = 7, CourseId = 7 },
    new WatchList { WatchListId = 8, FollowerId = 8, CourseId = 8 },
    new WatchList { WatchListId = 9, FollowerId = 9, CourseId = 9 },
    new WatchList { WatchListId = 10, FollowerId = 10, CourseId = 10 },
    new WatchList { WatchListId = 11, FollowerId = 11, CourseId = 11 },
    new WatchList { WatchListId = 12, FollowerId = 12, CourseId = 12 },
    new WatchList { WatchListId = 13, FollowerId = 13, CourseId = 13 },
    new WatchList { WatchListId = 14, FollowerId = 14, CourseId = 14 },
    new WatchList { WatchListId = 15, FollowerId = 15, CourseId = 15 },
    new WatchList { WatchListId = 16, FollowerId = 16, CourseId = 16 },
    new WatchList { WatchListId = 17, FollowerId = 17, CourseId = 17 },
    new WatchList { WatchListId = 18, FollowerId = 18, CourseId = 18 },
    new WatchList { WatchListId = 19, FollowerId = 19, CourseId = 19 },
    new WatchList { WatchListId = 20, FollowerId = 20, CourseId = 20 }
);
        #endregion
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
