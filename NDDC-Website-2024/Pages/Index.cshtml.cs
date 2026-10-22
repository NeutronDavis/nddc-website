using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Home;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomeData homeDb;
        private readonly IProjectsData projDb;
        public List<MyNewsModel> NewsSlide { get; set; }
        public List<MyNewsModel> NewsList { get; set; }
        public readonly string _containerUrl;
        public List<MyPhotoSpeakModel> Photos { get; set; }
        public MyUpdateModel PhysicalInfraUpdatePhoto { get; set; }
        public MyUpdateModel SocialInfraUpdatePhoto { get; set; }
        public MyUpdateModel PartnershipsPhoto { get; set; }
        public MyVideoModel MainVideo { get; set; }
        public List<MyVideoModel> Videos { get; set; }
        public MyAnnouncementModel Announcement { get; set; }
        public MyNewsModel CriticalUpdate { get; set; }
        public List<MyTestimonialModel> Testimonials { get; set; }
        public DateTime CountDownDate { get; set; }
        public MyLiveEventModel LiveEvent { get; set; }
        public bool IsEventLive { get; set; }
        public MyExecMngtModel ChairmanItem { get; set; }
        public List<MyExecMngtModel> BoardMembers { get; set; }
        public MyProjectInsightsModel ProjectInsights { get; set; }

        public IndexModel(IHomeData homeDb, IProjectsData projDb, IConfiguration configuration)
        {
            this.homeDb = homeDb;
            this.projDb = projDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");

            // Initialise lists to empty so Razor foreach never receives null
            NewsSlide       = new List<MyNewsModel>();
            NewsList        = new List<MyNewsModel>();
            Photos          = new List<MyPhotoSpeakModel>();
            Videos          = new List<MyVideoModel>();
            Testimonials    = new List<MyTestimonialModel>();
            BoardMembers    = new List<MyExecMngtModel>();
            ProjectInsights = new MyProjectInsightsModel();
		}

        public void OnGet()
        {
            var slidesFromDb = homeDb.DisplaySlides() ?? new List<MyNewsModel>();
            var defaultSlide = new MyNewsModel
            {
                Id = 0,
                NID = 0,
                Type = "Niger Delta Development Commission",
                Subject = "Empowering Communities, Building the Future.",
                Summary = "Advancing social welfare initiatives and bolstering infrastructure to create lasting positive transformation across the Niger Delta region.",
                ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDVKDs9QFDoYC-J_Ga230U9uPORsK4Aw0--pwFgVD4cIWNehYuWXjT1WopKjn7Se9M9oPnBFMRGKPJ07Ot1Emon_PAQl29op2zSJtiKdb90-RWRxbGP0lv5kzYVx1R8bpAQ_CCFolx1ambVH6uSVXOtx3A1UjQOOxPuJUQXlgyWp1dqtBFmpdRcZkVqa8NG-smykmSP5moh2U4T0c-u7HTbJvIqT-oAIkYpLYWABiGhngTR6bCqEZc3ro-OSl3ncW2ezVQp5N69Xw4"
            };

            NewsSlide = new List<MyNewsModel> { defaultSlide };
            NewsSlide.AddRange(slidesFromDb);

            NewsList                 = homeDb.ListHomePageNews()         ?? new List<MyNewsModel>();
            Photos                   = homeDb.DisplayPhotos()            ?? new List<MyPhotoSpeakModel>();
            PhysicalInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Physical");
            SocialInfraUpdatePhoto   = homeDb.GetImageByUpdateCategory("Social");
            PartnershipsPhoto        = homeDb.GetImageByUpdateCategory("Partnerships");
            MainVideo                = homeDb.DisplayMainVideo();
            Videos                   = homeDb.DisplayAllVideos()         ?? homeDb.DisplayVideos() ?? new List<MyVideoModel>();
            Announcement             = homeDb.GetAnnouncement();
            CriticalUpdate           = homeDb.GetCriticalNewsUpdate();
            Testimonials             = homeDb.ViewTestimonials()         ?? new List<MyTestimonialModel>();
            ChairmanItem             = homeDb.GetChairmanSingle();
            BoardMembers             = homeDb.GetAllBoardMembers()       ?? new List<MyExecMngtModel>();
            LiveEvent = homeDb.GetLiveEvent();
            if (LiveEvent != null)
            {
				CountDownDate = new DateTime(LiveEvent.StartDate.Year, LiveEvent.StartDate.Month, LiveEvent.StartDate.Day, LiveEvent.StartTime.Hour, LiveEvent.StartTime.Minute, 00);
			}
            IsEventLive = homeDb.GoLive();

            try
            {
                ProjectInsights = projDb.GetProjectInsights() ?? new MyProjectInsightsModel();
                if (ProjectInsights.TotalProjects == 0)
                {
                    ProjectInsights.TotalProjects = 21283;
                    ProjectInsights.CompletedProjects = 184;
                    ProjectInsights.StatesCovered = 9;
                    ProjectInsights.TotalCategories = 18;
                }
            }
            catch
            {
                ProjectInsights = new MyProjectInsightsModel
                {
                    TotalProjects = 21283,
                    CompletedProjects = 184,
                    StatesCovered = 9,
                    TotalCategories = 18
                };
            }
		}
    }
}
