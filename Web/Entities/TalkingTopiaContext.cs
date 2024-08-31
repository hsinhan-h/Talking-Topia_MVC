using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static NuGet.Packaging.PackagingConstants;

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

    public virtual DbSet<CourseCategorite> CourseCategorites { get; set; }

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
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=TalkingTopia;integrated security=True;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplyList>(entity =>
        {
            entity.HasKey(e => e.ApplyId).HasName("PK__ApplyLis__F0687F91F95B14E5");

            entity.HasIndex(e => e.MemberId, "IX_ApplyLists_MemberId");

            entity.Property(e => e.ApplyId).HasColumnName("ApplyID");
            entity.Property(e => e.ApplyDateTime).HasColumnType("datetime");
            entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");
            entity.Property(e => e.RejectReason).HasMaxLength(50);
            entity.Property(e => e.UpdateStatusDateTime).HasColumnType("datetime");

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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CouponCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CouponName)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7F51F70E3");

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.FiftyMinUnitPrice).HasColumnType("money");
            entity.Property(e => e.SubTitle)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ThumbnailUrl).IsRequired();
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.TwentyFiveMinUnitPrice).HasColumnType("money");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.VideoUrl).IsRequired();
        });

        modelBuilder.Entity<CourseCategorite>(entity =>
        {
            entity.HasKey(e => e.CourseCategoryId).HasName("PK__CourseCa__4D67EBB68E28BA31");

            entity.HasIndex(e => e.CourseId, "IX_CourseCategorites_CourseId");

            entity.Property(e => e.CategorytName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseCategorites)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseCat__Cours__5812160E");
        });

        modelBuilder.Entity<CourseHour>(entity =>
        {
            entity.HasKey(e => e.CourseHourId).HasName("PK__CourseHo__AE73575BBC30FF2E");

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Hour)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<CourseImage>(entity =>
        {
            entity.HasKey(e => e.CourseImageId).HasName("PK__CourseIm__349B6FE480594337");

            entity.HasIndex(e => e.CourseId, "IX_CourseImages_CourseId");

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.SubjectName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.SchoolName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B1808627D7C");

            entity.HasIndex(e => e.EducationId, "IX_Members_EducationId");

            entity.HasIndex(e => e.NationId, "IX_Members_NationId");

            entity.Property(e => e.BankAccount).HasMaxLength(50);
            entity.Property(e => e.BankCode).HasMaxLength(50);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NativeLanguage).HasMaxLength(255);
            entity.Property(e => e.Nickname)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SpokenLanguage).HasMaxLength(255);
            entity.Property(e => e.Udate)
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
                .HasColumnType("datetime")
                .HasColumnName("CDate");

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

            entity.Property(e => e.MemberPreferenceId).ValueGeneratedNever();
            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.FlagImage).IsRequired();
            entity.Property(e => e.NationName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCFBCC07793");

            entity.HasIndex(e => e.MemberId, "IX_Orders_MemberId");

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.CouponPrice).HasColumnType("money");
            entity.Property(e => e.PaymentType)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SentVatemail)
                .HasMaxLength(100)
                .HasColumnName("SentVATEmail");
            entity.Property(e => e.TaxIdNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.Vatnumber)
                .HasMaxLength(8)
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

            entity.Property(e => e.OrderDetailId).ValueGeneratedOnAdd();
            entity.Property(e => e.CourseCategory).HasMaxLength(50);
            entity.Property(e => e.CourseSubject).HasMaxLength(50);
            entity.Property(e => e.CourseTitle).HasMaxLength(255);
            entity.Property(e => e.DiscountPrice).HasColumnType("money");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.ProfessionalLicenseName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ProfessionalLicenseUrl).IsRequired();
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BookingTime).HasColumnType("datetime");
            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");

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

            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("CDate");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("UDate");
            entity.Property(e => e.WorkEndDate).HasColumnType("datetime");
            entity.Property(e => e.WorkExperienceFile).IsRequired();
            entity.Property(e => e.WorkName).HasMaxLength(50);
            entity.Property(e => e.WorkStartDate).HasColumnType("datetime");

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
    }
);


        modelBuilder.Entity<Course>().HasData(
    new Course { CourseId = 1, CategoryId = 1, SubjectId = 1, TutorId = 1, Title = "C# 入門", SubTitle = "從零開始學習 C#", TwentyFiveMinUnitPrice = 500, FiftyMinUnitPrice = 900, Description = "適合初學者的 C# 課程", IsEnabled = true, ThumbnailUrl = "csharp.jpg", VideoUrl = "csharp_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now },
    new Course { CourseId = 2, CategoryId = 2, SubjectId = 2, TutorId = 2, Title = "日語 N5", SubTitle = "基礎日語學習", TwentyFiveMinUnitPrice = 400, FiftyMinUnitPrice = 800, Description = "日語入門課程", IsEnabled = true, ThumbnailUrl = "japanese.jpg", VideoUrl = "japanese_intro.mp4", CoursesStatus = 1, Cdate = DateTime.Now }
);

        modelBuilder.Entity<CourseHour>().HasData(
    new CourseHour { CourseHourId = 1, Hour = "08:00-09:00", Cdate = DateTime.Now },
    new CourseHour { CourseHourId = 2, Hour = "09:00-10:00", Cdate = DateTime.Now }
);
        modelBuilder.Entity<CourseCategorite>().HasData(
    new CourseCategorite { CourseCategoryId = 1, CategorytName = "程式設計", CourseId = 1, Cdate = DateTime.Now },
    new CourseCategorite { CourseCategoryId = 2, CategorytName = "語言學習", CourseId = 2, Cdate = DateTime.Now }
);
        modelBuilder.Entity<CourseSubject>().HasData(
    new CourseSubject { SubjectId = 1, SubjectName = "C#", CourseCategoryId = 1, Cdate = DateTime.Now },
    new CourseSubject { SubjectId = 2, SubjectName = "日語", CourseCategoryId = 2, Cdate = DateTime.Now }
);

        modelBuilder.Entity<CourseImage>().HasData(
    new CourseImage { CourseImageId = 1, CourseId = 1, ImageUrl = "csharp_image.jpg", Cdate = DateTime.Now },
    new CourseImage { CourseImageId = 2, CourseId = 2, ImageUrl = "japanese_image.jpg", Cdate = DateTime.Now }
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
    new Review { ReviewId = 2, StudentId = 2, CourseId = 2, Rating = 4, CommentText = "非常實用！", Cdate = DateTime.Now }
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



        #endregion
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
