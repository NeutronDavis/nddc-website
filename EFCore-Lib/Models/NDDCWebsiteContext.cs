using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore_Lib.Models
{
    public partial class NDDCWebsiteContext : DbContext
    {
        public NDDCWebsiteContext()
        {
        }

        public NDDCWebsiteContext(DbContextOptions<NDDCWebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<AspnetApplication> AspnetApplications { get; set; } = null!;
        public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; } = null!;
        public virtual DbSet<AspnetPath> AspnetPaths { get; set; } = null!;
        public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; } = null!;
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; } = null!;
        public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; } = null!;
        public virtual DbSet<AspnetRole> AspnetRoles { get; set; } = null!;
        public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; } = null!;
        public virtual DbSet<AspnetUser> AspnetUsers { get; set; } = null!;
        public virtual DbSet<AspnetUsersInRole> AspnetUsersInRoles { get; set; } = null!;
        public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; } = null!;
        public virtual DbSet<Compliant> Compliants { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<EventSpeaker> EventSpeakers { get; set; } = null!;
        public virtual DbSet<ExecMngt> ExecMngts { get; set; } = null!;
        public virtual DbSet<Inquiry> Inquiries { get; set; } = null!;
        public virtual DbSet<Ireport> Ireports { get; set; } = null!;
        public virtual DbSet<IreportImage> IreportImages { get; set; } = null!;
        public virtual DbSet<LiveEvent> LiveEvents { get; set; } = null!;
        public virtual DbSet<MngtStaff> MngtStaffs { get; set; } = null!;
        public virtual DbSet<MyFile> MyFiles { get; set; } = null!;
        public virtual DbSet<MyManifest> MyManifests { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<NewsDepartment> NewsDepartments { get; set; } = null!;
        public virtual DbSet<NewsPhotoGallery> NewsPhotoGalleries { get; set; } = null!;
        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<PhotoSpeak> PhotoSpeaks { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Program> Programs { get; set; } = null!;
        public virtual DbSet<ProjectList> ProjectLists { get; set; } = null!;
        public virtual DbSet<ProjectLocation> ProjectLocations { get; set; } = null!;
        public virtual DbSet<Publication> Publications { get; set; } = null!;
        public virtual DbSet<SightsAndIcon> SightsAndIcons { get; set; } = null!;
        public virtual DbSet<SkillsApplication> SkillsApplications { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Suggestion> Suggestions { get; set; } = null!;
        public virtual DbSet<Tender> Tenders { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Update> Updates { get; set; } = null!;
        public virtual DbSet<UsersInAccount> UsersInAccounts { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;
        public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; } = null!;
        public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; } = null!;
        public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; } = null!;
        public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; } = null!;
        public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; } = null!;
        public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NDDC-Website;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(350);
            });

            modelBuilder.Entity<AspnetApplication>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Applications");

                entity.Property(e => e.ApplicationName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Membership");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetPath>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Paths");

                entity.Property(e => e.LoweredPath).HasMaxLength(256);

                entity.Property(e => e.Path).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_PersonalizationAllUsers");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings).HasColumnType("image");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_PersonalizationPerUser");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings).HasColumnType("image");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Profile");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PropertyNames).HasColumnType("ntext");

                entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");

                entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");
            });

            modelBuilder.Entity<AspnetRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Roles");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetSchemaVersion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_SchemaVersions");

                entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);

                entity.Property(e => e.Feature).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_Users");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetUsersInRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_UsersInRoles");
            });

            modelBuilder.Entity<AspnetWebEventEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("aspnet_WebEvent_Events");

                entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                entity.Property(e => e.Details).HasColumnType("ntext");

                entity.Property(e => e.EventId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.EventType).HasMaxLength(256);

                entity.Property(e => e.ExceptionType).HasMaxLength(256);

                entity.Property(e => e.MachineName).HasMaxLength(256);

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.RequestUrl).HasMaxLength(1024);
            });

            modelBuilder.Entity<Compliant>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.DirectorName).HasMaxLength(150);

                entity.Property(e => e.ImageUrl).HasMaxLength(150);

                entity.Property(e => e.Position).HasMaxLength(250);
            });

            modelBuilder.Entity<EventSpeaker>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.EventDesignation).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(150);

                entity.Property(e => e.OtherNames).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.SpeakerPhoto).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.TwitterHandle).HasMaxLength(150);
            });

            modelBuilder.Entity<ExecMngt>(entity =>
            {
                entity.HasKey(e => e.Emid);

                entity.ToTable("ExecMngt");

                entity.Property(e => e.Emid).HasColumnName("EMID");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.ExecName).HasMaxLength(450);

                entity.Property(e => e.Facebook).HasMaxLength(750);

                entity.Property(e => e.ImageUrl).HasMaxLength(750);

                entity.Property(e => e.Instagram).HasMaxLength(750);

                entity.Property(e => e.Position).HasMaxLength(450);

                entity.Property(e => e.Twitter).HasMaxLength(750);
            });

            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.ToTable("Inquiry");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(150);
            });

            modelBuilder.Entity<Ireport>(entity =>
            {
                entity.ToTable("IReports");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.ImageUrl1).HasMaxLength(100);

                entity.Property(e => e.ImageUrl2).HasMaxLength(100);

                entity.Property(e => e.ImageUrl3).HasMaxLength(100);

                entity.Property(e => e.ImageUrl4).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.VideoUrl).HasMaxLength(150);
            });

            modelBuilder.Entity<IreportImage>(entity =>
            {
                entity.ToTable("IReportImages");

                entity.Property(e => e.ImageUrl).HasMaxLength(150);

                entity.Property(e => e.IreportId).HasColumnName("IReportId");
            });

            modelBuilder.Entity<LiveEvent>(entity =>
            {
                entity.Property(e => e.BannerImage).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.LiveEventLink).HasColumnType("text");

                entity.Property(e => e.Summary).HasMaxLength(550);

                entity.Property(e => e.Theme).HasMaxLength(450);

                entity.Property(e => e.Title).HasMaxLength(350);

                entity.Property(e => e.TrailerVideo).HasMaxLength(250);
            });

            modelBuilder.Entity<MngtStaff>(entity =>
            {
                entity.HasKey(e => e.Msid);

                entity.ToTable("MngtStaff");

                entity.Property(e => e.Msid).HasColumnName("MSID");

                entity.Property(e => e.ImageUrl).HasMaxLength(750);

                entity.Property(e => e.Position).HasMaxLength(750);

                entity.Property(e => e.StaffName).HasMaxLength(450);
            });

            modelBuilder.Entity<MyFile>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.ToTable("MyFile");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Figure).HasColumnType("money");

                entity.Property(e => e.FileName).HasMaxLength(450);

                entity.Property(e => e.FileNo).HasMaxLength(150);
            });

            modelBuilder.Entity<MyManifest>(entity =>
            {
                entity.HasKey(e => e.ManId);

                entity.ToTable("MyManifest");

                entity.Property(e => e.ManId).HasColumnName("Man_ID");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.FileType).HasMaxLength(150);

                entity.Property(e => e.Flow).HasMaxLength(50);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ManDesc)
                    .HasMaxLength(450)
                    .HasColumnName("Man_Desc");

                entity.Property(e => e.ReceivedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Nid);

                entity.Property(e => e.Nid).HasColumnName("NID");

                entity.Property(e => e.Cmid).HasColumnName("CMID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.DisplayFormat).HasMaxLength(50);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(350);

                entity.Property(e => e.Ndid).HasColumnName("NDID");

                entity.Property(e => e.NewsId)
                    .HasMaxLength(50)
                    .HasColumnName("NewsID");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(350);

                entity.Property(e => e.Summary).HasColumnType("text");

                entity.Property(e => e.Tags).HasMaxLength(450);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<NewsDepartment>(entity =>
            {
                entity.HasKey(e => e.Ndid);

                entity.ToTable("NewsDepartment");

                entity.Property(e => e.Ndid).HasColumnName("NDID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DeptName).HasMaxLength(350);
            });

            modelBuilder.Entity<NewsPhotoGallery>(entity =>
            {
                entity.ToTable("NewsPhotoGallery");

                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(150);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OffId);

                entity.Property(e => e.OffId).HasColumnName("OffID");

                entity.Property(e => e.Address).HasMaxLength(750);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.ImageUrl).HasMaxLength(750);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.OfficeName).HasMaxLength(450);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Organization");

                entity.Property(e => e.AbiaStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.AbiaStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("AbiaStateOfficeGPS");

                entity.Property(e => e.Address).HasMaxLength(750);

                entity.Property(e => e.AkwaIbomStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.AkwaIbomStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("AkwaIbomStateOfficeGPS");

                entity.Property(e => e.BayelsaStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.BayelsaStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("BayelsaStateOfficeGPS");

                entity.Property(e => e.Creed).HasColumnType("text");

                entity.Property(e => e.CrossRiversStateIfficeAdd).HasColumnType("text");

                entity.Property(e => e.CrossRiversStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("CrossRIversStateOfficeGPS");

                entity.Property(e => e.DeltaStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.DeltaStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("DeltaStateOfficeGPS");

                entity.Property(e => e.EdoStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.EdoStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("EdoStateOfficeGPS");

                entity.Property(e => e.Email).HasMaxLength(450);

                entity.Property(e => e.Facebook).HasMaxLength(750);

                entity.Property(e => e.ImoStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.ImoStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("ImoStateOfficeGPS");

                entity.Property(e => e.Instagram).HasMaxLength(750);

                entity.Property(e => e.Linkdin).HasMaxLength(750);

                entity.Property(e => e.LogoUrl).HasMaxLength(750);

                entity.Property(e => e.MasterPlan).HasColumnType("text");

                entity.Property(e => e.Mission).HasColumnType("text");

                entity.Property(e => e.OfficeGpscordinates)
                    .HasMaxLength(350)
                    .HasColumnName("OfficeGPSCordinates");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.OndoStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.OndoStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("OndoStateOfficeGPS");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RiversStateOfficeAdd).HasColumnType("text");

                entity.Property(e => e.RiversStateOfficeGps)
                    .HasMaxLength(50)
                    .HasColumnName("RiversStateOfficeGPS");

                entity.Property(e => e.Twitter).HasMaxLength(750);

                entity.Property(e => e.Vision).HasColumnType("text");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.PageContent).HasColumnType("text");

                entity.Property(e => e.PageName).HasMaxLength(250);

                entity.Property(e => e.RedirectUrl).HasMaxLength(250);
            });

            modelBuilder.Entity<PhotoSpeak>(entity =>
            {
                entity.ToTable("PhotoSpeak");

                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.Property(e => e.PosId).HasColumnName("PosID");

                entity.Property(e => e.Category).HasMaxLength(150);

                entity.Property(e => e.PositionName).HasMaxLength(350);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.Nid);

                entity.Property(e => e.Nid).HasColumnName("NID");

                entity.Property(e => e.Cmid).HasColumnName("CMID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(350);

                entity.Property(e => e.Ndid).HasColumnName("NDID");

                entity.Property(e => e.NewsId)
                    .HasMaxLength(50)
                    .HasColumnName("NewsID");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(350);

                entity.Property(e => e.Summary).HasMaxLength(650);

                entity.Property(e => e.Tags).HasMaxLength(450);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectList>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("ProjectList");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ContractSum).HasColumnType("money");

                entity.Property(e => e.Contractor).HasMaxLength(250);

                entity.Property(e => e.DateOfAward).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(550);

                entity.Property(e => e.Lga)
                    .HasMaxLength(250)
                    .HasColumnName("LGA");

                entity.Property(e => e.Location).HasMaxLength(450);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(150);
            });

            modelBuilder.Entity<ProjectLocation>(entity =>
            {
                entity.HasKey(e => e.Plid);

                entity.ToTable("ProjectLocation");

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.DateField1)
                    .HasColumnType("date")
                    .HasColumnName("dateField1");

                entity.Property(e => e.DateField2)
                    .HasColumnType("date")
                    .HasColumnName("dateField2");

                entity.Property(e => e.DateField3)
                    .HasColumnType("date")
                    .HasColumnName("dateField3");

                entity.Property(e => e.IntField1).HasColumnName("intField1");

                entity.Property(e => e.IntField2).HasColumnName("intField2");

                entity.Property(e => e.IntField3).HasColumnName("intField3");

                entity.Property(e => e.IntField4).HasColumnName("intField4");

                entity.Property(e => e.IntField5).HasColumnName("intField5");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.StrField1).HasMaxLength(400);

                entity.Property(e => e.StrField2)
                    .HasMaxLength(400)
                    .HasColumnName("strField2");

                entity.Property(e => e.StrField3)
                    .HasMaxLength(400)
                    .HasColumnName("strField3");

                entity.Property(e => e.StrField4)
                    .HasMaxLength(400)
                    .HasColumnName("strField4");

                entity.Property(e => e.StrField5)
                    .HasMaxLength(400)
                    .HasColumnName("strField5");

                entity.Property(e => e.TxtField1)
                    .HasColumnType("text")
                    .HasColumnName("txtField1");

                entity.Property(e => e.TxtField2)
                    .HasColumnType("text")
                    .HasColumnName("txtField2");

                entity.Property(e => e.TxtField3)
                    .HasColumnType("text")
                    .HasColumnName("txtField3");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.PubId);

                entity.Property(e => e.DateUploaded).HasColumnType("datetime");

                entity.Property(e => e.PubSummary).HasMaxLength(550);

                entity.Property(e => e.PubThumbImage).HasMaxLength(450);

                entity.Property(e => e.PubTitle).HasMaxLength(250);

                entity.Property(e => e.PubUploadUrl).HasMaxLength(450);

                entity.Property(e => e.UploadedBy).HasMaxLength(150);
            });

            modelBuilder.Entity<SightsAndIcon>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.ImageUrl).HasMaxLength(150);

                entity.Property(e => e.Summary).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(350);
            });

            modelBuilder.Entity<SkillsApplication>(entity =>
            {
                entity.HasKey(e => e.Sdid);

                entity.Property(e => e.Sdid).HasColumnName("SDID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.AddressCity).HasMaxLength(150);

                entity.Property(e => e.AddressState).HasMaxLength(50);

                entity.Property(e => e.CertificateUpload).HasMaxLength(250);

                entity.Property(e => e.CurrentSkill).HasMaxLength(250);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.InstitutionDate).HasMaxLength(50);

                entity.Property(e => e.InstitutionName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.LgaletterUpload)
                    .HasMaxLength(250)
                    .HasColumnName("LGALetterUpload");

                entity.Property(e => e.MaritalStatus).HasMaxLength(50);

                entity.Property(e => e.OtherNames).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.Program).HasMaxLength(150);

                entity.Property(e => e.ProgramCategory).HasMaxLength(50);

                entity.Property(e => e.RegNo)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sex).HasMaxLength(50);

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.StateOfOrigin).HasMaxLength(150);
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.HasKey(e => e.Slid);

                entity.ToTable("Slider");

                entity.Property(e => e.Slid).HasColumnName("SLID");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(450);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SlideId)
                    .HasMaxLength(50)
                    .HasColumnName("SlideID");

                entity.Property(e => e.Subject).HasMaxLength(350);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("State");

                entity.Property(e => e.Sid)
                    .ValueGeneratedNever()
                    .HasColumnName("SID");

                entity.Property(e => e.StateName).HasMaxLength(100);

                entity.Property(e => e.StateType).HasMaxLength(50);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.ToTable("Subscription");

                entity.Property(e => e.SubId).HasColumnName("SubID");

                entity.Property(e => e.Email).HasMaxLength(250);
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.AdvertDate).HasColumnType("datetime");

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.DocumentUrl).HasMaxLength(350);

                entity.Property(e => e.Title).HasMaxLength(450);
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("Testimonial");

                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(150);

                entity.Property(e => e.Occupation).HasMaxLength(250);

                entity.Property(e => e.Testimonial1)
                    .HasMaxLength(450)
                    .HasColumnName("Testimonial");

                entity.Property(e => e.TestimonialBy).HasMaxLength(250);
            });

            modelBuilder.Entity<Update>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.ChallengeImage).HasMaxLength(250);

                entity.Property(e => e.Challenges).HasColumnType("text");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DescriptionImage).HasMaxLength(250);

                entity.Property(e => e.Giscordinates)
                    .HasMaxLength(50)
                    .HasColumnName("GISCordinates");

                entity.Property(e => e.Impact).HasColumnType("text");

                entity.Property(e => e.ImpactImage).HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(450);

                entity.Property(e => e.ProjectProgramType).HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(450);

                entity.Property(e => e.UpdateCategory).HasMaxLength(150);

                entity.Property(e => e.UpdateType).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersInAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UsersInAccount");

                entity.Property(e => e.Aid)
                    .HasMaxLength(10)
                    .HasColumnName("AID")
                    .IsFixedLength();

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Uaid).HasColumnName("UAID");

                entity.Property(e => e.Username).HasMaxLength(150);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.AddedBy).HasMaxLength(100);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.VideoDesc).HasMaxLength(450);

                entity.Property(e => e.VideoTitle).HasMaxLength(250);

                entity.Property(e => e.YoutubeUrl).HasMaxLength(450);
            });

            modelBuilder.Entity<VwAspnetApplication>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_Applications");

                entity.Property(e => e.ApplicationName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_MembershipUsers");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_Profiles");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_Roles");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_Users");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_UsersInRoles");
            });

            modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_WebPartState_Paths");

                entity.Property(e => e.LoweredPath).HasMaxLength(256);

                entity.Property(e => e.Path).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_WebPartState_Shared");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vw_aspnet_WebPartState_User");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
